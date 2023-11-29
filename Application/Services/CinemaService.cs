using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _cinemaRepository;

        public CinemaService(ICinemaRepository repository)
        {
            _cinemaRepository = repository;
        }

     

        public async Task<ResponseManager<Cinema>> GetCinemasByName(string cinemaName)
        {
            return await _cinemaRepository.GetCinemasByName(cinemaName);
        }

        public async Task<ResponseManager<Cinema>> GetAllCinemas()
        {
            return await _cinemaRepository.GetAllCinemas();
           
        }
        public string Delete(long id)
        {
            return  _cinemaRepository.Delete(id);
        }

        public async Task<ResponseManager<Cinema>> Update(Cinema cine)
        {
            return await _cinemaRepository.Update(cine);
        }

        public async Task<ResponseManager<Cinema>> Create(Cinema cine)
        {
            return await _cinemaRepository.Create(cine);
        }

        public async Task<ResponseManager<Cinema>> GetById(long id)
        {
            return await _cinemaRepository.GetById(id);
        }
    }
}
