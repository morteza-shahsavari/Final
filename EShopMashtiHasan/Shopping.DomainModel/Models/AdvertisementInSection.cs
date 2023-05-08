using System.ComponentModel.DataAnnotations;

namespace Shopping.DomainModel.Models
{
    public class AdvertisementInSection
    {
        public int ID { get; set; }

        public int AdvertisementId { get; set; }

        public int SectionId { get; set; }

        [StringLength(50)]
        public string ResourceTitle { get; set; }

        public int ResourceId { get; set; }

        public int Position { get; set; }

        public virtual Advertisement Advertisement { get; set; }

        public virtual Section Section { get; set; }
    }
}
