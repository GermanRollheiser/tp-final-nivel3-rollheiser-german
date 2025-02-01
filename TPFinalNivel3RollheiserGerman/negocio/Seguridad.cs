using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace product
{
    public static class Seguridad
    {
        public static bool activeSession(object user)
        {
            Usuario perfil = user != null ? (Usuario)user : null;

            if (perfil != null && perfil.Id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
