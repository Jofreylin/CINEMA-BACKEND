using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICinemaRepository
    {
         Task<ResponseManager<Cinema>> GetAllCinemas();

        Task<ResponseManager<Cinema>> GetCinemasByName(string cinemaName);
        string Delete(long id);
        Task<ResponseManager<Cinema>> Update(Cinema cine);
        Task<ResponseManager<Cinema>> Create (Cinema cine);
        Task<ResponseManager<Cinema>> GetById(long id);
    }
}
