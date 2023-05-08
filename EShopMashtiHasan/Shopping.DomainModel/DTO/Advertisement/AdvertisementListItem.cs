using System;

namespace Shopping.DomainModel.DTO.Advertisement
{
    public class AdvertisementListItem
    {
        public int AdvertisementId { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string Picture { get; set; }
        public bool Deleted { get; set; }
        public string Controller { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Alt { get; set; }
    }
}
