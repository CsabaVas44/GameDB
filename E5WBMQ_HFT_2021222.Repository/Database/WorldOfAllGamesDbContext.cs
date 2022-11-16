using E5WBMQ_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E5WBMQ_HFT_2021222.Repository.Data
{
    public class WorldOfAllGamesDbContext : DbContext
    {
        public virtual DbSet<VideoGames> VideoGames { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }

        public WorldOfAllGamesDbContext()
        {
            this.Database.EnsureCreated();
        }

        public WorldOfAllGamesDbContext(DbContextOptions<WorldOfAllGamesDbContext> options) :base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("GamingDb");
            }
        }

        //Inputs for dbseed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<VideoGames>(games => games
            .HasOne(games => games.Publisher)
            .WithMany(publisher => publisher.VideoGames)
            .HasForeignKey(games => games.PublisherId)
            .OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<VideoGames>(games => games
            .HasOne(games => games.Genre)
            .WithMany(genre => genre.VideoGames)
            .HasForeignKey(games => games.GenreId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<VideoGames>().HasData(new Models.VideoGames[]
            {
                new VideoGames("1	World of Warcraft	9	1	150	9.3	2004	True"),
                new VideoGames("2	OverWatch 2	2	1	50	9.1	2016	true"),
                new VideoGames("3	Diablo II	5	1	5	8	2000	True"),
                new VideoGames("4	Heroes of the Storm	8	1	0	8.6	2015	True"),
                new VideoGames("5	The Lost Vikings 2	4	1	0.5	7	1997	False"),
                new VideoGames("6	Borderlands	3	2	20	8	2009	False"),
                new VideoGames("7	Borderlands 2	3	2	28	9.5	2012	True"),
                new VideoGames("8	Borderlands 3	3	2	33	7	2019	True"),
                new VideoGames("9	Counter Strike: Global Offensive	2	3	40	8	2012	True"),
                new VideoGames("10	Dark Souls III	5	12	25	10	2016	True"),
                new VideoGames("11	Bloodborne	5	12	15	10	2016	True"),
                new VideoGames("12	Elden Ring	5	12	22	10	2022	True"),
                new VideoGames("13	Dark Souls	5	12	27	10	2011	True"),
                new VideoGames("14	Dark Souls II	5	12	8	10	2013	True"),
                new VideoGames("15	Sekiro: Shadows Die Twice	5	12	8	10	2018	False"),
                new VideoGames("16	Half-Life:Alyx	11	3	2	9.8	2020	False"),
                new VideoGames("17	Grand Theft Auto V	3	7	180	9	2013	True"),
                new VideoGames("18	Portal 2	4	3	5	10	2011	True"),
                new VideoGames("19	Portal	4	3	4	10	2007	False"),
                new VideoGames("20	Read Dead Redemption 2	5	7	45	10	2018	True"),
                new VideoGames("21	Hades	1	13	2	9.5	2018	False"),
                new VideoGames("22	Hollow Knight	1	5	3	10	2017	False"),
                new VideoGames("23	Sims 1	6	10	16	7	2000	True"),
                new VideoGames("24	Sims 2	6	10	6	8	2006	True"),
                new VideoGames("25	Sims 3	6	10	10	8	2009	True"),
                new VideoGames("26	Sims 4	6	10	15	8	2014	True"),
                new VideoGames("27	Team Fortress 2	2	3	50	10	2008	True"),
                new VideoGames("28	Crysis 3	2	10	1	8	2013	True"),
                new VideoGames("29	Legend of Zelda: Breath of the Wild	5	9	27.14	10	2018	False"),
                new VideoGames("30	Mario Odyssey	3	9	25	10	2018	False"),
                new VideoGames("31	Mario Kart 8 Deluxe	7	9	46.82	10	2017	True"),
                new VideoGames("32	Mario Party Superstars	1	9	6	8	2021	True"),
                new VideoGames("33	Mario Party 9	1	9	3	6	2016	True"),
                new VideoGames("34	Rocket League	7	13	50	9	2015	True"),
                new VideoGames("35	College Love game	6	10	1	10	2021	False"),
            });

            modelBuilder.Entity<Publishers>().HasData(new Publishers[]
            {
                new Publishers("1	Activision Blizzard	1979	Santa Monica, CA	Microsoft	6.5	9500"),
                new Publishers("2	2K Games	2005	Novato, CA	Take-Two Interactive	6.5	3000"),
                new Publishers("3	Valve	1996	Bellvue, WA		8	400"),
                new Publishers("4	tinyBuild	2011	Bellvue, WA		0.5	120"),
                new Publishers("5	Team Cherry	2017	Adelaide, AUS		0.5	5"),
                new Publishers("6	Bethesda	1986	RockVille, MD	Microsoft	1	420"),
                new Publishers("7	Rockstar Games	1998	New York, NY	Take-Two Interactive	1.5	2500"),
                new Publishers("8	Sega	1960	Tokyo, JP		5	3300"),
                new Publishers("9	Nintendo	1889	Kyoto, JP		15	6000"),
                new Publishers("10	Electronic Arts	1982	Redwood City, CA		7	13000"),
                new Publishers("11	Sony Interactive Entertainment	1993	Nam Mateo, CA	Sony Corportaion	15	8100"),
                new Publishers("12	Bandai Namco	1955	Shiba, JP		7.68	662"),
                new Publishers("13	Epic Games	1991	Cary, NC		32	2200"),
            });

            modelBuilder.Entity<Genres>().HasData(new Genres[]
            {
                new Genres("1	Action"),
                new Genres("2	Shooter"),
                new Genres("3	Adventure"),
                new Genres("4	Puzzle"),
                new Genres("5	RPG"),
                new Genres("6	Simulation"),
                new Genres("7	Sports"),
                new Genres("8	MOBA"),
                new Genres("9	MMORPG"),
                new Genres("10	SANDBOX"),
                new Genres("11	Virtual Reality"),
                new Genres("12	Action-Adventure"),
                new Genres("13	Family"),
            });
        }



    }
}
