using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XacNhan.Models
{
    public class CommonPropertis
    {
        public DateTime Created { get; set; } = new DateTime();
        public DateTime Updated { get; set; } = new DateTime();

        public string Message { get; set; }
    }
}
