
using Framework.BaseModel;
using Shopping.DomainModel.ViewModel.Categories;

using System.Collections.Generic;

namespace Shopping.DomainModel.DTO.Category
{
    public class CategorySearchModel : PageModel
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int? ParentID { get; set; }

        public string ParentName { get; set; }

        public bool IsMobileDevice { get; set; }

        public bool HaveChildrens { get; set; }

        public OrderByType OrderBy { get; set; }

        public List<CategorySearchModel> SubCategories { get; set; }
    }
}
