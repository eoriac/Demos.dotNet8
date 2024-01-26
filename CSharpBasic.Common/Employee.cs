namespace CSharpBasic.Common;

public class Employee : Person, IEmployee
{
    public Employee(string birthPlace, string name) 
        : this(birthPlace, name, string.Empty)
    {    }

    public Employee(string birthPlace, string name, string company)
        : base(birthPlace, name)
    {
        Company = company;
    }

    public string Company { get; set; }

    public double GetPayroll()
    {
        return 100;
    }

    public override string ToString()
    {
        return base.ToString() + $" {Company}";
    }
}
