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
        AccesoDatos data = new AccesoDatos();
        public bool toLogin(Usuario usuario)
        {
            try
            {
                data.toSetQuery("Select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where email = @email and pass = @pass");
                toLoadLoginParameters(usuario);
                data.toExecuteReader();

                while (data.Reader.Read())
                {
                    usuario.Id = (int)data.Reader["Id"];
                    usuario.Email = (string)data.Reader["email"];
                    usuario.Pass = (string)data.Reader["pass"];

                    if (!(data.Reader["nombre"] is DBNull))
                    {
                        usuario.Nombre = (string)data.Reader["nombre"];
                    }

                    if (!(data.Reader["apellido"] is DBNull))
                    {
                        usuario.Apellido = (string)data.Reader["apellido"];
                    }

                    if (!(data.Reader["urlImagenPerfil"] is DBNull))
                    {
                        usuario.ImagenPerfil = (string)data.Reader["urlImagenPerfil"];
                    }

                    usuario.TipoUsuario = (bool)(data.Reader["admin"]) == false ? TipoUsuario.NORMAL : TipoUsuario.ADMIN;
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
                data.toCloseConnection();
            }
        }

        public int toAdd(Usuario nuevo)
        {
            try
            {
                data.toSetQuery("Insert into USERS (email, pass, nombre, apellido, urlImagenPerfil, admin) output inserted.Id values (@email, @pass, @nombre, @apellido, @urlImagenPerfil, @admin)");
                toLoadNewParameters(nuevo);
                return data.toExcecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.toCloseConnection();
            }
        }

        public void toModify(Usuario modificar)
        {
            try
            {
                data.toSetQuery("Update USERS set email = @email, pass = @pass, nombre = @nombre, apellido = @apellido, urlImagenPerfil = @urlImagenPerfil, admin = @admin where Id = @id");
                toLoadModifiedParameters(modificar);
                data.toExcecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.toCloseConnection();
            }
        }

        public void toDelete(int id)
        {
            try
            {
                //data.toClearParameter();

                data.toSetQuery("delete from USERS where Id = @id");

                data.toSetParameter("@id", id);

                data.toExcecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.toCloseConnection();
            }
        }

        public List<Usuario> toList(string id = "")
        {
            List<Usuario> list = new List<Usuario>();

            try
            {
                string query = "Select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS ";
                data.toSetQuery(query);

                if (id != "")
                {
                    query += " where Id = " + id;
                    data.toSetQuery(query);
                }

                data.toExecuteReader();

                while (data.Reader.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Email = (string)data.Reader["email"];
                    aux.Pass = (string)data.Reader["pass"];

                    if (!(data.Reader["nombre"] is DBNull))
                    {
                        aux.Nombre = (string)data.Reader["nombre"];
                    }

                    if (!(data.Reader["apellido"] is DBNull))
                    {
                        aux.Apellido = (string)data.Reader["apellido"];
                    }

                    if (!(data.Reader["urlImagenPerfil"] is DBNull))
                    {
                        aux.ImagenPerfil = (string)data.Reader["urlImagenPerfil"];
                    }

                    aux.TipoUsuario = (bool)(data.Reader["admin"]) == false ? TipoUsuario.NORMAL : TipoUsuario.ADMIN;

                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.toCloseConnection();
            }
        }

        public List<Usuario> toSortBy(string campo, string criterio, string filtro)
        {
            List<Usuario> list = new List<Usuario>();

            try
            {
                string consulta = "Select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where ";

                if (campo == "1")
                {
                    switch (criterio)
                    {
                        case "1":
                            consulta += "nombre like '" + filtro + "%'";
                            break;
                        case "2":
                            consulta += "nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "2")
                {
                    switch (criterio)
                    {
                        case "1":
                            consulta += "email like '" + filtro + "%'";
                            break;
                        case "2":
                            consulta += "email like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "email like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "3")
                {
                    switch (criterio)
                    {
                        case "1":
                            consulta += "admin = " + filtro;
                            break;
                        case "2":
                            consulta += "admin = " + filtro;
                            break;
                        case "3":
                            consulta = "admin like '%" + filtro + "%'";
                            break;
                        default:
                            consulta = "admin like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "A.Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "A.Precio < " + filtro;
                            break;
                        default:
                            consulta += "A.Precio = " + filtro;
                            break;
                    }
                }

                data.toSetQuery(consulta);
                data.toExecuteReader();

                while (data.Reader.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Email = (string)data.Reader["email"];
                    aux.Pass = (string)data.Reader["pass"];

                    if (!(data.Reader["nombre"] is DBNull))
                    {
                        aux.Nombre = (string)data.Reader["nombre"];
                    }

                    if (!(data.Reader["apellido"] is DBNull))
                    {
                        aux.Apellido = (string)data.Reader["apellido"];
                    }

                    if (!(data.Reader["urlImagenPerfil"] is DBNull))
                    {
                        aux.ImagenPerfil = (string)data.Reader["urlImagenPerfil"];
                    }

                    aux.TipoUsuario = (bool)(data.Reader["admin"]) == false ? TipoUsuario.NORMAL : TipoUsuario.ADMIN;

                    list.Add(aux);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.toCloseConnection();
            }
        }

        private void toLoadLoginParameters(Usuario usuario)
        {
            data.toSetParameter("@email", usuario.Email);
            data.toSetParameter("@pass", usuario.Pass);
        }

        private void toLoadNewParameters(Usuario nuevo)
        {
            data.toSetParameter("@email", nuevo.Email);
            data.toSetParameter("@pass", nuevo.Pass);
            data.toSetParameter("@nombre", nuevo.Nombre);
            data.toSetParameter("@apellido", nuevo.Apellido);
            data.toSetParameter("@urlImagenPerfil", (Object)nuevo.ImagenPerfil ?? DBNull.Value); //Evaluar nulos
            data.toSetParameter("@admin", nuevo.TipoUsuario);
        }

        private void toLoadModifiedParameters(Usuario modificar)
        {
            data.toSetParameter("@id", modificar.Id);
            data.toSetParameter("@email", modificar.Email);
            data.toSetParameter("@pass", modificar.Pass);
            data.toSetParameter("@nombre", modificar.Nombre);
            data.toSetParameter("@apellido", modificar.Apellido);
            data.toSetParameter("@urlImagenPerfil", (Object)modificar.ImagenPerfil ?? DBNull.Value);
            data.toSetParameter("@admin", modificar.TipoUsuario);
        }
    }
}
