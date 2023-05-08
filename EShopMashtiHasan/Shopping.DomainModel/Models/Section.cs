using System.Collections.Generic;

namespace Shopping.DomainModel.Models
{
    public class Section
    {
        #region Ctor

        public Section()
        {
            AdvertisementInSections = new HashSet<AdvertisementInSection>();
        }

        #endregion

        #region Fields

        public int ID { get; set; }

        public string EnglishName { get; set; }

        public string FarsiName { get; set; }

        public string ControllerName { get; set; }

        public virtual ICollection<AdvertisementInSection> AdvertisementInSections { get; set; }

        #endregion

    }
}
