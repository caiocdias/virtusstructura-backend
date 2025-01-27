﻿namespace virtusstructura_backend.Models
{
    public class User
    {
        public int Id { get; set; }

        // Informações básicas do usuário
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Dados físicos do usuário
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        // Nível de experiência no treinamento
        public string ExperienceLevel { get; set; }

        // Relacionamento com planos de treino
        public ICollection<TrainingPlan> TrainingPlans { get; set; }
    }
}
