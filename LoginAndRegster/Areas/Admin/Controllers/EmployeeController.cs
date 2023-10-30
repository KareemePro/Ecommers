using LoginAndRegster.Servisec.Employees;
using LoginAndRegster.Servisec.Roles;

namespace LoginAndRegster.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IRoleServices _role;
        private readonly IEmployeeServices _employee;
        public EmployeeController(
            IRoleServices role,
            IEmployeeServices employee)
        {
            _role = role;
            _employee = employee;
        }
        [Authorize(Roles ="SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> GetAllSuperAdmins()
        {
            var superAdmin = await _employee.GetAllSuperAdmin();

            return View(superAdmin);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admin = await _employee.GetAllAdmin();
            
            return View(admin);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var user = await _employee.GetAllCustomer();

            return View(user);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            
            CreateEmployeeViewModel model = new()
            {
                Roles =   _role.GetSelectRole()
            };
            return View(model);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Roles = _role.GetSelectRole();
                return View(model);
            }
            
            if (await _employee.checkEmail(model.Email) is not null)
            {
                ModelState.AddModelError("", "This email orlady exest");
                model.Roles = _role.GetSelectRole();
                return View(model);
            }

            await _employee.CreateEmploye(model);

            if(model.RoleId == 2)

                return RedirectToAction(nameof(GetAllAdmins));

            else if(model.RoleId == 3)
            
                return RedirectToAction(nameof(GetAllSuperAdmins));
            
                   
            return Redirect("/Admin/HomeAdmin/Index");
            
        }

        public IActionResult Edit()
        {


            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {   
         return _employee.Delete(id) ? Ok() : BadRequest();
        }
    }
    
    
}
