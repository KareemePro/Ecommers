using LoginAndRegster.Servisec.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace LoginAndRegster.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ContactController : Controller
    {
        private readonly IContactServices _contact;
        public ContactController(IContactServices contact)
        {
            _contact = contact;
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Contact model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _contact.SendMessage(model);
            TempData["Success"] = "Message send success";
             
            return Redirect("/Customer/Home/Index");
        }
    }
}
