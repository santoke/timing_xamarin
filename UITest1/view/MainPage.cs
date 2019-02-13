using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1.view
{
    [TestFixture(Platform.Android)]
    class MainPage
    {
        IApp app;
        Platform platform;

        public MainPage(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void IsThereLoginButtons()
        {
            //AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            var results = app.Query(c => c.Button());
            Assert.IsTrue(results.Length == 3);
        }

        [Test]
        public void ClickFacebook()
        {

        }
    }
}
