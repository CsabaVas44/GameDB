using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E5WBMQ_HFT_2021222.Models
{
    public class VideoGames
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }

        [Required]
        [StringLength(50)]
        public string GameName { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int PublisherId { get; set; }

        
        public double CopiesSold { get; set; }

        [Range(0,10)]
        public double Rating { get; set; }

        [Range(1900,2100)]
        public int ReleaseYear { get; set; }

        public bool Multiplayer { get; set; }


        public VideoGames()
        {

        }
        public VideoGames(string file)
        {
            string[] split = file.Split('\u0009'); //Tabulator Unicode
            GameId = int.Parse(split[0]);
            GameName = split[1];
            GenreId = int.Parse(split[2]);
            PublisherId = int.Parse(split[3]);
            CopiesSold = double.Parse(split[4]);
            Rating = double.Parse(split[5]);
            ReleaseYear = int.Parse(split[6]);
            Multiplayer = bool.Parse(split[7]);
        }
    }
}
