using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionaire.Model
{
    public class DataContext : DbContext
    {
        public DbSet<ReasonsToBeHired> ReasonstoBeHired { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options ): base(options)
        {

        }


    }
}
