using SalonDeBelleza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalondeBelleza.WebAdmin.Controllers 
{
    public class CategoriasController : Controller
    {
        CategoriaBL _categoriasBL;
        // GET: Categorias
        public CategoriasController()
        {
            _categoriasBL = new CategoriaBL();
        }

        public ActionResult Index()
        {

            var ListadeCategorias = _categoriasBL.ObtenerCategorias();

            return View(ListadeCategorias);
        }

        public ActionResult Crear()
        {
            var nuevaCategoria = new Categoria();

            return View(nuevaCategoria);
        }

        [HttpPost]
        public ActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripcion no debe contener espacios al inicio");
                    return View(categoria);
                }
                
                _categoriasBL.GuardarCategorias(categoria);

                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Editar(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {

            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripcion no debe contener espacios al inicio");
                    return View(categoria);
                }

                _categoriasBL.GuardarCategorias(categoria);

                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Detalle(int id)
        {

            var categoria = _categoriasBL.ObtenerCategoria(id);

            return View(categoria);
        }

        public ActionResult Eliminar(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Eliminar(Categoria categoria)
        {

            _categoriasBL.EliminarCategoria(categoria.Id);

            return RedirectToAction("Index");
        }
    }
}