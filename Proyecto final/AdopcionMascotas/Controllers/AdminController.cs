using System;
using System.Linq;
using System.Web.Mvc;
using AdopcionMascotas.Data;

namespace AdopcionMascotas.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin (Dashboard principal)
        public ActionResult Index()
        {
            // Estadísticas generales
            ViewBag.TotalMascotas = db.Mascotas.Count();
            ViewBag.MascotasDisponibles = db.Mascotas.Count(m => m.Estado == "Disponible");
            ViewBag.MascotasEnProceso = db.Mascotas.Count(m => m.Estado == "En Proceso");
            ViewBag.MascotasAdoptadas = db.Mascotas.Count(m => m.Estado == "Adoptado");

            ViewBag.TotalSolicitudes = db.Solicitudes.Count();
            ViewBag.SolicitudesPendientes = db.Solicitudes.Count(s => s.Estado == "Pendiente");
            ViewBag.SolicitudesAprobadas = db.Solicitudes.Count(s => s.Estado == "Aprobada");
            ViewBag.SolicitudesRechazadas = db.Solicitudes.Count(s => s.Estado == "Rechazada");

            // Mascotas por especie
            ViewBag.TotalPerros = db.Mascotas.Count(m => m.Especie == "Perro");
            ViewBag.TotalGatos = db.Mascotas.Count(m => m.Especie == "Gato");
            ViewBag.TotalOtros = db.Mascotas.Count(m => m.Especie != "Perro" && m.Especie != "Gato");

            // Solicitudes recientes
            var solicitudesRecientes = db.Solicitudes
                .OrderByDescending(s => s.FechaSolicitud)
                .Take(5)
                .Select(s => new
                {
                    s.Id,
                    s.FechaSolicitud,
                    s.Estado,
                    NombreMascota = s.Mascota.Nombre,
                    NombreSolicitante = s.Usuario.NombreCompleto,
                    EmailSolicitante = s.Usuario.Email
                })
                .ToList();

            ViewBag.SolicitudesRecientes = solicitudesRecientes;

            return View();
        }

        // GET: Admin/Solicitudes (Ver todas las solicitudes)
        public ActionResult Solicitudes(string estado)
        {
            var solicitudes = db.Solicitudes.AsQueryable();

            // Filtrar por estado si se especifica
            if (!string.IsNullOrEmpty(estado))
            {
                solicitudes = solicitudes.Where(s => s.Estado == estado);
            }

            ViewBag.EstadoSeleccionado = estado;
            ViewBag.TotalPendientes = db.Solicitudes.Count(s => s.Estado == "Pendiente");
            ViewBag.TotalAprobadas = db.Solicitudes.Count(s => s.Estado == "Aprobada");
            ViewBag.TotalRechazadas = db.Solicitudes.Count(s => s.Estado == "Rechazada");

            return View(solicitudes.OrderByDescending(s => s.FechaSolicitud).ToList());
        }

        // GET: Admin/GestionarSolicitud/5
        public ActionResult GestionarSolicitud(int id)
        {
            var solicitud = db.Solicitudes.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }

            return View(solicitud);
        }

        // POST: Admin/AprobarSolicitud
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AprobarSolicitud(int id)
        {
            var solicitud = db.Solicitudes.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }

            solicitud.Estado = "Aprobada";
            solicitud.FechaRespuesta = DateTime.Now;

            // Cambiar estado de la mascota a "Adoptado"
            var mascota = db.Mascotas.Find(solicitud.IdMascota);
            if (mascota != null)
            {
                mascota.Estado = "Adoptado";
            }

            // Rechazar automáticamente otras solicitudes pendientes de la misma mascota
            var otrasSolicitudes = db.Solicitudes
                .Where(s => s.IdMascota == solicitud.IdMascota && s.Id != solicitud.Id && s.Estado == "Pendiente")
                .ToList();

            foreach (var otra in otrasSolicitudes)
            {
                otra.Estado = "Rechazada";
                otra.MotivoRechazo = "La mascota ya fue adoptada por otro solicitante.";
                otra.FechaRespuesta = DateTime.Now;
            }

            db.SaveChanges();

            TempData["Success"] = "Solicitud aprobada exitosamente.";
            return RedirectToAction("Solicitudes");
        }

        // POST: Admin/RechazarSolicitud
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RechazarSolicitud(int id, string motivoRechazo)
        {
            var solicitud = db.Solicitudes.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }

            solicitud.Estado = "Rechazada";
            solicitud.MotivoRechazo = motivoRechazo;
            solicitud.FechaRespuesta = DateTime.Now;

            // Si no hay más solicitudes pendientes, volver la mascota a "Disponible"
            var otrasPendientes = db.Solicitudes
                .Count(s => s.IdMascota == solicitud.IdMascota && s.Id != solicitud.Id && s.Estado == "Pendiente");

            if (otrasPendientes == 0)
            {
                var mascota = db.Mascotas.Find(solicitud.IdMascota);
                if (mascota != null && mascota.Estado == "En Proceso")
                {
                    mascota.Estado = "Disponible";
                }
            }

            db.SaveChanges();

            TempData["Success"] = "Solicitud rechazada.";
            return RedirectToAction("Solicitudes");
        }

        // GET: Admin/Reportes
        // GET: Admin/Reportes
        public ActionResult Reportes()
        {
            // Mascotas por estado
            ViewBag.Disponibles = db.Mascotas.Count(m => m.Estado == "Disponible");
            ViewBag.EnProceso = db.Mascotas.Count(m => m.Estado == "En Proceso");
            ViewBag.Adoptadas = db.Mascotas.Count(m => m.Estado == "Adoptado");

            // Especies más adoptadas 
            var todasEspecies = db.Mascotas
                .Where(m => m.Estado == "Adoptado")
                .ToList();

            var especiesAgrupadas = todasEspecies
                .GroupBy(m => (m.Especie == "Perro" || m.Especie == "Gato") ? m.Especie : "Otros")
                .Select(g => new { Especie = g.Key, Cantidad = g.Count() })
                .OrderByDescending(x => x.Cantidad)
                .ToList();

            var especiesData = especiesAgrupadas;

            if (especiesData.Any())
            {
                ViewBag.EspeciesLabels = string.Join(",", especiesData.Select(e => "'" + e.Especie + "'"));
                ViewBag.EspeciesDatos = string.Join(",", especiesData.Select(e => e.Cantidad));
            }
            else
            {
                ViewBag.EspeciesLabels = "";
                ViewBag.EspeciesDatos = "";
            }

            // Razas más adoptadas 
            var razasData = db.Mascotas
                .Where(m => m.Estado == "Adoptado" && !string.IsNullOrEmpty(m.Raza))
                .GroupBy(m => m.Raza)
                .Select(g => new { Raza = g.Key, Cantidad = g.Count() })
                .OrderByDescending(x => x.Cantidad)
                .Take(10)
                .ToList();

            if (razasData.Any())
            {
                ViewBag.RazasLabels = string.Join(",", razasData.Select(r => "'" + r.Raza + "'"));
                ViewBag.RazasDatos = string.Join(",", razasData.Select(r => r.Cantidad));
            }
            else
            {
                ViewBag.RazasLabels = "";
                ViewBag.RazasDatos = "";
            }

            // Adopciones por mes
            var fechaInicio = DateTime.Now.AddMonths(-12).Date; // Últimos 12 meses
            var mesesData = db.Solicitudes
                .Where(s => s.Estado == "Aprobada" && s.FechaRespuesta.HasValue)
                .ToList() // Traer a memoria primero
                .Where(s => s.FechaRespuesta.Value >= fechaInicio)
                .GroupBy(s => new { Year = s.FechaRespuesta.Value.Year, Month = s.FechaRespuesta.Value.Month })
                .Select(g => new
                {
                    Mes = GetMonthName(g.Key.Month) + " " + g.Key.Year,
                    Orden = g.Key.Year * 100 + g.Key.Month,
                    Cantidad = g.Count()
                })
                .OrderBy(x => x.Orden)
                .ToList();

            if (mesesData.Any())
            {
                ViewBag.MesesLabels = string.Join(",", mesesData.Select(m => "'" + m.Mes + "'"));
                ViewBag.MesesDatos = string.Join(",", mesesData.Select(m => m.Cantidad));
            }
            else
            {
                ViewBag.MesesLabels = "";
                ViewBag.MesesDatos = "";
            }

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

        // Método auxiliar para obtener nombre del mes
        private string GetMonthName(int month)
        {
            switch (month)
            {
                case 1: return "Ene";
                case 2: return "Feb";
                case 3: return "Mar";
                case 4: return "Abr";
                case 5: return "May";
                case 6: return "Jun";
                case 7: return "Jul";
                case 8: return "Ago";
                case 9: return "Sep";
                case 10: return "Oct";
                case 11: return "Nov";
                case 12: return "Dic";
                default: return month.ToString();
            }
        }
    }




}