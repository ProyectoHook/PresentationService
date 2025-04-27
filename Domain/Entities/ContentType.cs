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
        public string url { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Slide> slides { get; set; }

    }
}
