using AutoMapper;
using Sales.Domain.Entities;
using Sales.Models;
using Sales.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sales.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View(_mapper.Map<List<CategoryModel>>(_categoryService.GetCategories()));
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View(_mapper.Map<CategoryModel>(_categoryService.Find(id)));
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryService.Insert(_mapper.Map<Category>(model));
                }
                else
                {
                    ModelState.AddModelError("", "Error Creating category");
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_mapper.Map<CategoryModel>(_categoryService.Find(id)));
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}