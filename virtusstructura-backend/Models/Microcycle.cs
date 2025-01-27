namespace virtusstructura_backend.Models
{
    public class Microcycle
    {
        public int Id { get; set; }

        // Informações do microciclo
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Relacionamento com mesociclo
        public int MesocycleId { get; set; }
        public Mesocycle Mesocycle { get; set; }

        // Relacionamento com treinos
        public ICollection<Workout> Workouts { get; set; }
    }

}
