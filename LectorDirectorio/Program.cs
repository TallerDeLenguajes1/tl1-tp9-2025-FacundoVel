using System;
using System.IO;

Console.WriteLine("Ingrese el directorio a analizar: ");
string? path = Console.ReadLine();
while (!Directory.Exists(path))
{
    Console.WriteLine("El directorio NO existe");
    Console.WriteLine("Ingrese directorio valido: ");
    path = Console.ReadLine();
}

string[] files = Directory.GetFiles(path);
string[] directories = Directory.GetDirectories(path);

foreach (string carpeta in directories)
{
    DirectoryInfo info1 = new DirectoryInfo(carpeta);
    Console.WriteLine($"\nnombre directorio: {info1.Name}");
    foreach (string archivo in files)
    {
        Console.WriteLine("Archivos encontrados: ");
        FileInfo info = new FileInfo(archivo);
        Console.WriteLine($"\nnombre: {info.Name} tamaño: {info.Length}");

    }
}

