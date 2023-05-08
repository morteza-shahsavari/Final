

using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.Models;
using Shopping.DomainModel.ViewModel.Advertisement;
using System.Collections.Generic;
using System.Linq;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "WidgetSidebarBanner")]
    public class WidgetSidebarBannerViewComponent : ViewComponent
    {
        #region Fields

        private readonly IAdvertisementBuss _advertisementBuss;
        private readonly ISectionBuss _sectionBuss;
        private readonly IAdvertisementInSectionBuss _advertisementInSectionBuss;
        #endregion

        #region Ctor

        public WidgetSidebarBannerViewComponent(IAdvertisementBuss advertisementBuss, IAdvertisementInSectionBuss advertisementInSectionBuss, ISectionBuss sectionBuss)
        {
            _advertisementBuss = advertisementBuss;
            _advertisementInSectionBuss = advertisementInSectionBuss;
            _sectionBuss = sectionBuss;
        }

        #endregion

        #region Evenets

        public IViewComponentResult Invoke()
        {
            var SECTIONNAME = Utility.Constants.SidebarBanners;
            var section = _sectionBuss.GetBySectionName(SECTIONNAME);
            var advertisementInsections = new List<AdvertisementInSection>();
            List<Advertisment_VM> advertisementViewModels = new List<Advertisment_VM>();
            if (section != null)
            {
                advertisementInsections = _advertisementInSectionBuss.GetBySectionId(section.ID).OrderBy(x => x.Position).ToList();
                foreach (var advertisementInsection in advertisementInsections)
                {
                    var advertisements = _advertisementBuss.GetAll().Where(x => x.ID == advertisementInsection.AdvertisementId).ToList();
                    foreach (var advertisement in advertisements)
                    {
                        var advertisementViewModel = new Advertisment_VM();
                        advertisementViewModel.Alt = advertisement.Alt;
                        advertisementViewModel.Picture = advertisement.Picture;
                        advertisementViewModel.Link = advertisement.link;
                        advertisementViewModels.Add(advertisementViewModel);
                    }
                }
            }
            return View(advertisementViewModels);
        }

        #endregion
    }
}
