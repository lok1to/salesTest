using AutoMapper;
using Sales.Domain.Entities;
using Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales
{
    public class SalesProfile : Profile
    {
        public SalesProfile()
        {
            CreateMap<Tax, TaxModel>()
                .ReverseMap();
            CreateMap<Category, CategoryModel>()
                .ReverseMap();
            CreateMap<Item, ItemModel>()
 //               .ForMember(x => x.MateriaId, o => o.MapFrom(j => j.Materia.Id))
                .ReverseMap();
            CreateMap<Receipt, ReceiptModel>()
                .ReverseMap();
            CreateMap<ReceiptDetail, ReceiptDetailModel>()
                .ReverseMap();
        }
    }
}