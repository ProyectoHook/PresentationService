using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ask
    {
        public int IdAsk { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AskText { get; set; }
        public string Answer { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        

        public ICollection<Option> options { get; set; }

    }
}
