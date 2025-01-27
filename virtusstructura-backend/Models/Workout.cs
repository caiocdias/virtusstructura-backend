namespace virtusstructura_backend.Models
{
    public class Workout
    {
        public int Id { get; set; }

        // Informações do treino
        public string Name { get; set; }
        public DateTime Date { get; set; }

        // Relacionamento com microciclo
        public int MicrocycleId { get; set; }
        public Microcycle Microcycle { get; set; }

        // Relacionamento com exercícios
        public ICollection<Exercise> Exercises { get; set; }
    }

}
