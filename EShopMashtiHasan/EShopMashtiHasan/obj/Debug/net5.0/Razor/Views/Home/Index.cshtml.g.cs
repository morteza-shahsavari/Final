#pragma checksum "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c33b118a539d5b1e75f0af34d123c54af365b76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c33b118a539d5b1e75f0af34d123c54af365b76", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"365fcd668b1a44b72fbdeab2b6f10aa1c82e22c0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Shopping.DomainModel.ViewModel.Categories.CategoryProductListItem>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
  
    var cu = (Security.Domain.DTO.User.UserInfo )TempData["cu"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<main class=""main default"">
    <div class=""container"">
        <div class=""row"">
            <aside class=""sidebar col-12 col-lg-3 order-2 order-lg-1"">
                <div class=""sidebar-inner default"">
                    <div class=""widget-banner widget card"">
                        <a href=""/"" target=""_top"">
                            <img class=""img-fluid"" src=""assets/img/banner/1455.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 645, "\"", 651, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </a>\r\n                    </div>\r\n                    ");
#nullable restore
#line 19 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
               Write(await Html.PartialAsync("_ServiceIntroduction"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 21 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
                     if (Model.Products.Any(x => x.ShowInInstantOffer))
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
                   Write(await Component.InvokeAsync("WidgetSuggestion"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
                                                                        
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
#nullable restore
#line 25 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
               Write(await Component.InvokeAsync("WidgetSidebarBanner"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </aside>\r\n            <div class=\"col-12 col-lg-9 order-1 order-lg-2\">\r\n");
#nullable restore
#line 29 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
                 if (Model.Products.Any(x => x.ShowInAmazingOffer))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
               Write(await Component.InvokeAsync("AmazingOffer"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
                                                                
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 34 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
           Write(await Component.InvokeAsync("ProductCategories"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 35 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
                 if (Model.Products.Any(x => x.IsNew))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
               Write(await Component.InvokeAsync("NewProducts"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
                                                               
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 40 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
                 if (Model.Products.Any(x => x.UnitPrice < 500000 && x.UnitPrice > 5000000))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
               Write(await Component.InvokeAsync("SuggestedProducts"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
                                                                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 45 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\Home\Index.cshtml"
           Write(await Component.InvokeAsync("LatestProducts"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"row\"></div>\r\n    </div>\r\n\r\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Shopping.DomainModel.ViewModel.Categories.CategoryProductListItem> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591