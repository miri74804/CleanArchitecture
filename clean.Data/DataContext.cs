using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clean.Core.Entities;
using clean.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace clean.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> users {  get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=my_db");
        }
    }
}
