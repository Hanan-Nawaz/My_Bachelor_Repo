using OnlineJobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobPortal.ViewModel
{
    public class PostPhdVM
    {
        public IEnumerable<JobPostPhdExp> existingPostExp { get; set; }
        public JobPostPhdExp jobPostPhdExp { get; set; }
    }
}