#pragma checksum "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "582edb7bf3305e23b87f418643a1c43d21cd0226"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CartDropdown_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CartDropdown/Default.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\_ViewImports.cshtml"
using EShopMashtiHasan;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\_ViewImports.cshtml"
using EShopMashtiHasan.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\_ViewImports.cshtml"
using Shopping.DomainModel.ViewModel.Categories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\_ViewImports.cshtml"
using Shopping.DomainModel.ViewModel.Advertisement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\_ViewImports.cshtml"
using Shopping.DomainModel.DTO.Category;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\_ViewImports.cshtml"
using Shopping.DomainModel.DTO.Product;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\_ViewImports.cshtml"
using Shopping.DomainModel.DTO.Advertisement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\_ViewImports.cshtml"
using EShopMashtiHasan.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\_ViewImports.cshtml"
using Shopping.DomainModel.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\_ViewImports.cshtml"
using Shopping.DomainModel.ViewModel.Orders;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"582edb7bf3305e23b87f418643a1c43d21cd0226", @"/Views/Shared/Components/CartDropdown/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"365fcd668b1a44b72fbdeab2b6f10aa1c82e22c0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_CartDropdown_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CartDropdownList>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
  
    
    var count = Model.CartDropdownListItems.Sum(x => x.OrderCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n <div class=\"cart dropdown cartdropdown\" id=\"cartdropdown\">\r\n    <a href=\"#\" class=\"btn dropdown-toggle\" data-toggle=\"dropdown\" id=\"navbarDropdownMenuLink1\" >\r\n                            <img src=\"/assets/img/shopping-cart.png\"");
            BeginWriteAttribute("alt", " alt=\"", 337, "\"", 343, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            سبد خرید\r\n\r\n\r\n<span class=\"count-cart\"");
            BeginWriteAttribute("id", " id=\"", 413, "\"", 418, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 13 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
                          Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
   </a>
    <ul class=""dropdown-menu "" id=""cartdropdownul"" aria-labelledby=""navbarDropdownMenuLink1"">
        <div class=""basket-header"">
            <div class=""basket-total"">
                <span>مبلغ کل خرید:</span>
                <span id=""TotalAmount""> ");
#nullable restore
#line 19 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
                                   Write(Model.TotalAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                <span> تومان</span>
            </div>
            <a href=""/Orders/OrdersDetails"" class=""basket-link"">
                <span>مشاهده سبد خرید</span>
                <div class=""basket-arrow""></div>
            </a>
        </div>
        <ul class=""basket-list"">
            <li>
");
#nullable restore
#line 29 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
                 foreach (var item in Model.CartDropdownListItems)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 1141, "\"", 1212, 1);
#nullable restore
#line 31 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
WriteAttributeValue("", 1148, Url.Action("ProductDetails","Product",new{id = item.ProductId}), 1148, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"basket-item\">\r\n                        <button class=\"basket-item-remove\" data-productId=\"");
#nullable restore
#line 32 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
                                                                      Write(item.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></button>\r\n                        <div class=\"basket-item-content\">\r\n                            \r\n                            <div class=\"basket-item-image\">\r\n                                <img");
            BeginWriteAttribute("alt", " alt=\"", 1525, "\"", 1531, 0);
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 1532, "\"", 1562, 1);
#nullable restore
#line 36 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
WriteAttributeValue("", 1538, Url.Content(item.Image), 1538, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                              \r\n                            </div>\r\n\r\n\r\n                            <div class=\"btnQuntity\">\r\n                                <button class=\"btnplus plus\" data-productid=");
#nullable restore
#line 43 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
                                                                       Write(item.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            WriteLiteral(">\r\n                                    <i class=\"fa fa-plus btnQuntityi \" aria-hidden=\"true\"></i>\r\n                                </button>\r\n                                <span class=\"btnQuntity\">");
#nullable restore
#line 46 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
                                                    Write(item.OrderCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <button class=\"btnminus minus\" data-productid=");
#nullable restore
#line 47 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
                                                                         Write(item.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            WriteLiteral(@">
                                    <i class=""fa fa-minus btnQuntityi"" aria-hidden=""true""></i>
                                </button>
                            </div>


                            <div class=""basket-item-details"">
                                <div class=""basket-item-title"">
                                    ");
#nullable restore
#line 55 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
                               Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span  class=\"badge\">");
#nullable restore
#line 55 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
                                                                      Write(item.OrderCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </a>\r\n");
#nullable restore
#line 60 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </li>\r\n        </ul>\r\n");
#nullable restore
#line 63 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
         if (!User.Identity.IsAuthenticated)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a href=\"/Account/Login\" class=\"basket-submit\">ورود و ثبت سفارش</a>\r\n");
#nullable restore
#line 66 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Shared\Components\CartDropdown\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CartDropdownList> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
