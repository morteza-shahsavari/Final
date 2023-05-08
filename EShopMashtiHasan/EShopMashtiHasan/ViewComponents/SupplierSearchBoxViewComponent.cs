using Shopping.DomainModel.DTO.Supplier;
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "SupplierSearchBox")]
    public class SupplierSearchBoxViewComponent:ViewComponent
    {
        private ISupplierBuss buss;
        public SupplierSearchBoxViewComponent(ISupplierBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(Shopping.DomainModel.DTO.Supplier.SupplierSearchModel sm)
        {
            return View(sm);
        }
    }
}
