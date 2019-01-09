using System;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using System.Collections.Generic;
using System.Linq;
using AvalonEdit.AddIn.Util;

namespace AvalonEdit.AddIn.DataItems
{
    class PointModelCompletionData : CompletionData
    {
        public PointModelCompletionData()
        {

        }
        public PointModelCompletionData(string text)
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

            var outstr = "\"" + _list.FirstOrDefault(w => w.Key == this.CompletionText).Value + "\"" ;

            var offset = completionSegment.Offset  - PreFix.Length - 1;
            var length = completionSegment.Length + PreFix.Length + 1;
            textArea.Document.Replace(offset, length, outstr );

            //textArea.Document.Replace(completionSegment, "\"" + outstr + "\"");
        }

    }

}
