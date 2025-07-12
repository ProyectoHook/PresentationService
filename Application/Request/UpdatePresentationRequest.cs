using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class UpdatePresentationRequest
    {
        public int id { get; set; }
        public string title { get; set; }
        public bool activityStatus { get; set; }
        public DateTime? modifiedAt { get; set; }
        public DateTime createdAt { get; set; }
        public Guid idUserCreat { get; set; }
        public List<SlideRequest> slides { get; set; }
    }
}
