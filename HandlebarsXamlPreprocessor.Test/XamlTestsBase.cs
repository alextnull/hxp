using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.IO;

namespace HandlebarsXamlPreprocessor.Test
{
    public abstract class XamlTestsBase
    {
        protected void TestXaml(string symbols, string xamlName, string expectedXamlName)
        {
            var preprocessor = new XamlPreprocessor(symbols);
            var xaml = LoadXamlPage(xamlName);
            var expected = LoadXamlPage(expectedXamlName);
            var result = preprocessor.ProcessXaml(xaml);

            // perform char-by-char comparison, raise error with index info if mismatch
            var lineNumber = 1;
            for (var i = 0; i < expected.Length && i < result.Length; i++)
            {
                if (expected[i] != result[i])
                {
                    Assert.Fail("Character mismatch at index {0} (line number: {1}. Expected: {2} ({3}), actual: {4} ({5})", i, lineNumber, result[i], (int)result[i], expected[i], (int)expected[i]);
                }
                if (result[i] == '\n')
                {
                    lineNumber++;
                }
            }

            // still fail if one string is substring of the other 
            Assert.AreEqual(expected, result);
        }

        protected string LoadXamlPage(string pageName)
        {
            var fullName = string.Format(CultureInfo.InvariantCulture, "HandlebarsXamlPreprocessor.Test.Xaml.{0}", pageName);

            using (var stream = typeof(XamlTestsBase).Assembly.GetManifestResourceStream(fullName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
