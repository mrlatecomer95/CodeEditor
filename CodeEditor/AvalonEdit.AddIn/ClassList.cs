using AvalonEdit.AddIn.DataItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonEdit.AddIn
{
    public static class ClassList
    {

        public static IEnumerable<ICSharpCode.NRefactory.Completion.ICompletionData> GetPointCompletion()
        {
            var collection = GetPointList();
            var result = new List<PointModelCompletionData>();

            foreach (var item in collection)
            {
                var data = new PointModelCompletionData(item.Key);
                result.Add(data);
            }

            return result;
        }

        public static IEnumerable<ICSharpCode.NRefactory.Completion.ICompletionData> GetModelCompletion()
        {
            var collection = GetModelList();
            var result = new List<PointModelCompletionData>();

            foreach (var item in collection)
            {
                var data = new PointModelCompletionData(item.Key);
                result.Add(data);
            }
            return result;
        }

        public static ICollection<DataStructure> GetPointList()
        {
            var list = new List<DataStructure>();
            list.Add(new DataStructure() { Key = "Point1", Value = "poiter1.local" });
            list.Add(new DataStructure() { Key = "Point2", Value = "poiter2.local" });
            list.Add(new DataStructure() { Key = "Point3", Value = "poiter3.local" });
            list.Add(new DataStructure() { Key = "Point4", Value = "poiter4.local" });
            list.Add(new DataStructure() { Key = "Point5", Value = "poiter5.local" });
            list.Add(new DataStructure() { Key = "Point6", Value = "poiter6.local" });
            list.Add(new DataStructure() { Key = "Point7", Value = "poiter7.local" });
            return list;
        }
        public static ICollection<DataStructure> GetModelList()
        {
            var list = new List<DataStructure>();
            list.Add(new DataStructure() { Key = "Model1", Value = "model1.local" });
            list.Add(new DataStructure() { Key = "Model2", Value = "model2.local" });
            list.Add(new DataStructure() { Key = "Model3", Value = "model3.local" });
            list.Add(new DataStructure() { Key = "Model4", Value = "model4.local" });
            list.Add(new DataStructure() { Key = "Model5", Value = "model5.local" });
            list.Add(new DataStructure() { Key = "Model6", Value = "model6.local" });
            list.Add(new DataStructure() { Key = "Model7", Value = "model7.local" });
            return list;
        }


        public class DataStructure
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

    }
}
