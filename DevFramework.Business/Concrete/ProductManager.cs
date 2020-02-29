using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Business.Abstract;
using DevFramework.Business.ValidationRules.FluentValidation;
using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Core.DataAccess;
using DevFramework.DataAccess.Abstract;
using DevFramework.Entities.Concrete;

namespace DevFramework.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private readonly IQueryableRepository<Product> _queryable;

        public ProductManager(IProductDal productDal, IQueryableRepository<Product> queryable)
        {
            _productDal = productDal;
            _queryable = queryable;
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            ValidatorTool.FluentValidate(new ProductValidatior(), product);
            return _productDal.Add(product);
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Product> GetAll()
        {
            
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }
        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {

            _productDal.Add(product1);
            _productDal.Update(product2);

        }
        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            ValidatorTool.FluentValidate(new ProductValidatior(), product);
            return _productDal.Update(product);
        }
    }
}
