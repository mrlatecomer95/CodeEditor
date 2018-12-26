using CodeCompletion;
using ICSharpCode.AvalonEdit.Highlighting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            InitializeComponent();
        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            completion = new CSharpCompletion(new ScriptProvider());


            //var editor = new CodeTextEditor();
            //editor.FontFamily = new FontFamily("Consolas");
            //editor.FontSize = 12;
            //editor.Completion = completion;
            ////editor.OpenFile(fileName);
            //editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");

            //var tabItem = new TabItem();
            //tabItem.Content = editor;
            ////tabItem.Header = System.IO.Path.GetFileName(fileName);
            //tabControl.Items.Add(tabItem);
            var path = Environment.CurrentDirectory;
            //OpenFile(@"..\..\..\SampleFiles\Sample1.cs");
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
