using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<ResponseManager<MoviesView>>> GetAllMovies()
        {
            var response = await _movieService.GetAllMovies();
            return Ok(response);
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<ResponseManager<MoviesView>>> GetMoviesByName(string movieName)
        {
            var response = await _movieService.GetMoviesByName(movieName);
            return Ok(response);
        }

        [HttpGet("ById")]
        public async Task<ActionResult<ResponseManager<MoviesView>>> GetById(int movieId)
        {
            var response = await _movieService.GetById(movieId);
            return Ok(response);
        }

        [HttpGet("ActorsInMovie")]
        public async Task<ActionResult<ResponseManager<ActorsInMoviesView>>> GetActorsByMovie(int movieId)
        {
            var response = await _movieService.GetActorsByMovie(movieId);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ResponseManager>> Delete(int movieId, int userId)
        {
            var response = await _movieService.Delete(movieId, userId);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseManager<MovieDTO>>> Update(  MovieDTO model)
        {
            var response = await _movieService.Update(model);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseManager<MovieDTO>>> Create(  MovieDTO model)
        {
            var response = await _movieService.Create(model);
            return Ok(response);
        }

        [HttpDelete("DeleteActorInMovie")]
        public async Task<ActionResult<ResponseManager>> DeleteActor(int acInMoId, int userId)
        {
            var response = await _movieService.DeleteActorInMovie(acInMoId, userId);
            return Ok(response);
        }

    }
}
