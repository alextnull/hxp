using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HandlebarsXamlPreprocessor.Test
{
    [TestClass]
    public class AppTests : XamlTestsBase
    {
        [TestMethod]
        public void TestWpfAppDebug()
        {
            TestXaml("DEBUG_FEATURE", "App.Wpf.xaml", "App.Wpf.Debug.Expected.xaml");
        }

        [TestMethod]
        public void TestWpfAppRelease()
        {
            TestXaml("RELEASE_FEATURE", "App.Wpf.xaml", "App.Wpf.Release.Expected.xaml");
        }

        [TestMethod]
        public void TestAvaloniaAppDebug()
        {
            TestXaml("DEBUG_FEATURE", "App.Avalonia.axaml", "App.Avalonia.Debug.Expected.axaml");
        }

        [TestMethod]
        public void TestAvaloniaAppRelease()
        {
            TestXaml("RELEASE_FEATURE", "App.Avalonia.axaml", "App.Avalonia.Release.Expected.axaml");
        }
    }
}
