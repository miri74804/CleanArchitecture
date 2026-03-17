using clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Core.DTOs
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserProfileDto Profile { get; set; }
        public List<TaskDto> Tasks { get; set; }
  
    }
}
