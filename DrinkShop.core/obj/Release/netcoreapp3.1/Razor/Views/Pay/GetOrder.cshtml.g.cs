#pragma checksum "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "182835e9c1a8f8a1392eb102907138a7d266ba5f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pay_GetOrder), @"mvc.1.0.view", @"/Views/Pay/GetOrder.cshtml")]
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
#line 1 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\_ViewImports.cshtml"
using DrinkShop.core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\_ViewImports.cshtml"
using DrinkShop.core.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"182835e9c1a8f8a1392eb102907138a7d266ba5f", @"/Views/Pay/GetOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86c5e1df755f300f1a0fdead3945ab7b0a7a0421", @"/Views/_ViewImports.cshtml")]
    public class Views_Pay_GetOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DrinkShop.core.ViewModels.ResponseItems>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml"
  
    ViewData["Title"] = "GetOrder";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>GetOrder</h1>\r\n\r\n");
            WriteLiteral("\r\n<h3>總金額:");
#nullable restore
#line 10 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml"
   Write(Model.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n<h4>建立時間：");
#nullable restore
#line 12 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml"
    Write(ViewBag.time);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 13 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml"
  
    if (ViewBag.payTime != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h4>付款狀態：已付款</h4>\r\n        <h4>付款時間：");
#nullable restore
#line 17 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml"
            Write(ViewBag.payTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 18 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h4>付款狀態：未付款</h4>\r\n");
#nullable restore
#line 22 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br />
<h3>訂單內容</h3>
<table class=""table table-bordered"">
    <tr>
        <td style=""text-align: center;"">項目</td>
        <td style=""text-align: center;"">數量</td>
        <td style=""text-align: center;"">內容</td>
        <td style=""text-align: center;"">金額</td>
    </tr>
");
#nullable restore
#line 33 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml"
      
        foreach (var i in Model.Items)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 37 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml"
               Write(i.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 38 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml"
               Write(i.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 39 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml"
               Write(string.Format("{0}, {1}, {2}", i.Size, i.Sweetness, i.Ice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 40 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml"
               Write(i.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 42 "C:\Users\user\source\repos\DrinkShop\DrinkShop.core\Views\Pay\GetOrder.cshtml"

        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DrinkShop.core.ViewModels.ResponseItems> Html { get; private set; }
    }
}
#pragma warning restore 1591