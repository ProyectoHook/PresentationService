﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Querys
{
    public interface ISlideQuery
    {
        Task<Slide> GetSlideId(int slideId);
    }
}
