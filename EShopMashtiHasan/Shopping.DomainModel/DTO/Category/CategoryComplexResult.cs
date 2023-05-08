using Framework.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.Category
{
    public class CategoryComplexResult : IComplexObjectResult<List<CategoryListItem>, List<string>>
    {
        private List<CategoryListItem> mainResults;
        public List<CategoryListItem> MainResults {
            get 
            { return this.mainResults;
            }
            set
            {
                this.mainResults = value;
            }  
        }
        private List<string> errors;
        public List<string> Errors
        {
            get { return this.errors; }
            set { this.errors = value; }
        }
    }
}
