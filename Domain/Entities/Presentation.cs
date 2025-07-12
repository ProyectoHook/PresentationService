using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Presentation
    {
        public int IdPresentation { get; set; }
        public string Title { get; set; }
        public bool ActivityStatus { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid IdUserCreat { get; set; }
        public ICollection<Slide> Slides { get; set; }


    }
}
