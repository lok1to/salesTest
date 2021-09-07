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
    public class ReceiptController : Controller
    {
        private readonly IReceiptService _receiptService;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ReceiptController(IReceiptService receiptService, IItemService itemService, IMapper mapper)
        {
            _receiptService = receiptService;
            _mapper = mapper;
            _itemService = itemService;
        }

        // GET: Receipt
        public ActionResult Index()
        {
            return View(_mapper.Map<List<ReceiptModel>>(_receiptService.GetReceipts()));
        }

        // GET: Receipt/Details/5
        public ActionResult Details(int id)
        {
            return View(_mapper.Map<ReceiptModel>(_receiptService.Find(id)));
        }

        // GET: Receipt/Create
        public ActionResult Create()
        {
            PopulateItemDropDownList();
            return View();
        }

        // POST: Receipt/Create
        [HttpPost]
        public ActionResult Create(ReceiptModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _receiptService.Insert(Session["ItemIds"] as List<int>);
                    Session["ItemIds"] = null;
                }
                else
                {
                    ModelState.AddModelError("", "Error Creating receipt");
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Receipt/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_mapper.Map<ReceiptModel>(_receiptService.Find(id)));
        }

        // POST: Receipt/Edit/5
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

        // GET: Receipt/Delete/5
        public ActionResult Delete(int? id)
        {
            return View();
        }

        // POST: Receipt/Delete/5
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

        public string ReceiptDetails(int itemId)
        {
            var items = Session["ItemIds"] as List<int>;
            //Create new, if null
            if (items == null)
                items = new List<int>();

            items.Add(itemId);

            Session["ItemIds"] = items;

            return _itemService.Find(itemId).Name;
        }

        private void PopulateItemDropDownList(object selectedItem = null)
        {
            ViewBag.Item = new SelectList(_mapper.Map<List<ItemModel>>(_itemService.GetItems()), "Id", "Name", selectedItem);
        }
    }
}