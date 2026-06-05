using System;

class Program
{
    static void Main()
    {
        string nombre = "Naomy";
        string apellido = "Gonzalez Lopez";
        int edad = 20;
        double altura = 1.70;

        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Apellido: " + apellido);
        Console.WriteLine("Edad: " + edad);
        Console.WriteLine("Altura: " + altura + " m");

        Console.WriteLine($"\nHola, mi nombre es {nombre} {apellido}, tengo {edad} años y mido {altura} metros.");
    }
}
