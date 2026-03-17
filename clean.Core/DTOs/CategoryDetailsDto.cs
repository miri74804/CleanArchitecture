using clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Core.DTOs
{
    public class CategoryDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}
