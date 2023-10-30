using LoginAndRegster.Setting;

namespace LoginAndRegster.Servisec.Employees
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly AppDbContext _context;
        public EmployeeServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAdmin()
        {
            var admin = await (from a in _context.Employees
                               join r in _context.UserRoles
                               on a.UserId equals r.UserId
                               where r.Role.RoleNem == "Admin"
                               select a)
                               .AsNoTracking()
                               .ToListAsync();

            return admin;
        }

        public async Task<IEnumerable<Employee>> GetAllSuperAdmin()
        {
            var superAdmin = await (from s in _context.Employees
                                    join r in _context.UserRoles
                                    on s.UserId equals r.UserId
                                    where r.Role.RoleNem == "SuperAdmin"
                                    select s)
                                    .AsNoTracking()
                                    .ToListAsync();
            return superAdmin;
        }

        public async Task<IEnumerable<Customr>> GetAllCustomer()
        {
            var customers = await (from c in _context.Customers
                                   join r in _context.UserRoles
                                   on c.UserId equals r.UserId
                                   where r.Role.RoleNem == "User"
                                   select c)
                                   .AsNoTracking()
                                   .ToListAsync();
            return customers;
        }

        public async Task<Employee?> checkEmail(string email)
        {
            return await _context.Employees
                .Where(x => x.Email == email)
                .FirstOrDefaultAsync(x => x.Email == email);

        }

        public async Task CreateEmploye(CreateEmployeeViewModel model)
        {

            var hash = Hash.HashPassword(model.Password);
            Employee employee = new()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Phone = model.Phone,
                Email = model.Email,
                Password = hash,
                ConfirmPassword = model.ConfirmPassword
            };

            await _context.Employees.AddAsync(employee);
            var effected = _context.SaveChanges();
            if (effected > 0)
            {
                UserRole userRole = new()
                {
                    UserId = employee.UserId,
                    RoleId = model.RoleId
                };
                await _context.UserRoles.AddAsync(userRole);
                _context.SaveChanges();
            }

        }

        public  bool Delete(int id)
        {
            var userId =  _context.Users.Find(id);
            if(userId is not null)
            {
                _context.Remove(userId);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        
    }
}
