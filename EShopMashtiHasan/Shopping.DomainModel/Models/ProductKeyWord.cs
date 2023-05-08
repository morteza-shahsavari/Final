using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Shopping.DomainModel.Models
{
   public class ProductKeyWord
    {
        public int ProductKeyWordID { get; set; }
        public int ProductID { get; set; }
        public int KeywordID { get; set; }
        public Product Product { get; set; }
        public KeyWord KeyWord { get; set; }
    }
}
