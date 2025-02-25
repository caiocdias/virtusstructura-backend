﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace virtusstructura_backend.Models
{
    public class Macrocycle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public ICollection<Mesocycle> Mesocycles { get; set; }

        [Required]
        public int TrainingPlanId { get; set; }

        [ForeignKey("TrainingPlanId")]
        public TrainingPlan TrainingPlan { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
