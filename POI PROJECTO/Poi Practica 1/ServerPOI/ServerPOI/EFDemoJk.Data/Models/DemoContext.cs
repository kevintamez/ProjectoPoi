using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemoJk.Data.Models
{
    public class DemoContext: DbContext 
    {
        public DbSet <Usuario> usuarios{ get; set; }
    }
}
