

using EShopMashtiHasan.ViewModel;

namespace EShopMashtiHasan.Helper
{
   public interface ISessionHelper
   {
       void AddCurrentUserToSession(CurrentUser user);
       void RemoveCurrenrtFromSession(string Key);
        CurrentUser GetCurrentUser();

        //basket start

        void AddCurrentBasketToSession(Basket basket);
        void RemoveCurrentBasketFromSession(string Key);
        Basket GetCurrentBasket();

        //basketend

   }
}
