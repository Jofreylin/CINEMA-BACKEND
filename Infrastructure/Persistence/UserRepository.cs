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
using System.Web.Http;

namespace Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly CinemaContext _context;
        public UserRepository(CinemaContext context) {
            _context = context;        
        }

        public async Task<ResponseManager<UsersView>> GetAllUsers()
        {
            var response = new ResponseManager<UsersView>();
            try
            {

                var list = await _context.UsersViews.Where(x=>x.IsRecordActive == true).OrderByDescending(o=>o.CreatedAt).ToListAsync();

                response.DataList = list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return response;
        }


    }
}
