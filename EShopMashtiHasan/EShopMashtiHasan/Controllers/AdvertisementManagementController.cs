using EShopMashtiHasan.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Advertisement;
using System.Collections.Generic;
using System.IO;
using Security.Framework;

namespace EShopMashtiHasan.Controllers
{
    public class AdvertisementManagementController : Controller
    {
        #region Fields

        private readonly IAdvertisementBuss _advertisementBuss;
        private readonly IAdvertisementInSectionBuss _advertisementInSectionBuss;
        private readonly ISectionBuss _sectionBuss;
        private readonly IHostingEnvironment _env;

        #endregion

        #region Ctor

        public AdvertisementManagementController(
            IAdvertisementBuss advertisementBuss,
            IAdvertisementInSectionBuss advertisementInSectionBuss,
            ISectionBuss sectionBuss,
            IHostingEnvironment env)
        {
            _advertisementBuss = advertisementBuss;
            _advertisementInSectionBuss = advertisementInSectionBuss;
            _sectionBuss = sectionBuss;
            _env = env;
        }

        #endregion

        #region Events

        //Advertisement start
        public IActionResult Index()
        {
            var advertisements = _advertisementBuss.GetAll();
            var sections = _sectionBuss.GetAll();
            var advertisementListItems = new List<AdvertisementListItem>();
            foreach (var advertisement in advertisements)
            {
                foreach (var section in sections)
                {
                    var adsInSection = _advertisementInSectionBuss.GetByAdvertisementIdAndSectionId(advertisement.ID, section.ID);
                    var advertisementListItem = new AdvertisementListItem();
                    advertisementListItem.Alt = advertisement.Alt;
                    advertisementListItem.Picture = advertisement.Picture;
                    advertisementListItem.Deleted = advertisement.Deleted;
                    advertisementListItem.ExpireDate = advertisement.ExpireDate;
                    advertisementListItem.AdvertisementId = advertisement.ID;
                    if (adsInSection != null)
                    {
                        advertisementListItem.SectionName = _sectionBuss.Get(adsInSection.SectionId).EnglishName;
                        advertisementListItem.Controller = _sectionBuss.Get(adsInSection.SectionId).ControllerName;
                        advertisementListItem.SectionId = adsInSection.ID;
                        advertisementListItems.Add(advertisementListItem);
                    }
                }

            }
            return View(advertisementListItems);
        }

        public IActionResult AddNew()
        {
            var advertisementAddEditModel = PrepareAdvertisementAddEditModel();

            return View(advertisementAddEditModel);
        }

        public IActionResult Edit()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddEdit(AdvertisementViewModel model)
        {
            if (model.Picture == null)
            {
                TempData["ErrorMesssage"] = "لطفا عکس انتخاب کنید";
                return RedirectToAction("AddNew");
            }
            var fn = System.IO.Path.GetFileName(model.Picture.FileName);
            if (!fn.IsValidFileName())
            {
                TempData["ErrorMesssage"] = "نام فایل صحیح نمیباشد";
                return RedirectToAction("AddNew");
            }

            if (model.Picture.Length < 12000 || model.Picture.Length > 480000)
            {
                TempData["ErrorMesssage"] = "نام فایل صحیح نمیباشد";
                return RedirectToAction("AddNew");
            }
            fn = fn.ToUniqueFileName();
            var path = $"{_env.WebRootPath}/AdvertisementImages/{fn}";
            var dbName = $"~/AdvertisementImages/{fn}";
            FileStream fs = new FileStream(path, FileMode.Create);
            model.Picture.CopyTo(fs);

            var adsAddEditModel = new AdvertisementAddEditModel
            {
                Alt = model.Alt,
                ControllerName = model.ControllerName,
                Deleted = model.Deleted,
                ExpireDate = model.ExpireDate,
                ID = model.ID,
                Picture = dbName,
                SectionName = _sectionBuss.Get(model.SelectedSectionId).EnglishName,
                SectionId = model.SelectedSectionId,
                Position = model.Position,
                Link = model.Link
            };

            if (model == null || model.ID == 0)
            {
                _advertisementBuss.AddNew(adsAddEditModel);
                return RedirectToAction("Index");
            }
            else
            {
                _advertisementBuss.Update(adsAddEditModel);
                return RedirectToAction("Index");
            }
        }

        private AdvertisementViewModel PrepareAdvertisementAddEditModel()
        {
            AdvertisementViewModel advertisementAddEditModel = new AdvertisementViewModel();
            var sections = _sectionBuss.GetAll();
            foreach (var section in sections)
            {
                advertisementAddEditModel.Sections.
                    Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = section.EnglishName, Value = section.ID.ToString() });
            }
            return advertisementAddEditModel;
        }

        #endregion

    }
}