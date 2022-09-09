using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaCRUD.ADO;

namespace SistemaCRUD.Controllers
{
    public class ProductoesController : Controller
    {
        private BDCRUDINVENTARIOEntities db = new BDCRUDINVENTARIOEntities();

        // GET: Productoes
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Categoria).Include(p => p.Marca).Include(p => p.Proveedor);
            return View(producto.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.cod_categoria = new SelectList(db.Categoria, "cod_categoria", "nombre_categoria");
            ViewBag.cod_marca = new SelectList(db.Marca, "cod_marca", "nombre_marca");
            ViewBag.cod_proveedor = new SelectList(db.Proveedor, "cod_proveedor", "razon_social");
            return View();
        }

        // POST: Productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_producto,nombre_producto,modelo_producto,cod_marca,cod_proveedor,cod_categoria,cantidad,precio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_categoria = new SelectList(db.Categoria, "cod_categoria", "nombre_categoria", producto.cod_categoria);
            ViewBag.cod_marca = new SelectList(db.Marca, "cod_marca", "nombre_marca", producto.cod_marca);
            ViewBag.cod_proveedor = new SelectList(db.Proveedor, "cod_proveedor", "razon_social", producto.cod_proveedor);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_categoria = new SelectList(db.Categoria, "cod_categoria", "nombre_categoria", producto.cod_categoria);
            ViewBag.cod_marca = new SelectList(db.Marca, "cod_marca", "nombre_marca", producto.cod_marca);
            ViewBag.cod_proveedor = new SelectList(db.Proveedor, "cod_proveedor", "razon_social", producto.cod_proveedor);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_producto,nombre_producto,modelo_producto,cod_marca,cod_proveedor,cod_categoria,cantidad,precio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_categoria = new SelectList(db.Categoria, "cod_categoria", "nombre_categoria", producto.cod_categoria);
            ViewBag.cod_marca = new SelectList(db.Marca, "cod_marca", "nombre_marca", producto.cod_marca);
            ViewBag.cod_proveedor = new SelectList(db.Proveedor, "cod_proveedor", "razon_social", producto.cod_proveedor);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
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
