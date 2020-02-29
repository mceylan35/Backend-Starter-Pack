using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Business.Abstract;
using DevFramework.Business.Concrete;
using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.DataAccess.Abstract;
using DevFramework.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace DevFramework.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope(); //singleton
            Bind<IProductDal>().To<EfProductDal>();
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            //Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
