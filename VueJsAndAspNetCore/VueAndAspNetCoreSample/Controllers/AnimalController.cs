using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Classes;
using Services.Services;

namespace AndagonTestSample.Controllers
{
    [Route("api/animal")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }
        
        public IActionResult  Get()
        {
            var result = _animalService.Get();
            if (result == null)
            {
                return Ok(new List<Animal>());
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Animal animal)
        {
           var result = _animalService.Add(animal);
           if (result.Status == TransactionStatus.Failed)
           {
               return BadRequest(error: result);
           }
            return Ok();
        }
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            _animalService.Remove(name);
            return Ok();
        }
    }
}
