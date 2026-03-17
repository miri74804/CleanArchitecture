using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Core.DTOs
{
    public class TaskDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public UserDto User { get; set; }
        public List<CategoryDto> Categories { get; set; }


    }
}
