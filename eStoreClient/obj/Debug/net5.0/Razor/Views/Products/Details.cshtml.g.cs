#pragma checksum "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6ea6b584430a87110a27be0c25bd5c7444ec144"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Details), @"mvc.1.0.view", @"/Views/Products/Details.cshtml")]
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
#line 1 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\_ViewImports.cshtml"
using eStoreClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\_ViewImports.cshtml"
using eStoreClient.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6ea6b584430a87110a27be0c25bd5c7444ec144", @"/Views/Products/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1191b10e7ddfea7b122988f3ef83a70f0660f8d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Products_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BusinessObject.Product>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
  
    ViewData["Title"] = "Details";
    var role = Context.Session.GetString("role");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Product</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n");
            WriteLiteral("        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.Category.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Weight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.Weight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UnitsInStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.UnitsInStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n");
#nullable restore
#line 53 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
     if (role.Contains("admin"))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
   Write(Html.ActionLink("Edit", "Edit", new {  id = Model.ProductId  }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "D:\WorkPlace\C#_NangCao\PRN221_C#_Ky_8\Lab\Lab1\Assignment01Solution_DuyenNPCE150850\eStoreClient\Views\Products\Details.cshtml"
                                                                        
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6ea6b584430a87110a27be0c25bd5c7444ec1448881", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BusinessObject.Product> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
