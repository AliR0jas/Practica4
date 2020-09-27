using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica4.Models
{
    public class InformacionViewModel
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public string NombreOriginal { get; set; }
        public DateTime? FechaEstreno { get; set; }
        public string Descripcion { get; set; }
        public IEnumerable<Apariciones> InfoApariciones { get; set; }
    }
}
