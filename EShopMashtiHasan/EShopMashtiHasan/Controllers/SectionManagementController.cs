using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Advertisement;
using System.Linq;

namespace EShopMashtiHasan.Controllers
{
    public class SectionManagementController : Controller
    {
        #region Fields

        private readonly ISectionBuss _sectionBuss;

        #endregion

        #region ctro

        public SectionManagementController(ISectionBuss sectionBuss)
        {
            _sectionBuss = sectionBuss;
        }

        #endregion

        #region Events

        public IActionResult Index()
        {
            var sections = _sectionBuss.GetAll();
            var sectionListItem = sections.Select(x=>new SectionListItem {
                ControllerName = x.ControllerName,
                SectionID=x.ID,
                SectionName = x.EnglishName
            });
            return View(sectionListItem);
        }

        public IActionResult AddNew() 
        {
            return View();
        }

        public IActionResult Edit() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEdit(SectionAddEditModel model) 
        {
            if (ModelState.IsValid) 
            {
                if (model.SectionID == 0)
                {
                    _sectionBuss.AddNew(model);
                    return View("/Views/SectionManagement/AddNew.cshtml");
                }
                else 
                {
                    _sectionBuss.Update(model);
                    return Edit();
                }
            }
            return Edit();
        }

        #endregion

    }
}
