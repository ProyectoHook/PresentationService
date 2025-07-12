using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContentType
    {
        public int IdContentType { get; set; }
        public string ContentTypeName { get; set; }
        public ICollection<Slide> slides { get; set; }

    }
}
