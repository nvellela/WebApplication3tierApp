using _2DataAccessLayer.Context.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Context
{   

    public class DBEntitiesContext : DbContext
    {
        public DBEntitiesContext(DbContextOptions<DBEntitiesContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        //public DbSet<Category> Categories { get; set; }
    }

}
