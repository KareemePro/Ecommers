using LoginAndRegster.Servisec.Categorys;
using Microsoft.AspNetCore.Mvc;

namespace LoginAndRegster.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="SuperAdmin")]
    public class CategoryController : Controller
    {
                   
            private readonly ICategoryServices _category ;
            public CategoryController(ICategoryServices category)
            {
                _category = category;
            }

            public async Task<IActionResult> Index()
            {
                var category = await _category.GetAll();
                return View(category);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Category model)
            {
                if (ModelState.IsValid)
                {
                    var n = _category.CheckName(model.Name);
                    if (n != null)
                    {
                        ModelState.AddModelError("", "this Name ordy exit");
                        return View(model);
                    }
                    else
                    {
                        await _category.Create(model);
                        return RedirectToAction(nameof(Index));
                    }

                }
                return View(model);
            }

            public IActionResult Edit(int id)
            {

                var productType = _category.GetById(id);
                if (productType == null)
                {
                    return NotFound();
                }

                return View(productType);
            }



            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(Category model)
            {
                if (ModelState.IsValid)
                {
                    var productType = _category.CheckName(model.Name);
                    if (productType != null)
                    {
                        ModelState.AddModelError("", "this Name ordy exit");
                        return View(model);
                    }
                    else
                    {
                        await _category.Edit(model);
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(model);
            }



            public IActionResult Delete(int id)
            {

                var productType = _category.GetById(id);
                if (productType == null)
                {
                    return NotFound();
                }
                return View(productType);
            }



            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(int id, Category model)
            {

                if (id != model.Id)
                {
                    return NotFound();
                }
                var categorys = _category.GetById(id);
                if (categorys == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    await _category.Delete(categorys);
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
        }
}
