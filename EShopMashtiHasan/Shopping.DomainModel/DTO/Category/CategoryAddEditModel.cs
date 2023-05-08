using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.Category
{
   public class CategoryAddEditModel
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="*")]
        [Display(Name = "نام رده")]
        public string CategoryName { get; set; }
        [StringLength(100,MinimumLength = 0,ErrorMessage = "توضیح حداکثر 100 حرف")]
        public string SmallDescription { get; set; }
        public int? ParentID { get; set; }
        
    }
}
