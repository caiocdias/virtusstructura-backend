namespace virtusstructura_backend.Models
{
    public class Macrocycle
    {
        public int Id { get; set; }

        // Informações do macrociclo
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Relacionamento com plano de treino
        public int TrainingPlanId { get; set; }
        public TrainingPlan TrainingPlan { get; set; }

        // Relacionamento com mesociclos
        public ICollection<Mesocycle> Mesocycles { get; set; }
    }

}
