// See https://aka.ms/new-console-template for more information
using E5WBMQ_HFT_2021222.Logic.Logics;
using E5WBMQ_HFT_2021222.Repository.Data;
using E5WBMQ_HFT_2021222.Repository.ModelRepositories;

Console.WriteLine("Hello, World!");

WorldOfAllGamesDbContext worldOfAllGamesDbContext = new WorldOfAllGamesDbContext(); 

VideoGamesRepository vgr = new VideoGamesRepository(worldOfAllGamesDbContext);

VideoGamesLogic vgl = new VideoGamesLogic(vgr);

Console.WriteLine(vgl.OldestGameReleasedByPublisher().PublisherName);
Console.WriteLine(vgl.SoldCopiesOfGivenGenre("Action"));
Console.WriteLine(vgl.MostPopularGenre());


