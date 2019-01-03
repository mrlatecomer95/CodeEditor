using System;

namespace UtilityPointClass
{
    public interface IPointClass
    {
        string Location { get; set; }
        string Name { get; set; }
        string Value { get; set; }
        Type DType { get; set; }
    }
}