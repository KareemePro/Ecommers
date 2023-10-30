using LoginAndRegster.Servisec.Customers;


namespace LoginAndRegster.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AccountController : Controller
    {
        private readonly ICustomerServices _customer;
        private readonly AppDbContext _context;
        public AccountController(ICustomerServices customer, AppDbContext context)
        {
            _customer = customer;
            _context = context;
        }
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
    
        public async Task<IActionResult> Register(Customr model)
        {

            if (ModelState.IsValid)
            {
                var c = await _customer.CheckEmail(model.Email);
                if (c == false)
                {
                    ModelState.AddModelError("", "This Email alrady exist");
                    return View(model);
                }

                await _customer.RegisterCustomer(model);
                TempData["Success"] = "The account was created successfully";

                return RedirectToAction(nameof(Login));
            }

            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(Login model)
        {
            if (ModelState.IsValid)
            {

                model.Password = Hash.HashPassword(model.Password);

                var user = (from u in _context.Users
                            join c in _context.UserRoles
                            on u.UserId equals c.UserId
                            select new
                            {
                                u.FirstName,
                                u.Email,
                                u.Password,
                                c.Role.RoleNem
                            }).FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);


                if (user is not null)
                {

                    //creating the security context
                    var claims = new List<Claim>{
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Name,user.FirstName),
                        new Claim(ClaimTypes.Role,user.RoleNem)
                    };

                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                    if (user.RoleNem == "User")
                        return RedirectToAction("Index", "Home");
                    else if (user.RoleNem == "Admin" || user.RoleNem == "SuperAdmin")
                        return Redirect("/Admin/HomeAdmin/Index");
                }

            }

            ModelState.AddModelError("", "Invalid Email or Password");

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
            
    }
}
