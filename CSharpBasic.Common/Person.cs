namespace CSharpBasic.Common;

public class Person : Human // No hace falta ponerlo explicitamente
{
    private string name;

    public Person(string birthPlace, string name)
    {         
        BirthPlace = birthPlace ?? throw new ArgumentNullException(nameof(birthPlace));

        this.name = name;
    }    

    public string Name 
    { 
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public override int GetAge()
    {
        return Age;
    }

    public int GetAge(int age)
    {
        return Age;
    }

    public new string GetName()
    {        
        return Name;
    }

    public new int Age { get; set; }

    public string BirthPlace { get; private set; }

    public override string ToString()
    {
        return $"{name}: {Age} -> {BirthPlace}";
    }
}
