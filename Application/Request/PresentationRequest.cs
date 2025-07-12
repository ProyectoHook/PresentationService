using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Application.Request
{

    // PresentationRequest class
    // This class is used to represent a request for creating or updating a presentation.
    // It contains properties that are necessary for the creation or update of a presentation.}
    public class PresentationRequest
    {

        public string title { get; set; }
        public bool activityStatus { get; set; }
        public Guid idUserCreat { get; set; }
        public List<SlideRequest> slides { get; set; }

    }
}