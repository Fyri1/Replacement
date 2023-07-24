using System;
using System.Xml.Linq;
using txt_read;
using txt_read.Modifiers;


class Program
{
    static Client _client;
    static void Main(string[] args)
    {



      
        var mods = ChooseMods();
        _client = new Client(mods, File.ReadAllLines("data.txt"));

        _client.Start(5);
        UpdateUi();
        Console.ReadLine();

    }
    private static void UpdateUi()
    {
        Task.Run(() =>
        {
            while (true)
            {
                Thread.Sleep(1500);

                Console.Clear();
                if (_client is not null)
                    Console.WriteLine($"{_client.Done}/{_client.Total}");
            }
        });

    }
    public static IEnumerable<Modifier> ChooseMods()
    {
        var mods = Config.GetConfig().Modifiers;
        Console.WriteLine("This modifiers are available:\n");
        for (int i = 0; i < mods.Count; i++)
        {
            Console.WriteLine($"{i} : {mods[i].Name}");

        }

        var res = new List<Modifier>();
        foreach (var i in ParseIndices())
        {
            res.Add(mods[i]);
        }
        return res;

    }

    static IEnumerable<int> ParseIndices()
    {
        try
        {
            Console.WriteLine("Enter indices  (i.e. 0,3,4)");
            var str = Console.ReadLine();
            return str.Split(',').Select(w => int.Parse(w));
        }
        catch
        {
            return ParseIndices();
        }

    }
}