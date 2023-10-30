
using LoginAndRegster.Servisec.Categorys;
using LoginAndRegster.Servisec.Products;


namespace LoginAndRegster.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductServices _services;
        private readonly ICategoryServices _cServices;

        public ProductController(
            IProductServices services,
            ICategoryServices cServices)
        {
            _services = services;
            _cServices = cServices;

        }
       
        public async Task<IActionResult> Index()
        {
            var model = await _services.GetAll();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(decimal lowAmount, decimal largAmount)
        {
            var products = await _services.Search(lowAmount, largAmount);
            if (products is null)
            {
                var product = _services.GetAll();
                return View(product);
            }

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _services.GetById(id);
            if (product is null)
                return NotFound();
            return View(product);
        }

        public IActionResult Create()
        {
            CreateProductViewModel viewModel = new()
            {
                Category = _cServices.GetSelectList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Category = _cServices.GetSelectList();
                return View(model);
            }
            await _services.Create(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _services.GetById(id);

            if (product is null)
            {
                return NotFound();
            }

            EditProductViewModel viewModel = new()
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ProductColor = product.ProductColor,
                CategoryId = product.CategoryId,
                Category = _cServices.GetSelectList(),
                CurrentName = product.Image
            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = await _services.Edit(model);
                if (product is null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            model.Category = _cServices.GetSelectList();
            return View(model);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _services.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
    }
}
