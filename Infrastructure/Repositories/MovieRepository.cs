using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
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
                var movies = await _context.MoviesViews.Where(x => x.IsRecordActive == true)
                    .OrderByDescending(o => o.CreatedAt).ToListAsync();
                response.DataList = movies;
            }
            catch (CustomException e)
            {
                throw new CustomException(e.Message, e.InnerException, e.StatusCode, e.ClassName, e.MethodName, e.CreationUserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }

        public async Task<ResponseManager<MoviesView>> GetMoviesByName(string name)
        {
            var response = new ResponseManager<MoviesView>();
            try
            {
                var movies = await _context.MoviesViews.Where(x => x.IsRecordActive == true &&
                                                              x.MovieName.Contains(name))
                    .OrderByDescending(o => o.CreatedAt).ToListAsync();
                response.DataList = movies;
            }
            catch (CustomException e)
            {
                throw new CustomException(e.Message, e.InnerException, e.StatusCode, e.ClassName, e.MethodName, e.CreationUserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }

        public async Task<ResponseManager> Delete(int id, int userId)
        {

            var response = new ResponseManager();
            try
            {

                await _context.Movies.Where(x => x.MovieId == id)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(p => p.IsRecordActive, false)
                        .SetProperty(p => p.LastModificationByUserId, userId)
                        .SetProperty(p => p.LastModificationAt, DateTime.Now));

                await _context.SaveChangesAsync();
            }
            catch (CustomException e)
            {
                throw new CustomException(e.Message, e.InnerException, e.StatusCode, e.ClassName, e.MethodName, e.CreationUserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }

        public async Task<ResponseManager<MovieDTO>> Update(MovieDTO model)
        {
            var response = new ResponseManager<MovieDTO>();
            try
            {
                await _context.Movies.Where(x => x.MovieId == model.MovieId)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(p => p.MovieName, model.MovieName)
                        .SetProperty(p => p.ClassificationId, model.ClassificationId)
                        .SetProperty(p => p.GenderId, model.GenderId)
                        .SetProperty(p => p.DirectorName, model.DirectorName)
                        .SetProperty(p => p.ReleaseDate, model.ReleaseDate)
                        .SetProperty(p => p.ReleaseHour, model.ReleaseHour)
                        .SetProperty(p => p.Synopsis, model.Synopsis)
                        .SetProperty(p => p.LastModificationByUserId, model.UserId)
                        .SetProperty(p => p.LastModificationAt, DateTime.Now));

                await _context.SaveChangesAsync();

                response.SingleData = model;
            }
            catch (CustomException e)
            {
                throw new CustomException(e.Message, e.InnerException, e.StatusCode, e.ClassName, e.MethodName, e.CreationUserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }

        public async Task<ResponseManager<MovieDTO>> Create(MovieDTO model)
        {
            var response = new ResponseManager<MovieDTO>();
            try
            {
                var newMovie = new Movie
                {
                    MovieName           = model.MovieName,
                    GenderId            = model.GenderId,
                    ClassificationId    = model.ClassificationId,
                    Synopsis            = model.Synopsis,
                    DirectorName        = model.DirectorName,
                    ReleaseDate         = model.ReleaseDate,
                    ReleaseHour         = model.ReleaseHour,
                    CreatedByUserId     = model.UserId,
                    IsRecordActive      = true
                };

                await _context.Movies.AddAsync(newMovie);
                await _context.SaveChangesAsync();

                model.MovieId = newMovie.MovieId;
                response.SingleData = model;
            }
            catch (CustomException e)
            {
                throw new CustomException(e.Message, e.InnerException, e.StatusCode, e.ClassName, e.MethodName, e.CreationUserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }

        public async Task<ResponseManager<MoviesView>> GetById(int id)
        {
            var response = new ResponseManager<MoviesView>();
            try
            {
                var movieUpd = await _context.MoviesViews.FirstOrDefaultAsync(a => a.MovieId == id);

                response.SingleData = movieUpd;
            }
            catch (CustomException e)
            {
                throw new CustomException(e.Message, e.InnerException, e.StatusCode, e.ClassName, e.MethodName, e.CreationUserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }
    }
}
