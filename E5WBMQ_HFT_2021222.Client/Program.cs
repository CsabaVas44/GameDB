using ConsoleTools;
using E5WBMQ_HFT_2021222.Client;
using E5WBMQ_HFT_2021222.Models;

RestService rest;

rest = new RestService("http://localhost:5011/", "videogames");

var videogamesSubMenu = new ConsoleMenu(args, level: 1)
    .Add("List", () => List("VideoGames"))
    .Add("Create", () => Create("VideoGames"))
    .Add("Delete", () => Delete("VideoGames"))
    .Add("Update", () => Update("VideoGames"))
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

void Create(string entity)
{
    if (entity == "VideoGames")
    {

        string name = Console.ReadLine();
        int gen = int.Parse(Console.ReadLine());
        int pub = int.Parse(Console.ReadLine());

        rest.Post(
            new VideoGames() { GameName = name, GenreId = gen, PublisherId = pub }, "videogames");
    }

    if (entity == "Publishers")
    {

        Console.Write("Enter Publisher Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Pub Foundation:");
        int foundation = int.Parse(Console.ReadLine());

        rest.Post(new Publishers() { PublisherName = name, Foundation = foundation}, "publishers");

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
            List<VideoGames> games = rest.Get<VideoGames>("videogames");
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

            VideoGames update = rest.Get<VideoGames>(id, "videogames");

            Console.Write($"New name [old: {update.GameName}]: ");
            string name = Console.ReadLine();
            update.GameName = name;

            rest.Put(update, "videogames");
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
            Console.Write("Enter Actor's id to delete: ");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "videogames");
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
