using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Practica4.Models
{
    public class CortosViewModel
    {
        public string NombreCategoria { get; set; }
        public IEnumerable<Models.Cortometraje> Cortometraje { get; set; }

    }
}
