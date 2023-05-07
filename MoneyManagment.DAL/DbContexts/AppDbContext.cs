using Microsoft.EntityFrameworkCore;
using MoneyManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagment.DAL.DbContexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) 
        {
        
        }

        public DbSet<Expose> Exposes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
