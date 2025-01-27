namespace virtusstructura_backend.Models
{
    public class TrainingPlan
    {
        public int Id { get; set; }

        // Informações do plano
        public string Name { get; set; }
        public string Goal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Relacionamento com usuário
        public int UserId { get; set; }
        public User User { get; set; }

        // Relacionamento com macrociclos
        public ICollection<Macrocycle> Macrocycles { get; set; }
    }
}
