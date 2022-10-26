using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Range(1900,2100)]
        public int Foundation { get; set; }

        [StringLength(50)]
        public string HeadQuarters { get; set; }

        [StringLength(50)]
        public string ParentCompany { get; set; }

        [Range(0,double.MaxValue)]
        public double AnnualSales { get; set; }

       
        [Range (0,int.MaxValue)]
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
            AnnualSales = int.Parse(split[5]);
            NumberOfEmployees = int.Parse(split[6]);
        }

        /*
         * 
         * A Model osztályokban legyenek letárolva a
         * z idegen kulcsok és használjon Navigation
         * Propertyket LazyLoader-rel ahol lehet! 
         * A Linq lekérdezésekben akkor használjunk join-t, ha
         * elkerülhetetlen;
         * 
         */

    }
}
