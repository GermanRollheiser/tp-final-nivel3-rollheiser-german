using domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace product
{
    public class FavoritoNegocio
    {
        private AccesoDatos data = new AccesoDatos();

        public List<Favorito> toList(string id = "")
        {
            List<Favorito> list = new List<Favorito>();

            try
            {
                string query = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.IdCategoria, A.IdMarca, A.Precio, C.Descripcion as Categoria, " +
                    "M.Descripcion as Marca, F.IdArticulo as Articulo, F.IdUser as Usuario from ARTICULOS A inner join FAVORITOS F ON (A.Id = F.IdArticulo) inner join USERS U ON (F.IdUser = U.Id), CATEGORIAS C, MARCAS M " +
                    "where A.IdCategoria = C.Id and A.IdMarca = M.Id and F.IdArticulo = A.Id ";

                data.toSetQuery(query);

                if (id != "")
                {
                    query += " and U.Id = " + id;
                    data.toSetQuery(query);
                }

                data.toExecuteReader();

                while (data.Reader.Read())
                {
                    Favorito item = new Favorito();
                    item.Id = (int)data.Reader["Id"];
                    item.Codigo = (string)data.Reader["Codigo"];
                    item.Nombre = (string)data.Reader["Nombre"];
                    item.Descripcion = (string)data.Reader["Descripcion"];
                    item.Precio = Math.Round(data.Reader.GetDecimal(7), 2);

                    if (!(data.Reader["ImagenUrl"] is DBNull))
                    {
                        item.ImagenUrl = (string)data.Reader["ImagenUrl"];
                    }

                    item.Categoria = new Categoria();
                    item.Categoria.Id = (int)data.Reader["IdCategoria"];
                    item.Categoria.Descripcion = (string)data.Reader["Categoria"];

                    item.Marca = new Marca();
                    item.Marca.Id = (int)data.Reader["IdMarca"];
                    item.Marca.Descripcion = (string)data.Reader["Marca"];

                    item.IdArticulo = (int)data.Reader["Articulo"];
                    item.IdUser = (int)data.Reader["Usuario"];

                    list.Add(item);
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

        public int toAdd(Favorito nuevo)
        {
            try
            {
                data.toSetQuery("Insert into FAVORITOS (IdUser, IdArticulo) output inserted.Id values (@IdUser, @IdArticulo)");
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

        public void toDelete(int idUser, int idArticulo)
        {
            try
            {
                data.toSetQuery("delete from FAVORITOS where IdUser = @IdUser and IdArticulo = @IdArticulo");

                data.toSetParameter("@IdUser", idUser);
                data.toSetParameter("@IdArticulo", idArticulo);

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

        private void toLoadNewParameters(Favorito nuevo)
        {
            data.toSetParameter("@IdUser", nuevo.IdUser);
            data.toSetParameter("@IdArticulo", nuevo.IdArticulo);
        }

        private void toLoadToDeleteParameters(Favorito nuevo)
        {
            data.toSetParameter("@IdUser", nuevo.IdUser);
            data.toSetParameter("@IdArticulo", nuevo.IdArticulo);
        }
    }
}
