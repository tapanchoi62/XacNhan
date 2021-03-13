using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XacNhan.Models
{
    public class MailClass
    {
        public string FromMailId { get; set; } = "tapanchoi62@gmail.com";
        public string FromMailIdPassword { get; set; } = "Minhtu123";
        public List<string> ToMailIds { get; set; } = new List<string>();
        public string Subject { get; set; } = "";
        public string Body { get; set; } = "";
        public bool isBodyhtml { get; set; } = true;
        public List<string> Attachment { get; set; } = new List<string>();
       

    }
}
