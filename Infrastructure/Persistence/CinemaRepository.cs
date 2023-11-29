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
    public class CinemaRepository : ICinemaRepository
    {
        private readonly CinemaContext _context;

        public CinemaRepository(CinemaContext cinemaContext)
        {
            _context = cinemaContext;
        }

        public async Task<ResponseManager<Cinema>> GetAllCinemas()
        {
            var response = new ResponseManager<Cinema>();
            try
            {
                var cines = await _context.Cinemas.Where(x => x.IsRecordActive == true)
                    .OrderByDescending(o => o.CreatedAt).ToListAsync();
                response.DataList = cines;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }

        public async Task<ResponseManager<Cinema>> GetCinemasByName(string cinemaName)
        {
            var response = new ResponseManager<Cinema>();
            try
            {
                var cines = await _context.Cinemas.Where(x => x.IsRecordActive == true &&
                                                              x.CinemaName.Contains(cinemaName))
                    .OrderByDescending(o => o.CreatedAt).ToListAsync();
                response.DataList = cines;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }

        public string Delete(long id)
        {
            return delete((id));
        }

        public string delete(long id)
        {
            var response = "OK";
            try
            {
                _context.Remove(_context.Cinemas.Single(x => x.CinemaId == id));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                response = "Error";
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }


        public async Task<ResponseManager<Cinema>> Update(Cinema cine)
        {
           var response = new ResponseManager<Cinema>();
           try
           {
               var cineUpd = _context.Cinemas.First(a => a.CinemaId == cine.CinemaId);
                cineUpd = cine;
                _context.Update(cineUpd);
               _context.SaveChanges();
               response.SingleData = cineUpd;
           }
           catch (Exception e)
           {
               Console.WriteLine(e.StackTrace);
           }

           return response;
        }
      
        public async Task<ResponseManager<Cinema>> Create(Cinema cine)
        {
            var response = new ResponseManager<Cinema>();
            try
            {
                var cineAdd = _context.Cinemas.Add(cine);
               
                _context.SaveChanges();
                response.SingleData = cineAdd.Entity;;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return response;  
        }

       public async Task<ResponseManager<Cinema>> GetById(long id)
        {
            var response = new ResponseManager<Cinema>();
            try
            {
                var cineUpd = _context.Cinemas.First(a => a.CinemaId == id);
                response.SingleData = cineUpd;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return response;
        }
    }
}
