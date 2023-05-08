using Shopping.DomainModel.DTO.Supplier;
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "SupplierList")]
    public class SupplierListViewComponent:ViewComponent
    {
        private readonly ISupplierBuss buss;
        public SupplierListViewComponent(ISupplierBuss buss)
        {
            this.buss= buss;
        }
        private void setPager(SupplierSearchModel sm)
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
        public IViewComponentResult Invoke(SupplierSearchModel sm)
        {
            
            int rc = 0;
            if (sm == null || sm.PageSize == 0)
            {
                // sm = new CategorySearchModel {PageSize = 10};
                sm.PageSize = 10;

            }
            var sup = buss.Search(sm, out rc);
            sm.RecordCount = rc;
            setPager(sm);
            return View(sup);
        }

    }
}
