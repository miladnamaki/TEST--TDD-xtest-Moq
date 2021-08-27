using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTest.Models
{
    public class DataBaseContext:DbContext

    {
        public DataBaseContext(DbContextOptions< DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}
