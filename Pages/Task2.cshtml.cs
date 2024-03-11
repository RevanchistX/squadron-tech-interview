using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Squadron.DTO.Task2;
using Squadron.Services;

namespace squadron.Pages;

public class Task2Model : PageModel
{
    public void OnPost()
    {
        var loginParameter = Request.Form["login"].ToString();
        if (!string.IsNullOrEmpty(loginParameter))
        {
            if (!LoginService.UpdateLoginStatus(Request.Form["login"].ToString(), out User user)) return;
            ViewData["User"] = user;
        }

        var answerParameter = Request.Form["answer"].ToString();
        if (!string.IsNullOrEmpty(answerParameter))
        {
            var split = answerParameter.Split("-");
            var userId = split[0];
            var id = split[1];
            var answer = split[2];
            if (int.TryParse(id, out var intId) && int.TryParse(userId, out var intUserId))
            {
                var equations =
                    DbService.LoadDbFile<Equation>("/Task2/dbEquations.json", out string equationsDbFilePath);
                var users =
                    DbService.LoadDbFile<User>("/Task2/dbUsers.json", out string usersDbFilePath);
                var equation = equations.Find(eq => eq.Id == intId);
                var currentUser = users.Find(us => us.Id == intUserId);
                if (equation != null && currentUser != null)
                {
                    if (bool.TryParse(answer, out var answerBool))
                    {
                        var comparison = equation.Evaluate().Equals(equation.Result).Equals(answerBool);
                        if (comparison)
                        {
                            currentUser.Answers.Add(intId, equation.Evaluate());
                        }
                        else
                        {
                            currentUser.Answers.Add(intId, equation.Result);
                        }

                        DbService.SaveDbFile(usersDbFilePath, users);
                    }
                }
            }
        }
    }
}