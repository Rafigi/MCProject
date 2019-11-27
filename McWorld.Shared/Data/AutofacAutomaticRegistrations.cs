namespace McWorld.Shared.Data
{
    using Autofac;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    public class AutofacAutomaticRegistrations : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = AssemblyLoader.GetLoadedSimuAssemblies().ToArray();

            // Register all types implementing interfaces as their interface type(s)
            builder
              .RegisterAssemblyTypes(assemblies)
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();
        }
    }
}
