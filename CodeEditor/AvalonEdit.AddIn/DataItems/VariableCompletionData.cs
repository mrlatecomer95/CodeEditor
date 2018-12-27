using AvalonEdit.AddIn.Images;
using ICSharpCode.NRefactory.Completion;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.TypeSystem;
using System;

namespace AvalonEdit.AddIn.DataItems
{
    internal class VariableCompletionData : CompletionData, IVariableCompletionData
    {
        public VariableCompletionData(IVariable variable)
        {
            if (variable == null) throw new ArgumentNullException("variable");
            Variable = variable;

            IAmbience ambience = new CSharpAmbience();
            DisplayText = variable.Name;
            Description = ambience.ConvertVariable(variable);
            CompletionText = Variable.Name;
            this.Image = CompletionImage.Field.BaseImage;
        }

        public IVariable Variable { get; private set; }
    } //end class VariableCompletionData
}