
using System.ComponentModel.DataAnnotations;


namespace Shopping.DomainModel.DTO.Supplier
{
   public class SupplierAddEditModel
    {
        //[Range(1,1000,ErrorMessage = "")]
        public int SupplierID { get; set; }
        [Required(ErrorMessage ="نام را وارد کنید")]
        [Display(Name = "نام تامین کننده")]
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "ادرس را وارد کنید")]
        [StringLength(400,ErrorMessage = "حداقل 10 تا حد اکثر 400 تا", MinimumLength =10)]
        public string Address { get; set; }
        //[RegularExpression(@"^[آ-ی]{1,40}$",
        //    ErrorMessage = "Characters are not allowed.")]
        public string Mobile { get; set; }
        public string Tel { get; set; }

    }
}
