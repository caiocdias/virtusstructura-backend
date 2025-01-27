using System;
using System.Security.Cryptography;
using System.Text;

namespace virtusstructura_backend.Models
{
    public class User
    {
        public int Id { get; set; }

        // Informações básicas do usuário
        public string Name { get; set; }
        public string Email { get; set; }

        // Propriedades privadas para proteger os dados sensíveis
        private string PasswordHash { get; set; }
        private string PasswordSalt { get; set; }

        // Dados físicos do usuário
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        // Nível de experiência no treinamento
        public string ExperienceLevel { get; set; }

        // Relacionamento com planos de treino
        public ICollection<TrainingPlan> TrainingPlans { get; set; }

        // Método para definir uma senha e gerar o hash
        public void SetPassword(string password)
        {
            // Gera um salt único
            PasswordSalt = GenerateSalt();

            // Gera o hash da senha com o salt
            PasswordHash = GenerateHash(password, PasswordSalt);
        }

        // Método para validar a senha fornecida
        public bool ValidatePassword(string password)
        {
            // Compara o hash da senha fornecida com o hash armazenado
            var hashedInput = GenerateHash(password, PasswordSalt);
            return hashedInput == PasswordHash;
        }

        // Método para gerar um salt único
        private string GenerateSalt()
        {
            var saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Método para gerar o hash da senha
        private string GenerateHash(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}