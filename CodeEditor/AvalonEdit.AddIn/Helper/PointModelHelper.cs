using System.Collections.Generic;

namespace AvalonEdit.AddIn.Helper
{
    public class PointModelHelper
    {
        public IEnumerable<PointModel> List { get; }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }



    }
}
