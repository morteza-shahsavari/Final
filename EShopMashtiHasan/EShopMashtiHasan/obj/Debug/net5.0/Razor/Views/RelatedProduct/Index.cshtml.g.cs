#pragma checksum "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\RelatedProduct\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df29d0cb5dd0ca5681e0790ba0c1272228949d37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RelatedProduct_Index), @"mvc.1.0.view", @"/Views/RelatedProduct/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df29d0cb5dd0ca5681e0790ba0c1272228949d37", @"/Views/RelatedProduct/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"365fcd668b1a44b72fbdeab2b6f10aa1c82e22c0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_RelatedProduct_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Shopping.DomainModel.DTO.RelatedProduct.RelatedProductsearchAddModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\RelatedProduct\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_PanelAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"IndexPagePanel\">\r\n    <div id=\"dvSearch\" class=\"DvSearch\">\r\n        ");
#nullable restore
#line 10 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\RelatedProduct\Index.cshtml"
   Write(await Component.InvokeAsync("RelatedProductSearchBox",this.Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div id=\"dvGrid\" class=\"ListBox\">\r\n        ");
#nullable restore
#line 14 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\RelatedProduct\Index.cshtml"
   Write(await Component.InvokeAsync("RelatedProductList",this.Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n<script>\r\n\r\n    $(\"#RelatedToID\").select2({\r\n\r\n        ajax: {\r\n            url: \'");
#nullable restore
#line 24 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\RelatedProduct\Index.cshtml"
             Write(Url.Action("GetRelated", "RelatedProduct"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            data: function (params) {
                var query = {
                    search: params.term,
                    type: 'public'
                }
                // Query parameters will be ?search=[term]&type=public
                return query;
            }
        }

        ,

        tags: true,
       
        multiple: true,

        placeholder: {
            id: ""-1"",
            text: ""کالاهای مشابه را انتخاب نمایید "",
        }
        ,
        allowClear: true,
       
        tokenSeparators: [',', ' '], dir: ""rtl""

    });



    $(document).on(""click"", ""#btnAddNewRoot"", function () {
        var actionBind = $(this).attr(""data-action-BindGrid"");
        RelatedTo = $(""#RelatedToID"").select2('val')
        var id = parseInt($(""#ProductID"").val());
        var url = '");
#nullable restore
#line 58 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\RelatedProduct\Index.cshtml"
              Write(Url.Action("AddRelatedToProduct","RelatedProduct"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
        $.post(url, { RelatedTo: RelatedTo, ""id"": id }, function (op) {
            if (op.success.toString() == ""true"") {
                ShowSuccessMessage(op.message);
                BindKey(actionBind);
            }
        });
    });


    function BindKey(url) {
        var SendingData = $(""#frmAddnewRoot"").serialize();
        $.get(url, SendingData, function (grd) {
            $(""#dvGrid"").html(grd);
        });
    }



    $(document).on(""click"", ""[data-Delete='DeleteKey']"", function () {
        var actionBind = $(this).attr(""data-action-BindGrid"");
        var actionRefresh = $(this).attr(""data-action-RefreshGrid"");
        if (confirm(""آیا مطمنید"")) {
            var id = $(this).attr(""data-id"");
            var sendingData = ""id="" + id;
            var sendingUrl = $(this).attr(""data-action"");
            $.post(sendingUrl, sendingData, function (op) {
                if (op.success.toString() == ""true"") {
                    var rowID = ""#tr_"" + id;
         ");
            WriteLiteral("           $(rowID).slideUp(500);\r\n                    BindKey(actionBind);\r\n                }\r\n                else {\r\n                    ErrorMessage(op.message);\r\n                }\r\n            });\r\n        }\r\n\r\n    });\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Shopping.DomainModel.DTO.RelatedProduct.RelatedProductsearchAddModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
