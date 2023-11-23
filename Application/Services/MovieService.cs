using Application.DTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository repository)
        {
            _movieRepository = repository;
        }

        public async Task<ResponseManager<MoviesView>> GetAllMovies()
        {
            return  await _movieRepository.GetAllMovies();
        }
    }
}
