#pragma checksum "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7faafc992ef7e52eb7345a144b9d9464c7980733"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__Layout), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_Layout.cshtml")]
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
#line 1 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Shared\_Layout.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Shared\_Layout.cshtml"
using JustBlog.Model.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7faafc992ef7e52eb7345a144b9d9464c7980733", @"/Areas/Admin/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ecae8ca55e328e553413cf603b645b6cf8ad0ea", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/sidebars.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/sidebars.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/urlhelper.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<!doctype html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7faafc992ef7e52eb7345a144b9d9464c79807336447", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 335, "\"", 345, 0);
                EndWriteAttribute();
                WriteLiteral(@">
    <meta name=""author"" content=""Mark Otto, Jacob Thornton, and Bootstrap contributors"">
    <meta name=""generator"" content=""Hugo 0.88.1"">
    <title>Admin JustBlog Page</title>

    <link rel=""canonical"" href=""https://getbootstrap.com/docs/5.1/examples/sidebars/"">

    <!-- Bootstrap core CSS -->
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7faafc992ef7e52eb7345a144b9d9464c79807337329", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    <!-- Custom styles for this template -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7faafc992ef7e52eb7345a144b9d9464c79807338559", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <style>\r\n        .ck-editor__editable {\r\n            min-height: 300px;\r\n        }\r\n    </style>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7faafc992ef7e52eb7345a144b9d9464c798073310553", async() => {
                WriteLiteral(@"
    <div class=""container-fluid"">

        <div class=""row"">
            <div class=""flex-shrink-0 p-3 bg-white col-md-2 border-left nav-bar"">
                <a href=""/admin/home"" class=""d-flex align-items-center pb-3 mb-3 link-dark text-decoration-none border-bottom"">
                    <svg class=""bi me-2"" width=""30"" height=""24""><use xlink:href=""#bootstrap"" /></svg>
                    <div class=""fs-6 fw-semibold"">Just Blog Admin</div>
                </a>
                <a href=""/home"" class=""d-flex align-items-center pb-3 mb-3 link-dark text-decoration-none border-bottom"">
                    <svg class=""bi me-2"" width=""30"" height=""24""><use xlink:href=""#bootstrap"" /></svg>
                    <div class=""fs-6 fw-semibold"">Just Blog Web</div>
                </a>

                <a href=""#"" style=""pointer-events: none; cursor: default;"" class=""d-flex align-items-center pb-3 mb-3 link-dark text-decoration-none border-bottom"">
                    <svg class=""bi me-2"" width=""30"" height=""2");
                WriteLiteral("4\"><use xlink:href=\"#bootstrap\" /></svg>\r\n                    <div class=\"fs-6 fw-semibold\">\r\n                        Wellcome, ");
#nullable restore
#line 47 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Shared\_Layout.cshtml"
                             Write(userManager.GetUserName(User));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                    </div>
                </a>

                <ul class=""list-unstyled ps-0"">
                    <li class=""mb-1"">
                        <button class=""btn btn-toggle align-items-center rounded collapsed"" data-bs-toggle=""collapse"" data-bs-target=""#cate-collapse"" aria-expanded=""false"">
                            Category Manager
                        </button>
                        <div class=""collapse"" id=""cate-collapse"">
                            <ul class=""btn-toggle-nav list-unstyled fw-normal pb-1 small"">
                                <li><a href=""/admin/category/index"" class=""link-dark rounded"">List</a></li>
                                <li><a href=""/admin/category/create"" class=""link-dark rounded"">Create</a></li>
                            </ul>
                        </div>
                    </li>
                    <li class=""mb-1"">
                        <button class=""btn btn-toggle align-items-center rounded collapsed"" data-bs-toggle=""collap");
                WriteLiteral(@"se"" data-bs-target=""#post-collapse"" aria-expanded=""false"">
                            Post Manager
                        </button>
                        <div class=""collapse"" id=""post-collapse"">
                            <ul class=""btn-toggle-nav list-unstyled fw-normal pb-1 small"">
                                <li><a href=""/admin/post/index"" class=""link-dark rounded"">List</a></li>
                                <li><a href=""/admin/post/create"" class=""link-dark rounded"">Create</a></li>
                            </ul>
                        </div>
                    </li>
                    <li class=""mb-1"">
                        <button class=""btn btn-toggle align-items-center rounded collapsed"" data-bs-toggle=""collapse"" data-bs-target=""#tag-collapse"" aria-expanded=""false"">
                            Tag Manager
                        </button>
                        <div class=""collapse"" id=""tag-collapse"">
                            <ul class=""btn-toggle-nav list-unstyled");
                WriteLiteral(@" fw-normal pb-1 small"">
                                <li><a href=""/admin/post/index"" class=""link-dark rounded"">List</a></li>
                                <li><a href=""/admin/post/create"" class=""link-dark rounded"">Create</a></li>
                            </ul>
                        </div>
                    </li>
                    <li class=""mb-1"">
                        <button class=""btn btn-toggle align-items-center rounded collapsed"" data-bs-toggle=""collapse"" data-bs-target=""#role-collapse"" aria-expanded=""false"">
                            Role Manager
                        </button>
                        <div class=""collapse"" id=""role-collapse"">
                            <ul class=""btn-toggle-nav list-unstyled fw-normal pb-1 small"">
                                <li><a href=""/admin/post/index"" class=""link-dark rounded"">List</a></li>
                                <li><a href=""/admin/post/create"" class=""link-dark rounded"">Create</a></li>
                            </");
                WriteLiteral(@"ul>
                        </div>
                    </li>
                    <li class=""mb-1"">
                        <button class=""btn btn-toggle align-items-center rounded collapsed"" data-bs-toggle=""collapse"" data-bs-target=""#user-collapse"" aria-expanded=""false"">
                            User Manager
                        </button>
                        <div class=""collapse"" id=""user-collapse"">
                            <ul class=""btn-toggle-nav list-unstyled fw-normal pb-1 small"">
                                <li><a href=""/admin/post/index"" class=""link-dark rounded"">List</a></li>
                                <li><a href=""/admin/post/create"" class=""link-dark rounded"">Create</a></li>
                            </ul>
                        </div>
                    </li>
                    <li class=""border-top my-3""></li>
                    <li class=""mb-1"">
                        <button class=""btn btn-toggle align-items-center rounded collapsed"" data-bs-toggle=""co");
                WriteLiteral(@"llapse"" data-bs-target=""#account-collapse"" aria-expanded=""false"">
                            Account
                        </button>
                        <div class=""collapse"" id=""account-collapse"">
                            <ul class=""btn-toggle-nav list-unstyled fw-normal pb-1 small"">
                                <li><a href=""#"" class=""link-dark rounded"">New...</a></li>
                                <li><a href=""#"" class=""link-dark rounded"">Profile</a></li>
                                <li><a href=""#"" class=""link-dark rounded"">Settings</a></li>
                                <li><a href=""#"" class=""link-dark rounded"">Sign out</a></li>
                            </ul>
                        </div>
                    </li>
                    <li class=""mb-1"">
                        <a class=""btn btn-danger btn-lg"" href=""/account/logout"">Logout</a>
                    </li>
                </ul>
            </div>
            <div class=""col-md-10 mt-3 mb-3 pr-5 pl-5"">
  ");
                WriteLiteral("              ");
#nullable restore
#line 127 "D:\FSoft\EF\JustBlogMVC\JustBlog.WebApp\Areas\Admin\Views\Shared\_Layout.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7faafc992ef7e52eb7345a144b9d9464c798073318084", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7faafc992ef7e52eb7345a144b9d9464c798073319184", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7faafc992ef7e52eb7345a144b9d9464c798073320284", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7faafc992ef7e52eb7345a144b9d9464c798073321384", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script src=""https://cdn.ckeditor.com/ckeditor5/29.2.0/classic/ckeditor.js""></script>
    <script>
        ClassicEditor
            .create(document.querySelector('#editor'))
            .catch(error => {
                console.error(error);
            });
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<AppUser> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<AppUser> signInManager { get; private set; }
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
