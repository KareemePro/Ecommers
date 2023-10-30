

namespace LoginAndRegster.Servisec.Categorys
{
    public class CategoryServices : ICategoryServices
    {
        private readonly AppDbContext _context;
        public CategoryServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            return  await _context.Categorys.AsNoTracking().ToListAsync();
        }

        public Category? GetById(int id)
        {
            return _context.Categorys.AsNoTracking().SingleOrDefault(d => d.Id == id);
        }

        public async Task Create(Category model)
        {
            await _context.AddAsync(model);
            _context.SaveChanges();

        }

        public async Task Edit(Category model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(Category model)
        {
            _context.Categorys.Remove(model);
            await _context.SaveChangesAsync();

        }

        public Category? CheckName(string model)
        {
            return _context.Categorys.Where(n => n.Name == model).FirstOrDefault();

        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Categorys.
                 Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name }).
                 OrderBy(x => x.Text).
                 ToList();
        }
    }
}
