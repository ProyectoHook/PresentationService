using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Response
{
    public class askResponseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AskText { get; set; }
        public List<optionResponseDto> Options { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
