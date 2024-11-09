using MediatR;
using Microsoft.EntityFrameworkCore;
using PartyMix.Application.PlaylistEntries.Commands.CreatePlaylistEntry;
using PartyMix.Application.PlaylistEntries.Queries.GetPlaylistEntry;
using PartyMix.Application.Rooms.Commands.CreateRoom;
using PartyMix.Application.Rooms.Commands.EnterRoom;
using PartyMix.Application.Rooms.Queries.GetRoom;
using PartyMix.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<PartyMixDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseNpgsql(
            builder.Configuration.GetConnectionString("PartyMix"),
            npgsqlOptions => { npgsqlOptions.MigrationsAssembly("PartyMix.Migrations"); }
        );
    });

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateRoomCommand>());

//// Add FluentValidation
//builder.Services.AddValidatorsFromAssemblyContaining<CreateGameCommandValidator>();

// Add Cors
builder.Services.AddCors(options => options.AddDefaultPolicy(policyBuilder =>
    policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// rooms
app.MapGet("/rooms/{id}", async (string id, IMediator mediator, CancellationToken cancellationToken) =>
    {
        var result = await mediator.Send(new GetRoomQuery { Id = id }, cancellationToken);
        return result.Match(
            Results.Ok,
            _ => Results.NotFound());
    })
    .WithName("GetRoom")
    .WithOpenApi();

app.MapPost("/rooms",
        (CreateRoomCommand command, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(command, cancellationToken))
    .WithName("CreateRoom")
    .WithOpenApi();

app.MapPost("/login", async (EnterRoomCommand command, IMediator mediator, CancellationToken cancellationToken) =>
    {
        var result = await mediator.Send(command, cancellationToken);
        return result.Match(
            _ => Results.NoContent(),
            _ => Results.NotFound(),
            _ => Results.Unauthorized());
    })
    .WithName("EnterRoom")
    .WithOpenApi();

// playlist entries
app.MapPost("/playlistEntries",
        async (CreatePlaylistEntryCommand command, IMediator mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.Match(
                Results.Ok,
                _ => Results.NotFound());
        })
    .WithName("CreatePlaylistEntry")
    .WithOpenApi();

app.MapGet("/playlistEntries/{id:int}", async (int id, IMediator mediator, CancellationToken cancellationToken) =>
    {
        var result = await mediator.Send(new GetPlaylistEntryQuery { Id = id }, cancellationToken);
        return result.Match(
            stream => Results.File(stream, "audio/mpeg", enableRangeProcessing: true),
            _ => Results.NotFound());
    })
    .WithName("GetPlaylistEntry")
    .WithOpenApi();

app.Run();

app.UseCors();