using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Api.Controllers.Task
{
    public class TaskCommandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
