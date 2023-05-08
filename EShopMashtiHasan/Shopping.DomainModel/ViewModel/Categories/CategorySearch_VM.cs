
using Framework.BaseModel;
using System.Collections.Generic;

namespace Shopping.DomainModel.ViewModel.Categories
{
    public class CategorySearch_VM: PageModel
    {
        public string CategoryName { get; set; }
        public bool IsMobileDevice { get; set; }
        public int Productcount { get; set; }
        public string SortName { get; set; }
        public OrderByType OrderBy { get; set; }
        public ICollection<CategoryProductListItem> CategoryProductListItems { get; set; }
    }
}
