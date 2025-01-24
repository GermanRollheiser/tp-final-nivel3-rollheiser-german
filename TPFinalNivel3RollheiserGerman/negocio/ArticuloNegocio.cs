using domain;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace product
{
    public class ArticuloNegocio
    {
        private AccesoDatos data = new AccesoDatos();

        public List<Articulo> toList(string id = "")
        {
            List<Articulo> list = new List<Articulo>();

            try
            {
                string query = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.IdCategoria, A.IdMarca, A.Precio, " +
                    "C.Descripcion as Categoria, M.Descripcion as Marca from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria = C.Id and A.IdMarca = M.Id ";

                data.toSetQuery(query);

                if (id != "")
                {
                    query += " and A.Id = " + id;
                    data.toSetQuery(query);
                }
                
                data.toExecuteReader();

                while (data.Reader.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Codigo = (string)data.Reader["Codigo"];
                    aux.Nombre = (string)data.Reader["Nombre"];
                    aux.Descripcion = (string)data.Reader["Descripcion"];
                    aux.Precio = Math.Round(data.Reader.GetDecimal(7), 2);

                    if (!(data.Reader["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)data.Reader["ImagenUrl"];
                    }
                    
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)data.Reader["IdCategoria"];
                    aux.Categoria.Descripcion = (string)data.Reader["Categoria"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)data.Reader["IdMarca"];
                    aux.Marca.Descripcion = (string)data.Reader["Marca"];

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

        public void toAdd(Articulo nuevo)
        {
            try
            {
                data.toClearParameter();

                data.toSetQuery("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) " +
                "values (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio)");

                toLoadNewParameters(nuevo);

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

        public void toModify(Articulo modificar)
        {
            try
            {
                data.toClearParameter();

                data.toSetQuery("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, " +
                    "IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @imagenUrl, Precio = @precio where Id = @id");
                
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
                data.toClearParameter();

                data.toSetQuery("delete from ARTICULOS where Id = @id");

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

        public List<Articulo> toSortBy(string campo, string criterio, string filtro)
        {
            List<Articulo> list = new List<Articulo>();

            try
            {
                string consulta = ("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.IdCategoria, A.IdMarca, A.Precio, " +
                    "C.Descripcion as Categoria, M.Descripcion as Marca from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria = C.Id and A.IdMarca = M.Id and ");

                if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "A.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Categoría")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%'";
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
                    Articulo aux = new Articulo();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Codigo = (string)data.Reader["Codigo"];
                    aux.Nombre = (string)data.Reader["Nombre"];
                    aux.Descripcion = (string)data.Reader["Descripcion"];
                    aux.Precio = Math.Round(data.Reader.GetDecimal(7), 2);

                    if (!(data.Reader["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)data.Reader["ImagenUrl"];
                    }

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)data.Reader["IdCategoria"];
                    aux.Categoria.Descripcion = (string)data.Reader["Categoria"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)data.Reader["IdMarca"];
                    aux.Marca.Descripcion = (string)data.Reader["Marca"];

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

        private void toLoadModifiedParameters(Articulo modificar)
        {
            data.toSetParameter("@codigo", modificar.Codigo);
            data.toSetParameter("@nombre", modificar.Nombre);
            data.toSetParameter("@descripcion", modificar.Descripcion);
            data.toSetParameter("@idMarca", modificar.Marca.Id);
            data.toSetParameter("@idCategoria", modificar.Categoria.Id);
            data.toSetParameter("@imagenUrl", modificar.ImagenUrl);
            data.toSetParameter("@precio", modificar.Precio);
            data.toSetParameter("@id", modificar.Id);
        }

        private void toLoadNewParameters(Articulo nuevo)
        {
            data.toSetParameter("@codigo", nuevo.Codigo);
            data.toSetParameter("@nombre", nuevo.Nombre);
            data.toSetParameter("@descripcion", nuevo.Descripcion);
            data.toSetParameter("@idMarca", nuevo.Marca.Id);
            data.toSetParameter("@idCategoria", nuevo.Categoria.Id);
            data.toSetParameter("@imagenUrl", nuevo.ImagenUrl);
            data.toSetParameter("@precio", nuevo.Precio);
        }
    }
}
