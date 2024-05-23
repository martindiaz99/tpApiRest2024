namespace TP_Veterinaria.Models
{
    public class Atencion
    {
        public int Id { get; set; }
        public string MotivoConsulta { get; set; }
        public int IdTratamiento { get; set; }
        public int IdMedicamento { get; set; }
        public DateTime FechaAtencion { get; set; }
    }
}
