using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJobPortal.Models
{
    public class JobPublications
    {
        [Key]
        public int publication_id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string author_name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string journal_name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(8000)]
        public string journal_address { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string issn_number { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string publication_title { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(8000)]
        public string vol_no { get; set; }

        [Required]
        public int start_page { get; set; }

        [Required]
        public int end_page { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(8000)]
        public string hec_category { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string published_year { get; set; }

        [Required]
        public float impact_factor { get; set; }


    }
}