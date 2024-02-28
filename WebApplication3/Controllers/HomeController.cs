using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {

		public vebcontext db;

		public HomeController(vebcontext context)
		{
			db = context;
		}
		[HttpGet]


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult catal()
        {
            return View();
        }

        
		
		public IActionResult bok1()
		/* для рабботы с бд */
		{
			var goods = db.Goods.ToList(); 
			return View(goods);
		}

		public IActionResult bok2()
		{
            var goods = db.Goods.ToList();
            return View(goods);
        }

		public IActionResult bok3()
		{
            var goods = db.Goods.ToList();
            return View(goods);
        }

		public IActionResult bok4()
		{
            var goods = db.Goods.ToList();
            return View(goods);
        }

		public IActionResult aboutUs()
		{
			return View();
		}

        public IActionResult reg()
        {
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber && myNumber != 0)
            {
                TempData["myNumber"] = myNumber;
                return RedirectToAction("Profile");
            }
            
            return View();
        }
        public IActionResult reg1(userss newuser)
        {
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber && myNumber != 0)
            {
                TempData["myNumber"] = myNumber;
                return RedirectToAction("Profile");
            }
            if (!newuser.email.Contains("@") || !newuser.email.Contains("."))  /* Проверка на корректность имейл */
            {
                ViewData["ErrorMessage"] = "Некоррректный Email.";
                return View("reg");
            }
            else if(db.users.Any(u => u.email==newuser.email)) /* Функция для поиска совпадения по имейл */
            {
                TempData["ErrorMassage"] = "Такой email уже есть.";  /* В ErrorMassage кидаем ошибку, это временная память, до обращения к ней */
                return RedirectToAction("reg", "Home");  /* Переходим в действ рег в хом */
            }
            var newUser = new userss
            {
                usersID = db.users.Max(u => (int)u.usersID) + 1,  /* Находим макс в бд и кладем в айли макс+1 */
                password = newuser.password,
                email = newuser.email,
                name = newuser.name
            };
            db.users.Add(newUser); /* Добавляем в бд */
            db.SaveChanges(); /* Сохр изм в табл */
            TempData["myNumber"] = newUser.usersID;
            return RedirectToAction("Index"); /* Переход в профиль, еслии всё успешно */
        }
        public IActionResult cont()
		{
			return View();
		}


        public IActionResult vhod()
        {
            return View();
        }

        public IActionResult vhod1(userss newuser)
        {
            var newUser = new userss
            {
                usersID = newuser.usersID,
                password = newuser.password,
                email = newuser.email,
                
            };
            userss? user = db.users.FirstOrDefault(u => u.email == newUser.email && u.password == newUser.password);
            if (user != null)
            {
                TempData["myNumber"] = user.usersID;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Неверный email или пароль";
                return RedirectToAction("reg");
            }
        }

        public IActionResult Contacts() => View();
        public IActionResult SendContact(Contacts model)
        {
            var newContact = new Contacts
            {
                ContactId = db.Contact.Max(u => (int)u.ContactId) + 1,
                Name = model.Name,
                Email = model.Email,
                Comment = model.Comment
            };
            db.Contact.Add(newContact);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Profile()
        {
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber && myNumber != 0)
            {
                var cartData = new List<Carts>();
                
                if (db.Cart.Any())
                {
                    cartData = db.Cart.ToList();
                }
                
                var comboModel = new ComboModelProfileANDGoodsCard
                {
                    GoodssData = db.Goods.ToList(),
                    userssData = db.users.ToList(),
                    CartData = cartData,
                    usersID = myNumber
                };
                TempData["myNumber"] = comboModel.usersID;
                return View(comboModel);
            }
            else
            {
                TempData["myNumber"] = 0;
                return RedirectToAction("vhod");
            }
        }


        public IActionResult Logoff()
        {
            TempData["myNumber"] = 0;
            return RedirectToAction("Index", "Home");
        } /* выход */

        public IActionResult RemoveUser()
        {
            int userId = 0;
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userId = myNumber;
            }
            var itemToDelete = db.users.FirstOrDefault(g => g.usersID == userId);
            db.users.Remove(itemToDelete);
            db.SaveChanges();
            TempData["myNumber"] = 0;
            return RedirectToAction("Index", "Home");
        }/* удал */
        
        [HttpPost]
        public IActionResult AddToCart(int goodid)
        {

            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber && myNumber != 0)
            {
                var newCart = new Carts
                {
                    CartId = db.Cart.Max(u => (int)u.CartId) + 1,
                    goodid = goodid,
                    usersID = myNumber
                };
                TempData["myNumber"] = newCart.usersID;
                db.Cart.Add(newCart);
                db.SaveChanges();
                return Ok();
            }
            return StatusCode(500);
        }      /* Корзина */


        [HttpGet]
        public IActionResult Search(string searchTerm)
        {
            var searchResults = db.Goods.Where(g => g.info.Contains(searchTerm) ||
                            g.miniinfo.Contains(searchTerm) ||
                            g.name.Contains(searchTerm))
                .ToList();
            return PartialView("_SearchResultsPartial", searchResults);
        }


    }
}




