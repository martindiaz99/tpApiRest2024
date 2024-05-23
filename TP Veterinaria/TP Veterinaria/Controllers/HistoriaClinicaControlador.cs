using Microsoft.AspNetCore.Mvc;
using TP_Veterinaria.Data;
using TP_Veterinaria.Models;

namespace TP_Veterinaria.Controllers
{
    [Route("api/historiasclinicas")]
    [ApiController]
    public class HistoriaClinicaControlador : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;

        public HistoriaClinicaControlador(ApplicationDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        //Get
        [HttpGet("idAnimal")]
        public List<HistoriaClinica> ContultarHistoriaAnimal(int idAnimal)
        {
            List<HistoriaClinica> ListaHistoriasClinicas = new List<HistoriaClinica>();

            _context.HistoriaClinica.Where(x => x.IdAnimal == idAnimal).ToList();

            return ListaHistoriasClinicas;
        }

        //Get
        [HttpGet("idMedicamento")]
        public async Task<List<HistoriaClinica>> ConsultarHistoriaPorMedicamento(int idMedicamento)
        {
            //Obtener listado de Atenciones que tengan ese idMedicamento
            var urlPedido = $"https://localhost:7001/api/atenciones/idMedicamento?idMedicamento={idMedicamento}";

            var respuesta = await _httpClient.GetAsync(urlPedido);
            respuesta.EnsureSuccessStatusCode();

            List<Atencion> ListaAtenciones = await respuesta.Content.ReadFromJsonAsync<List<Atencion>>();

            //Obtener una Lista de los Id de esas atenciones
            List<int> ListaIdAtenciones = new List<int>();
            foreach (Atencion atencion in ListaAtenciones)
            {
                ListaIdAtenciones.Add(atencion.Id);
            }

            //Comparar ambas Listas de Id y guardar los que coincidan
            List<HistoriaClinica> ListaHistoriasClinicas = _context.HistoriaClinica.Where(x => ListaIdAtenciones.Any(id => x.IdAtenciones.Contains(id))).ToList();

            return ListaHistoriasClinicas;
        }
    }
}
