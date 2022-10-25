using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E5WBMQ_HFT_2021222.Models
{
    public class Genres
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }

        [Required]
        [StringLength(50)]
        public string GenreName { get; set; }

        public virtual ICollection<VideoGames> VideoGames { get; set; }

        public Genres()
        {

        }
        public Genres(string file)
        {
            string[] line = file.Split('\u0009');
            GenreId = int.Parse(line[0]);
            GenreName = line[1];

        }
    }
}
