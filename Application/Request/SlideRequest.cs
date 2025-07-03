using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class SlideRequest
    {
        public int IdPresentation { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Position { get; set; }
        public string BackgroundColor { get; set; }
        public AskRequest? Ask { get; set; }
        public string? url { get; set; }

    }
}
