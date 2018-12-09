using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookyourdoctor.Models
{
    public class gmailsent
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        [DataType(DataType.Time)]
        public DateTime startTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime endTime { get; set; }
    }
}