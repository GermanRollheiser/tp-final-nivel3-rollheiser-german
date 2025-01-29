using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;

namespace product
{
    public class UsuarioNegocio
    {
        public bool toLogin(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.toSetQuery("Select Id, admin from USERS where email = @email and pass = @pass");
                datos.toSetParameter("@email", usuario.User);
                datos.toSetParameter("@pass", usuario.Pass);
                datos.toExecuteReader();

                while (datos.Reader.Read())
                {
                    usuario.Id = (int)datos.Reader["Id"];
                    usuario.TipoUsuario = (bool)(datos.Reader["admin"]) == false ? TipoUsuario.NORMAL : TipoUsuario.ADMIN;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.toCloseConnection();
            }
        }
    }
}
