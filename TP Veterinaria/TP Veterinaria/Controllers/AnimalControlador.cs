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
        [HttpGet("idAnimal")]
        public Animal ConsultarAnimal(int idAnimal)
        {
            return _context.Animal.Find(idAnimal);
        }

        //Get
        [HttpGet("idDueno")]
        public List<Animal> ConsultarAnimalPorDueño(int idDueno)
        {
            List<Animal> ListaAnimales = new List<Animal>();
            
            ListaAnimales = _context.Animal.Where(x => x.Dueño == idDueno).ToList();

            return ListaAnimales;
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
        public async Task<ActionResult> ActualizarAnimal(AnimalDto animalDto, int idAnimal)
        {
            if (ConsultarAnimal(idAnimal) != null)
            {
                //Pasar los datos del DTO a la clase de Modelo
                Animal animal = new Animal();
                animal.Id = idAnimal;
                animal.Nombre = animalDto.Nombre;
                animal.FechaNacimiento = animalDto.FechaNacimiento;
                animal.Raza = animalDto.Raza;
                animal.Dueño = animalDto.Dueño;
                animal.Sexo = animalDto.Sexo;

                _context.Update(animal);
                await _context.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //Delete
        [HttpDelete("id")]
        public async Task<ActionResult> EliminarAnimal(int idAnimal)
        {
            Animal animalEliminar = ConsultarAnimal(idAnimal);

            if (animalEliminar != null)
            {
                _context.Remove(animalEliminar);
                await _context.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
