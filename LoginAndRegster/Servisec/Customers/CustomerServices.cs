using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace LoginAndRegster.Servisec.Customers
{
    public class CustomerServices:ICustomerServices
    {
        private readonly AppDbContext _context;
        public CustomerServices(AppDbContext context)
        {
            _context = context;
        }


        public async Task<bool> CheckEmail(string email)
        {
            var c = await _context.Customers.SingleOrDefaultAsync( x => x.Email ==email);
            if(c is null)
            {
                return true;
            }
            return false;
        }

        public async Task RegisterCustomer(Customr model)
        {
            model.Password = Hash.HashPassword(model.Password);

            await _context.Customers.AddAsync(model);
            var effected = _context.SaveChanges();
            if (effected > 0)
            {
                UserRole userRole = new()
                {
                    UserId = model.UserId,
                    RoleId = 1
                };
                await _context.UserRoles.AddAsync(userRole);
                _context.SaveChanges();
            }
        }
       

       
    }
}
