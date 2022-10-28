using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E5WBMQ_HFT_2021222.Models
{
    public class Publishers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }

        [Required]
        [StringLength(50)]
        public string PublisherName { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Foundation { get; set; }

        [StringLength(50)]
        public string HeadQuarters { get; set; }

        [StringLength(50)]
        public string ParentCompany { get; set; }

        public double AnnualSales { get; set; }


        [Range(0, int.MaxValue)]
        public int NumberOfEmployees { get; set; }

        public virtual ICollection<VideoGames> VideoGames { get; set; }


        public Publishers()
        {
            this.VideoGames = new HashSet<VideoGames>();
        }
        public Publishers(string file)
        {
            string[] split = file.Split('\u0009'); //Tabulator Unicode
            PublisherId = int.Parse(split[0]);
            PublisherName = split[1];
            Foundation = int.Parse(split[2]);
            HeadQuarters = split[3];
            ParentCompany = split[4];
            AnnualSales = double.Parse(split[5], CultureInfo.InvariantCulture);
            NumberOfEmployees = int.Parse(split[6]);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.PublisherId, this.PublisherName, this.Foundation);
        }

        public override bool Equals(object? obj)
        {
            Publishers b = obj as Publishers;

            if (b == null)
            {
                return false;
            }

            else
            {
                return this.PublisherId == b.PublisherId && this.PublisherName == b.PublisherName && this.Foundation == b.Foundation;
            }

        }
    }
}
