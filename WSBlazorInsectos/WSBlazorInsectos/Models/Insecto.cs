using System;
using System.Collections.Generic;

#nullable disable

namespace WSBlazorInsectos.Models
{
    public partial class Insecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
    }
}
