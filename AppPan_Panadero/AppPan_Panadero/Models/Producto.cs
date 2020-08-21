using System;
using System.Collections.Generic;
using System.Text;

namespace AppPan_Panadero.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Nombre_producto { get; set; }
        public byte[] Foto_producto { get; set; }
        public bool Disponible { get; set; }
        public double Precio { get; set; }
    }
}
