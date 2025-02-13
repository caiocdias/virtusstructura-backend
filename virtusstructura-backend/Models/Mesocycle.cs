using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace virtusstructura_backend.Models
{
    public class Mesocycle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Objective { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<Microcycle> Microcycles { get; set; }

        [Required]
        public int MacrocycleId { get; set; }

        [ForeignKey("MacrocycleId")]
        public Macrocycle Macrocycle { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
