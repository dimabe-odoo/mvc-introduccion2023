using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers;

public class PrincipalBaseController : Controller
{
    protected IActionResult ResponseMessage(bool isError, string message, string action = "Index")
    {
        if (isError)
            TempData["ErrorMessage"] = message;
        else
            TempData["SuccessMessage"] = message;

        return RedirectToAction(action);
    }
}