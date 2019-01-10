using System.Collections.Generic;

namespace AvalonEdit.AddIn.Util
{
    public static class PrefixCaller
    {
        public static List<string> GetPrefixList {
            get {
                var list = new List<string>();
                list.Add("FIFO");
                list.Add("MIFO");
                return list;
            }
        }
    }
}
