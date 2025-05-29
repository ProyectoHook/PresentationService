using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Slide
    {
        public int IdSlide { get; set; }
        public int IdPresentation { get; set; }
        public Presentation Presentation { get; set; }
        public string Title { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int Position { get; set; }
        public string BackgroundColor { get; set; }
        public int? IdAsk { get; set; }
        public Ask Ask { get; set; }

        public int IdContentType { get; set; }
        public ContentType ContentType { get; set; }



    }
}
