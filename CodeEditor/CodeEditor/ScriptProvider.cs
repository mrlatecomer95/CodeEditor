using AvalonEdit.AddIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEditor
{
    /// <summary>
    /// This is a simple script provider that adds a few using statements to the C# scripts (.csx files)
    /// </summary>
    class ScriptProvider : ICSharpScriptProvider
    {
        public string GetNamespace() => null;

        //public string GetUsing()
        //{
        //    return "" +
        //           "using System; " +
        //           "using System.Collections.Generic; " +
        //           "using System.Linq; " +
        //           "using System.Text; ";
        //}

        public string GetUsing() => null;

        public string GetVars() => null;
    }
}
