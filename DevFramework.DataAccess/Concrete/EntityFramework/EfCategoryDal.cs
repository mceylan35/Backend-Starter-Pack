using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.DataAccess.Abstract;
using DevFramework.Entities.Concrete;

namespace DevFramework.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
      
    }
}
