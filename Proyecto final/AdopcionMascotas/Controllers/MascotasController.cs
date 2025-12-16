using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AdopcionMascotas.Data;
using AdopcionMascotas.Models;

namespace AdopcionMascotas.Controllers
{
    public class MascotasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mascotas (Catálogo público)
        // GET: Mascotas (Catálogo público)
        public ActionResult Index(string especie)
        {
            var mascotas = db.Mascotas
                .Include(m => m.Refugio)
                .Where(m => m.Estado == "Disponible");

            // Filtrar por especie
            if (!string.IsNullOrEmpty(especie))
            {
                if (especie == "Otro")
                {
                    // "Otros" incluye todo lo que NO sea Perro o Gato
                    mascotas = mascotas.Where(m => m.Especie != "Perro" && m.Especie != "Gato");
                }
                else
                {
                    // Perro o Gato específicamente
                    mascotas = mascotas.Where(m => m.Especie == especie);
                }
            }

            ViewBag.EspecieSeleccionada = especie;

            return View(mascotas.OrderByDescending(m => m.FechaRegistro).ToList());
        }

        // GET: Mascotas/Details/5
        public ActionResult Details(int? id)
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

            return View(mascota);
        }

        // GET: Mascotas/Create (Solo para Admin)
        public ActionResult Create()
        {
            ViewBag.IdRefugio = new SelectList(db.Refugios, "Id", "Nombre");
            return View();
        }

        // POST: Mascotas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Especie,Raza,Edad,Sexo,Tamanio,Descripcion,FotoUrl,Estado,IdRefugio")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                mascota.FechaRegistro = DateTime.Now;
                mascota.Estado = "Disponible";
                db.Mascotas.Add(mascota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRefugio = new SelectList(db.Refugios, "Id", "Nombre", mascota.IdRefugio);
            return View(mascota);
        }

        // GET: Mascotas/Edit/5 (Solo para Admin)
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdRefugio = new SelectList(db.Refugios, "Id", "Nombre", mascota.IdRefugio);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Especie,Raza,Edad,Sexo,Tamanio,Descripcion,FotoUrl,Estado,IdRefugio,FechaRegistro")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRefugio = new SelectList(db.Refugios, "Id", "Nombre", mascota.IdRefugio);
            return View(mascota);
        }

        // GET: Mascotas/Delete/5 (Solo para Admin)
        public ActionResult Delete(int? id)
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

            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mascota mascota = db.Mascotas.Find(id);
            db.Mascotas.Remove(mascota);
            db.SaveChanges();
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