using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using static System.Collections.Specialized.BitVector32;

namespace product
{
    public static class Validacion
    {
        public static bool validaTextoVacio(object control)
        {
            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static bool validaEmail(object pattern)
        {
            Regex email = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            if (!email.IsMatch(pattern.ToString()))
            {
                return true;
            }
            return false;
        }

        public static bool validaPassword(object pattern)
        {
            Regex password = new Regex(@"^[\s\S]{3,20}$");

            if (!password.IsMatch(pattern.ToString()))
            {
                return true;
            }
            return false;
        }

        public static bool validaPrecio(object pattern)
        {
            Regex precio = new Regex(@"\d+(\,\d\d)?$");

            if (!precio.IsMatch(pattern.ToString()))
            {
                return true;
            }
            return false;
        }
    }
}
