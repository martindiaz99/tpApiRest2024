namespace TP_Veterinaria.Models
{
    public class HistoriaClinica
    {
        public int Id { get; set; }
        public int IdAnimal { get; set; }
        public string Tratamiento { get; set; }
        public int IdMedicamento { get; set; }
        public DateTime FechaAtencion { get; set; }
    }
}
