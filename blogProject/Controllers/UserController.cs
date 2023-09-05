using AutoMapper;
using blogProject.Entities;
using blogProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace blogProject.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public UserController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<UserViewModel> users = _databaseContext.Users.ToList().Select(x => _mapper.Map<UserViewModel>(x)).ToList(); ;

            return View(users);
        }
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(CreateUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.UserName.ToLower() == model.Username.ToLower()))
                {
                    ModelState.AddModelError(model.Username, "Usernam is already exist");
                    return View(model);
                }



                User user = _mapper.Map<User>(model);
                _databaseContext.Users.Add(user);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }
        public IActionResult EditUser(Guid id)
        {
            User user = _databaseContext.Users.Find(id);
            EditUserViewModel model = _mapper.Map<EditUserViewModel>(user);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditUser(Guid id, EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.UserName.ToLower() == model.Username.ToLower() && x.Id != id))
                {
                    ModelState.AddModelError("Username", "Username is already exist");
                    return View(model);
                }

                User user = _databaseContext.Users.Find(id);
                if (user == null)
                {
                    return NotFound(); // Belirtilen kullanıcı bulunamadı.
                }

                _mapper.Map(model, user);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }




        [HttpGet]
        public IActionResult DeleteUser(Guid id)
        {
            User user = _databaseContext.Users.Find(id);

            if (user.Id!=null)
            {

                _databaseContext.Users.Remove(user); 
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View("Index");
        }
    }
}
