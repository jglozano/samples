#region License

//
// Author: Javier Lozano <javier@lozanotek.com>
// Copyright (c) 2009-2010, lozanotek, inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

#endregion

namespace InjectableWebForms.Core {
    using System;
    using System.Linq;
    using Castle.Core;
    using Castle.Windsor;

    public static class IoC {
        public static IWindsorContainer Container { get; private set; }

        public static void Initialize() {
            Container = new WindsorContainer();
        }

        public static void CleanUp() {
            if(Container == null) return;
            Container.Dispose();
        }

        public static void BuildUp<T>(T instance) where T : class {
            if (instance == null) return;

            // Get the type
            Type instanceType = instance.GetType();
            
            // For all public properties, see if you can 'inject' the dependency
            instanceType.GetProperties()
                .Where(property => property.CanWrite && Container.Kernel.HasComponent(property.PropertyType))
                .ForEach(property => property.SetValue(instance, Container.Resolve(property.PropertyType), null));
        }

        public static void TearDown<T>(T instance) where T : class {
            if (instance == null) return;

            Type instanceType = instance.GetType();

            // For all public properties see if you can 'dispose' of any inject properties
            instanceType.GetProperties()
                .Where(property => Container.Kernel.HasComponent(property.PropertyType))
                .ForEach(property => Container.Release(property.GetValue(instance, null)));
        }
    }
}