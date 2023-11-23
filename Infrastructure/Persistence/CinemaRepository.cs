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
    public class CinemaRepository :ICinemaRepository
    {
        private readonly CinemaContext _context;

        public CinemaRepository(CinemaContext cinemaContext)
        {
            _context = cinemaContext;
        }
        public async Task<ResponseManager<CinemasView>> GetAllCinemas()
        {
            var response = new ResponseManager<CinemasView>();
            try
            {
                var cines = _context.CinemasViews.Where(x => x.IsRecordActive == true)
                    .OrderByDescending(o => o.CreatedAt).ToListAsync();
                response.DataList = cines;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return response;
        }
        public async Task<ResponseManager<CinemasView>> GetCinemasByName(string cinemaName)
        {
            var response = new ResponseManager<CinemasView>();
            try
            {
                var cines = _context.CinemasViews.Where(x => x.IsRecordActive == true && 
                x.CinemaName.Contains(cinemaName)).OrderByDescending(o => o.CreatedAt).ToListAsync();
                response.DataList = cines;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return response;
        }
    }
}
