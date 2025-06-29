using System;
using System.IO;
using System.Text;
using LectorTagMP3;

Console.WriteLine("Ingrese la ruta del archivo MP3: ");
string? path = Console.ReadLine();

while(string.IsNullOrWhiteSpace(path) || !File.Exists(path) || !path.EndWith(".mp"))
{
    Console.WriteLine("Ruta invalida o el archivo no es un MP3. Intente nuevamente:");
    path = Console.ReadLine();
}

FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

if(fs.Length < 128)
{
    Console.WriteLine("Archivo demasiado pequeño para contener etiqueta ID3v1.");
    fs.close();
    return;
}

fs.Seek(-128, SeekOrigin.End);
byte[] tagBytes = new byte[128];
fs.Read(tagBytes, 0, 128);
fs.Close();

string tag = Encoding.ASCII.GetString(tagBytes, 0, 3);
if(tag != "TAG")
{
    Console.WriteLine("El archivo no contiene una etiqueta ID3v1.");
    return;
}

Encoding latin1 = Encoding.GetEncoding("latin1");

string titulo = latin1.GetString(tagBytes, 3, 39).Trim('\0').Trim();
string artista = latin1.GetString(tagBytes, 33, 39).Trim('\0').Trim();
string album = latin1.GetString(tagBytes, 63, 39).Trim('\0').Trim();
string anio = latin1.GetString(tagBytes, 93, 4).Trim('\0').Trim();

ID33v1Tag id3v1Tag = new ID33v1Tag(titulo, artista, album, anio);
info.Mostrar();