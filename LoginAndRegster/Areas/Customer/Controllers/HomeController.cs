using LoginAndRegster.Servisec.Categorys;
using LoginAndRegster.Servisec.Products;

namespace LoginAndRegster.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IProductServices _productS;
        public HomeController(IProductServices productS)
        {
            _productS = productS;
           
        }

        public async Task<IActionResult> Index(string pName="" , int categoryId = 0)
        {
            IEnumerable<Product> allProduct = await _productS.GetProduct(pName, categoryId);
            
            return View(allProduct);
        }
        

    }
}