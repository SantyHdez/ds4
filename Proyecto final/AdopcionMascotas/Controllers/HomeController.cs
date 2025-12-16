using System.Linq;
using System.Web.Mvc;
using AdopcionMascotas.Data;

namespace AdopcionMascotas.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Home
        // GET: Home
        public ActionResult Index()
        {
            // Obtener mascotas disponibles para mostrar en la página principal
            var mascotasDestacadas = db.Mascotas
                .Where(m => m.Estado == "Disponible")
                .OrderByDescending(m => m.FechaRegistro)
                .Take(6)
                .ToList();

            // Contar estadísticas para la página principal
            ViewBag.TotalMascotas = db.Mascotas.Count(m => m.Estado == "Disponible");
            ViewBag.TotalAdoptados = db.Mascotas.Count(m => m.Estado == "Adoptado");

            return View(mascotasDestacadas);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sobre Nosotros";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacto";
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}