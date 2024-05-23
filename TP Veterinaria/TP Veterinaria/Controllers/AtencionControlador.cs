using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Veterinaria.Data;
using TP_Veterinaria.Dto;
using TP_Veterinaria.Models;

namespace TP_Veterinaria.Controllers
{
    [Route("api/atenciones")]
    [ApiController]
    public class AtencionControlador : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AtencionControlador(ApplicationDbContext context)
        {
            _context = context;
        }

        //Post
        [HttpPost]
        public async Task<int> CrearAtencion(AtencionDto atencionDto)
        {
            if (atencionDto.FechaAtencion <= DateTime.Today.AddDays(30) //Dentro de 30 dias desde hoy
                && atencionDto.FechaAtencion >= DateTime.Today) //Fecha mayor que hoy
            {
                //Pasar los datos del DTO a la clase de Modelo
                Atencion atencion = new Atencion();
                atencion.MotivoConsulta = atencionDto.MotivoConsulta;
                atencion.IdTratamiento = atencionDto.IdTratamiento;
                atencion.IdMedicamento = atencionDto.IdMedicamento;
                atencion.FechaAtencion = atencionDto.FechaAtencion;

                //Guardar en la base
                _context.Add(atencion);
                await _context.SaveChangesAsync();
                return atencion.Id;
            }
            else
            {
                return 0;
            }
        }

        //Get
        [HttpGet("idMedicamento")]
        public async Task<List<Atencion>> ConsultaAtencionPorMedicamento(int idMedicamento)
        {
            List<Atencion> ListaAtenciones = new List<Atencion>();

            ListaAtenciones = _context.Atencion.Where(x => x.IdMedicamento == idMedicamento).ToList();

            return ListaAtenciones;
        }
    }
}
