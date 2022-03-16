#pragma checksum "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4687a726c4c92dfffcaa10e50388973de3e2c7a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Result), @"mvc.1.0.view", @"/Views/Home/Result.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4687a726c4c92dfffcaa10e50388973de3e2c7a3", @"/Views/Home/Result.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c01cfe949fe35887b9c045e9ef2e2f5e2e69041", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Result : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ShortRecipe>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container\">\r\n");
#nullable restore
#line 3 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
        foreach (ShortRecipe recipe in Model)
           {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"thumbnail card shadow mb-5\">\r\n                <div class=\"clearfix\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 230, "\"", 249, 1);
#nullable restore
#line 7 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
WriteAttributeValue("", 236, recipe.Image, 236, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 250, "\"", 269, 1);
#nullable restore
#line 7 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
WriteAttributeValue("", 256, recipe.Title, 256, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:30%\" class=\"float-left mr-2\">\r\n                    <h5 class=\"mt-3\">");
#nullable restore
#line 8 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
                                Write(recipe.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"mt-3\"><strong>Missed Ingredients:</strong>\r\n");
#nullable restore
#line 10 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
                         for (var i = 0; i < recipe.MissedIngredients.Count; i++)
                       {
                           

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
                      Write(recipe.MissedIngredients[i].Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
                             if (i < recipe.MissedIngredients.Count - 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>, </span>\r\n");
#nullable restore
#line 17 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
                             
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </p>   \r\n                    <p class=\"mt-3\"><strong>Used Ingredients:</strong>\r\n");
#nullable restore
#line 21 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
                     for (var i = 0; i < recipe.UsedIngredientCount; i++)
                   {
                       

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
                  Write(recipe.UsedIngredients[i].Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
                        if (i < recipe.UsedIngredients.Count - 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>, </span>\r\n");
#nullable restore
#line 27 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
                             
                   }    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </p>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 32 "C:\Conestoga\Application Project (INFO2310)\RecipeSuggestion\RecipeSuggestion\RecipeSuggestion\Views\Home\Result.cshtml"
           }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ShortRecipe>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
