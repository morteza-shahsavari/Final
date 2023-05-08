using EShopMashtiHasan.Helper.Keys;
using EShopMashtiHasan.ViewModel;

using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

namespace EShopMashtiHasan.Helper
{
    public class SessionHelper : ISessionHelper
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void AddCurrentUserToSession(CurrentUser user)
        {
            // var key = "my-key";
            var str = JsonConvert.SerializeObject(user);
            httpContextAccessor.HttpContext.Session.SetString(SessionKeys.CurrentUserKey, str);


        }

        public void RemoveCurrenrtFromSession(string Key)
        {
            httpContextAccessor.HttpContext.Session.Remove(Key);
        }

        public CurrentUser GetCurrentUser()
        {
            var str = httpContextAccessor.HttpContext.Session.GetString(SessionKeys.CurrentUserKey);
            var currentUser = JsonConvert.DeserializeObject<CurrentUser>(str);
            return currentUser;
        }

        //Basket start

        public void AddCurrentBasketToSession(Basket basket)
        {
            var str = JsonConvert.SerializeObject(basket);
            httpContextAccessor.HttpContext.Session.SetString(SessionKeys.CurrentBasketKey, str);
        }

        public void RemoveCurrentBasketFromSession(string Key)
        {
            httpContextAccessor.HttpContext.Session.Remove(Key);
        }

        public Basket GetCurrentBasket()

        {
            var str = httpContextAccessor.HttpContext.Session.GetString(SessionKeys.CurrentBasketKey);
            if (str == null || string.IsNullOrEmpty(str))
            {
                var basket = new Basket();
                AddCurrentBasketToSession(basket);
                str = httpContextAccessor.HttpContext.Session.GetString(SessionKeys.CurrentBasketKey);
                return JsonConvert.DeserializeObject<Basket>(str);
            }
            else
            {
                var currentBasket = JsonConvert.DeserializeObject<Basket>(str);
                return currentBasket;
            }
        }

        //Basket End
    }
}
