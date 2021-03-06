#pragma checksum "E:\freelance\MyStore\Application\MyStore\MyStore.Web\Views\Category\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce8d75f193ecae90b15eb60e063f61179a1191ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category_Index), @"mvc.1.0.view", @"/Views/Category/Index.cshtml")]
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
#line 1 "E:\freelance\MyStore\Application\MyStore\MyStore.Web\Views\_ViewImports.cshtml"
using MyStore.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce8d75f193ecae90b15eb60e063f61179a1191ea", @"/Views/Category/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83ee839993df8f00363d2d916d4690aaead05d3d", @"/Views/_ViewImports.cshtml")]
    public class Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/page/Category.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\freelance\MyStore\Application\MyStore\MyStore.Web\Views\Category\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""section"">
    <div class=""section-body"">
        <h2 class=""section-title"">Product Division</h2>
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""card"">
                    <div class=""card-body"">
                     
                            <div class=""card-header-form float-right position-relative fa-pull-right"">
                                <div class=""input-group"">
                                    <div class=""input-group-btn"">
                                        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 648, "\"", 765, 5);
            WriteAttributeValue("", 658, "showInPopup(\'", 658, 13, true);
#nullable restore
#line 18 "E:\freelance\MyStore\Application\MyStore\MyStore.Web\Views\Category\Index.cshtml"
WriteAttributeValue("", 671, Url.Action("CreateOrEdit", "Category", null, Context.Request.Scheme), 671, 69, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 740, "\',\'New", 740, 6, true);
            WriteAttributeValue(" ", 746, "Product", 747, 8, true);
            WriteAttributeValue(" ", 754, "Category\')", 755, 11, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-success text-white""><i class=""fas fa-random""></i>Create</a>
                                    </div>
                                </div>
                            </div>
                        
                      
                            <input type=""hidden"" value=""true"" id=""canEdit"" />
                       
                      
                        <div class=""table-responsive-lg"" style=""text-align: center; padding-top: 70px"">
                            <table id=""tblproductCategory"" class=""table table-hover table-scale--hover table-cards align-items-center table-sm"">
                            </table>
                        </div>
                        <div class=""modal fade"" id=""createCategoryModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""CreateCategoryModal"" aria-hidden=""true"" data-backdrop=""static"">
                            <div id=""createCategoryContainer"">
                            </div>
                        </div>

           ");
            WriteLiteral(@"             <div class=""modal fade"" id=""editCategoryModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""EditCategoryModal"" aria-hidden=""true"" data-backdrop=""static"">
                            <div id=""editCategoryContainer"">
                            </div>
                        </div>

                       
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<div id=""getCategories"" data-request-url=""");
#nullable restore
#line 49 "E:\freelance\MyStore\Application\MyStore\MyStore.Web\Views\Category\Index.cshtml"
                                     Write(Url.Action("GetCategories", "Category"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></div>\r\n<div id=\"editCategory\" data-request-url=\"");
#nullable restore
#line 50 "E:\freelance\MyStore\Application\MyStore\MyStore.Web\Views\Category\Index.cshtml"
                                    Write(Url.Action("CreateOrEdit", "Category"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce8d75f193ecae90b15eb60e063f61179a1191ea7145", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 51 "E:\freelance\MyStore\Application\MyStore\MyStore.Web\Views\Category\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
