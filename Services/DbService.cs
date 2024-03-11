using System.Text.Json;
using Squadron.DTO.Task1;

namespace Squadron.Services;

public static class DbService
{
    public static List<T> LoadDbFile<T>(string dbFile, out string filePath)
    {
        filePath = Directory.GetCurrentDirectory() + "/db" + dbFile;
        var loadedDb = File.ReadAllLines(filePath);
        return JsonSerializer.Deserialize<List<T>>(string.Join(" ", loadedDb));
    }

    public static void SaveDbFile<T>(string dbFilePath, List<T> dbValue)
    {
        File.WriteAllText(dbFilePath, JsonSerializer.Serialize(dbValue));
    }
}