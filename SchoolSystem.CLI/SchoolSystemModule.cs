using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using System.IO;
using System.Reflection;
using Ninject.Extensions.Factory;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;
using SchoolSystem.Framework.Core.Providers;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
            }

            Bind<IParser>().To<CommandParserProvider>().InSingletonScope();
            Bind<IReader>().To<ConsoleReaderProvider>().InSingletonScope();
            Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope();

            Bind<ISchoolFactory>().ToFactory().InSingletonScope();

        }
    }
}