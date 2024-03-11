using Microsoft.Extensions.Primitives;
using Squadron.DTO.Task2;

namespace Squadron.Services;

public static class LoginService
{
    public static bool UpdateLoginStatus(string loginStatus, out User user)
    {
        user = null;
        if (!loginStatus.Contains('-')) return false;
        var split = loginStatus.Split("-");
        var status = split[0];
        var id = split[1];
        if (!int.TryParse(id, out var intId)) return false;
        var userList = DbService.LoadDbFile<User>("/Task2/dbUsers.json", out string usersDbFilePath);
        user = userList.Find(user => user.Id == intId);
        user.IsLoggedIn = status.Equals("login");
        // userList.FindAll(user => user.Id != intId).ForEach(user => user.IsLoggedIn = false);
        DbService.SaveDbFile(usersDbFilePath, userList);
        return true;
    }
}