#pragma checksum "C:\Users\yeiso\Desktop\quiz B\SEMANA 11_TAREA\SEMANA 11_TAREA\EditorialMVC\Areas\Cliente\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f4c917e3beb7e54f4e785caf2a2ec0c8b680f1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Cliente_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Cliente/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\yeiso\Desktop\quiz B\SEMANA 11_TAREA\SEMANA 11_TAREA\EditorialMVC\Areas\Cliente\Views\_ViewImports.cshtml"
using EditorialMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\yeiso\Desktop\quiz B\SEMANA 11_TAREA\SEMANA 11_TAREA\EditorialMVC\Areas\Cliente\Views\_ViewImports.cshtml"
using EditorialMvc.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\yeiso\Desktop\quiz B\SEMANA 11_TAREA\SEMANA 11_TAREA\EditorialMVC\Areas\Cliente\Views\_ViewImports.cshtml"
using EditorialMvc.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f4c917e3beb7e54f4e785caf2a2ec0c8b680f1a", @"/Areas/Cliente/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e305f05414604d2f418c89a49e6da262e1288054", @"/Areas/Cliente/Views/_ViewImports.cshtml")]
    public class Areas_Cliente_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EditorialMvc.Models.Usuario>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\yeiso\Desktop\quiz B\SEMANA 11_TAREA\SEMANA 11_TAREA\EditorialMVC\Areas\Cliente\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row pb-3 backgroundWhite\">\r\n");
#nullable restore
#line 8 "C:\Users\yeiso\Desktop\quiz B\SEMANA 11_TAREA\SEMANA 11_TAREA\EditorialMVC\Areas\Cliente\Views\Home\Index.cshtml"
     foreach (var libro in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""col-lg-3 col-md-6"">
            <div class=""row p-2"">
                <div class=""col-12  p-1"" style=""border:1px solid #008cba; border-radius: 5px;"">
                    <div class=""card"" style=""border:0px;"">
                        <img");
            BeginWriteAttribute("src", " src=\"", 441, "\"", 463, 1);
#nullable restore
#line 14 "C:\Users\yeiso\Desktop\quiz B\SEMANA 11_TAREA\SEMANA 11_TAREA\EditorialMVC\Areas\Cliente\Views\Home\Index.cshtml"
WriteAttributeValue("", 447, libro.Direccion, 447, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top rounded\" height=\"400px\" />\r\n                        <div class=\"pl-1\">\r\n                            <p class=\"card-title h5\"><b style=\"color:#2c3e50\">");
#nullable restore
#line 16 "C:\Users\yeiso\Desktop\quiz B\SEMANA 11_TAREA\SEMANA 11_TAREA\EditorialMVC\Areas\Cliente\Views\Home\Index.cshtml"
                                                                         Write(libro.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                            <p class=\"card-title text-primary\">por <b>");
#nullable restore
#line 17 "C:\Users\yeiso\Desktop\quiz B\SEMANA 11_TAREA\SEMANA 11_TAREA\EditorialMVC\Areas\Cliente\Views\Home\Index.cshtml"
                                                                 Write(libro.Direccion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                        </div>\r\n                        <div style=\"padding-left:5px;\">\r\n                            <p>Precio: <strike><b");
            BeginWriteAttribute("class", " class=\"", 891, "\"", 899, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 20 "C:\Users\yeiso\Desktop\quiz B\SEMANA 11_TAREA\SEMANA 11_TAREA\EditorialMVC\Areas\Cliente\Views\Home\Index.cshtml"
                                                      Write(libro.CompaniaId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></strike></p>\r\n                        </div>\r\n                        <div style=\"padding-left:5px;\">\r\n                            <p style=\"color:maroon\">Al por mayor: <b");
            BeginWriteAttribute("class", " class=\"", 1094, "\"", 1102, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 23 "C:\Users\yeiso\Desktop\quiz B\SEMANA 11_TAREA\SEMANA 11_TAREA\EditorialMVC\Areas\Cliente\Views\Home\Index.cshtml"
                                                                         Write(libro.CodigoPostal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                        </div>\r\n                    </div>\r\n                    <div>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6f4c917e3beb7e54f4e785caf2a2ec0c8b680f1a7714", async() => {
                WriteLiteral("Detalles");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "C:\Users\yeiso\Desktop\quiz B\SEMANA 11_TAREA\SEMANA 11_TAREA\EditorialMVC\Areas\Cliente\Views\Home\Index.cshtml"
                                                                                       WriteLiteral(libro.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 32 "C:\Users\yeiso\Desktop\quiz B\SEMANA 11_TAREA\SEMANA 11_TAREA\EditorialMVC\Areas\Cliente\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EditorialMvc.Models.Usuario>> Html { get; private set; }
    }
}
#pragma warning restore 1591