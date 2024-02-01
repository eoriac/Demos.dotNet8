

using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

using CSharpBasic.Common;
using System.Runtime.CompilerServices;


namespace CSharpBasic;

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

        var personSerialized = JsonConvert.SerializeObject(person);
        System.Console.WriteLine(personSerialized);


        var jsonObject = JsonConvert.DeserializeObject<Person>("{\"Name\":\"Juan\",\"Age\":3,\"BirthPlace\":\"Madrid\"}");
        System.Console.WriteLine(jsonObject); 

        var command = string.Empty;
        while (string.Compare(command, "quit", StringComparison.InvariantCultureIgnoreCase) != 0)
        {
            System.Console.WriteLine($"Option: {command}");

            command = Console.ReadLine();

            // no se ejecutan siempre
        }

        do
        {
            System.Console.WriteLine("al menos una vez");
        } while (false);

        var ageOverload = person.GetAge(3);


        var stringToAddDollarSign = "Hola";

        System.Console.WriteLine(stringToAddDollarSign.AddDollarSign());
    }
}

