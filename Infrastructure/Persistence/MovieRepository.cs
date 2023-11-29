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

        public async Task<ResponseManager<Movie>> GetAllMovies()
        {
            var response = new ResponseManager<Movie>();
            try
            {
                var movies = await _context.Movies.Where(x => x.IsRecordActive == true)
                    .OrderByDescending(o => o.CreatedAt).ToListAsync();
                response.DataList = movies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }

        public async Task<ResponseManager<Movie>> GetMoviesByName(string name)
        {
            var response = new ResponseManager<Movie>();
            try
            {
                var movies = await _context.Movies.Where(x => x.IsRecordActive == true &&
                                                              x.MovieName.Contains(name))
                    .OrderByDescending(o => o.CreatedAt).ToListAsync();
                response.DataList = movies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }

        public string Delete(long id)
        {
            var response = "OK";
            try
            {
                _context.Remove(_context.Movies.Single(x => x.MovieId == id));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                response = "Error";
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }

        public async Task<ResponseManager<Movie>> Update(Movie cine)
        {
            var response = new ResponseManager<Movie>();
            try
            {
                var movie = _context.Movies.First(a => a.MovieId == cine.MovieId);
                movie = cine;
                _context.Update(movie);
                _context.SaveChanges();
                response.SingleData = movie;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return response;
        }

        public async Task<ResponseManager<Movie>> Create(Movie cine)
        {
            var response = new ResponseManager<Movie>();
            try
            {
                var movieAdd = _context.Movies.Add(cine);
               
                _context.SaveChanges();
                response.SingleData = movieAdd.Entity;;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return response;  
        }

        public async Task<ResponseManager<Movie>> GetById(long id)
        {
            var response = new ResponseManager<Movie>();
            try
            {
                var movieUpd = _context.Movies.First(a => a.MovieId == id);
                response.SingleData = movieUpd;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return response;
        }
    }
}
