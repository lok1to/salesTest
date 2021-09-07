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
    public class TaxController : Controller
    {
        private readonly ITaxService _taxService;
        private readonly IMapper _mapper;

        public TaxController(ITaxService taxService, IMapper mapper)
        {
            _taxService = taxService;
            _mapper = mapper;
        }

        // GET: Tax
        public ActionResult Index()
        {
            return View(_mapper.Map<List<TaxModel>>(_taxService.GetTaxes()));
        }

        // GET: Tax/Details/5
        public ActionResult Details(int id)
        {
            return View(_mapper.Map<TaxModel>(_taxService.Find(id)));
        }

        // GET: Tax/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tax/Create
        [HttpPost]
        public ActionResult Create(TaxModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _taxService.Insert(_mapper.Map<Tax>(model));
                }
                else
                {
                    ModelState.AddModelError("", "Error Creating tax");
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tax/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_mapper.Map<TaxModel>(_taxService.Find(id)));
        }

        // POST: Tax/Edit/5
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

        // GET: Tax/Delete/5
        public ActionResult Delete(int? id)
        {
            return View();
        }

        // POST: Tax/Delete/5
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