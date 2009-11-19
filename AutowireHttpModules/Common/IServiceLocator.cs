namespace Common
{
    using System;
    using System.Collections.Generic;
    using Castle.Core;
    using Castle.Windsor;

    public interface IServiceLocator : IDisposable
    {
        void InitializeWith(IWindsorContainer container);
        T Resolve<T>();
        T Resolve<T>(string key);
        List<T> ResolveServices<T>();
        void Unregister<Interface>();
        void Unregister<Interface>(string key);
        void Register<Interface, Implementation>();
        void Register<Interface>(Type implType);
        void Register<Interface, Implementation>(string key);
        void RegisterSingleton<Interface, Implementation>();
        void Register(string key, Type type, LifestyleType lifestyleType);
        void Release(object instance);
        IWindsorContainer GetContainer();
        void Reset();
    }
}