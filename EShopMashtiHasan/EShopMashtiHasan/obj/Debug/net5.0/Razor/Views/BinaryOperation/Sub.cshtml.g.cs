#pragma checksum "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\BinaryOperation\Sub.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59f51ad88adee155fc1b7f2de5e0a691e7880602"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BinaryOperation_Sub), @"mvc.1.0.view", @"/Views/BinaryOperation/Sub.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59f51ad88adee155fc1b7f2de5e0a691e7880602", @"/Views/BinaryOperation/Sub.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"365fcd668b1a44b72fbdeab2b6f10aa1c82e22c0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_BinaryOperation_Sub : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EShopMashtiHasan.Models.Numbers>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\BinaryOperation\Sub.cshtml"
 using (@Html.BeginForm("MakeSub","BinaryOperation",FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<table>\r\n    <tr>\r\n        <td>FirstNumber</td>\r\n        <td>\r\n           ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "59f51ad88adee155fc1b7f2de5e0a691e78806025904", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 8 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\BinaryOperation\Sub.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.FirstNumber);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n    <tr>\r\n        <td>Second Number</td>\r\n        <td>\r\n            ");
#nullable restore
#line 14 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\BinaryOperation\Sub.cshtml"
       Write(Html.TextBoxFor(x => x.SecondNumber, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n    <tr>\r\n        <td>\r\n            <input type=\"submit\" name=\"name\" value=\"Sub\" class=\"btn btn-primary\"/>\r\n        </td>\r\n    </tr>\r\n</table>   \r\n");
#nullable restore
#line 23 "C:\Users\mori\Desktop\morteza\EShopMashtiHasan\EShopMashtiHasan\Views\BinaryOperation\Sub.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EShopMashtiHasan.Models.Numbers> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
