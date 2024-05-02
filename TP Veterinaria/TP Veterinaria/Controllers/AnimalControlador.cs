using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP_Veterinaria.Controllers
{
    [Route("api/animales")]
    [ApiController]
    public class AnimalControlador : ControllerBase
    {
        //Get
        [HttpGet]
        public int ContultarAnimal()
        {
            return 2;
        }

        //Post
        [HttpPost]
        public int CrearAnimal()
        {
            return 2;
        }

        //Put
        [HttpPut("id")]
        public ActionResult ActualizarAnimal(int id)
        {
            if (true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //Delete
        [HttpDelete("id")]
        public int EliminarAnimal()
        {
            return 2;
        }
    }
}
