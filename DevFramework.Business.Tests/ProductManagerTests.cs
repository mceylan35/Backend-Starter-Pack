using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Business.Concrete;
using DevFramework.DataAccess.Abstract;
using DevFramework.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DevFramework.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void ProductValidationCheck()
        {
            Mock<IProductDal> mock=new Mock<IProductDal>();
           // ProductManager productManager=new ProductManager(mock.Object);
        //    productManager.Add(new Product());

        }
    }
}
