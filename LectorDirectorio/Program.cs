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

string[] directorios = Directory.GetDirectories(path);
Console.WriteLine("\nCarpetas Encontradas: ");

foreach(string carpeta in directorios)
{
    DirectoryInfo info = new DirectoryInfo(carpeta);
    Console.WriteLine($"- {info.Name}");
}
