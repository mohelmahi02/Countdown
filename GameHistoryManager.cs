// GameHistoryManager.cs
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace CountDown
{
    public static class GameHistoryManager
    {
        private const string FileName = "game_history.json";

        public static async Task SaveGameHistoryAsync(List<History> gameHistories)
        {
            var json = JsonSerializer.Serialize(gameHistories);
            var localPath = Path.Combine(FileSystem.AppDataDirectory, FileName);
            await File.WriteAllTextAsync(localPath, json);
        }

        public static async Task<List<History>> LoadGameHistoryAsync()
        {
            var localPath = Path.Combine(FileSystem.AppDataDirectory, FileName);

            if (File.Exists(localPath))
            {
                var json = await File.ReadAllTextAsync(localPath);
                return JsonSerializer.Deserialize<List<History>>(json);
            }

            return new List<History>();
        }
    }
}
