﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Clase12.Models
{
    public class Movie
    {
        public int ID { get; set; }
       
        public String Nombre { get; set; }

        public TipoPelicula tipoPelicula { get; set; }
        public byte IdTipoPelicula { get; set; }
    }
}