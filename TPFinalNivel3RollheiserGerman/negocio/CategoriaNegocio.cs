using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace product
{
    public class CategoriaNegocio
    {
        public List<Categoria> toList()
        {
            List<Categoria> list = new List<Categoria>();
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.toSetQuery("select Id, Descripcion from CATEGORIAS");

                data.toExecuteReader();

                while (data.Reader.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Descripcion = (string)data.Reader["Descripcion"];

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
    }
}
