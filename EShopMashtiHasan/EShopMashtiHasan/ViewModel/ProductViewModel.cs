using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EShopMashtiHasan.ViewModel
{
    public class ProductViewModel
    {
        #region ctor

        public ProductViewModel()
        {
            Features = new List<SelectListItem>();
            Categories = new List<SelectListItem>();
            Supplires = new List<SelectListItem>();
        }

        #endregion

        //public IFormFile Image { get; set; }
        [Required(ErrorMessage = "نام محصول را وارد کنید")]
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string SmallDescription { get; set; }
        public string Description { get; set; }
        public int SelectedSupplierID { get; set; }
        public int SelectedCategoryID { get; set; }
        public IFormFile Picture1 { get; set; }
        public IFormFile Picture2 { get; set; }
        public bool ShowInAmazingOffer { get; set; }
        public bool ShowInInstantOffer { get; set; }
        public DateTime? ExpireDateSpecialOffer { get; set; }
        public string ProductFeatureValue { get; set; }
        public int SelectedFeatureId { get; set; }
        public bool IsNew { get; set; }
        public IList<SelectListItem> Features{ get; set; }
        public IList<SelectListItem> Categories{ get; set; }
        public IList<SelectListItem> Supplires{ get; set; }
    }
}
