using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XacNhan.Models
{
    public class MailClass
    {
        public string FromMailId { get; set; }
        public string FromMailIdPassword { get; set; }
        public List<string> ToMailIds { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool isBodyhtml { get; set; }
        public List<string> Attachment { get; set; }
       

    }
}
