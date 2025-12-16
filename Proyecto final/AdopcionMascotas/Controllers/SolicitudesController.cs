using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AdopcionMascotas.Data;
using AdopcionMascotas.Models;

namespace AdopcionMascotas.Controllers
{
    public class SolicitudesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Solicitudes/Solicitar/5 (Formulario para solicitar adopción)
        public ActionResult Solicitar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Mascota mascota = db.Mascotas
                .Include(m => m.Refugio)
                .FirstOrDefault(m => m.Id == id);

            if (mascota == null)
            {
                return HttpNotFound();
            }

            if (mascota.Estado != "Disponible")
            {
                TempData["Error"] = "Esta mascota ya no está disponible para adopción.";
                return RedirectToAction("Details", "Mascotas", new { id = mascota.Id });
            }

            ViewBag.Mascota = mascota;
            return View();
        }

        // POST: Solicitudes/Solicitar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Solicitar(int idMascota, string nombreCompleto, string email, string telefono, string comentarios)
        {
            // Validaciones básicas
            if (string.IsNullOrEmpty(nombreCompleto) || string.IsNullOrEmpty(email))
            {
                TempData["Error"] = "Por favor complete todos los campos obligatorios.";
                return RedirectToAction("Solicitar", new { id = idMascota });
            }

            // Buscar o crear usuario
            var usuario = db.Usuarios.FirstOrDefault(u => u.Email == email);
            if (usuario == null)
            {
                // Crear nuevo usuario
                usuario = new Usuario
                {
                    NombreCompleto = nombreCompleto,
                    Email = email,
                    Telefono = telefono,
                    Password = "temporal123", // Password temporal
                    Rol = "Usuario",
                    FechaRegistro = DateTime.Now
                };
                db.Usuarios.Add(usuario);
                db.SaveChanges();
            }

            // Verificar si ya existe una solicitud pendiente para esta mascota y usuario
            var solicitudExistente = db.Solicitudes
                .Any(s => s.IdMascota == idMascota && s.IdUsuario == usuario.Id && s.Estado == "Pendiente");

            if (solicitudExistente)
            {
                TempData["Error"] = "Ya tienes una solicitud pendiente para esta mascota.";
                return RedirectToAction("Details", "Mascotas", new { id = idMascota });
            }

            // Crear la solicitud
            var solicitud = new Solicitud
            {
                IdMascota = idMascota,
                IdUsuario = usuario.Id,
                FechaSolicitud = DateTime.Now,
                Estado = "Pendiente",
                Comentarios = comentarios
            };

            db.Solicitudes.Add(solicitud);

            // Cambiar estado de la mascota a "En Proceso"
            var mascota = db.Mascotas.Find(idMascota);
            if (mascota != null)
            {
                mascota.Estado = "En Proceso";
            }

            db.SaveChanges();

            TempData["Success"] = "¡Tu solicitud ha sido enviada exitosamente! Nos pondremos en contacto contigo pronto.";
            return RedirectToAction("Confirmacion", new { id = solicitud.Id });
        }

        // GET: Solicitudes/Confirmacion/5
        public ActionResult Confirmacion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Solicitud solicitud = db.Solicitudes
                .Include(s => s.Mascota)
                .Include(s => s.Usuario)
                .FirstOrDefault(s => s.Id == id);

            if (solicitud == null)
            {
                return HttpNotFound();
            }

            return View(solicitud);
        }

        // GET: Solicitudes/MisSolicitudes (Ver solicitudes por email)
        public ActionResult MisSolicitudes(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return View("BuscarSolicitudes");
            }

            var usuario = db.Usuarios.FirstOrDefault(u => u.Email == email);
            if (usuario == null)
            {
                TempData["Error"] = "No se encontraron solicitudes con ese correo electrónico.";
                return View("BuscarSolicitudes");
            }

            var solicitudes = db.Solicitudes
                .Include(s => s.Mascota)
                .Where(s => s.IdUsuario == usuario.Id)
                .OrderByDescending(s => s.FechaSolicitud)
                .ToList();

            ViewBag.Email = email;
            ViewBag.NombreUsuario = usuario.NombreCompleto;

            return View(solicitudes);
        }

        // GET: Solicitudes (Lista de todas las solicitudes - Admin)
        public ActionResult Index()
        {
            var solicitudes = db.Solicitudes
                .Include(s => s.Mascota)
                .Include(s => s.Usuario)
                .OrderByDescending(s => s.FechaSolicitud)
                .ToList();

            return View(solicitudes);
        }

        // GET: Solicitudes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Solicitud solicitud = db.Solicitudes
                .Include(s => s.Mascota)
                .Include(s => s.Mascota.Refugio)
                .Include(s => s.Usuario)
                .FirstOrDefault(s => s.Id == id);

            if (solicitud == null)
            {
                return HttpNotFound();
            }

            return View(solicitud);
        }

        // POST: Solicitudes/Aprobar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Aprobar(int id)
        {
            Solicitud solicitud = db.Solicitudes.Find(id);
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
            return RedirectToAction("Index");
        }

        // POST: Solicitudes/Rechazar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rechazar(int id, string motivoRechazo)
        {
            Solicitud solicitud = db.Solicitudes.Find(id);
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
            return RedirectToAction("Index");
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