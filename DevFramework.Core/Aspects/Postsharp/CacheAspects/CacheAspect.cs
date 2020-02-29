
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCuttingConcerns.Caching;
using FluentValidation.Validators;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cacheType;
        private int _cacheByMinute;
        private ICacheManager _cacheManager;

        public CacheAspect(Type cacheType, int cacheByMinute=60)
        {
            _cacheType = cacheType;
            _cacheByMinute = cacheByMinute;
          
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            //cache manager türünde değil ise 
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType)==false)
            {
                throw new Exception("Wrong Cache Manager");
            }

            _cacheManager = (ICacheManager) Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);

        }
       
    }
}
