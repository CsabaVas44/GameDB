using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E5WBMQ_HFT_2021222.Models
{
    public class Genres
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }

        [Required]
        [StringLength(100)]
        public string GenreName { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<VideoGames> VideoGames { get; set; }

        public Genres()
        {
            this.VideoGames = new HashSet<VideoGames>();
        }
        public Genres(string file)
        {
            string[] line = file.Split('\u0009');
            GenreId = int.Parse(line[0]);
            GenreName = line[1];
        }
        public override bool Equals(object? obj)
        {
            Genres b = obj as Genres;

            if (b == null)
            {
                return false;
            }
            else
            {
                return this.GenreId == b.GenreId && this.GenreName == b.GenreName;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.GenreId, this.GenreName);
        }
    }
}
