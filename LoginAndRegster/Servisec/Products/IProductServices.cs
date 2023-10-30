namespace LoginAndRegster.Servisec.Products
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetAll();

        Task Create(CreateProductViewModel model);

        Product? GetById(int? id);

        Task<Product?> Edit(EditProductViewModel model);

        bool Delete(int id);
        Task<IEnumerable<Product>> Search(decimal lowAmount, decimal largAmount);
        Task<IEnumerable<Product>> GetProduct(string pName = "", int categoryId = 0);

    }
}
