using Framework.Utility;
using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.CategoryFeature;
using Shopping.DomainModel.DTO.OrdersAndOrderDetials;
using System.Linq;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "OrderAdminList")]
    public class OrderAdminListViewComponent:ViewComponent
    {
        private readonly IOrderBuss buss;
        private readonly IUserBuss Userbuss;
        public OrderAdminListViewComponent(IOrderBuss buss, IUserBuss userbuss)
        {
            this.buss = buss;
            Userbuss = userbuss;
        }
        private void setPager(OrderSearchModel sm)
        {
            if (sm.RecordCount % sm.PageSize == 0)
            {
                sm.pageCount = sm.RecordCount / sm.PageSize;
            }
            else
            {
                sm.pageCount = sm.RecordCount / sm.PageSize + 1;

            }
            ViewBag.sm = sm;

        }
        public IViewComponentResult Invoke(OrderSearchModel sm)
        {
            int rc = 0;

            if (sm == null || sm.PageSize == 0) { sm.PageSize = 30; }


            var PA = buss.Search(sm, out rc);
            var q = PA.Select(x => new OrderListItem
            {
                OrderDescription= x.OrderDescription,
                OrderDate= PersianDateCalender.ToPersian(x.OrderDate),
                OrderID= x.OrderID,
                Address= x.Address, 
                RequiredDate =  PersianDateCalender.ToPersian(x.RequiredDate),
                IsFainaly= x.IsFainaly==false? 1 : 2,
                TotalAmount= x.TotalAmount,
                UserName=Userbuss.GetUser(x.UserID).UserName,
            });
            sm.RecordCount = rc;
            setPager(sm);
            return View(q);

        }
    }
}
