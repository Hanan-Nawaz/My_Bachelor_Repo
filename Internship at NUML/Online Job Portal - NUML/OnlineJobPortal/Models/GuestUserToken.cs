using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJobPortal.Models
{
    public class GuestUserToken
    {
        [Key]
        public int TokenID { get; set; }

        [Required]
        public string AuthToken { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public DateTime IssuedOn { get; set; }

        [Required]
        public DateTime ExpiresOn { get; set; }
    }
}