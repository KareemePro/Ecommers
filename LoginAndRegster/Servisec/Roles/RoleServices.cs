namespace LoginAndRegster.Servisec.Roles
{
    public class RoleServices : IRoleServices
    {
        private readonly AppDbContext _context;
        public RoleServices(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetSelectRole()
        {
            return _context.Roles.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.RoleNem }).ToList();
        }


    }
}
