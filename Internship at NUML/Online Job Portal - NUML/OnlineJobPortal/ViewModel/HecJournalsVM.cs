using OnlineJobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobPortal.ViewModel
{
    public class HecJournalsVM
    {
        public IEnumerable<JobPaperhecJournals> existingPapers { get; set; }
        public JobPaperhecJournals jobPaperhecJournals { get; set; }
    }
}