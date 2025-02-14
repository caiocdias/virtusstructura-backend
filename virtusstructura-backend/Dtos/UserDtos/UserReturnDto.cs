using virtusstructura_backend.Models;

namespace virtusstructura_backend.Dtos.UserDtos
{
    public class UserReturnDto
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string ExperienceLevel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
