using System.IO;
using System.Text.Json;
using ThePaintingLoverApplication.Models;

namespace ThePaintingLoverApplication.Services
{
    public class UserDataService
    {
        private const string FileName = "users.json";
        private const string DirectoryPath = "Files/Saves";

        public List<User> GetAllUsers()
        {
            string fullFilePath = Path.Combine(GetFilesDirectoryPath(), FileName);
            if (File.Exists(fullFilePath))
            {
                string jsonString = File.ReadAllText(fullFilePath);
                return JsonSerializer.Deserialize<List<User>>(jsonString);
            }
            else
            {
                return new List<User>();
            }
        }

        public User GetUser(string email)
        {
            var users = GetAllUsers();
            return users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public void SaveUserData(User user)
        {
            string fullFilePath = Path.Combine(GetFilesDirectoryPath(), FileName);
            EnsureDirectoryExists(GetFilesDirectoryPath());
            List<User> users;
            if (File.Exists(fullFilePath))
            {
                string existingJson = File.ReadAllText(fullFilePath);
                users = JsonSerializer.Deserialize<List<User>>(existingJson) ?? new List<User>();
            }
            else
            {
                users = new List<User>();
            }
            users.Add(user);
            string jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fullFilePath, jsonString);
        }

        public void UpdateUserData(User user)
        {
            string fullFilePath = Path.Combine(GetFilesDirectoryPath(), FileName);
            EnsureDirectoryExists(GetFilesDirectoryPath());
            string existingJson = File.ReadAllText(fullFilePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(existingJson) ?? new List<User>();

            var existingUser = users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                existingUser.FavoritePaintings = user.FavoritePaintings;
                existingUser.Notes = user.Notes;
            }
            else
            {
                users.Add(user);
            }

            string jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fullFilePath, jsonString);
        }

        private void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private string GetFilesDirectoryPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DirectoryPath);
        }
    }
}
