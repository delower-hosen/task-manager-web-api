using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Api.Controllers.TaskItem
{
    public class TaskItemCommandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
