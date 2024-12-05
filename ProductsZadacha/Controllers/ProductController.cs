using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductsZadacha.Data;
using ProductsZadacha.Data.Models;
using ProductsZadacha.Models;

namespace ProductsZadacha.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        public ProductController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel model)
        {
            Product product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity
            };
            db.Products.Add(product);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }
        public IActionResult Visualisation()
        {
            List<ProductViewModel> model = db.Products.Select(x =>
            new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity
            }).ToList();
            return View(model);
        }
    }
}
