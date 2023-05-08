using System.Collections.Generic;

namespace Shopping.DomainModel.Models
{
    public class KeyWord
    {
        public int KeyWordID { get; set; }
        public string KeyWordText { get; set; }
        public ICollection<ProductKeyWord> ProductKeyWords { get; set; }

        public KeyWord()
        {
            this.ProductKeyWords = new List<ProductKeyWord>();
        }
    }
}
