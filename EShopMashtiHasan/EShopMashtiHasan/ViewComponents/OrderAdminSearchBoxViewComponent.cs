using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;

using Shopping.DomainModel.DTO.OrdersAndOrderDetials;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "OrderAdminSearchBox")]
    public class OrderAdminSearchBoxViewComponent:ViewComponent
    {
        private readonly IOrderBuss buss;
        public OrderAdminSearchBoxViewComponent(IOrderBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(OrderSearchModel sm)
        {

          return View(sm);
        }
    }
}
