using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Response
{
    public class PresentationResponse
    {
        public string title { get; set; }
        public bool activityStatus { get; set; }
        public DateTime modifiedAt { get; set; }
        public DateTime createdAt { get; set; }
        public Guid idUserCreat { get; set; }
        public List<SlideResponse> Slides { get; set; }

    }
}