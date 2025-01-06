using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week13_1
{
    // Media Player Interface
    public interface MediaPlayer
    {
        void Play(MediaFile mediaFile);
    }

    // Media File Classes
    public abstract class MediaFile
    {
        public string Name { get; set; }

        protected MediaFile(string name)
        {
            Name = name;
        }
    }
    // Subclasses of MP3 and MP4 files
    public class MP3File : MediaFile
    {
        public MP3File(string name) : base(name) { }
    }

    public class MP4File : MediaFile
    {
        public MP4File(string name) : base(name) { }
    }

    // Existing Player Classes
    public class MP3Player
    {
        public void playMP3(string mp3FileName)
        {
            Console.WriteLine($"Playing MP3 File: {mp3FileName}");
        }
    }

    public class MP4Player
    {
        public void playMP4(MP4File mp4File)
        {
            Decompress(mp4File);
            Console.WriteLine($"Playing MP4 File: {mp4File.Name}");
        }

        public void Decompress(MP4File mp4File)
        {
            Console.WriteLine($"Decompressing MP4 File: {mp4File.Name}");
        }
    }

    // Adapaters
    // MP3PlayerAdapter
    public class MP3PlayerAdapter : MediaPlayer
{
    private MP3Player _mp3Player;

    public MP3PlayerAdapter(MP3Player mp3Player)
    {
        _mp3Player = mp3Player;
    }

    public void Play(MediaFile mediaFile)
    {
        // We expect mediaFile to be an MP3File
        if (mediaFile is MP3File mp3File)
        {
            // Delegate to the MP3Player
            _mp3Player.playMP3(mp3File.Name);
        }
        else
        {
            Console.WriteLine($"Cannot play file: {mediaFile.Name} (not an MP3)");
        }
    }
    }

    // MP4PlayerAdapter
    public class MP4PlayerAdapter : MediaPlayer
    {
        private MP4Player _mp4Player;

        public MP4PlayerAdapter(MP4Player mp4Player)
        {
            _mp4Player = mp4Player;
        }

        public void Play(MediaFile mediaFile)
        {
            // We expect mediaFile to be an MP4File
            if (mediaFile is MP4File mp4File)
            {
                // Delegate to the MP4Player
                _mp4Player.playMP4(mp4File);
            }
            else
            {
                Console.WriteLine($"Cannot play file: {mediaFile.Name} (not an MP4)");
            }
        }
    }

}
