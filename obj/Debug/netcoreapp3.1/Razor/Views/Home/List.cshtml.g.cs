#pragma checksum "C:\Users\Александр\Desktop\К релизу УРААА\RazorPageNewTest\Views\Home\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc32e28cb7753d1eacd91da8d051aa735ccd8ddc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_List), @"mvc.1.0.view", @"/Views/Home/List.cshtml")]
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
#line 1 "C:\Users\Александр\Desktop\К релизу УРААА\RazorPageNewTest\Views\_ViewImports.cshtml"
using RazorPageNewTest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Александр\Desktop\К релизу УРААА\RazorPageNewTest\Views\_ViewImports.cshtml"
using RazorPageNewTest.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Александр\Desktop\К релизу УРААА\RazorPageNewTest\Views\Home\List.cshtml"
using System.IO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc32e28cb7753d1eacd91da8d051aa735ccd8ddc", @"/Views/Home/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f45a4d7432198f8719b802ba8610a89a899afa9a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ClassFileViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Александр\Desktop\К релизу УРААА\RazorPageNewTest\Views\Home\List.cshtml"
  
    ViewData["Title"] = "Согласование";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Александр\Desktop\К релизу УРААА\RazorPageNewTest\Views\Home\List.cshtml"
  
    foreach (var temp in Model.AllFile)
    {
        string e = temp.FullName.Substring(temp.FullName.LastIndexOf(".") + 1);
        string picSrc = "";
        if (e == "docx" || e=="doc")
            picSrc = "ResPic/Word.png";
        if (e == "pdf")
            picSrc = "ResPic/PDF.png";
        if (e == "sig")
            picSrc = "ResPic/ETsP.png";

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"tasks\">\r\n        <div class=\"task\" data-id=\"");
#nullable restore
#line 18 "C:\Users\Александр\Desktop\К релизу УРААА\RazorPageNewTest\Views\Home\List.cshtml"
                              Write(temp.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n            <div class=\"task__content\">\r\n                <img id=\"im\"");
            BeginWriteAttribute("src", " src=\"", 608, "\"", 621, 1);
#nullable restore
#line 20 "C:\Users\Александр\Desktop\К релизу УРААА\RazorPageNewTest\Views\Home\List.cshtml"
WriteAttributeValue("", 614, picSrc, 614, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                ");
#nullable restore
#line 21 "C:\Users\Александр\Desktop\К релизу УРААА\RazorPageNewTest\Views\Home\List.cshtml"
           Write(temp.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 25 "C:\Users\Александр\Desktop\К релизу УРААА\RazorPageNewTest\Views\Home\List.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ClassFileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
