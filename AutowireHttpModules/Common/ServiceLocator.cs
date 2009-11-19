namespace Common
{
    using System;
    using System.Collections.Generic;
    using Castle.Core;
    using Castle.Windsor;
    using Castle.Windsor.Configuration.Interpreters;

    [Serializable]
    public class ServiceLocator : IServiceLocator
    {
        private static readonly object _lockDummy = new object();
        private static IWindsorContainer _container;
        private static bool _initiliazed;
        private readonly IComponentFileProvider componentFileProvider;

        public ServiceLocator() : this(null)
        {
        }

        public ServiceLocator(IComponentFileProvider fileProvider)
        {
            componentFileProvider = fileProvider;

            Instance = this;
        }

        public static IServiceLocator Instance { get; set; }

        #region IServiceLocator Members

        public void InitializeWith(IWindsorContainer container)
        {
            _container = container;
            _initiliazed = true;
        }

        public virtual T Resolve<T>()
        {
            EnsureInitialized();
            return !_container.Kernel.HasComponent(typeof(T)) ?
                default(T) : _container.Resolve<T>();
        }

        public T Resolve<T>(string key)
        {
            EnsureInitialized();
            return !_container.Kernel.HasComponent(key) ?
                default(T) : _container.Resolve<T>(key);
        }

        public List<T> ResolveServices<T>()
        {
            EnsureInitialized();

            var services = _container.Kernel.ResolveAll<T>();
            return new List<T>(services);
        }

        public void Unregister<Interface>()
        {
            var serviceType = typeof(Interface);
            Unregister<Interface>(serviceType.FullName);
        }

        public void Unregister<Interface>(string key)
        {
            if (!_container.Kernel.HasComponent(key)) return;
            _container.Kernel.RemoveComponent(key);
        }

        public void Register<Interface, Implementation>()
        {
            string registerKey = string.Format("{0}-{1}",
                                               typeof(Interface).Name,
                                               typeof(Implementation).FullName);

            Register<Interface, Implementation>(registerKey);
        }

        public void Register<Interface>(Type implType)
        {
            EnsureInitialized();

            var key = string.Format("{0}-{1}", typeof(Interface).Name, implType.FullName);
            var isRegistered = _container.Kernel.HasComponent(key);
            if (isRegistered) return;

            _container.AddComponentLifeStyle(key, 
                typeof (Interface), 
                implType, 
                LifestyleType.Transient);
        }

        public void Register<Interface, Implementation>(string key)
        {
            EnsureInitialized();

            var isRegistered = _container.Kernel.HasComponent(key);
            if (isRegistered) return;

            RegisterWithLifestyle<Interface, Implementation>(key, LifestyleType.Transient);
        }

        private static void RegisterWithLifestyle<Interface, Implementation>(string key, LifestyleType lifestyleType)
        {
            var serviceType = typeof(Interface);
            var implType = typeof(Implementation);

            _container.AddComponentLifeStyle(key, serviceType, implType, lifestyleType);
        }

        public void Register(string key, Type type, LifestyleType lifestyleType)
        {
            EnsureInitialized();

            var isRegistered = _container.Kernel.HasComponent(key);
            if (isRegistered) return;

            _container.AddComponentLifeStyle(key, type, lifestyleType);
        }

        public void RegisterSingleton<Interface, Implementation>()
        {
            EnsureInitialized();

            var key = string.Format("singleton-{0}-{1}",
                                       typeof(Interface).Name,
                                       typeof(Implementation).FullName);

            var isRegistered = _container.Kernel.HasComponent(key);
            if (isRegistered) return;

            RegisterWithLifestyle<Interface, Implementation>(key, LifestyleType.Singleton);
        }

        public void Release(object instance)
        {
            _container.Release(instance);
        }

        public IWindsorContainer GetContainer()
        {
            EnsureInitialized();
            return _container;
        }

        public void Reset()
        {
            if (_container == null) return;

            _container.Dispose();
            _container = null;
        }

        public void Dispose()
        {
            Reset();
        }

        #endregion

        private void EnsureInitialized()
        {
            if (_initiliazed) return;

            lock (_lockDummy)
            {
                if (_initiliazed) return;

                IWindsorContainer container;
                if (componentFileProvider != null)
                {
                    string configPath = componentFileProvider.GetComponentFilePath();
                    var configInterpreter = new XmlInterpreter(configPath);
                    container = new WindsorContainer(configInterpreter);
                }
                else
                {
                    container = new WindsorContainer();
                }

                InitializeWith(container);
                _initiliazed = true;
            }
        }
    }
}