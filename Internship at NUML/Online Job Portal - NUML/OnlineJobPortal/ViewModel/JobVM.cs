using OnlineJobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobPortal.ViewModel
{
    public class JobVM
    {
        public IEnumerable<JobAds> existingAds { get; set; }
        public JobAds jobAds { get; set; }
    }
}