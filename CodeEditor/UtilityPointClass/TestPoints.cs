

using System.Collections.Generic;

namespace UtilityPointClass
{
    public static class TestPoints
    {
        public static List<IPointClass> GetPointList()
        {
            List<IPointClass> pList = new List<IPointClass>();

            //pList.Add(new PointClass() { Name = "Point1", DataType = "Float", Location = ".LOCAL" });
            //pList.Add(new PointClass() { Name = "Point2", DataType = "Float", Location = ".LOCAL" });
            //pList.Add(new PointClass() { Name = "Point3", DataType = "Float", Location = ".LOCAL" });
            //pList.Add(new PointClass() { Name = "Point4", DataType = "Float", Location = ".LOCAL" });
            //pList.Add(new PointClass() { Name = "Point5", DataType = "Float", Location = ".LOCAL" });

            return pList;

        }

        public static void TestCreate(PointClass Points)
        {
        }
    }
}
