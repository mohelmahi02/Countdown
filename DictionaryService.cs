using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace CountDown
{
    public class DictionaryService
    {
        private const string DictionaryUrl = "https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/cdwords.txt";
        private const string FileName = "cdwords.txt";

        public async Task<string> GetDictionaryAsync()
        {
            var localPath = Path.Combine(FileSystem.AppDataDirectory, FileName);

            if (!File.Exists(localPath))
            {
                await DownloadDictionaryAsync(localPath);
            }

            return await File.ReadAllTextAsync(localPath);
        }

        private async Task DownloadDictionaryAsync(string localPath)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(DictionaryUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    await File.WriteAllTextAsync(localPath, content);
                }
                else
                {
                    throw new Exception("Unable to download the dictionary file.");
                }
            }
        }
    }
}
