﻿namespace TP_Veterinaria.Models
{
    public class HistoriaClinica
    {
        public int Id { get; set; }
        public int IdAnimal { get; set; }
        public List<int> IdAtenciones { get; set; }
    }
}
