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
    using System.Web;
    using System.Web.Compilation;
    using System.Web.UI;
    using Castle.Core;
    using Castle.Windsor;

    public class InjectableHandlerFactory : IHttpHandlerFactory {
        #region IHttpHandlerFactory Members

        public virtual IHttpHandler GetHandler(HttpContext context, string requestType, string virtualPath, string path) {
            var page = BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof (Page)) as IHttpHandler;

            return page == null ? null : ResolveInjectableProperties(page, IoC.WindsorContainer);
        }

        public void ReleaseHandler(IHttpHandler handler) {
            ReleaseInjectedProperties(handler, IoC.WindsorContainer);
        }

        #endregion

        public virtual IHttpHandler ResolveInjectableProperties(IHttpHandler instance, IWindsorContainer container) {
            if (instance == null) {
                return null;
            }

            Type instanceType = instance.GetType();
            instanceType.GetProperties()
                .Where(property => property.CanWrite && container.Kernel.HasComponent(property.PropertyType))
                .ForEach(property => property.SetValue(instance, container.Resolve(property.PropertyType), null));

            return instance;
        }

        public virtual void ReleaseInjectedProperties(IHttpHandler instance, IWindsorContainer container) {
            if (instance == null) {
                return;
            }

            Type instanceType = instance.GetType();

            instanceType.GetProperties()
                .Where(property => container.Kernel.HasComponent(property.PropertyType))
                .ForEach(property => container.Release(property.GetValue(instance, null)));
        }
    }
}