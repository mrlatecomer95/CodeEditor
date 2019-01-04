using System;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using System.Collections.Generic;
using System.Linq;
using AvalonEdit.AddIn.Util;

namespace AvalonEdit.AddIn.DataItems
{
    class MyCompletionData : CompletionData
    {
        public MyCompletionData()
        {

        }
        public MyCompletionData(string text)
        {
            DisplayText = CompletionText = Description = text;
        }
        public string PreFix { get; set; }

        public override void Complete(TextArea textArea, ISegment completionSegment, EventArgs insertionRequestEventArgs)
        {
            var _list = new List<ClassList.DataStructure>();
            switch (PreFix)
            {
                case Constants.PointCaller:
                    _list = ClassList.GetPointList() as List<ClassList.DataStructure>;
                    break;
                case Constants.ModelCaller:
                    _list = ClassList.GetModelList() as List<ClassList.DataStructure>;
                    break;
                default:
                    break;
            }
            textArea.Document.Replace(completionSegment, "\"" + _list.FirstOrDefault(w => w.Key == this.CompletionText).Value + "\"");
        }

    }

}
