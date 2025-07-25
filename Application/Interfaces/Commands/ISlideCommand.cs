﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface ISlideCommand
    {
        Task InsertSlide(Slide slide);
        Task UpdateSlide(Slide slide);
        Task DeleteSlide(Slide slide);
    }
}
