using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBilirTask2.Models.Concrete.Entity;

namespace WebBilirTask2.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-07T1LR2;  Database=WebBilirHardTask; integrated security=true");
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<TypeOf> TypeOfs { get; set; }
        
    }
}
