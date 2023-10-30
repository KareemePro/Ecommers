namespace LoginAndRegster.Servisec.Contacts
{
    public class ContactServices : IContactServices
    {
        private readonly AppDbContext _context;
        public ContactServices(AppDbContext context)
        {
            _context = context;
        }


        public async Task SendMessage(Contact model)
        {
            await _context.Contacts.AddAsync(model);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Contact?> GetById(int id)
        {
            return await _context.Contacts
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public bool Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact is null)
                return false;
            _context.Remove(contact);
            _context.SaveChanges();
            return true;
        }
    }
}
