using sistemadepedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistemadepedidos.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            try
            {
                using (var db = new sistemapedidosEntities1())
                {
                    return View(db.pedidos.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new sistemapedidosEntities1())
            {
                pedidos fo = db.pedidos.Find(id);
                return View(fo);
            }
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(pedidos a)
        {
            if (!ModelState.IsValid) { return View(); }
            try
            {
                using (var db = new sistemapedidosEntities1())
                {
                    double valorProduto = ObterValorProduto(Convert.ToInt32(a.id_produto));

                    a.valortotal =Convert.ToDouble(a.quantidade)* valorProduto;
                    a.data = DateTime.Now;
                    db.pedidos.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error ao adicionar o fornecedor", ex);
                return View();
            }
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {

                using (var db = new sistemapedidosEntities1())
                {
                    pedidos fo = db.pedidos.Find(id);
                    return View(fo);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(pedidos a)
        {
            try
            {  //para validar que los campos esten llenos
                if (!ModelState.IsValid) { return View(); }
                using (var db = new sistemapedidosEntities1())
                {
                    pedidos f = db.pedidos.Find(a.id);
                    f.id_produto = a.id_produto;
                    f.quantidade = a.quantidade;
                    f.id_fornecedor = a.id_fornecedor;

                    f.valortotal = Convert.ToDouble(a.quantidade) * ObterValorProduto(Convert.ToInt32(a.id_produto));

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new sistemapedidosEntities1())
            {
                pedidos fo = db.pedidos.Find(id);
                db.pedidos.Remove(fo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

       
        public ActionResult ListaFornecedor()
        {
            using (var db = new sistemapedidosEntities1())
            {
                return PartialView(db.fornecedor.ToList());
            }
        }
        public ActionResult ListaProducto()
        {
            using (var db = new sistemapedidosEntities1())
            {
                return PartialView(db.produto.ToList());
            }
        }
        public static string ObterNomeFornecedor(int id_fornecedor)
        {
            using (var db = new sistemapedidosEntities1())
            {
                return db.fornecedor.Find(id_fornecedor).nome;
            }
        }
        public static string ObterNomeProduto(int id_produto)
        {
            using (var db = new sistemapedidosEntities1())
            {
                return db.produto.Find(id_produto).descripcion;
            }
        }
        public Double ObterValorProduto(int id_produto)
        {
            using (var db = new sistemapedidosEntities1())
            {
                return Convert.ToDouble(db.produto.Find(id_produto).valor);
            }
        }
    }
}
