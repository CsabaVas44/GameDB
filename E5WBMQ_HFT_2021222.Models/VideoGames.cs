using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        public int GenreId { get; set; }

        public int PublisherId { get; set; }
        
        public double CopiesSold { get; set; }

        [Range(0,10)]
        public double Rating { get; set; }

        public int ReleaseYear { get; set; }

        public bool Multiplayer { get; set; }

        [NotMapped]
        public virtual Genres Genre { get; set; }
        [NotMapped]
        public virtual Publishers Publisher { get; set; }


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
            CopiesSold = double.Parse(split[4], CultureInfo.InvariantCulture);
            Rating = double.Parse(split[5],CultureInfo.InvariantCulture);
            ReleaseYear = int.Parse(split[6]);
            Multiplayer = bool.Parse(split[7]);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.GameId, this.GenreId,this.PublisherId);
        }

        public override bool Equals(object? obj)
        {
            VideoGames b = obj as VideoGames;

            if (b == null)
            {
                return false;
            }

            else
            {
                return this.GameId == b.GameId && this.GenreId == b.GenreId && this.PublisherId == b.PublisherId;
                //&& this.GameName == b.GameName && this.GenreId == b.GenreId && this.PublisherId == b.PublisherId && this.CopiesSold == b.CopiesSold && this.Rating == b.Rating && this.ReleaseYear == b.ReleaseYear && this.Multiplayer == b.Multiplayer; 
            }
        }

    }
}
