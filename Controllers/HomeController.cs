using DataPOC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DataPOC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DatabaseContext _databaseContext;

        public HomeController(ILogger<HomeController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            var productsList = (from product in _databaseContext.Product
                                select new SelectListItem()
                                {
                                    Text = product.Name,
                                    Value = product.ProductId.ToString(),
                                }).ToList();

            productsList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });

            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Listofproducts = productsList;
            ViewBag.List = productViewModel;
            return View(productViewModel);
        }

        //public JsonResult ComboBox()        
        //{
        //    var productsList = (from product in _databaseContext.Product
        //                        select new SelectListItem()
        //                        {
        //                            Text = product.Name,
        //                            Value = product.ProductId.ToString(),
        //                        }).ToList();

        //    productsList.Insert(0, new SelectListItem()
        //    {
        //        Text = "----Select----",
        //        Value = string.Empty
        //    });

        //    ProductViewModel productViewModel = new ProductViewModel();
        //    productViewModel.Listofproducts = productsList;
            
        //    productViewModel.ProductId = "1";

        //    ViewBag.List = productViewModel;
        //    return Json(productViewModel.Listofproducts);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
