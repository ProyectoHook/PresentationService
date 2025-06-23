using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class AskRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AskText { get; set; }
        public int Answer { get; set; }
        public int IdSlide { get; set; }
    }
}
