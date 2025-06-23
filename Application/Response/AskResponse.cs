using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class AskResponse
    {
        public int IdAsk { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AskText { get; set; }
        public int CorrectOptionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
