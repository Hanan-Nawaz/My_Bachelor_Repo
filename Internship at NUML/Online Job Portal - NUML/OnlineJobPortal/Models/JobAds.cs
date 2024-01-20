using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJobPortal.Models
{
    public class JobAds
    {
        [Key]
        public int job_id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string job_title { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string job_department { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(8000)]
        public string job_description { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string job_type { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string job_scale { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(8000)]
        public string job_advertisment { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string job_location { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(8000)]
        public string job_employment_type { get; set; }

        [Required]
        public DateTime? job_application_deadline { get; set; }

        [Required]
        public DateTime? job_date_posted { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(8000)]
        public string job_application_instructions { get; set; }

        [Required]
        public Byte is_job_processing_fee { get; set; }

        public int job_processing_fee { get; set; }

        [Required]
        public Byte job_status { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string job_current_stage { get; set; }

        
    }







}