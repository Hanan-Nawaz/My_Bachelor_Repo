using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJobPortal.Models
{
    public class JobPaperhecJournals
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int w_paper { get; set; }

        [Required]
        public int x_paper { get; set; }

        [Required]
        public int y_paper { get; set; }

        [Required]
        public int z_paper { get; set; }

        [Required]
        public int total { get; set; }

        [Required]
        public int last_5_years { get; set; }

        [Required]
        public int total_hec_approved { get; set; }

        [Required]
        public int total_hec_not_approved { get; set; }
    }
}