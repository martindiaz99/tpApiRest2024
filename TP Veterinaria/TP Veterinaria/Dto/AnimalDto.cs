namespace TP_Veterinaria.Dto
{
    public class AnimalDto
    {
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Sexo { get; set; }
        public int Dueño { get; set; }
    }
}
