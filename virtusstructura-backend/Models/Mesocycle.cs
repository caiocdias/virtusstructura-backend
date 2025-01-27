namespace virtusstructura_backend.Models
{
    public class Mesocycle
    {
        public int Id { get; set; }

        // Informações do mesociclo
        public string Name { get; set; }
        public string Objective { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Relacionamento com macrociclo
        public int MacrocycleId { get; set; }
        public Macrocycle Macrocycle { get; set; }

        // Relacionamento com microciclos
        public ICollection<Microcycle> Microcycles { get; set; }
    }
}
