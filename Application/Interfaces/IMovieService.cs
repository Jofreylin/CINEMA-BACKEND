using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieService
    {
        Task<ResponseManager<Movie>> GetAllMovies();

        Task<ResponseManager<Movie>> GetMoviesByName(string name);
        string Delete(long id);
        Task<ResponseManager<Movie>> Update(Movie cine);
        Task<ResponseManager<Movie>> Create (Movie cine);
        Task<ResponseManager<Movie>> GetById(long id);
    }
}
