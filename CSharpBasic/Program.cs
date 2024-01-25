

internal class Program
{
    private static void Main(string[] args)
    {
        // Comentario de una sola línea

        /*
        Permite escribir en varias lineas
        Linea 2
        ....
        Linea N
        */

        // <Tipo> nombreDeLaVariable [= <valor inicial>];
        int edad = 25;

        // edad = edad + 3;

        edad += 3;

        // Preferible para inicilizar strings que no sabemos el valor
        var nombre = string.Empty;

        // No utilizar!
        string noRecomendado = null;

        // var nombre = valorInicial;
        var nombreEdad = nombre.Equals("");

        bool mayorEdad = edad > 18;

        float floatNumber = 4.5f;
        double doubleNumber = 4.5d;       


        var persona = new { Nombre = "Juan", Edad = 25};

        //Console.WriteLine(nombreEdad);


        Console.WriteLine($"Hello, {persona}");


        var person = new Person("Madrid", "Juan"){ Age = 3 };

        System.Console.WriteLine(person);

        Person personEmployee = new Employee("Madrid", "Juan", "Microsoft");

        System.Console.WriteLine(personEmployee);


        IEmployee ipersonEmployee = new Employee("Madrid", "Pepe", "Microsoft");

        System.Console.WriteLine(ipersonEmployee.GetPayroll());

    }


}

// SOLID
// Single Responsibility
// Open/Close
// Liskov Substitution
// Inversion of control
// Dependency Injection

public class Person : Object // No hace falta ponerlo explicitamente
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

    public int Age { get; set; }

    public string BirthPlace { get; private set; }

    public override string ToString()
    {
        return $"{name}: {Age} -> {BirthPlace}";
    }
}

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

public interface IEmployee
{
    double GetPayroll();
}