namespace WebApplication3.DependencyResolution {
    using System.Web;

    using WebApplication3.App_Start;

    using StructureMap.Web.Pipeline;

    public class StructureMapScopeModule : IHttpModule {
        public void Dispose() {
        }

        public void Init(HttpApplication context) {
            context.BeginRequest += (sender, e) => StructuremapMvc.StructureMapDependencyScope.CreateNestedContainer();
            context.EndRequest += (sender, e) => {
                HttpContextLifecycle.DisposeAndClearAll();
                StructuremapMvc.StructureMapDependencyScope.DisposeNestedContainer();
            };
        }
    }
}