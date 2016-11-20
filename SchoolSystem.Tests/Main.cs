using Moq;
using Ninject;
using NUnit.Framework;
using SchoolSystem.Cli;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;
using SchoolSystem.Framework.Core.Providers;


namespace SchoolSystem.Tests
{
    [TestFixture]
    public class Main
    {
        [Test]
        public void Test()
        {
            //IReader reader = new ConsoleReaderProvider();
            //IWriter writer = new ConsoleWriterProvider();
            //var mockSchoolFactory = new Mock<ISchoolFactory>();
            //IParser parser = new CommandParserProvider(new CommandFactory(), mockSchoolFactory.Object, new Database());
            //IDatabase database = new Database();

            //var engine = new Engine(reader, writer, parser, database);

            IKernel kernel = new StandardKernel(new SchoolSystemModule());

            IEngine engine = kernel.Get<IEngine>();
            engine.Start();


        }
    }
}
