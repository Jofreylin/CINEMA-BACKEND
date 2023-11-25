using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
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
            this._cinemaService = cinemaServ;
        }

        [HttpGet("/all")]
        public async Task<ActionResult<ResponseManager<CinemasView>>> GetAll()
        {
            var response = await _cinemaService.GetAllCinemas();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseManager<CinemasView>>> GetCinemasByName(string name)
        {
            var response = await _cinemaService.GetCinemasByName(name);
            return Ok(response);
        }

    }
}
