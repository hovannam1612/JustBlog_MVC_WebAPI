#pragma checksum "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e416a3009b8fd04ae1c879589a2f602a6571c11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Post_PostDetail), @"mvc.1.0.view", @"/Areas/Admin/Views/Post/PostDetail.cshtml")]
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
#line 1 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\_ViewImports.cshtml"
using JustBlog.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\_ViewImports.cshtml"
using JustBlog.WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml"
using JustBlog.ViewModel.Posts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml"
using JustBlog.Application.Services.TagServices;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e416a3009b8fd04ae1c879589a2f602a6571c11", @"/Areas/Admin/Views/Post/PostDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ecae8ca55e328e553413cf603b645b6cf8ad0ea", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Post_PostDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PostViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DetailPostTag", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-sm text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 6 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml"
  
    TempData["TitlePage"] = "Detail page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h2>Post Detail</h2>
<br />
<div class=""row justify-content-center"">
    <div class=""col-md-12 col-lg-12 col-xl-12"">

        <!-- Post preview-->
        <div class=""card"">
            <div class=""card-header"">
                <h4>
                    ");
#nullable restore
#line 18 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml"
               Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </h4>\r\n                <p class=\"post-meta small\">\r\n                    Posted ");
#nullable restore
#line 21 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml"
                      Write(Model.CreatedOn);

#line default
#line hidden
#nullable disable
            WriteLiteral(" with  ");
#nullable restore
#line 21 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml"
                                             Write(Model.ViewCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" view(s)\r\n                </p>\r\n            </div>\r\n\r\n            <div class=\"card-body\">\r\n\r\n");
#nullable restore
#line 27 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml"
                  
                    var tags = tagService.FindTagsByPostId(Model.Id);
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <b>Tag:</b>\r\n");
#nullable restore
#line 31 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml"
                 foreach (var tagItem in tags)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e416a3009b8fd04ae1c879589a2f602a6571c116620", async() => {
#nullable restore
#line 33 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml"
                                                                                                                                        Write(tagItem.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml"
                                                                          WriteLiteral(tagItem.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 34 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p><b>Short Description:</b> ");
#nullable restore
#line 35 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml"
                                        Write(Model.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"card-footer\">\r\n                <b>Content: </b>\r\n                <p>");
#nullable restore
#line 39 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Post\PostDetail.cshtml"
              Write(Html.Raw(Model.PostContent));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n        <br />\r\n        <a href=\"/admin/post/index\" class=\"btn btn-primary\">List of Posts</a>\r\n\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ITagService tagService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PostViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591