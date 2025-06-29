using System;
using System.IO;

Console.WriteLine("Ingrese el directorio a analizar: ");
string? path = Console.ReadLine();

while(!Directory.Exists(path))
{
    Console.WriteLine("El directorio NO existe");
    Console.WriteLine("Ingrese un directorio valido: ");
    path = Console.ReadLine();
}

