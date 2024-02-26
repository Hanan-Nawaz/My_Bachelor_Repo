using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJobPortal.Models
{
    public class JobPrePhdExp
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string institute { get; set; }

        [Required]
        public string position_held { get; set; }

        [Required]
        public string status { get; set; }

        [Required]
        public DateTime period_from { get; set; }

        [Required]
        public DateTime period_to { get; set; }

        [Required]
        public int exp_year { get; set; }

        [Required]
        public int exp_month { get; set; }
    }
}