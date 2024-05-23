using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Veterinaria.Data;
using TP_Veterinaria.Models;

namespace TP_Veterinaria.Controllers
{
    [Route("api/medicamentos")]
    [ApiController]
    public class MedicamentoControlador : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MedicamentoControlador(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("idMedicamento")]
        public Medicamento ConsultarMedicamento(int idMedicamento)
        {
            return _context.Medicamento.Find(idMedicamento);
        }
    }
}