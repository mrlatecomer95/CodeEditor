using AvalonEdit.AddIn;
using ICSharpCode.AvalonEdit.Highlighting;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UtilityPointClass;
namespace CodeEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CSharpCompletion completion;
        public MainWindow()
        {
            //Dictionary of Points
            string className = "PIPointers";

            var pointList = new List<PointClass>();
            pointList.Add(new PointClass() { Name = "Point1", Location = ".Local", DType = GetDataType("float"), Value = "1" });
            pointList.Add(new PointClass() { Name = "Point2", Location = ".Local", DType = GetDataType("string"), Value = "2" });
            pointList.Add(new PointClass() { Name = "Point3", Location = ".Local", DType = GetDataType("float"), Value = "3" });
            pointList.Add(new PointClass() { Name = "Point4", Location = ".Local", DType = GetDataType("float"), Value = "4" });
            pointList.Add(new PointClass() { Name = "Point5", Location = ".Local", DType = GetDataType("string"), Value = "5" });
            pointList.Add(new PointClass() { Name = "Point6", Location = ".Local", DType = GetDataType("float"), Value = "6" });

            CodeDomPoints.createType(className, pointList);
            InitializeComponent();
        }

        private Type GetDataType(string TypeName)
        {
            switch (TypeName.ToLower())
            {
                case "string":
                    return typeof(string);
                case "float":
                    return typeof(float);
                default:
                    return typeof(string);
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            completion = new CSharpCompletion(new ScriptProvider());

            

            var path = Environment.CurrentDirectory;

            OpenFile(@"C:\Users\earlsan.villegas\Documents\Github\CodeEditor\SampleFiles\Sample1.cs");
        }

        private void OpenFile(string fileName)
        {
            var editor = new CodeTextEditor();
            editor.FontFamily = new FontFamily("Consolas");
            editor.FontSize = 12;
            editor.Completion = completion;
            editor.OpenFile(fileName);
            editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");

            var tabItem = new TabItem();
            tabItem.Content = editor;
            tabItem.Header = System.IO.Path.GetFileName(fileName);
            tabControl.Items.Add(tabItem);

        }


    }
}
