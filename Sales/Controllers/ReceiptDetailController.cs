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
    public class ReceiptDetailController : Controller
    {
        private readonly IMapper _mapper;

        public ReceiptDetailController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ActionResult ReceiptDetails(int? i)
        {
            ViewBag.i = i;
            return PartialView();
        }
    }
}