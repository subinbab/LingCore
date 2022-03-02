using LingCore.BL;
using LingCore.DAO;
using LingCore.DAO.ADO;
using Microsoft.AspNetCore.Mvc;

namespace LingCore.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            Product product = new Product();
            DataReader<Product> data =  new DataReader<Product>();

            return View(data.GetAllData(product,"Product"));
        }
    }
}
