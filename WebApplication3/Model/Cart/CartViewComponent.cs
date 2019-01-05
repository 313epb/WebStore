using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;

namespace WebApplication3.Model.Cart
{
    public class CartViewComponent:ViewComponent
    {
        private readonly ICartService _cartService;

        public CartViewComponent(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IViewComponentResult Invoke()
        {
            var cartView = _cartService.TransformCart();
            return View(cartView);
        }
    }
}