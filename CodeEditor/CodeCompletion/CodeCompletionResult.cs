

using ICSharpCode.AvalonEdit.CodeCompletion;
using System.Collections.Generic;

namespace CodeCompletion
{
    public class CodeCompletionResult
    {
        public List<ICompletionData> CompletionData = new List<ICompletionData>();
        public ICompletionData SuggestedCompletionDataItem;
        public int TriggerWordLength;
        public string TriggerWord;

        public IOverloadProvider OverloadProvider;
    }
}
