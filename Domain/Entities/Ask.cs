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

        // Relación 1:N: muchas opciones
        public ICollection<Option> Options { get; set; } = new List<Option>();

        public int IdSlide { get; set; }
        public Slide Slide { get; set; }

        public DateTime? ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
