namespace Squadron.DTO.Task1;

public class History(string fileName, DateTime date, List<City> cities)
{
    public string FileName { get; set; } = fileName;
    public DateTime Date { get; set; } = date;
    public List<City> Cities { get; set; } = cities;
}