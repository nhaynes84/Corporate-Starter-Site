using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using XYZCorpTempSite.Interfaces;

namespace XYZCorpTempSite.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .InNamespace("XYZCorpTempSite.Repositories").WithServiceDefaultInterfaces()
                .LifestyleTransient());
        }
    }
}