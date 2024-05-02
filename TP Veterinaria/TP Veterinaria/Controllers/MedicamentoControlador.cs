using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP_Veterinaria.Controllers
{
    [Route("api/medicamentos")]
    [ApiController]
    public class MedicamentoControlador : ControllerBase
    {
        [HttpGet]
        public int ConsultarMedicamento()
        {
            return 2;
        }
    }
}
