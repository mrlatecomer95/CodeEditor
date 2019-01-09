

using ICSharpCode.AvalonEdit.CodeCompletion;
using System.Collections.Generic;

namespace AvalonEdit.AddIn
{
    public class CodeCompletionResult
    {
        public List<ICompletionData> CompletionData = new List<ICompletionData>();
        //public List<ICSharpCode.NRefactory.Completion.ICompletionData> CompletionData = new List<ICSharpCode.NRefactory.Completion.ICompletionData>();
        public ICompletionData SuggestedCompletionDataItem;
        public int TriggerWordLength;
        public string TriggerWord;

        public IOverloadProvider OverloadProvider;
    }
}
