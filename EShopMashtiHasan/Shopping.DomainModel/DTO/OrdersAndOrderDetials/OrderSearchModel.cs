using Framework.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.OrdersAndOrderDetials
{
    public class OrderSearchModel:PageModel
    {
        public int OrderID { get; set; }
        public string Mobile { get; set; }
    }
}
