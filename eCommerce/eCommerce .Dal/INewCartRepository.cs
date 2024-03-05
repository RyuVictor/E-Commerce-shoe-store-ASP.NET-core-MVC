using eCommerce.Models;

namespace eCommerce_.Dal
{
    public interface INewCartRepository
    {
        Task<int> GenerateNewCart(int customerId);
        Task<List<MyCartVM>> GetCartItems(int cartId);

    }
}
