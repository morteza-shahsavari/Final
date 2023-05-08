using System.Collections.Generic;

namespace Shopping.DomainModel.ViewModel
{
    public class ProductsDtailsViewModel
    {
        #region Ctor

        public ProductsDtailsViewModel()
        {
            FeatureViewModels = new List<FeatureViewModel>();
        }

        #endregion
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public double UnitPice { get; set; }
        public string  SmallDescription  { get; set; }
        public string  Description  { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
        public string Picture { get; set; }
        public IList<FeatureViewModel> FeatureViewModels { get; set; }
    }
}
