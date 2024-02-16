using OnlineJobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobPortal.ViewModel
{
    public class PublicationVM
    {
        public IEnumerable<JobPublications> existingPublications { get; set; }
        public JobPublications jobPublication { get; set; }
    }
}