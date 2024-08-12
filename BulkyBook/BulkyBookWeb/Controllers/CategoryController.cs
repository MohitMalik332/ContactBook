using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
            
        }

        public IActionResult ShowAllNames(int Id = 0)
        {
            IEnumerable<Category2> objNames = _db.Categories.Select(x =>
            new Category2{
                Name = x.Name,
                Id = x.Id
            });
            if(Id != 0){
                TempData["SelectedContact"] = _db.Categories.FirstOrDefault(x => x.Id == Id).ContactNumber.ToString();
            }
            return View(objNames);
        }

        //GET Method
        public IActionResult Create()
        {
            return View();

        }
        // POST Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.ContactNumber.ToString())
            {
                ModelState.AddModelError("CustomError", "The Display order cannot exactly match the Name");
            }
            if (ModelState.IsValid) 
            { 
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult DeleteContact(int Id)
        {
            // Handle the parameter
            var contact = _db.Categories.FirstOrDefault(c => c.Id == Id);

            _db.Categories.Remove(contact);
            _db.SaveChanges();
            return RedirectToAction("Index"); // Redirect to the index or another view
        }

        [HttpGet]
        public IActionResult EditContact(int Id)
        {
            // Handle the parameter
            var contact = _db.Categories.FirstOrDefault(c => c.Id == Id);

            
            return View("Create", contact); // Redirect to the index or another view
        }

        public IActionResult ShowAllContactNo()
        {
            IEnumerable<Category3> allContactNo = _db.Categories.Select(x => new Category3
            {
                ContactNumber = x.ContactNumber
            });
            return View(allContactNo);
        }

        
    }
}
