using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly IMovieService _movieService;
  
        public MoviesController(IMovieService movieServ)
        {
            this._movieService = movieServ;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseManager<MoviesView>>> GetAll()
        {
            var response = await _movieService.GetAllMovies();
            return Ok(response);
        }

       

    }
}
