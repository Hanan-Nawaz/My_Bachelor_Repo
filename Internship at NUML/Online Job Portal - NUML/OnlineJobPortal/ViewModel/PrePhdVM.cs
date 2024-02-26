using OnlineJobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobPortal.ViewModel
{
    public class PrePhdVM
    {
        public IEnumerable<JobPrePhdExp> existingPreExp { get; set; }
        public JobPrePhdExp jobPrePhdExp { get; set; }
    }
}