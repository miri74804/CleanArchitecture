using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Core.DTOs
{
    public class ProfileDetailsDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public UserDto User { get; set; }
    }
}
