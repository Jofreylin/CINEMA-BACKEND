using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaContext _context;
        public MovieRepository(CinemaContext cinemaContext)
        {
            _context = cinemaContext;
        }
        public async Task<ResponseManager<MoviesView>> GetAllMovies()
        {
            var response = new ResponseManager<MoviesView>();
            try
            {
               var pelis= await _context.MoviesViews.Where(x => x.IsRecordActive == true)
              .OrderByDescending(o => o.CreatedAt).ToListAsync();
                response.DataList = pelis;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }
    }
}
