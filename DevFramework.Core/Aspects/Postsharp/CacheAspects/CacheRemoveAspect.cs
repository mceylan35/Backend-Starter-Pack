using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheRemoveAspect:OnMethodBoundaryAspect
    {
        //tüm cacheleri silme
        //belirli cacheleri sil
        private string _pattern;
        private Type _cacheType;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(Type cacheType)
        {
            _cacheType = cacheType;
        }

        public CacheRemoveAspect(string patern,Type cacheType)
        {
            _pattern = patern;
            _cacheType = cacheType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType)==false)
            {
                throw new Exception("Wrong Cache Manager");
            }

            _cacheManager = (ICacheManager) Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern)
            ?string.Format("{}.{}.",args.Method.ReflectedType.Namespace,args.Method.ReflectedType.Name)
            :_pattern);
        }
    }
}
