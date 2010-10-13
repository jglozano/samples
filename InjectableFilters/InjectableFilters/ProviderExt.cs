namespace InjectableFilters {
    using System.Linq;
    using System.Web.Mvc;

    public static class ProviderExt {
        public static void Remove<TProvider>(this FilterProviderCollection providers) where TProvider : IFilterProvider {
            var provider = FilterProviders.Providers.Single(f => f is TProvider);
            providers.Remove(provider);
        }
    }
}