using Ninject.Modules;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Item>>().To<Repository<Item>>();
            Bind<IRepository<Category>>().To<Repository<Category>>();
            Bind<IRepository<Receipt>>().To<Repository<Receipt>>();
            Bind<IRepository<Tax>>().To<Repository<Tax>>();
        }
    }
}
