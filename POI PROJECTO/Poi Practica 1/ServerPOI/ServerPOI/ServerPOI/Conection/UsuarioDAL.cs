using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ServerPOI.Conection
{
    public class UsuarioDAL
    {
        public static int AgregarUsuario(Usuario u) {
            int retorno = 0;
            MySqlCommand comando= new MySqlCommand(string.Format("Insert into clientes (nombreCliente,passwordCliente) values('{1}','{2}')",u.nombre,u.password),Connection.con());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
    }
}
