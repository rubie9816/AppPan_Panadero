using System;
using System.Collections.Generic;
using System.Text;

namespace AppPan_Panadero.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}

