#pragma checksum "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\RoleActionManagement\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77738638d1765cd2a6712419f30e23441e2c0b03"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RoleActionManagement_Index), @"mvc.1.0.view", @"/Views/RoleActionManagement/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77738638d1765cd2a6712419f30e23441e2c0b03", @"/Views/RoleActionManagement/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"365fcd668b1a44b72fbdeab2b6f10aa1c82e22c0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_RoleActionManagement_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Security.Domain.DTO.RoleAction.RoleActionSearchModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\RoleActionManagement\Index.cshtml"
  
    ViewData["Title"] = "دسترسی ها";
    Layout = "~/Views/Shared/_PanelAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("  <div class=\"IndexPagePanel\">\r\n    <div id=\"dvSearch\" class=\"DvSearch\">\r\n    ");
#nullable restore
#line 10 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\RoleActionManagement\Index.cshtml"
Write(await Component.InvokeAsync("RoleActionSearchBox",this.Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n    <div id=\"dvGrid\" class=\"ListBox\">\r\n    ");
#nullable restore
#line 14 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\RoleActionManagement\Index.cshtml"
Write(await Component.InvokeAsync("RoleActionList",this.Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Security.Domain.DTO.RoleAction.RoleActionSearchModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
