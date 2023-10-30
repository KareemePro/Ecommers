namespace LoginAndRegster.Servisec.Customers
{
    public interface ICustomerServices
    {
        Task<bool> CheckEmail(string email);
        Task RegisterCustomer(Customr model);
        //Task<User?> Login(Login model);
       // UserRole GetRole(int id);
        //Task<UserRole?> Login(Login model);
    }
}
