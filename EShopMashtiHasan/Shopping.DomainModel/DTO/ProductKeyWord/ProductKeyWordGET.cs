using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.ProductKeyWord
{
    public class ProductKeyWordGET
    {
        public string KeyWordText { get; set; }
        public string ProductName { get; set; }
        public int ProductKeyWordID { get; set; }
        public int ProductID { get; set; }
    }
}
