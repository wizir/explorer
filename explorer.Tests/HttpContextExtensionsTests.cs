using System.Collections.Generic;
using System.Linq;
using explorer.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using ServiceProvider = explorer.Extensions.ServiceProvider;


namespace explorer.Tests
{
    [TestFixture]
    public class HttpContextExtensionsTests
    {
        [SetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();
            var mock = new Mock<IStaticAssetsResolver>();

            mock.Setup(m => m.GetScriptUrl(It.IsAny<string>())).Returns<string>(s => $"script:{s}");
            mock.Setup(m => m.GetStylesheetUrl(It.IsAny<string>())).Returns<string>(s => $"stylesheet:{s}");
            services.AddSingleton(provider => mock.Object);
            
            ServiceProvider.Setup(services);
        }
        
        
        [Test]
        public void AddScript_WorksFine()
        {
            var context = new DefaultHttpContext();
            
            context.AddScript("main");
            context.AddScript("secondary");

            int expectedItems = 1;
            int expectedScripts = 2;
            
            Assert.AreEqual(expectedItems, context.Items.Count);
            Assert.IsInstanceOf<HashSet<string>>(context.Items["scripts"]);

            var set = (HashSet<string>)context.Items["scripts"];
            
            Assert.AreEqual(expectedScripts, set.Count);
            Assert.AreEqual("script:main", set.First());
            Assert.AreEqual("script:secondary", set.ToList()[1]);
        }
        
        
        [Test]
        public void AddStylesheet_WorksFine()
        {
            var context = new DefaultHttpContext();
            
            context.AddStylesheet("main");
            context.AddStylesheet("secondary");

            int expectedItems = 1;
            int expectedScripts = 2;
            
            Assert.AreEqual(expectedItems, context.Items.Count);
            Assert.IsInstanceOf<HashSet<string>>(context.Items["stylesheets"]);

            var set = (HashSet<string>)context.Items["stylesheets"];
            
            Assert.AreEqual(expectedScripts, set.Count);
            Assert.AreEqual("stylesheet:main", set.First());
            Assert.AreEqual("stylesheet:secondary", set.ToList()[1]);
        }
        
        
        [Test]
        public void RenderStylesheets_Production()
        {

            var mock = new Mock<IWebHostEnvironment>();
            mock.Setup(m => m.EnvironmentName).Returns("Production");
            ServiceProvider.AddSingleton(provider => mock.Object);

            var context = new DefaultHttpContext();
            context.AddStylesheet("main");

            var rendered = context.RenderStylesheets();

            var expected = new HtmlString("<link rel=\"stylesheet\" href=\"stylesheet:main\"/>\n");
            
            Assert.AreEqual(expected.Value, rendered.Value);
        }
        
        
        [Test]
        public void RenderStylesheets_Development()
        {

            var mock = new Mock<IWebHostEnvironment>();
            mock.Setup(m => m.EnvironmentName).Returns("Development");
            ServiceProvider.AddSingleton(provider => mock.Object);

            var context = new DefaultHttpContext();
            context.AddStylesheet("main");

            var rendered = context.RenderStylesheets();

            var expected = new HtmlString("<script src=\"stylesheet:main\"></script>\n");
            
            Assert.AreEqual(expected.Value, rendered.Value);
        }
        
        
        
        [Test]
        public void RenderScripts_WorksFine()
        {
            var context = new DefaultHttpContext();
            
            context.AddScript("main");

            var rendered = context.RenderScripts();

            var expected = new HtmlString("<script src=\"script:main\"></script>\n");
            
            Assert.AreEqual(expected.Value, rendered.Value);
        }
    }
}