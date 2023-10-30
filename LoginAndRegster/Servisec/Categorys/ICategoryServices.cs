namespace LoginAndRegster.Servisec.Categorys
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAll();
        IEnumerable<SelectListItem> GetSelectList();

        Category? GetById(int id);

        Task Create(Category model);
        Task Edit(Category model);
        Task Delete(Category model);
        Category? CheckName(string model);
    }
}
