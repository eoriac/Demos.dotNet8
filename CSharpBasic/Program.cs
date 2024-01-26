

using System.Collections.Generic;
using System.IO;

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


        //IEmployee ipersonEmployee = new Employee("Madrid", "Pepe", "Microsoft");

        IEmployee ipersonEmployee = new DummyClass();

        System.Console.WriteLine(ipersonEmployee.GetPayroll());

        var genericObject = new GenericSample<Employee>();

        var values = new List<Person>();

        var length = values.Count;

        for (int i = 0; i < length; i++)
        {
            System.Console.WriteLine(values[i].Name);
        }

        // Tamaño predefinido
        int[] ints = new int[5];

        //
        int[] ints2 = new int[] {4, 5, 6};

        var values2 = (ICollection<Person>) values;        
        
        foreach (var item in values2)
        {
            System.Console.WriteLine(item);
        }

        if (values is IEmployee)
        {
            System.Console.WriteLine("values is IEmployee");
        }

        var operatorAs = values as IEmployee;

        System.Console.WriteLine(" sdfsdf ");
        System.Console.WriteLine(operatorAs?.GetPayroll());
        System.Console.WriteLine(" sdfsdfsdf");

        int age1 = 2;

        _ = int.TryParse("34", out age1);

        System.Console.WriteLine(age1);

        _ = double.TryParse("36,4", out double age2);

        System.Console.WriteLine(age2);


        var fecha = DateTime.Now;

        System.Console.WriteLine(fecha);

        var _24FromNow = fecha.AddHours(24);

        System.Console.WriteLine(_24FromNow);

        System.Console.WriteLine(_24FromNow.ToString("yyyy/M/d H:m"));
         
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

class DummyClass : IEmployee
{
    public double GetPayroll()
    {
        return 0;
    }
}

public class GenericSample<T> where T : Person, IEmployee
{
    public T GetReturnObjectT { get; set; }

    public string GetAverage(T objectToCalculate){
        var result = $"{objectToCalculate.GetPayroll()} {objectToCalculate.Age}";
        return result;
    }
}

public interface IEmployee
{
    double GetPayroll();
}