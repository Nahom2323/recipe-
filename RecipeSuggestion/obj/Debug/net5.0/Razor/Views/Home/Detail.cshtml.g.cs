#pragma checksum "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee00c48c0cc1feaae8df99153d40755b60ce35de"
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
#line 1 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\_ViewImports.cshtml"
using RecipeSuggestion;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\_ViewImports.cshtml"
using RecipeSuggestion.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\_ViewImports.cshtml"
using RecipeSuggestion.Models.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee00c48c0cc1feaae8df99153d40755b60ce35de", @"/Views/Home/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c01cfe949fe35887b9c045e9ef2e2f5e2e69041", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Recipe>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"thumbnail card shadow\">\r\n    <div class=\"clearfix\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 94, "\"", 112, 1);
#nullable restore
#line 5 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
WriteAttributeValue("", 100, Model.Image, 100, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 113, "\"", 131, 1);
#nullable restore
#line 5 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
WriteAttributeValue("", 119, Model.Title, 119, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:50%\" class=\"float-right\">\r\n        <h4>");
#nullable restore
#line 6 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n\r\n        <h5>Ingredients:</h5>\r\n        <p>\r\n");
#nullable restore
#line 10 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
              
                for (var i = 0; i < @Model.ExtendedIngredients.Count; i++)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
               Write(Model.ExtendedIngredients[i].Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                     if (i < @Model.ExtendedIngredients.Count - 1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>, </span>\r\n");
#nullable restore
#line 18 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                     
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </p>\r\n\r\n        <h5>How to cook?</h5>\r\n        <ol>\r\n");
#nullable restore
#line 25 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
            for (var i = 0; i < @Model.AnalyzedInstructions[0].Steps.Count; i++)
          {

#line default
#line hidden
#nullable disable
            WriteLiteral("              <li>\r\n                <!-- Step description -->\r\n                ");
#nullable restore
#line 29 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
           Write(Model.AnalyzedInstructions[0].Steps[i].Step);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n              </li>\r\n");
#nullable restore
#line 31 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
          }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ol>\r\n\r\n        <h5>Servings: ");
#nullable restore
#line 34 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                 Write(Model.Servings);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n        <h5>Pricing per serving: ");
#nullable restore
#line 36 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                            Write(Model.PricePerServing);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n        <h5>Health Score: ");
#nullable restore
#line 38 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                     Write(Model.HealthScore);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n        <h5>\r\n                    <strong>Cuisines:</strong>\r\n");
#nullable restore
#line 42 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                      
                        if (@Model.Cuisines.Count==0)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                       Write(Html.Raw("N/A"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                                            ;
                            
                        }
                        else
                        {
                            for (var i = 0; i < @Model.Cuisines.Count; i++)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                           Write(Model.Cuisines[i]);

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                                              Write(Html.Raw(", "));

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                                                                  ;
                            }
                        }

                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </h5>\r\n           <h5>Source: <a");
            BeginWriteAttribute("href", " href=\"", 1740, "\"", 1763, 1);
#nullable restore
#line 58 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
WriteAttributeValue("", 1747, Model.SourceUrl, 1747, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 58 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
                                             Write(Model.SourceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>, <a");
            BeginWriteAttribute("href", " href=\"", 1790, "\"", 1824, 1);
#nullable restore
#line 58 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Detail.cshtml"
WriteAttributeValue("", 1797, Model.SpoonacularSourceUrl, 1797, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Spoonacular API</a></h5>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Recipe> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
