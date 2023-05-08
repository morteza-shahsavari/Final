using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EShopMashtiHasan.ViewModel
{

    public class AdvertisementViewModel
    {
        public AdvertisementViewModel()
        {
            Sections = new List<SelectListItem>();
        }
        public int ID { get; set; }

        public int SelectedSectionId{ get; set; }
     
        public string Alt { get; set; }

        public IFormFile Picture { get; set; }

        public bool Deleted { get; set; }

        public DateTime ExpireDate { get; set; }

        public string SectionName { get; set; }

        public string ControllerName { get; set; }

        public string Link { get; set; }

        public int Position { get; set; }
        public IList<SelectListItem> Sections { get; set; }
    }
}