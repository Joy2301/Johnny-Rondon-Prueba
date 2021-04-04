using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using Tarea9;
using System.Web.UI;
using System.Diagnostics;

namespace Tarea9.Controllers
{
    public class pacientesController : Controller
    {
        private DB_A722D3_vacunadosrdv3Entities db = new DB_A722D3_vacunadosrdv3Entities();

        // GET: pacientes
        public ActionResult Index()
        {
            var pacientes = db.pacientes.Include(p => p.provincias).Include(p => p.TipoSangre);
            return View(pacientes.ToList());
        }

        // GET: pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pacientes pacientes = db.pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        // GET: pacientes/Create
        public ActionResult Create(pacientes pacientes, municipios municipios)
        {
            ViewBag.ProvinciaId = new SelectList(db.provincias, "Id", "Nombre");
            ViewBag.TipoSangreId = new SelectList(db.TipoSangre, "Id", "Nombre");
            pacientes.Correo = "ejemplo@hotmail.com";
            pacientes.FechaNacimiento = DateTime.Now;
            return View(pacientes);
        }

        // POST: pacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cedula,Nombre,Apellido,Telefono,Correo,FechaNacimiento,TipoSangreId,ProvinciaId,Direccion,Le_Dio_Covid,Justificacion,latitud,longitud")] pacientes pacientes)
        {
            //Cuerpo del correo enviado
            string Body = "" +
                "<body>" +
                "<h3>La informacion registrada del paciente es la siguiente:</h3>" +
                "<br>" +
                "<p>" +
                "Cedula: " + pacientes.Cedula +
                "<br>" +
                "Nombre: " + pacientes.Nombre +
                "<br>" +
                "Apellido: " + pacientes.Apellido +
                "<br>" +
                "Telefono: " + pacientes.Telefono +
                "<br>" +
                "Correo " + pacientes.Correo +
                "<br>" +
                "Fecha de Nacimiento: " + pacientes.FechaNacimiento +
                "<br>" +
                "Direccion: " + pacientes.Direccion +
                "<br>" +
                "Le ha dado Covid antes: " + pacientes.Le_Dio_Covid +
                "<br>" +
                "Justifica que deben vacunarlo en casa porque: " + pacientes.Justificacion +
                "<br>" +
                "</p>" +
                "<h4>Estos datos son almacenados unicamente con fines medicos y seran tratados confidencialmente</h4>" +
                "</body>";

            //Desde este correo seran enviados los datos
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("Pruebajoy2301@gmail.com", "Eljhonny");
            smtp.EnableSsl = true;

            //Este esel cuerpo del mensaje
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("Pruebajoy2301@gmail.com", "Vacunados COVID-19");
            mail.To.Add(new MailAddress(pacientes.Correo));
            mail.Subject = "Datos sobre el paciente";
            mail.IsBodyHtml = true;
            mail.Body = Body;

            Debug.WriteLine("Enviaste el correo a" + pacientes.Correo);

            //Lo enviamos
            smtp.Send(mail);

            if (ModelState.IsValid)
            {
                db.pacientes.Add(pacientes);
                db.SaveChanges();
                return RedirectToAction("CreacionExitosa");
            }

            ViewBag.ProvinciaId = new SelectList(db.provincias, "Id", "Nombre", pacientes.ProvinciaId);
            ViewBag.TipoSangreId = new SelectList(db.TipoSangre, "Id", "Nombre", pacientes.TipoSangreId);
            return View(pacientes);
        }

        public ActionResult CreacionExitosa()
        {
            return View();
        }

        // GET: pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pacientes pacientes = db.pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinciaId = new SelectList(db.provincias, "Id", "Nombre", pacientes.ProvinciaId);
            ViewBag.TipoSangreId = new SelectList(db.TipoSangre, "Id", "Nombre", pacientes.TipoSangreId);
            return View(pacientes);
        }

        // POST: pacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cedula,Nombre,Apellido,Telefono,Correo,FechaNacimiento,TipoSangreId,ProvinciaId,Direccion,Le_Dio_Covid,Justificacion,latitud,longitud")] pacientes pacientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinciaId = new SelectList(db.provincias, "Id", "Nombre", pacientes.ProvinciaId);
            ViewBag.TipoSangreId = new SelectList(db.TipoSangre, "Id", "Nombre", pacientes.TipoSangreId);
            return View(pacientes);
        }

        // GET: pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pacientes pacientes = db.pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        // POST: pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pacientes pacientes = db.pacientes.Find(id);
            db.pacientes.Remove(pacientes);
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
