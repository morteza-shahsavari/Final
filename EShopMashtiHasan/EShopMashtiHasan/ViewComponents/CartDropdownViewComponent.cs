using Shopping.DomainModel.ViewModel.Orders;
using EShopMashtiHasan.Helper;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "CartDropdown")]
    public class CartDropdownViewComponent : ViewComponent
    {
        #region Fields

        private readonly ISessionHelper _sessionHelper;

        #endregion

        #region Ctor

        public CartDropdownViewComponent(ISessionHelper sessionHelper)
        {
            _sessionHelper = sessionHelper;
        }

        #endregion

        #region Events

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basket = _sessionHelper.GetCurrentBasket();
            var cartDropdownList = new CartDropdownList();
            if (basket.OrderDetails != null) 
            {
                foreach (var item in basket.OrderDetails) 
                {
                    cartDropdownList.TotalAmount = basket.OrderDetails.Sum(x=>x.Quantity * x.UnitPrice).ToString("#");
                    cartDropdownList.Count = basket.OrderDetails.Count();
                    cartDropdownList.CartDropdownListItems.Add(new CartDropdownListItem
                    {
                        Image = item.Image,
                        OrderCount = item.Quantity,
                        ProductId = item.ProductID,
                        ProductName = item.ProductName,
                        Price = item.UnitPrice.ToString("#")
                    }); 
                }
            }
            
            return View(cartDropdownList);
        }

        #endregion
    }
}
