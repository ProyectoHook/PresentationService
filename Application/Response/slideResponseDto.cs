using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Response
{
    public class slideResponseDto
    {
        public int IdSlide { get; set; }
        public string? Url { get; set; }
        public string BackgroundColor { get; set; }
        public string Title { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int Position { get; set; }
        public askResponseDto? Ask { get; set; }
    }
}
