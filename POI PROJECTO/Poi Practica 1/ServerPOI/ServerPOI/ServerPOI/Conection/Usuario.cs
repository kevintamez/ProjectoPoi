using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerPOI.Conection
{
    public class Usuario
    {
        public int id {get;set;}
        public String nombre{get;set;}
        public String password { get; set; }

        public Usuario() { }

        public Usuario(int id, String nombre,String password) {
            this.id = id;
            this.nombre = nombre;
            this.password = password;
        }
    }
}
