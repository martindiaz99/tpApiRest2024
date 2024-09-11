using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Veterinaria.Data;
using TP_Veterinaria.Dto;
using TP_Veterinaria.Models;
using TP_Veterinaria.Controllers;
using System.Net.Http;
using Azure;
using System.Net;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost("Registrar")]
        public async Task<ActionResult> CrearDueño([FromBody] DueñoDto dueñoDto)
        {
            Dueño dueño = new Dueño();
            dueño.Dni = dueñoDto.Dni;
            dueño.Nombre = dueñoDto.Nombre;

            //Guardar en la base
            _context.Add(dueño);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Get
        [HttpGet("Lista")]
        public async Task<List<Dueño>> listaDueños()
        {
            return _context.Dueño.ToList();
        }

        [HttpGet("Consultar")]
        public async Task<Dueño> consultarDueño(string dni)
        {
            return await _context.Dueño.FirstOrDefaultAsync(x => x.Dni == dni);
        }

        //Get
        [HttpDelete("Eliminar")]
        public async Task<ActionResult> eliminarDueño(string dni)
        {
            var dueñoEliminar = await _context.Dueño.FirstOrDefaultAsync(x => x.Dni == dni);

            if (dueñoEliminar != null)
            {
                _context.Remove(dueñoEliminar);
                await _context.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult> modificarDueño([FromBody] DueñoDto dueñoDto)
        {

            var dueñoModificar = await _context.Dueño.FirstOrDefaultAsync(x => x.Dni == dueñoDto.Dni);

            if (dueñoModificar != null)
            {
                dueñoModificar.Nombre = dueñoDto.Nombre;

                _context.Entry(dueñoModificar).State = EntityState.Modified;
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
