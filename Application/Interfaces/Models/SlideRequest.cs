using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Models
{
    public class SlideRequest
    {
        public int IdPresentation { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }
        public string BackgroundColor { get; set; }.
        public int IdAsk { get; set; }
        public int IdContentType { get; set; }
    }
}
