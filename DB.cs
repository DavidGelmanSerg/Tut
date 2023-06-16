using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace JobLink
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public List <Groups> Groups { get; set; }=new List<Groups>();
    }

    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public DateTime start_date { get; set; }
        public DateTime deadline { get; set; }

        public int User_id { get; set; }
        public Users user { get; set; }

        public int Group_id { get; set; }
        public Groups group { get; set; }
    }
    public class Groups
    {
        public int Id { get; set; }
        public string GName { get;set; }

        public List<Users> Users { get; set; } = new List<Users>();
    }

    public class ApplicationContext : DbContext
    {
        public DbSet  <Task> Tasks { get;set; }
        public DbSet<Groups> Groups { get; set;  }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=GelmanDS06082003;database=mydb;",
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }


}
