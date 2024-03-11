using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Squadron.DTO.Task1;
using Squadron.Services;

namespace squadron.Pages;

public class Task1Model : PageModel
{
    public void OnPost(IFormFile? file)
    {
        if (file == null) return;
        var parsedFile = ParseTask1File(file);
        var currentDb = DbService.LoadDbFile<History>("/Task1/db.json", out string filePath);
        currentDb.Add(parsedFile);

        System.IO.File.WriteAllText(filePath, JsonSerializer.Serialize(currentDb));
        ViewData["citiesHistory"] = currentDb;
    }

    public static History ParseTask1File(IFormFile file)
    {
        var task1List = new List<City>();
        using var reader = new StreamReader(file.OpenReadStream());
        while (reader.Peek() >= 0)
        {
            var line = reader.ReadLine();
            var split = line?.Split(",");
            // TODO VALIDATIDATION HERE
            task1List.Add(new City(split[0].Trim(), split[1].Trim(), split[2].Trim()));
        }


        return new History(file.FileName, DateTime.Now, task1List);
    }
}