﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace virtusstructura_backend.Models
{
    public class TrainingPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Goal { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public ICollection<Macrocycle> Macrocycles { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
