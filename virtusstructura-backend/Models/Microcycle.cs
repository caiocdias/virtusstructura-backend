using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace virtusstructura_backend.Models
{
    public class Microcycle
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

        public ICollection<Workout> Workouts { get; set; }

        [Required]
        public int MesocycleId { get; set; }

        [ForeignKey("MesocycleId")]
        public Mesocycle Mesocycle { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.Now;
        }
    }

}
