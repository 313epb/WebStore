using WebApplication3.Model.Cart;

namespace WebApplication3.Data
{
    public interface ICartService
    {
        void DecrementFromCart(int id);
        void RemoveFromCart(int id);
        void RemoveAll();
        void AddToCart(int id);
        CartViewModel TransformCart();
    }
}