using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if(title.Length > 100 )
        {
            Console.WriteLine("Judul Video Tidak Valid");
        }

        Random rnd = new Random();
        this.id = rnd.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int hitung)
    {
        if (hitung > 10000000)
        {
            Console.WriteLine("Input penambahan play count terlalu besar");
        }
        try
        {
            checked
            {
                this.playCount += hitung;
            }
        } catch (OverflowException) {
            Console.WriteLine("Overflow pada penambahan play count");
        }

    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video ID: " + this.id);
        Console.WriteLine("Title: "  + this.title);
        Console.WriteLine("Play count: " + this.playCount);
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Herlin Priatna");

        // Uji prekondisi
        try
        {
            SayaTubeVideo video1 = new SayaTubeVideo(null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        // Uji exception
        for (int i = 0; i < 1000000000; i += 10000000)
        {
            try
            {
                video.IncreasePlayCount(10000000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        video.PrintVideoDetails();
    }
}
