#pragma checksum "C:\Users\erick\OneDrive\Escritorio\prueba\AppGym\AppGym\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "381fbbcaffb036767b174d1dd12d44f559748e36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\erick\OneDrive\Escritorio\prueba\AppGym\AppGym\Views\_ViewImports.cshtml"
using AppGym;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\erick\OneDrive\Escritorio\prueba\AppGym\AppGym\Views\_ViewImports.cshtml"
using AppGym.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"381fbbcaffb036767b174d1dd12d44f559748e36", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4e4d06f1fd2ff831da73c09ade978ead32a70ee", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\erick\OneDrive\Escritorio\prueba\AppGym\AppGym\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    ViewData["nameHeader"] = "App Gym Standar";
    ViewData["descriptionHeader"] = "Los mejores planes de entrenamiento a tu alcance.";
    ViewData["head"] = true;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""bg-dark text-white"">
     <h2 style=""text-align:center"">Planes de inscripcion.</h2> 
</div>

<div class=""row"" id=""cards"">

    <div class=""col-md-5"">
        <div class=""card"" >
            <img class=""card-img-top"" src=""/imgs/gymLogo.jpg"" width=""100"" alt=""Card image cap"">
            <div class=""card-body"">
                <h5 class=""card-title"">1 persona</h5>
                <p class=""card-text"">Este plan consta de un texto de prueba en el cual es general para cada uno de los card mencionados en este apartado de informaci??n</p>
            </div>
        </div>
    </div>

    <div class=""col-md-5"">
        <div class=""card"" >
            <img class=""card-img-top"" src=""/imgs/gymLogo.jpg"" width=""100"" alt=""Card image cap"">
            <div class=""card-body"">
                <h5 class=""card-title"">2 persona</h5>
                <p class=""card-text"">Este plan consta de un texto de prueba en el cual es general para cada uno de los card mencionados en este apartado de inform");
            WriteLiteral(@"aci??n</p>
            </div>
        </div>
    </div>

</div>

<div class=""row"">

    <div class=""col-md-5"">
        <div class=""card"" >
            <img class=""card-img-top"" src=""/imgs/gymLogo.jpg"" width=""100"" alt=""Card image cap"">
            <div class=""card-body"">
                <h5 class=""card-title"">3 persona</h5>
                <p class=""card-text"">Este plan consta de un texto de prueba en el cual es general para cada uno de los card mencionados en este apartado de informaci??n</p>
            </div>
        </div>
    </div>

    <div class=""col-md-5"">
        <div class=""card"" >
            <img class=""card-img-top"" src=""/imgs/gymLogo.jpg"" width=""100"" alt=""Card image cap"">
            <div class=""card-body"">
                <h5 class=""card-title"">Esudiante</h5>
                <p class=""card-text"">Este plan consta de un texto de prueba en el cual es general para cada uno de los card mencionados en este apartado de informaci??n</p>
            </div>
        </div>
    </di");
            WriteLiteral("v>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
