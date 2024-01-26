namespace CSharpBasic.Common;

// SOLID
// Single Responsibility
// Open/Close
// Liskov Substitution
// Inversion of control
// Dependency Injection


public abstract class Human
{

    private string name;

    protected int Age {get; set;}

    public virtual int GetAge()
    {
        return 0;
    }

    public string GetName()
    {
        return this.name;
    }

    public override string ToString()
    {
        return "I'm Human";
    }
}
