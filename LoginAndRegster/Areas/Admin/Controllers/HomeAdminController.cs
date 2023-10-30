using LoginAndRegster.Servisec.Contacts;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace LoginAndRegster.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize]
    public class HomeAdminController : Controller
    {
        private readonly IContactServices _contact;
        public HomeAdminController(IContactServices contact)
        {
            _contact = contact;
        }

       
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
           
            return View(await _contact.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var contact = await _contact.GetById(id);
            if (contact is null)
                return NotFound();
            return View(contact);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (!_contact.Delete(id))
                return BadRequest();
            return Ok();
        }
    }
}
