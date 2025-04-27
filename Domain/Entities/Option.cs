using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Option
    {
        public int IdOption { get; set; }
        public string OptionText { get; set; }
        public int IdAsk { get; set; }
        public Ask Ask { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
