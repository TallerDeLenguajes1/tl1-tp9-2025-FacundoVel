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

string[] archivos = Directory.GetFiles(path);
Console.WriteLine("\nArchivos encontrados: ");

foreach(string archivo in archivos)
{
    FileInfo info = new FileInfo(archivo);
    double tamanioKB = info.Length / 1024.0;
    Console.WriteLine($"- {info.Name} | Tamaño: {tamanioKB:F2} KB");
}

string csvPath = Path.Combine(path, "reporte_archivos.csv");

using (StreamWriter writer = new StreamWriter(csvPath))
{
    writer.WriteLine("Nombre del Arcivo, Tamaño (KB), Fecha de Ultima modificacion");

    foreach(string archivo in archivos)
    {
        FileInfo info = new FileInfo(archivo);
        string nombre = info.Name;
        double tamanioKB = info.Length / 1024.0;
        string fechaModificacion = info.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss");

        writer.WriteLine($"{nombre}, {tamanioKB:F2}, {fechaModificacion}");
    }
}
Console.WriteLine($"\n Se genero GSV en : {csvPath}");