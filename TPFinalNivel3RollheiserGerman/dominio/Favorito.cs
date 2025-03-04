﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Favorito
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; }
        public int IdTablaArt { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
    }
}
