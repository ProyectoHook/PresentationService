using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Response
{

    // PresentationRequest class
    // This class is used to represent a request for creating or updating a presentation.
    // It contains properties that are necessary for the creation or update of a presentation.
    public class PresentationResponse
    {
        public string title { get; set; }
        public bool activityStatus { get; set; }
        public DateTime modifiedAt { get; set; }
        public DateTime createdAt { get; set; }
        public Guid idUserCreat { get; set; }

    }
}