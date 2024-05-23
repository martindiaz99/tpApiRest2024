namespace TP_Veterinaria.Dto
{
    public class AtencionDto
    {
        public string MotivoConsulta { get; set; }
        public int IdTratamiento { get; set; }
        public int IdMedicamento { get; set; }
        public DateTime FechaAtencion { get; set; }
    }
}
