window.audioPlayer = {
    audio: null,
    dotNetReference: null,

    initialize: function (dotNetRef) {
        this.dotNetReference = dotNetRef;
        this.audio = new Audio();

        this.audio.addEventListener('timeupdate', () => {
            const percentage = (this.audio.currentTime / this.audio.duration) * 100;
            this.dotNetReference.invokeMethodAsync('OnPlaybackProgress', percentage);
        });

        this.audio.addEventListener('ended', () => {
            this.dotNetReference.invokeMethodAsync('OnSongEnded');
        });
    },

    loadAndPlay: function (url) {
        if (this.audio) {
            this.audio.src = url;
            this.audio.load();
            this.audio.play();
        }
    },

    play: function () {
        if (this.audio) {
            this.audio.play();
        }
    },

    pause: function () {
        if (this.audio) {
            this.audio.pause();
        }
    }
};