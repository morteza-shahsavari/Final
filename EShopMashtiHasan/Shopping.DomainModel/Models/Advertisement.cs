using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shopping.DomainModel.Models
{
    public class Advertisement
    {
        #region Ctro

        public Advertisement()
        {
            AdvertisementInSections = new HashSet<AdvertisementInSection>();
        }

        #endregion
        public int ID { get; set; }

        public string Alt { get; set; }

        [StringLength(500)]
        public string Picture { get; set; }

        public bool Deleted { get; set; }

        public DateTime ExpireDate{ get; set; }

        public string link { get; set; }

        public virtual ICollection<AdvertisementInSection> AdvertisementInSections { get; set; }

    }
}
