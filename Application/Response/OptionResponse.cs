using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class OptionResponse
    {
        public int IdOption { get; set; }
        public string OptionText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int IdAsk { get; set; }

    }
}
