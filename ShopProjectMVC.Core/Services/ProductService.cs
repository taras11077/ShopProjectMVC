using ShopProjectMVC.Core.Interfaces;
using ShopProjectMVC.Core.Models;

namespace ShopProjectMVC.Core.Services;

public class ProductService : IProductService
{
    private readonly IRepository _repository;

    public ProductService(IRepository repository)
    {
        _repository = repository;
    }


    public async Task<Product> AddProduct(Product product)
    {
        return await _repository.Add(product);
    }

    
    public async Task<Order> BuyProduct(int userId, int productId)
    {
        var product = await _repository.GetById<Product>(productId);
        var user = await _repository.GetById<User>(userId);

        if (product == null || product.Count <= 0)
        {
            throw new ArgumentException("Product not available");
        }

        var order = new Order
        {
            User = user,
            Product = product,
            CreatedAt = DateTime.UtcNow
        };

        product.Count -= 1;
		await _repository.Add(order);

		return order;
    }



    public async Task DeleteProduct(int id)
    {
        await _repository.Delete<Product>(id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _repository.GetAll<Product>();
    }


    public IEnumerable<Category> GetAllCategories()
    {
	    return _repository.GetAll<Category>();
    }

	public async Task<Product> GetProductById(int id)
    {
        return await _repository.GetById<Product>(id);
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        return await _repository.Update(product);
    }
}

