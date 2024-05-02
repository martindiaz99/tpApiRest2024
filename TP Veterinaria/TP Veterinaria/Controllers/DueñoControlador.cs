using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Veterinaria.Models;

namespace TP_Veterinaria.Controllers
{
    [Route("api/dueños")]
    [ApiController]
    public class DueñoControlador : ControllerBase
    {
        //Post
        [HttpPost]
        public int CrearDueño()
        {
            return 2;
        }
    }
}
