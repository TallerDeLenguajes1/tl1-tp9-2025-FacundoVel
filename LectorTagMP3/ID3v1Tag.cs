namespace LectorTagMP3
{
    public class ID33v1Tag
    {
        private string _titulo;
        private string _artista;
        private string _album;
        private string _anio;

        public string Titulo{get => _titulo; set => _titulo = value;}
        public string Artista{get => _artista; set => _artista = value;}
        public string Album{get => _album; set => _album = value;}
        public string Anio{get => _anio; set => _anio = value;}
        
        public IDv1tag(string titulo, string artista, string album, string año)
        {
            _titulo = titulo;
            _artista = artista;
            _album = album;
            _anio = anio;
        }

        public void Mostrar()
        {
            Console.WriteLine("\n--- Informacion del MP3 ---");
            Console.WriteLine($"Titulo : {Titulo}");
            Console.WriteLine($"Artista: {Artista}");
            Console.WriteLine($"Album  : {Album}");
            Console.WriteLine($"Año    : {Anio}");
        }
    }
}