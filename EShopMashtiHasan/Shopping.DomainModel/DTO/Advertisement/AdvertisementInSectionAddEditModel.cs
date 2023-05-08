using System.ComponentModel.DataAnnotations;

namespace Shopping.DomainModel.DTO.Advertisement
{
    public class AdvertisementInSectionAddEditModel
    {
        public int ID { get; set; }

        public int AdvertisementId { get; set; }

        public int SectionId { get; set; }

        [StringLength(50)]
        public string ResourceTitle { get; set; }

        public int ResourceId { get; set; }

        public int Position { get; set; }
    }
}
