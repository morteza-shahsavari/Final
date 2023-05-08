using Framework.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.Supplier
{
   public class SupplierComplexResult:IComplexObjectResult< List<SupplierListItem>,List<string>>
    {
        public List<SupplierListItem> MainResults { get; set; }
        public List<string> Errors { get; set; }
    }
}
