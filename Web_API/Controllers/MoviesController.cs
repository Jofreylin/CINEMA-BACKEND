using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly IMovieService _movieService;
  
        public MoviesController(IMovieService movieServ)
        {
            this._movieService = movieServ;
        }

       
     
        [HttpGet]
        public async Task<ActionResult<ResponseManager<Movie>>> GetAllMovies()
        {
            var response = await _movieService.GetAllMovies();
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseManager<Movie>>> GetMoviesByName(string name)
        {
            var response = await _movieService.GetMoviesByName(name);
            return Ok(response);
        }
        [HttpPost]
        public string Delete(long id)
        {
            return _movieService.Delete(id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseManager<Movie>>> Update(Movie cine)
        {
            var response = await _movieService.Update(cine);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseManager<Movie>>> Create(Movie cine)
        {
            var response = await _movieService.Create(cine);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseManager<Movie>>> GetById(long id)
        {
            var response = await _movieService.GetById(id);
            return Ok(response);
        }
       

    }
}
