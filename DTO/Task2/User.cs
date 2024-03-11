namespace Squadron.DTO.Task2;

public class User(int id, string name, Dictionary<int, double> answers)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public bool IsLoggedIn { get; set; } = false;
    public Dictionary<int, double> Answers { get; set; } = answers;
}