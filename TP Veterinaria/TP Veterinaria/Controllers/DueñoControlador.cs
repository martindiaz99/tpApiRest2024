using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Veterinaria.Data;
using TP_Veterinaria.Dto;
using TP_Veterinaria.Models;
using TP_Veterinaria.Controllers;
using System.Net.Http;
using Azure;

namespace TP_Veterinaria.Controllers
{
    [Route("api/duenos")]
    [ApiController]
    public class DueñoControlador : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;

        public DueñoControlador(ApplicationDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        //Post
        [HttpPost]
        public async Task<ActionResult> CrearDueño(DueñoDto dueñoDto)
        {
            //Pasar los datos del DTO a la clase de Modelo
            Dueño dueño = new Dueño();
            dueño.Dni = dueñoDto.Dni;
            dueño.Nombre = dueñoDto.Nombre;

            //Guardar en la base
            _context.Add(dueño);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Get
        [HttpGet("idDueno")]
        public async Task<List<Animal>> ConsultarAnimalesDueño(int idDueno)
        {
            var urlPedido = $"https://localhost:7001/api/animales/idDueno?idDueno={idDueno}";

            var respuesta = await _httpClient.GetAsync(urlPedido);
            respuesta.EnsureSuccessStatusCode();

            List<Animal> ListaAnimales = await respuesta.Content.ReadFromJsonAsync<List<Animal>>();

            return ListaAnimales;
        }
    }
}
