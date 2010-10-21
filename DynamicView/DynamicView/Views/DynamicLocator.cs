namespace DynamicView.Views {
    using System;
    using System.Dynamic;
    using System.Linq;
    using StructureMap;

    public class DynamicLocator : DynamicObject {
        public DynamicLocator(IContainer container) {
            Container = container;
        }

        public IContainer Container { get; private set; }

        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            var contractType = GetContractType(binder.Name);

            if (contractType == null) {
                // Assume that the name of the property is the name
                // of the contract sans "I"
                contractType = GetContractType("I" + binder.Name);

                if (contractType == null) {
                    // If we've made it this far, something is wrong and we should throw an error.
                    throw new InvalidOperationException(string.Format("Service for '{0}' was not registered.", binder.Name));
                }
            }

            // Get the actual instance
            result = Container.GetInstance(contractType);
            return true;
        }

        protected virtual Type GetContractType(string contractName) {
            // Have to go with route since we don't have an
            // Assembly FQN for the Type - perhaps we need to do some type caching 
            // here to get better perf
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .Where(type => type.Name.ToLower().Contains(contractName.ToLower()))
                .FirstOrDefault();
        }
    }
}
