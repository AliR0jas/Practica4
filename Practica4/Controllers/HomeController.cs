using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica4.Models;

namespace Practica4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pelicula()
        {
            pixarContext context = new pixarContext();
            var pelicula = context.Pelicula.OrderBy(x => x.Nombre);
            return View(pelicula);
        }

        [Route("{id}")]
        public IActionResult Informacion(string id)
        {
            pixarContext context = new pixarContext();

            var nombre = id.Replace("-", " ").ToUpper();
            var pelicula = context.Pelicula.Include(x => x.Apariciones).FirstOrDefault(x => x.Nombre.ToUpper() == nombre);
            var info = context.Apariciones.Include(x => x.IdPersonajeNavigation).Include(x => x.IdPeliculaNavigation).Where
                (x => (x.IdPelicula == pelicula.Id)).Select(x => x);
            if (pelicula == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                InformacionViewModel ivm = new InformacionViewModel();

                ivm.Nombre = pelicula.Nombre;
                ivm.Id = pelicula.Id;
                ivm.NombreOriginal = pelicula.NombreOriginal;
                ivm.FechaEstreno = pelicula.FechaEstreno;
                ivm.Descripcion = pelicula.Descripción;
                ivm.InfoApariciones = info;
                return View(ivm);
            }
        }

        public IActionResult Cortos()
        {
            pixarContext context = new pixarContext();
            var corto = context.Categoria.OrderBy(x => x.Nombre).Select(x => new CortosViewModel
            { NombreCategoria = x.Nombre, Cortometraje = x.Cortometraje.OrderBy(x => x.Nombre) });
            return View(corto);
        }
        public IActionResult Cortometraje(string id)
        {
            pixarContext context = new pixarContext();
            var nombre = id.Replace("-", " ").ToLower();
            var cortom = context.Cortometraje.FirstOrDefault(x => x.Nombre.ToLower() == nombre);
            if (cortom == null)
            {
                return RedirectToAction("Cortos");
            }
            else
            {
                return View(cortom);
            }

        }
    }
}
