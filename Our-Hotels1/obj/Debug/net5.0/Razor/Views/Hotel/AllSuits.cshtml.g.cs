#pragma checksum "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43cb889083a62041d0c6687deedf70a0f074bb42"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hotel_AllSuits), @"mvc.1.0.view", @"/Views/Hotel/AllSuits.cshtml")]
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
#line 1 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\_ViewImports.cshtml"
using Our_Hotels1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\_ViewImports.cshtml"
using Our_Hotels1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\_ViewImports.cshtml"
using OurHotels.Dto.User;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\_ViewImports.cshtml"
using Our_Hotels1.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\_ViewImports.cshtml"
using My_Tables.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\_ViewImports.cshtml"
using OurHotels.Dto.Hotel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\_ViewImports.cshtml"
using OurHotels.Dto.Room;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\_ViewImports.cshtml"
using OurHotels.Dto.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\_ViewImports.cshtml"
using OurHotels.Dto.Customer;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43cb889083a62041d0c6687deedf70a0f074bb42", @"/Views/Hotel/AllSuits.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4795a9ef56e10071bae904edaf147890b9ff8d1c", @"/Views/_ViewImports.cshtml")]
    public class Views_Hotel_AllSuits : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List< OurHotels.Dto.Hotel.RoomDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Room", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddSuit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("avatar-img rounded-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
  
	Layout = "_HotelLayout";
	ViewData["title"]= "All Suits";
	bool suit=true;

#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n\r\n</style>\r\n\t\t<div class=\"col-md-7 col-lg-8 col-xl-9\">\r\n\t\t\t\t<div class=\"one\">\r\n\t\r\n <div class=\"d-flex justify-content-end\">\r\n            <div>\r\n\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43cb889083a62041d0c6687deedf70a0f074bb427011", async() => {
                WriteLiteral("\r\n\t\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43cb889083a62041d0c6687deedf70a0f074bb427273", async() => {
                    WriteLiteral("\r\n                    <i class=\"bi bi-plus\"></i>Add Suit\r\n                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                \r\n            </div>\r\n           \r\n\t\t\t</div>\r\n<div class=\"service-count\">\r\n              \r\n\t\t\t\t<div class=\"patient-details\">\r\n");
#nullable restore
#line 27 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
                      if(Model.Count()==1)
				{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<h5><b><i class=\"service-count-number\"  style=\"font-size: 18px; font-weight: bold;\"></i></b>");
#nullable restore
#line 29 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
                                                                                                           Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span>Suit</span></h5>\r\n");
#nullable restore
#line 30 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
				}else if(Model.Count() > 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h5><b><i class=\"service-count-number\" style=\"font-size: 18px; font-weight: bold;\"></i></b>");
#nullable restore
#line 32 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
                                                                                                          Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span>Rooms</span></h5>\r\n");
#nullable restore
#line 33 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h5 class=\"no-rooms-text\">No suits added yet</h5>\r\n");
#nullable restore
#line 37 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</div>\r\n            </div>\r\n\r\n</div>\r\n\t\t\t\t\t\t\t<div class=\"row row-grid\">\r\n\t\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "43cb889083a62041d0c6687deedf70a0f074bb4212124", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 43 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => suit);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 44 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
             foreach(var item in Model)
			{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"								<div class=""col-md-6 col-lg-4 col-xl-3"">
									
			<div class=""card widget-profile pat-widget-profile"">

										<div class=""card-body"">
											<div class=""pro-widget-content"">
												<div class=""profile-info-widget"">
													<a  class=""booking-doc-img"">
														<h5>");
#nullable restore
#line 54 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
                                                       Write(item.RoomNum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"profile-det-info\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<h3>");
#nullable restore
#line 57 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
                                                       Write(item.Floor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"patient-details\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<h5><b>Room Price :</b> ");
#nullable restore
#line 60 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
                                                                               Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<h5 class=\"mb-0\"><i class=\"fas fa-map-marker-alt\"></i> ");
#nullable restore
#line 61 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
                                                                                                              Write(item.RoomDirection1);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 61 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
                                                                                                                                    Write(item.RoomDirection2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"patient-info\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<ul>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<li>Beds <span>");
#nullable restore
#line 68 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
                                                              Write(item.numOfBeds);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<li>Phone <span>");
#nullable restore
#line 69 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
                                                               Write(item.phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t</ul>\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t<ul class=\"clinic-gallery\" style=\"display: flex; flex-wrap: wrap;\">\r\n");
#nullable restore
#line 75 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
                                                 foreach(var im in item.Images)
						                               	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   <li  style=\"flex: 1 0 33.33%; padding: 5px; list-style-type:none\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<a class=\"avatar avatar-sm mr-2\" data-fancybox=\"gallery\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "43cb889083a62041d0c6687deedf70a0f074bb4218046", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2663, "~/assets/img/rooms/", 2663, 19, true);
#nullable restore
#line 80 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
AddHtmlAttributeValue("", 2682, im.Url.Split("rooms\\").ElementAt(1), 2682, 37, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</li>\r\n");
#nullable restore
#line 83 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
							
                                                          }

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t</ul>\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"card-footer text-center\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t <a");
            BeginWriteAttribute("href", " href=\"", 2955, "\"", 3029, 1);
#nullable restore
#line 90 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
WriteAttributeValue("", 2962, Url.Action("EditSuit", "Room", new { RoomId = item.RoomEntityId }), 2962, 67, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Edit</a>\r\n\t\t\t\t\t\t\t                <a");
            BeginWriteAttribute("href", " href=\"", 3090, "\"", 3166, 1);
#nullable restore
#line 91 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"
WriteAttributeValue("", 3097, Url.Action("DeleteSuit", "Room", new { RoomId = item.RoomEntityId }), 3097, 69, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger ml-2\">Delete</a>\r\n                          \r\n\t\t\t\t\t\t\t\r\n                        </div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 100 "C:\Users\ASUS\source\repos\Our-Hotels1 - test\Our-Hotels1\Views\Hotel\AllSuits.cshtml"


           }

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\r\n\r\n\t\t\t\t\t\t</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List< OurHotels.Dto.Hotel.RoomDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591