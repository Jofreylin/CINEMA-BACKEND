using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Web_API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {

        private readonly ICinemaService _cinemaService;
  
        public CinemasController(ICinemaService cinemaServ)
        {
           _cinemaService = cinemaServ;
        }


        [HttpPost]
        public async Task<ActionResult<ResponseManager<Cinema>>> Cinemas()
        {
            Console.WriteLine("hello");
            var response =  await _cinemaService.GetAllCinemas();
            return Ok(response);
        }

       
        [HttpPost]
        public async Task<ActionResult<ResponseManager<Cinema>>> SelectByName(string name)
        {
            var response = await _cinemaService.GetCinemasByName(name);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseManager<Cinema>>> GetByID(int id)
        {
            var response = await _cinemaService.GetById(id);
            return Ok(response);
        }
     
        [HttpPost]
        public IActionResult Delete(long id)
        {
            _cinemaService.Delete(id);
            return this.Ok();
        }
        
        [HttpPost]
        public async Task<ActionResult<ResponseManager<Cinema>>> Update(Cinema cine)
        {
            var response =await _cinemaService.Update(cine);
            return this.Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseManager<Cinema>>> Create(Cinema cine)
        {
            var response = await _cinemaService.Create(cine);
            return this.Ok(response);
        }
   
       

    }
}
