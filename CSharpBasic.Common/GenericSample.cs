namespace CSharpBasic.Common;

public class GenericSample<T> where T : Person, IEmployee
{
    public T GetReturnObjectT { get; set; }

    public string GetAverage(T objectToCalculate){
        var result = $"{objectToCalculate.GetPayroll()} {objectToCalculate.Age}";
        return result;
    }
}
