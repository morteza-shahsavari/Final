
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.KeyWord;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "KeyWordSearchBox")]
    public class KeyWordSearchBoxViewComponent:ViewComponent
    {
        private readonly IKeyWordBuss buss;
        public KeyWordSearchBoxViewComponent(IKeyWordBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(KeyWordSearchModel sm)
        {
            return View(sm);
        }
    }
}
