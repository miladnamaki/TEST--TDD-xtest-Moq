using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcTest.Models;
using MvcTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServies _productServies;

        public ProductController(IProductServies productServies)
        {
            _productServies = productServies;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return  View(_productServies.GetALL());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var prudoct = _productServies.GetById(id);
            if (prudoct==null)
            {
                return NotFound(404);
            }
            return View( _productServies.GetById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (!ModelState.IsValid) 
                {
                    return BadRequest(ModelState);
                }
                _productServies.Add(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(Product model)
        {
            return View(_productServies.GetById(model.Id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product model)
        {
            try
            {
                _productServies.edit(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_productServies.GetById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _productServies.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
