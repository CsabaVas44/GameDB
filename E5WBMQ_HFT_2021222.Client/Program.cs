using ConsoleTools;
using E5WBMQ_HFT_2021222.Client;
using E5WBMQ_HFT_2021222.Models;
using System.Globalization;
using System.Security.Cryptography;

RestService rest = new("http://localhost:5011/", "genres");

var videogamesNonCrudMenu = new ConsoleMenu(args, level: 2)
    .Add("Which Publisher released the oldest game of the bunch?", () => NonCruds("OldestGameReleasedByWhom")) 
    .Add("Which genre has sold the most copies, (therefore making it the most popular)?", () => NonCruds("MostPopularGenre")) 
    .Add("About how much was sold of a given genre (eg. RPG)", () => NonCruds("SoldCopiesOfGivenGenre")) 
    .Add("Which games have the same genre as this game (eg Hades)", () => NonCruds("GenrePerGame")) 
    .Add("Which games are of this given genre? (eg. RPG)", () => NonCruds("AllOfTheSameGenre")) 
    .Add("How many copies has the given publisher sold on average?", () => NonCruds("AverageSoldCopiesByPublisher"))
    .Add("How many copies of games has each publisher sold on average?", () => NonCruds("CopiesSoldByEachPublisher"))
    .Add("How many games are there of each genre?", () => NonCruds("NumberOfGamesPerGenre"))
    .Add("Exit", ConsoleMenu.Close);

var videogamesSubMenu = new ConsoleMenu(args, level: 1)
    .Add("List", () => List("VideoGames"))
    .Add("Create", () => Create("VideoGames"))
    .Add("Delete", () => Delete("VideoGames"))
    .Add("Update", () => Update("VideoGames"))
    .Add("Queries", () => videogamesNonCrudMenu.Show())
    .Add("Exit", ConsoleMenu.Close);

var publishersSubMenu = new ConsoleMenu(args, level: 1)
    .Add("List", () => List("Publishers"))
    .Add("Create", () => Create("Publishers"))
    .Add("Delete", () => Delete("Publishers"))
    .Add("Update", () => Update("Publishers"))
    .Add("Exit", ConsoleMenu.Close);

var genresSubMenu = new ConsoleMenu(args, level: 1)
    .Add("List", () => List("Genres"))
    .Add("Create", () => Create("Genres"))
    .Add("Delete", () => Delete("Genres"))
    .Add("Update", () => Update("Genres"))
    .Add("Exit", ConsoleMenu.Close);

var menu = new ConsoleMenu(args, level: 0)
    .Add("VideoGames", () => videogamesSubMenu.Show())
    .Add("Publishers", () => publishersSubMenu.Show())
    .Add("Genres", () => genresSubMenu.Show())
    .Add("Exit", ConsoleMenu.Close);
menu.Show();

menu.Show();

void Create(string entity)
{
    if (entity == "VideoGames")
    {
        Console.Write("Enter VideoGame Name: ");
        string name = Console.ReadLine();

        Console.Write("GenreId:");
        int genre = int.Parse(Console.ReadLine());

        Console.Write("Enter Publisher Id: ");
        int pub = int.Parse(Console.ReadLine());


        rest.Post(new VideoGames()
        {
            GameName = name,
            GenreId = genre,
            PublisherId = pub,

        }, "videogames/create");
    }
    if (entity == "Publishers")
    {
        Console.Write("Enter Publisher Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Pub Foundation:");
        int foundation = int.Parse(Console.ReadLine());


        rest.Post(new Publishers() {
            PublisherName = name,
            Foundation = foundation, }, "publishers");
    }

    if (entity == "Genres")
    {
        Console.Write("Enter Genre Name: ");
        string name = Console.ReadLine();

        rest.Post(new Genres() { GenreName = name }, "genres");
    }

}
void List(string entity)
    {
        if (entity == "VideoGames")
        {
            List<VideoGames> games = rest.Get<VideoGames>("videogames/readall");
            foreach (var item in games)
            {
                Console.WriteLine(item.GameId + ": " + item.GameName);
            }
        }   

        else if (entity == "Publishers")
        {
            List<Publishers> publishers = rest.Get<Publishers>("publishers");
            foreach (var item in publishers)
            {
                Console.WriteLine(item.PublisherId + ": " + item.PublisherName);
            }
        }

        else if (entity == "Genres")
        {
            List<Genres> genres = rest.Get<Genres>("genres");
            foreach (var item in genres)
            {
                Console.WriteLine(item.GenreId+ ": " + item.GenreName);
            }
        }
        Console.ReadLine();
}
void Update(string entity)
    {
        if (entity == "VideoGames")
        {
            Console.Write("Enter Video Game's id to update: ");
            int id = int.Parse(Console.ReadLine());

            VideoGames update = rest.Get<VideoGames>(id, "videogames/read");

            Console.Write($"New name [old: {update.GameName}]: ");
            string name = Console.ReadLine();
            update.GameName = name;

            rest.Put(update, "videogames/update");
        }

        if (entity == "Publishers")
        {
            Console.Write("Enter Publisher's id to update: ");
            int id = int.Parse(Console.ReadLine());

            Publishers update = rest.Get<Publishers>(id, "publishers");

            Console.Write($"New name [old: {update.PublisherName}]: ");
            string name = Console.ReadLine();
            update.PublisherName = name;

            rest.Put(update, "publishers");
        }

        if (entity == "Genres")
        {
            Console.Write("Enter Genre's id to update: ");
            int id = int.Parse(Console.ReadLine());

            Genres update = rest.Get<Genres>(id, "genres");

            Console.Write($"New name [old: {update.GenreName}]: ");
            string name = Console.ReadLine();
            update.GenreName = name;

            rest.Put(update, "genres");
        }
}
void Delete(string entity)
    {
        if (entity == "VideoGames")
        {
            Console.Write("Enter VideoGame's id to delete: ");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "videogames/delete");
        }
        if (entity == "Publishers")
        {
            Console.Write("Enter Publisher's id to delete: ");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "publishers");
        }
        if (entity == "Genres")
        {
            Console.Write("Enter Genre's id to delete: ");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "genres");
        }
}
void NonCruds(string name)
{
    if (name == "OldestGameReleasedByWhom")
    {
        string oldest = rest.GetSingle<string>("videogames/OldestGameReleasedByWhom");
        Console.WriteLine(oldest);
        Console.ReadLine();
    }
    if (name == "MostPopularGenre")
    {
        string popular = rest.GetSingle<string>("videogames/MostPopularGenre");
        Console.WriteLine(popular);
        Console.ReadLine();
    }
    if (name == "SoldCopiesOfGivenGenre")
    {
        Console.WriteLine("Given Genre: (eg. RPG) ");
        string genre = Console.ReadLine();
        var sold = rest.GetByName<double>(genre,"videogames/SoldCopiesOfGivenGenre");
        Console.WriteLine(sold);
        Console.ReadLine();
    }
    if (name == "GenrePerGame")
    {
        Console.WriteLine("Given Game (eg. Hades)");
        string gameName = Console.ReadLine();
        var springyThing = rest.GetMany<string>("videogames/GenrePerGame", gameName);
        springyThing.ForEach(x => Console.WriteLine(x));
        Console.ReadLine();
    }
    if (name == "AllOfTheSameGenre")
    {
        Console.WriteLine("Given Genre: (eg. RPG)");
        string genre = Console.ReadLine();
        var all = rest.GetMany<VideoGames>("videogames/AllOfTheSameGenre", genre);
        foreach (var item in all)
        {
            Console.WriteLine(item.GameName);
        }
        Console.ReadLine();
    }
    if (name == "AverageSoldCopiesByPublisher")
    {
        Console.WriteLine("Given Publisher (eg. Electronic Arts)");
        var pub = Console.ReadLine();
        var back = rest.GetByName<double>(pub, "videogames/AverageSoldCopiesByPublisher");
        Console.WriteLine(back);
        Console.ReadLine();
    }
    if (name == "CopiesSoldByEachPublisher")
    {
        var back = rest.GetKeys<string,double>("videogames/CopiesSoldByEachPublisher");
        foreach (var item in back)
        {
            Console.WriteLine(item);
        }
        Console.ReadLine();
    }
    if (name == "NumberOfGamesPerGenre")
    {
        var back = rest.GetKeys<string, int>("videogames/NumberOfGamesPerGenre");
        foreach (var item in back)
        {
            Console.WriteLine(item);
        }
        Console.ReadLine();
    }
}