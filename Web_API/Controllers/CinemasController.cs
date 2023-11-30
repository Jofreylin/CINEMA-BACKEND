﻿using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {

        private readonly ICinemaService _cinemaService;
  
        public CinemasController(ICinemaService cinemaServ)
        {
           _cinemaService = cinemaServ;
        }


        [HttpGet]
        public async Task<ActionResult<ResponseManager<CinemasView>>> Cinemas()
        {
            var response =  await _cinemaService.GetAllCinemas();
            return Ok(response);
        }

       
        [HttpGet("ByName")]
        public async Task<ActionResult<ResponseManager<CinemasView>>> GetByName(string name)
        {
            var response = await _cinemaService.GetCinemasByName(name);
            return Ok(response);
        }

        [HttpGet("ById")]
        public async Task<ActionResult<ResponseManager<CinemasView>>> GetByID(int id)
        {
            var response = await _cinemaService.GetById(id);
            return Ok(response);
        }
     
        [HttpDelete]
        public async Task<ActionResult<ResponseManager>> Delete(int cinemaId, int userId)
        {
            var response = await _cinemaService.Delete(cinemaId, userId);
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<ActionResult<ResponseManager<CinemaDTO>>> Update(CinemaDTO cine)
        {
            var response = await _cinemaService.Update(cine);
            return this.Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseManager<CinemaDTO>>> Create(CinemaDTO cine)
        {
            var response = await _cinemaService.Create(cine);
            return this.Ok(response);
        }
   
       

    }
}