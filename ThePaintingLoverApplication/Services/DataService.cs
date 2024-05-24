using System.IO;
using Newtonsoft.Json;
using ThePaintingLoverApplication.Models;

namespace ThePaintingLoverApplication.Services
{
    public class DataService
    {
        private List<Artist> artists;
        private List<Style> styles;

        public DataService()
        {
            artists = GetArtists();
            styles = GetStyles();
        }

        private const string ArtistsFile = "artists.json";
        private const string StylesFile = "styles.json";
        private const string DirectoryPath = "Files/Data";

        public List<Artist> GetArtists()
        {
            string artistsFilePath = Path.Combine(GetFilesDirectoryPath(), ArtistsFile);
            return LoadDataFromFile<Artist>(artistsFilePath);
        }

        public List<Style> GetStyles()
        {
            string stylesFilePath = Path.Combine(GetFilesDirectoryPath(), StylesFile);
            return LoadDataFromFile<Style>(stylesFilePath);
        }

        private List<T> LoadDataFromFile<T>(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }

        private string GetFilesDirectoryPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DirectoryPath);
        }
    }
}
