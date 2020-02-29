using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Entities.Concrete;
using FluentValidation;

namespace DevFramework.Business.ValidationRules.FluentValidation
{
     public class ProductValidatior:AbstractValidator<Product>
    {
        public ProductValidatior()
        {
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.ProductName).Length(2, 40);
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p => p.CategoryId == 1); //Kategori Id'si 1 olan ürünlerin fiyatları 20den büyük olmalı.
            //RuleFor(p => p.ProductName).Must(StartWithA); 
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
