using sistemadepedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistemadepedidos.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            using (var obj=new sistemapedidosEntities1()) {
                return View(obj.produto.ToList());
            }
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new sistemapedidosEntities1())
            {
                produto fo = db.produto.Find(id);
                return View(fo);
            }
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(produto a)
        {
            a.valor = a.valor;
            if (!ModelState.IsValid) { return View(); }
            try
            {
                using (var db = new sistemapedidosEntities1())
                {
                    a.data = DateTime.Now;
                    db.produto.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error ao adicionar o fornecedor", ex);
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {   //para validar que los campos esten llenos
                if (!ModelState.IsValid) { return View(); }

                using (var db = new sistemapedidosEntities1())
                {
                    produto fo = db.produto.Find(id);
                    return View(fo);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(produto a)
        {
            try
            {   //para validar que los campos esten llenos
                if (!ModelState.IsValid) { return View(); }
                using (var db = new sistemapedidosEntities1())
                {
                    produto al = db.produto.Find(a.id);
                    al.id = a.id;
                    al.descripcion = a.descripcion;
                   
                    al.valor = a.valor;

                    db.SaveChanges();

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new sistemapedidosEntities1())
            {
                produto fo = db.produto.Find(id);
                db.produto.Remove(fo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

      
     
    }
}
