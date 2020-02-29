﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspects.Postsharp.ValidationAspects
{
    [Serializable]//Compile Time'da koda dahil olacak. 
    public class FluentValidationAspect:OnMethodBoundaryAspect
    {
        Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }


        //Methoda girdiğinde doğrulama yapmak için OnEntry kullanıyoruz.
        public override void OnEntry(MethodExecutionArgs args)
        {

            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType);//gettype ile parametreleri gez reflection Programing

            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator,entity);
            }


        }
       
    }
}
