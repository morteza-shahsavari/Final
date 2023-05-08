using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.CategoryFeature;
using Shopping.DomainModel.DTO.OrdersAndOrderDetials;
using Shopping.DomainModel.Models;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace EShopMashtiHasan.Controllers
{
    public class OrdersAdminController : Controller
    {
        private readonly IOrderBuss buss;
        public OrdersAdminController(IOrderBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(OrderSearchModel sm)
        {
            return View(sm);
        }

        public IActionResult OrderAdminSearchBox(OrderSearchModel sm)
        {
            return ViewComponent("OrderAdminSearchBox", sm);
        }

        public IActionResult OrderAdminList(OrderSearchModel sm)
        {

            return ViewComponent("OrderAdminList", sm);


        }

        public IActionResult OrderDetailsAdmin(int id)
        {
            var q = buss.GetAllOrderDetailsListByOrderId(id);

            return View(q);
        }



        [HttpPost]
        public JsonResult UpdateIsFainaly(int id, int IsFainaly)
        {
            var q = false;
            if (IsFainaly == 2)
            {
                q = true;
            }
            

            return Json(buss.UpdateIsFainaly(id, q));
        }

    }
}
