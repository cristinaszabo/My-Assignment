#pragma checksum "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c58ddf1c28593bf68f9580b3326115c05a517635"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Dashboard.cshtml", typeof(AspNetCore.Views_Home_Dashboard))]
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
#line 1 "E:\CODING\DojoActivity\Views\_ViewImports.cshtml"
using DojoActivity;

#line default
#line hidden
#line 2 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
using DojoActivity.Models;

#line default
#line hidden
#line 3 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c58ddf1c28593bf68f9580b3326115c05a517635", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8457dd025be78c037bd06f59feefd4db5b05a17f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Activity>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(88, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
            BeginContext(135, 102, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n  <div class=\"col-8\">\r\n    <h3><i>Welcome <span style=\"color:rgb(218, 68, 180)\"> ");
            EndContext();
            BeginContext(238, 30, false);
#line 12 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                                                     Write(ViewBag.LoggedInUser.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(268, 668, true);
            WriteLiteral(@" </span> to Dojo Activity Center!</i></h3>
  </div>
  <div class=""col-4"">
    <a href=""/"">Logout</a>
  </div>
</div>
<hr>
<br>

<div class=""row"">
    <div clas=""col"">
        <table class=""table table-striped"">
            <thead class=""thead-dark"">
                <tr>
                    <th scope=""col"">Activity</th>
                    <th scope=""col"">Date and Time</th>
                    <th scope=""col"">Duration</th>
                    <th scope=""col"">Coordinator</th>
                    <th scope=""col"">Participants</th>
                    <th scope=""col"">Actions</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 35 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                  
                    int? LoggedInUser = @Context.Session.GetInt32 ("UserId");
                    foreach( var act in Model )
                    {
                        if ( DateTime.Now < act.StartDate )
                        {

#line default
#line hidden
            BeginContext(1195, 72, true);
            WriteLiteral("                            <tr>\r\n                                <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1267, "\"", 1299, 2);
            WriteAttributeValue("", 1274, "/activity/", 1274, 10, true);
#line 42 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 1284, act.ActivityId, 1284, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1300, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1302, 17, false);
#line 42 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                                                                   Write(act.ActivityTitle);

#line default
#line hidden
            EndContext();
            BeginContext(1319, 47, true);
            WriteLiteral("</a></td>\r\n                                <td>");
            EndContext();
            BeginContext(1367, 13, false);
#line 43 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                               Write(act.StartDate);

#line default
#line hidden
            EndContext();
            BeginContext(1380, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1424, 12, false);
#line 44 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                               Write(act.Duration);

#line default
#line hidden
            EndContext();
            BeginContext(1436, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1438, 15, false);
#line 44 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                                             Write(act.TimeMeasure);

#line default
#line hidden
            EndContext();
            BeginContext(1453, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1497, 25, false);
#line 45 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                               Write(act.Coordinator.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1522, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1524, 24, false);
#line 45 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                                                          Write(act.Coordinator.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1548, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1592, 24, false);
#line 46 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                               Write(act.Participations.Count);

#line default
#line hidden
            EndContext();
            BeginContext(1616, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 47 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                                  
                                    if( act.CoordinatorId == LoggedInUser )
                                    {

#line default
#line hidden
            BeginContext(1775, 46, true);
            WriteLiteral("                                        <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1821, "\"", 1851, 2);
            WriteAttributeValue("", 1828, "/delete/", 1828, 8, true);
#line 50 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 1836, act.ActivityId, 1836, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1852, 49, true);
            WriteLiteral("><span style=\"color:red\">DELETE</span></a></td>\r\n");
            EndContext();
#line 51 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                                    }
                                    else 
                                    {
                                        bool attending = false;
                                        foreach (var part in act.Participations)
                                        {
                                            if(part.User.UserId == (int)LoggedInUser)
                                            {
                                                attending = true;
                                            }
                                        }
                                        if (attending)
                                        {

#line default
#line hidden
            BeginContext(2602, 50, true);
            WriteLiteral("                                            <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2652, "\"", 2681, 2);
            WriteAttributeValue("", 2659, "/leave/", 2659, 7, true);
#line 64 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 2666, act.ActivityId, 2666, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2682, 51, true);
            WriteLiteral("><span style=\"color:orange\">LEAVE</span></a></td>\r\n");
            EndContext();
#line 65 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
            BeginContext(2865, 50, true);
            WriteLiteral("                                            <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2915, "\"", 2943, 2);
            WriteAttributeValue("", 2922, "/join/", 2922, 6, true);
#line 68 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 2928, act.ActivityId, 2928, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2944, 49, true);
            WriteLiteral("><span style=\"color:green\">JOIN</span></a></td>\r\n");
            EndContext();
#line 69 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                                        }
                                    }
                                

#line default
#line hidden
            BeginContext(3110, 35, true);
            WriteLiteral("                            </tr>\r\n");
            EndContext();
#line 73 "E:\CODING\DojoActivity\Views\Home\Dashboard.cshtml"
                        }
                    }
                

#line default
#line hidden
            BeginContext(3214, 221, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n  <div class=\"col-8\"></div>\r\n  <div class=\"col-4\">\r\n    <a href=\"newactivity\" class=\"btn btn-info\"> Add New Activity</a>\r\n  </div>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Activity>> Html { get; private set; }
    }
}
#pragma warning restore 1591
