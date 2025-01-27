namespace virtusstructura_backend.Models
{
    public class TrainingPlan
    {
        public int Id { get; set; } // Identificador único (PK)

        // Informações do plano
        public string Name { get; set; } // Nome do plano (Ex.: "Treino de 12 semanas")
        public string Goal { get; set; } // Objetivo principal (Ex.: "Hipertrofia")
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Relacionamento com usuário
        public int UserId { get; set; } // Chave estrangeira para User
        public User User { get; set; } // Referência ao usuário

        // Relacionamento com macrociclos
        public ICollection<Macrocycle> Macrocycles { get; set; }
    }
}
