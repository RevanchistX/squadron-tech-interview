using System.Text.Json;
using Squadron.DTO.Task1;

namespace Squadron.Services;

public class DBService
{
    public static List<T> LoadDbFile<T>(string dbFile, out string filePath)
    {
        var currentFolder = Directory.GetCurrentDirectory();
        var dbFolder = currentFolder + "/db";
        filePath = dbFolder + dbFile;
        var loadedDb = File.ReadAllLines(filePath);
        return JsonSerializer.Deserialize<List<T>>(string.Join(" ", loadedDb));
    }
}