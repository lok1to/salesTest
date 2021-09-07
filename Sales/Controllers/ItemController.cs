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
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, ICategoryService categoryService, IMapper mapper)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: Item
        public ActionResult Index()
        {
            return View(_mapper.Map<List<ItemModel>>(_itemService.GetItems()));
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View(_mapper.Map<CategoryModel>(_itemService.Find(id)));
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            PopulateCategoryDropDownList();
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(ItemModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _itemService.Insert(_mapper.Map<Item>(model));
                }
                else
                {
                    ModelState.AddModelError("", "Error Creating item");
                    PopulateCategoryDropDownList(model.CategoryId);
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _mapper.Map<ItemModel>(_itemService.Find(id));
            PopulateCategoryDropDownList(category.CategoryId);
            return View(category);
        }

        // POST: Item/Edit/5
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

        // GET: Item/Delete/5
        public ActionResult Delete(int? id)
        {
            return View();
        }

        // POST: Item/Delete/5
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

        private void PopulateCategoryDropDownList(object selectedCategory = null)
        {
            ViewBag.Category = new SelectList(_mapper.Map<List<CategoryModel>>(_categoryService.GetCategories()), "Id", "Name", selectedCategory);
        }
    }
}