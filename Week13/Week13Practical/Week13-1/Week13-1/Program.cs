// See https://aka.ms/new-console-template for more information
using Week13_1;

public class Program
{
    public static void Main(string[] args)
    {
        // Create some files
        MediaFile soundFile = new MP3File("song.mp3");
        MediaFile movieFile = new MP4File("movie.mp4");

        // Create the original players
        MP3Player mp3Player = new MP3Player();
        MP4Player mp4Player = new MP4Player();

        // Create adapters that make them conform to MediaPlayer
        MediaPlayer mp3Adapter = new MP3PlayerAdapter(mp3Player);
        MediaPlayer mp4Adapter = new MP4PlayerAdapter(mp4Player);

        // Use the adapters via the MediaPlayer interface
        MediaPlayer mp;

        mp = mp3Adapter;
        mp.Play(soundFile);
        // Expected: "Playing MP3 File: song.mp3"

        mp = mp4Adapter;
        mp.Play(movieFile);
        // Expected:
        //   "Decompressing MP4 File: movie.mp4"
        //   "Playing MP4 File: movie.mp4"
    }
}
