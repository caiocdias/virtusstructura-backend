namespace virtusstructura_backend.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        // Informações do exercício
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double Load { get; set; }

        // Relacionamento com treino
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
    }

}
