#pragma checksum "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "905dadbcae2cb353838c13765bdab8fac46695d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Detail), @"mvc.1.0.view", @"/Views/Home/Detail.cshtml")]
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
#line 1 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\_ViewImports.cshtml"
using RecipeSuggestion;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\_ViewImports.cshtml"
using RecipeSuggestion.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\_ViewImports.cshtml"
using RecipeSuggestion.Models.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"905dadbcae2cb353838c13765bdab8fac46695d1", @"/Views/Home/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c01cfe949fe35887b9c045e9ef2e2f5e2e69041", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Recipe>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SaveRecipe", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
  
    ViewData["Title"] = @Model.Title;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- Show a message if the recipe is saved sucessfully -->\r\n");
#nullable restore
#line 6 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
 if (TempData["Message"]!=null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p class=\"alert alert-primary\" role=\"alert\">");
#nullable restore
#line 8 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                                           Write(TempData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 9 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"thumbnail card shadow\">\r\n    <div class=\"clearfix\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 311, "\"", 329, 1);
#nullable restore
#line 12 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
WriteAttributeValue("", 317, Model.Image, 317, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 330, "\"", 348, 1);
#nullable restore
#line 12 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
WriteAttributeValue("", 336, Model.Title, 336, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:50%\" class=\"float-right\">\r\n        <h4 class=\"m-2\">");
#nullable restore
#line 13 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                   Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n\r\n        <h5 class=\"m-2\">Ingredients:</h5>\r\n        <ul>\r\n");
#nullable restore
#line 17 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
              
                    for (var i = 0; i < @Model.ExtendedIngredients.Count; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                       <li class=\"m-2\">");
#nullable restore
#line 20 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                                  Write(Model.ExtendedIngredients[i].Original);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 21 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n        <h5 class=\"m-2\">How to cook?</h5>\r\n        <ol class=\"m-2\">\r\n");
#nullable restore
#line 26 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
             for (var i = 0; i < @Model.AnalyzedInstructions[0].Steps.Count; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>\r\n                    <!-- Step description -->\r\n                    ");
#nullable restore
#line 30 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
               Write(Model.AnalyzedInstructions[0].Steps[i].Step);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 32 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ol>\r\n\r\n        <h5 class=\"m-2\">Servings: ");
#nullable restore
#line 35 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                             Write(Model.Servings);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n        <h5 class=\"m-2\">Pricing per serving: ");
#nullable restore
#line 37 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                                        Write(Model.PricePerServing);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n        <h5 class=\"m-2\">Health Score: ");
#nullable restore
#line 39 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                                 Write(Model.HealthScore);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n        <h5 class=\"m-2\">\r\n            <strong>Cuisines:</strong>\r\n");
#nullable restore
#line 43 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
              
                if (@Model.Cuisines.Count == 0)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
               Write(Html.Raw("N/A"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                                    ;

                }
                else
                {
                    for (var i = 0; i < @Model.Cuisines.Count; i++)
                    {
                        if (i != @Model.Cuisines.Count - 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>");
#nullable restore
#line 55 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                             Write(Model.Cuisines[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral(", </span>\r\n");
#nullable restore
#line 56 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>");
#nullable restore
#line 59 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                             Write(Model.Cuisines[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 60 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                            }
                        }

                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </h5>\r\n        <h5 class=\"m-2\">Source: <a");
            BeginWriteAttribute("href", " href=\"", 2102, "\"", 2125, 1);
#nullable restore
#line 66 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
WriteAttributeValue("", 2109, Model.SourceUrl, 2109, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 66 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                                                      Write(Model.SourceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>, <a");
            BeginWriteAttribute("href", " href=\"", 2152, "\"", 2186, 1);
#nullable restore
#line 66 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
WriteAttributeValue("", 2159, Model.SpoonacularSourceUrl, 2159, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Spoonacular API</a></h5>\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "905dadbcae2cb353838c13765bdab8fac46695d112652", async() => {
                WriteLiteral("Save this recipe");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-recipeId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "C:\Users\juho1\Desktop\recipe\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["recipeId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-recipeId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["recipeId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Recipe> Html { get; private set; }
    }
}
#pragma warning restore 1591
