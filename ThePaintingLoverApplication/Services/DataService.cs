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

        public void AddArtist(Artist newArtist)
        {
            newArtist.Paintings = new List<Painting>();
            artists.Add(newArtist);
            SaveArtists();
        }

        public void RemoveArtistData(Artist artistToRemove)
        {
            artists.Remove(artistToRemove);
            SaveArtists();
        }

        public void UpdateArtistData(Artist oldArtist, Artist editedArtist)
        {
            var index = artists.FindIndex(a => a.Name == oldArtist.Name);
            if (index != -1)
            {
                artists[index] = editedArtist;
                editedArtist.Paintings= oldArtist.Paintings;
                SaveArtists();
            }
        }

        public void AddStyle(Style newStyle)
        {
            styles.Add(newStyle);
            SaveStyles();
        }

        public void RemoveStyleData(Style styleToRemove)
        {
            styles.Remove(styleToRemove);
            SaveStyles();
        }

        public void UpdateStyleData(Style oldStyle, Style editedStyle)
        {
            var index = styles.FindIndex(a => a.Name == oldStyle.Name);
            if (index != -1)
            {
                styles[index] = editedStyle;
                SaveStyles();
            }
        }

        private void SaveArtists()
        {
            string artistsFilePath = Path.Combine(GetFilesDirectoryPath(), ArtistsFile);
            SaveDataToFile(artistsFilePath, artists);
        }

        private void SaveStyles()
        {
            string stylesFilePath = Path.Combine(GetFilesDirectoryPath(), StylesFile);
            SaveDataToFile(stylesFilePath, styles);
        }

        private void SaveDataToFile<T>(string filePath, List<T> data)
        {
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        private List<T> LoadDataFromFile<T>(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }

        private string GetFilesDirectoryPath()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            return Path.Combine(projectDirectory, DirectoryPath);
        }
    }
}
