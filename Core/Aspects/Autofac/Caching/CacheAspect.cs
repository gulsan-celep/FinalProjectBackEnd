using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            // namespace'i al demek ReflectedType. Burada key oluşturmaya çalışıyorum. Örn: Core.Aspects.Autofac.Caching.CacheAspect.Intercept
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            // parametreleri al liste yap
            var arguments = invocation.Arguments.ToList();
            // key oluşturduk
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            // Bu key bellekte yani cache de var mı kontrol et
            if (_cacheManager.IsAdd(key))
            {
                //Kendin manuel bir return oluştur demek. invocation.ReturnValue. 
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed(); // Methodu çalıştır.
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
