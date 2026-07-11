using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("10 Tips for Surviving Greek Mythologies Underworld", "Hades_Official", 600);
        video1.AddComment(new Comment("xX_AthenianSlayer_Xx", "If you have Theseus, keep him."));
        video1.AddComment(new Comment("Zeus", "Typical Hades, chronically online."));
        video1.AddComment(new Comment("Sisyphus", "I'm tired, boss."));
        videos.Add(video1);

        Video video2 = new Video("Forging the Perfect Lightning Bolt", "HephaestusForge", 720);
        video2.AddComment(new Comment("Hermes", "First!!"));
        video2.AddComment(new Comment("MereMortal1200BC", "Instructions unclear, shocked to death."));
        video2.AddComment(new Comment("Apollo", "Could be Shinier."));
        videos.Add(video2);

        Video video3 = new Video("Top 10 Sea Monsters to Avoid This Summer", "The_Original_AquaMan", 660);
        video3.AddComment(new Comment("Jason Momoa", "You're my idol."));
        video3.AddComment(new Comment("NarcisSUS", "Can you make water more reflective?"));
        video3.AddComment(new Comment("Medussssa", "@NarcisSUS DO NOT GIVE HIM ANY IDEAS."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}