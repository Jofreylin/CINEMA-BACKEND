using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CinemaService : ICinemaService
    {
        public readonly ICinemaRepository cinemaRepository;

        public CinemaService(ICinemaRepository repository)
        {
            this.cinemaRepository = repository;
        }

        public async Task<ResponseManager<CinemasView>> GetAllCinemas()
        {
            return await cinemaRepository.GetAllCinemas();
        }

        public async Task<ResponseManager<CinemaView>> GetCinemaByName(string cinemaName)
        {
            return await cinemaRepository.GetCinemasByName(cinemaName);
        }
    }
}
