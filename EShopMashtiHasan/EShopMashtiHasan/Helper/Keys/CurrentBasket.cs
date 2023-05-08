

using EShopMashtiHasan.ViewModel;

using System.Collections.Generic;

namespace EShopMashtiHasan.Helper.Keys
{
    public class CurrentBasket
    {
        private readonly ISessionHelper sessionHelper;
        public CurrentBasket(ISessionHelper sessionHelper,
            Basket basket)
        {
            this.sessionHelper = sessionHelper;
            MyBasket = basket;
        }

        public Basket MyBasket
        {
            get
            {
               return sessionHelper.GetCurrentBasket();
            }
             
            set
            {//mire to session set mikone

                sessionHelper.AddCurrentBasketToSession(value);
            }
        }
    }
}