using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace virtusstructura_backend.Models
{
    public class User
    {
        private const int SaltSize = 16; 
        private const int KeySize = 32;
        private const int Iterations = 100_000;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        private byte[] PasswordHash { get; set; } = new byte[0];

        [Required]
        public int Age { get; set; }
        
        [Required]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        [StringLength (100)]
        public string ExperienceLevel { get; set; }

        public ICollection<TrainingPlan> TrainingPlans { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.Now;
        }

        public void SetPassword(string password)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA512))
                {
                    byte[] key = pbkdf2.GetBytes(KeySize);

                    PasswordHash = new byte[SaltSize + KeySize];
                    Array.Copy(salt, 0, PasswordHash, 0, SaltSize);
                    Array.Copy(key, 0, PasswordHash, SaltSize, KeySize);
                }
            }

        }

        public bool ValidatePassword(string password)
        {
            if (PasswordHash == null || PasswordHash.Length != SaltSize + KeySize)
                return false;

            byte[] salt = new byte[SaltSize];
            Array.Copy(PasswordHash, 0, salt, 0, SaltSize);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA512))
            {
                byte[] computedKey = pbkdf2.GetBytes(KeySize);

                for (int i = 0; i < KeySize; i++)
                {
                    if (computedKey[i] != PasswordHash[SaltSize + i])
                        return false;
                }
                return true;
            }
        }
    }
}