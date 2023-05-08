using System.ComponentModel.DataAnnotations;
using System;

namespace Shopping.DomainModel.DTO.Advertisement
{
    public class AdvertisementAddEditModel
    {
        #region Fields
        public int ID { get; set; }

        public int SectionId{ get; set; }

        public int Position { get; set; }

        public string Alt { get; set; }

        [Required(ErrorMessage = "عکس الزامی میباشد")]
        [StringLength(500)]
        public string Picture { get; set; }

        public bool Deleted { get; set; }

        [Required(ErrorMessage = "مدت زمان نمایش الزامی می باشد")]
        [Display(Name = "مدت زمان نمایش")]
        public DateTime ExpireDate { get; set; }

        [Display(Name = "بخش قابل نمایش")]
        [Required(ErrorMessage = "وارد کردن نام بخش قابل نمایش اجباری است")]
        public string SectionName { get; set; }

        public string Link { get; set; }
        public string ControllerName { get; set; }

        #endregion

    }
}