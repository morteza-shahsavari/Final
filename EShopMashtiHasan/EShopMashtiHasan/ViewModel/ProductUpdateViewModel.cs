using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;

namespace EShopMashtiHasan.ViewModel
{
    public class ProductUpdateViewModel
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "نام محصول را وارد کنید")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "قیمت محصول را وارد کنید")]
        public int UnitPrice { get; set; }
        [Required(ErrorMessage = "توضیحات محصول را وارد کنید")]
        public string SmallDescription { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "سازنده محصول را وارد کنید")]
        public int SupplierID { get; set; }
        [Required(ErrorMessage = "دسته بندی محصول را وارد کنید")]
        public int CategoryID { get; set; }
        public IFormFile Picture1 { get; set; }
        public IFormFile Picture2 { get; set; }

    }
}
