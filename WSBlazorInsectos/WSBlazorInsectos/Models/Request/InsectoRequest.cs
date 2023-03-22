using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSBlazorInsectos.Models.Request
{
    public class InsectoRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
    }
}
