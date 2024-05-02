using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP_Veterinaria.Controllers
{
    [Route("api/atenciones")]
    [ApiController]
    public class AtencionControlador : ControllerBase
    {
        //Post
        [HttpPost]
        public int CrearAtencion()
        {
            return 2;
        }
    }
}
