using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Veterinaria.Data;
using TP_Veterinaria.Dto;
using TP_Veterinaria.Models;

namespace TP_Veterinaria.Controllers
{
    [Route("api/animales")]
    [ApiController]
    public class AnimalControlador : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AnimalControlador(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get
        [HttpGet]
        public Animal ContultarAnimal(int id)
        {
            return _context.Animal.Find(id);
        }

        //Post
        [HttpPost]
        public async Task<int> CrearAnimalAsync(AnimalDto animalDto)
        {
            //Pasar los datos del DTO a la clase de Modelo
            Animal animal = new Animal();
            animal.Nombre = animalDto.Nombre;
            animal.FechaNacimiento = animalDto.FechaNacimiento;
            animal.Raza = animalDto.Raza;
            animal.Dueño = animalDto.Dueño;
            animal.Sexo = animalDto.Sexo;

            //Guardar en la base
            _context.Add(animal);
            await _context.SaveChangesAsync();
            return animal.Id;
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
