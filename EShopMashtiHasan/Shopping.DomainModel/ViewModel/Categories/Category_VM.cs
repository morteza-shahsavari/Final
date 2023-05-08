using System.Collections.Generic;

namespace Shopping.DomainModel.ViewModel.Categories
{
    public class Category_VM
    {
        public int ChildId { get; set; }
        public string ChildName { get; set; }
        public bool HaveSubCategory { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public bool IsMobileDevice { get; set; }
        public List<Category_VM> SubCategories{ get; set; }
    }
}
