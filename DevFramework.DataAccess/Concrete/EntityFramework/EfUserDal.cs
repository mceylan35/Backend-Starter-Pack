using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.DataAccess.Abstract;
using DevFramework.Entities.ComplexTypes;
using DevFramework.Entities.Concrete;

namespace DevFramework.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<UserRole> GetUserRoles(User user)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = context ;
                return null;
            }
        }
    }
}
