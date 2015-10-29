using DataAcces.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Model
{
    public class DemoContext :DbContext
    {
        public DbSet <Usuario> Usuarios{ get; set; }
    }
}
