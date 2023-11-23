﻿using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICinemaRepository
    {
        public async Task<ResponseManager<CinemasView>> GetAllCinemas();

        public async Task<ResponseManager<CinemasView>> GetCinemasByName(string cinemaName);
    }
}