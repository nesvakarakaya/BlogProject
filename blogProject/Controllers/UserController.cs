using blogProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace blogProject.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public UserController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
