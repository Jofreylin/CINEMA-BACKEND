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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository repository)
        {
            _movieRepository = repository;
        }


       public  Task<ResponseManager<Movie>> GetAllMovies()
        {
            return  _movieRepository.GetAllMovies();
        }

       public async Task<ResponseManager<Movie>> GetMoviesByName(string name)
       {
           return await _movieRepository.GetMoviesByName(name);
       }

       public string Delete(long id)
       {
           return _movieRepository.Delete(id);
       }

       public async Task<ResponseManager<Movie>> Update(Movie cine)
       {
           return await _movieRepository.Update(cine);
       }

       public async Task<ResponseManager<Movie>> Create(Movie cine)
       {
           return await _movieRepository.Create(cine);
       }

       public async Task<ResponseManager<Movie>> GetById(long id)
       {
           return await _movieRepository.GetById(id);
       }
    }
}
