#pragma checksum "C:\Users\aliss\source\repos\TesteNovaVida\TesteNovaVida\Views\Shared\_MensagensPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b47bd2f86249014aadf1859b16c05e7c44d904a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__MensagensPartial), @"mvc.1.0.view", @"/Views/Shared/_MensagensPartial.cshtml")]
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
#line 1 "C:\Users\aliss\source\repos\TesteNovaVida\TesteNovaVida\Views\_ViewImports.cshtml"
using TesteNovaVida;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\aliss\source\repos\TesteNovaVida\TesteNovaVida\Views\_ViewImports.cshtml"
using TesteNovaVida.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b47bd2f86249014aadf1859b16c05e7c44d904a", @"/Views/Shared/_MensagensPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce78c7d040b3e58476a2d580b374a24b5a4c9b2c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__MensagensPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\aliss\source\repos\TesteNovaVida\TesteNovaVida\Views\Shared\_MensagensPartial.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<script type=\"text/javascript\">\r\n    $(document).ready(function () {\r\n");
#nullable restore
#line 6 "C:\Users\aliss\source\repos\TesteNovaVida\TesteNovaVida\Views\Shared\_MensagensPartial.cshtml"
         if (TempData["MostraErro"] != null)
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                mostraDialogo(\"");
#nullable restore
#line 9 "C:\Users\aliss\source\repos\TesteNovaVida\TesteNovaVida\Views\Shared\_MensagensPartial.cshtml"
                          Write(TempData["MostraErro"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\", \"danger\");\r\n            ");
#nullable restore
#line 10 "C:\Users\aliss\source\repos\TesteNovaVida\TesteNovaVida\Views\Shared\_MensagensPartial.cshtml"
                   
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 13 "C:\Users\aliss\source\repos\TesteNovaVida\TesteNovaVida\Views\Shared\_MensagensPartial.cshtml"
         if (TempData["MostraSucesso"] != null)
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                mostraDialogo(\"");
#nullable restore
#line 16 "C:\Users\aliss\source\repos\TesteNovaVida\TesteNovaVida\Views\Shared\_MensagensPartial.cshtml"
                          Write(TempData["MostraSucesso"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\", \"success\");\r\n            ");
#nullable restore
#line 17 "C:\Users\aliss\source\repos\TesteNovaVida\TesteNovaVida\Views\Shared\_MensagensPartial.cshtml"
                   
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 20 "C:\Users\aliss\source\repos\TesteNovaVida\TesteNovaVida\Views\Shared\_MensagensPartial.cshtml"
         if (TempData["MostraInfo"] != null)
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                mostraDialogo(\"");
#nullable restore
#line 23 "C:\Users\aliss\source\repos\TesteNovaVida\TesteNovaVida\Views\Shared\_MensagensPartial.cshtml"
                          Write(TempData["MostraInfo"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\", \"info\");\r\n            ");
#nullable restore
#line 24 "C:\Users\aliss\source\repos\TesteNovaVida\TesteNovaVida\Views\Shared\_MensagensPartial.cshtml"
                   
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    })\r\n</script>\r\n");
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
