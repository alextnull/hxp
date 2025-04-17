using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace HandlebarsXamlPreprocessor
{
    /// <summary>
    /// The actual XAML preprocessor
    /// </summary>
    public class XamlPreprocessor
    {
        private string[] definedSymbols;

        /// <summary>
        /// Initializes a new instance of the <see cref="XamlPreprocessor"/> class.
        /// </summary>
        /// <param name="definedSymbols">The defined symbols.</param>
        public XamlPreprocessor(string definedSymbols)
        {
            this.definedSymbols = (definedSymbols ?? string.Empty)
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToArray();
        }

        /// <summary>
        /// Processes the specified source XAML file and writes the results to specified target path.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="targetPath">The target path.</param>
        /// <returns>A value indicating whether the target XAML file has been written. If no changes are made to the XAML, the targetPath is not written and false is returned.</returns>
        public bool ProcessXamlFile(string sourcePath, string targetPath)
        {
            var xamlDoc = File.ReadAllText(sourcePath);
            var result = ProcessXaml(xamlDoc);
            if (result != null) {
                // ensure target directory exists
                var targetDirectory = Path.GetDirectoryName(targetPath);
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }
                File.WriteAllText(targetPath, result);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Processes the specified source XAML and returns the result.
        /// </summary>
        /// <param name="xaml">The xaml.</param>
        /// <returns></returns>
        public string ProcessXaml(string xaml)
        {
            var template = Handlebars.Compile(xaml);
            IDictionary<string, object> data = new ExpandoObject();
            foreach (var constant in definedSymbols)
            {
                data.Add(constant, constant);
            }
            var render = template(data);
            return render;
        }
    }
}
