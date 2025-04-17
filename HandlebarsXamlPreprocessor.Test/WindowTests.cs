using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HandlebarsXamlPreprocessor.Test
{
    [TestClass]
    public class WindowTests : XamlTestsBase
    {
        [TestMethod]
        public void TestWpfMainWindowDebug()
        {
            TestXaml("DEBUG_FEATURE", "MainWindow.Wpf.xaml", "MainWindow.Wpf.Debug.Expected.xaml");
        }

        [TestMethod]
        public void TestWpfMainWindowRelease()
        {
            TestXaml("RELEASE_FEATURE", "MainWindow.Wpf.xaml", "MainWindow.Wpf.Release.Expected.xaml");
        }

        [TestMethod]
        public void TestAvaloniaMainWindowDebug()
        {
            TestXaml("DEBUG_FEATURE", "MainWindow.Avalonia.axaml", "MainWindow.Avalonia.Debug.Expected.axaml");
        }

        [TestMethod]
        public void TestAvaloniaMainWindowRelease()
        {
            TestXaml("RELEASE_FEATURE", "MainWindow.Avalonia.axaml", "MainWindow.Avalonia.Release.Expected.axaml");
        }
    }
}
