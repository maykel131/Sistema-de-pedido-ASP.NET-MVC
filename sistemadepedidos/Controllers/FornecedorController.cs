using sistemadepedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace sistemadepedidos.Controllers
{
    public class FornecedorController : Controller
    {
       
        public ActionResult Index()
        {
            try
            {
                using (var db = new sistemapedidosEntities1())
                {
                    return View(db.fornecedor.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult Details(int id)
        {
            using (var db = new sistemapedidosEntities1())
            {
                fornecedor fo = db.fornecedor.Find(id);
                return View(fo);
            }
         
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(fornecedor a)
        {
            if(!ModelState.IsValid){ return View();}

            try
            {
                using(var db = new sistemapedidosEntities1()){

                    db.fornecedor.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }   
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error ao adicionar o fornecedor",ex);
                return View();
            }
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {   

                using (var db = new sistemapedidosEntities1())
                {
                    fornecedor fo = db.fornecedor.Find(id);
                    return View(fo);
                }
            }
            catch (Exception)
            {

                throw;
            }
          
            
        }

        // POST: Fornecedor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(fornecedor a)
        {
            try
            {  //para validar que los campos esten llenos
                if (!ModelState.IsValid) { return View(); }
                using (var db = new sistemapedidosEntities1())
                {
                    fornecedor al = db.fornecedor.Find(a.id);
                    al.id    = a.id;
                    al.nome  = a.nome;
                    al.cnpj  = a.cnpj;
                    al.uf    = a.uf;
                    al.email = a.email;
                    al.razao = a.razao;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new sistemapedidosEntities1())
            {
                fornecedor fo = db.fornecedor.Find(id);
                db.fornecedor.Remove(fo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
        }

        public ActionResult ListaCidades()
        {
                return PartialView();
        }


    }
}
