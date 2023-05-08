using Framework.BaseModel;
using System.Collections.Generic;

namespace Shopping.DomainModel.DTO.Product
{
    public class ProductComplexResult : IComplexObjectResult<List<ProductListItem>, List<string>>
    {
        private List<ProductListItem> mainResults;

        public List<ProductListItem> MainResults
        {
            get { return this.mainResults; }
            set { this.mainResults = value; }
        }

        private List<string> errors;

        public List<string> Errors
        {
            get { return this.errors; }
            set { this.errors = value; }
        }
    }
}
