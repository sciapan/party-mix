using MediatR;
using Microsoft.EntityFrameworkCore;
using PartyMix.Application.Rooms.Commands.CreateRoom;
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

app.MapPost("/rooms", (CreateRoomCommand command, IMediator mediator) => mediator.Send(command))
    .WithName("CreateRoom")
    .WithOpenApi();

app.Run();

app.UseCors();