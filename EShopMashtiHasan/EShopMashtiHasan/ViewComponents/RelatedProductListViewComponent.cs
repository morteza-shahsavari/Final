using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.RelatedProduct;


namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RelatedProductList")]
    public class RelatedProductListViewComponent:ViewComponent
    {


            private readonly IProductBuss buss;
            public RelatedProductListViewComponent(IProductBuss buss)
            {
                this.buss = buss;
            }
            private void setPager(RelatedProductsearchAddModel sm)
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
            public IViewComponentResult Invoke(RelatedProductsearchAddModel sm)
            {
                int rc = 0;

                if (sm == null || sm.PageSize == 0) { sm.PageSize = 10; }


                var PA = buss.searchRelated(sm, out rc);
                sm.RecordCount = rc;
                setPager(sm);
                return View(PA);

            }
        }






}





