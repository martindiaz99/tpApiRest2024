using Microsoft.AspNetCore.Mvc;

namespace TP_Veterinaria.Controllers
{
    [Route("api/historiasclinicas")]
    [ApiController]
    public class HistoriaClinicaControlador : Controller
    {
        //Get
        [HttpGet]
        public int ContultarHistoriaAnimal(int idAnimal)
        {
            return 2;
        }

        //Get
        [HttpGet]
        public int ConsultarHistoriaPorMedicamento(int idMedicamento)
        {
            return 2;
        }
    }
}
