
using LoginAndRegster.Setting;

namespace LoginAndRegster.Servisec.Products
{
    public class ProductServices : IProductServices
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _host;
        private readonly string _imagePaht;
        public ProductServices(AppDbContext context,
             IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
            _imagePaht = $"{_host.WebRootPath}{FileSetting.ImgaPaht}";
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.
                Include(x => x.Category).
                AsNoTracking().
                ToListAsync();
        }

        public async Task Create(CreateProductViewModel model)
        {

            var imageName = await SaveImage(model.Image);

            Product product = new()
            {
                Name = model.Name,
                Price = model.Price,
                ProductColor = model.ProductColor,
                Description = model.Description,
                Image = imageName,
                CategoryId = model.CategoryId,

            };

            await _context.AddAsync(product);
            _context.SaveChanges();
        }

        public Product? GetById(int? id)
        {
            return _context.Products.
                AsNoTracking().
                SingleOrDefault(p => p.Id == id);
        }

        public async Task<Product?> Edit(EditProductViewModel model)
        {
            var product = _context.Products.SingleOrDefault(d => d.Id == model.Id);

            if (product is null)
                return null;

            var hasNewImage = model.Image is not null;
            var oldImage = product.Image;

            product.Name = model.Name;
            product.Price = model.Price;
            product.ProductColor = model.ProductColor;

            product.Description = model.Description;


            if (hasNewImage)
            {
                product.Image = await SaveImage(model.Image!);
            }
            var effectedRow = _context.SaveChanges();

            if (effectedRow > 0)
            {
                if (hasNewImage)
                {
                    var image = Path.Combine(_imagePaht, oldImage);
                    File.Delete(image);
                }
                return product;
            }
            else
            {
                //var image = Path.Combine(_imagePaht, product.Image);
                //File.Delete(image);
                //return null;
                return null;
            }

        }

        private async Task<string> SaveImage(IFormFile image)
        {
            var imageName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            var path = Path.Combine(_imagePaht, imageName);

            using var stream = File.Create(path);
            await image.CopyToAsync(stream);

            return imageName;
        }

        public bool Delete(int id)
        {
            var isDeleted = false;

            var product = _context.Products.Find(id);
            if (product is null)
                return isDeleted;

            _context.Remove(product);
            var effectedRow = _context.SaveChanges();

            if (effectedRow > 0)
            {
                isDeleted = true;
                var image = Path.Combine(_imagePaht, product.Image);
                File.Delete(image);
            }

            return isDeleted;
        }
        public async Task<IEnumerable<Product>> Search(decimal lowAmount, decimal largAmount)
        {
            return await _context.Products.
                Include(p => p.Category).
                Where(p => p.Price <= largAmount && p.Price >= lowAmount).
                ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProduct(string pName = "", int categoryId = 0)
        {
            pName = pName.ToLower();
            var products = await (from product in _context.Products
                                  join category in _context.Categorys
                                  on product.CategoryId equals category.Id
                                  where string.IsNullOrWhiteSpace(pName) ||
                                  (product != null && product.Name.ToLower().StartsWith(pName))
                                  select new Product
                                  {
                                     Id = product.Id,
                                     Name = product.Name,
                                     ProductColor = product.ProductColor,
                                     Price = product.Price,
                                     Image = product.Image,
                                     Description = product.Description,
                                     CategoryId = product.CategoryId,
                                     CategoryName = category.Name
                                  }).ToListAsync();
            if(categoryId > 0)
            {
                products = products.Where(x => x.CategoryId == categoryId).ToList();
            }
            return products;
        }

    }
}
