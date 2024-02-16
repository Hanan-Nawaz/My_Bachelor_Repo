using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJobPortal.Models
{
    public class JobGuestUsers
    {
        [Key]
        public int GuestID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string CNIC { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime? DOB { get; set; }

        [Required]
        public string CellPhone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Type { get; set; }
    }
}