#pragma checksum "D:\_WAHID\Technical Test Visionet\PromoApp\Views\Promotion\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e56c3d9cb07675af86a566dfd8ce669ad6a882b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Promotion_Index), @"mvc.1.0.view", @"/Views/Promotion/Index.cshtml")]
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
#line 1 "D:\_WAHID\Technical Test Visionet\PromoApp\Views\_ViewImports.cshtml"
using PromoApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\_WAHID\Technical Test Visionet\PromoApp\Views\_ViewImports.cshtml"
using PromoApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e56c3d9cb07675af86a566dfd8ce669ad6a882b", @"/Views/Promotion/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63190399f7b37335643e6037b7768394aa0d7050", @"/Views/_ViewImports.cshtml")]
    public class Views_Promotion_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\_WAHID\Technical Test Visionet\PromoApp\Views\Promotion\Index.cshtml"
  
    ViewData["Title"] = "Promotion";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card shadow mb-4\">\r\n    <div class=\"card-header py-3\">\r\n        ");
#nullable restore
#line 9 "D:\_WAHID\Technical Test Visionet\PromoApp\Views\Promotion\Index.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
    <div class=""card-body"">
        <div id=""frm""></div>
    </div>
    <div class=""card-footer"">
        <button id=""submitData"" class=""btn btn-primary btn-sm"">Submit</button>
        <a href=""/"" class=""btn btn-danger btn-sm"">Cancel</a>
    </div>
</div>


");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            LoadFrm();\r\n        });\r\n\r\n        function LoadFrm() {\r\n            $.get(\'");
#nullable restore
#line 28 "D:\_WAHID\Technical Test Visionet\PromoApp\Views\Promotion\Index.cshtml"
              Write(Url.Action("NewPromo", "Promotion"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', null, function (result) {
                $('#frm').html('');
                $('#frm').html(result);

                $('#valType').change(function () {
                    var tipe = $('#valType').val();
                    if (tipe == 'Percentage') {
                        $('#valu').val(0);
                        $(""#valu"").removeAttr(""max"");
                        $('#valu').attr('max', 100);
                    }
                    else {
                        $('#valu').val(0);
                        $(""#valu"").removeAttr(""max"");
                        $('#valu').attr('max', 999999999);
                    }
                    $('#valu').trigger(""change"");
                })

                $.get('");
#nullable restore
#line 47 "D:\_WAHID\Technical Test Visionet\PromoApp\Views\Promotion\Index.cshtml"
                  Write(Url.Action("LoadStore", "Promotion"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', null, function (result) {
                    $('#tblStore').html('');
                    $('#tblStore').html(result);
                })

                $('#dates').daterangepicker({
                    singleDatePicker: false,
                    showDropdowns: false,
                    minYear: 2020,
                    maxYear: parseInt(moment().format('YYYY'), 10),
                    locale: {
                        format: 'DD-MM-YYYY'
                    }
                },
                    function (start, end) {
                        $('#start').val(start.format('YYYY-MM-DD'));
                        $('#end').val(end.format('YYYY-MM-DD'));
                    }
                );

                $.validator.unobtrusive.parse('#_frm');

                $('#submitData').click(function (e) {
                    e.preventDefault();
                    e.stopImmediatePropagation();
                    Proses();
                });
            });
        }

 ");
                WriteLiteral(@"       function Proses() {
            if ($('#_frm').valid()) {


                var str = [];
                $('#tblStore').find('tr').each(function (i, x) {
                    var row = $(this);
                    if (row.find('input[type=""checkbox""]').is(':checked')) {
                        str[i] = row.find('td').eq(1).html();
                    }
                });
                $('#stre').val(str.join());

                var form = $('#_frm')[0];
                var data = new FormData(form);
                $.ajax({
                        type: ""POST"",
                        enctype: 'multipart/form-data',
                        url: '");
#nullable restore
#line 95 "D:\_WAHID\Technical Test Visionet\PromoApp\Views\Promotion\Index.cshtml"
                         Write(Url.Action("Submit", "Promotion"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                        data: data,
                        processData: false,
                        contentType: false,
                        cache: false,
                        timeout: 600000,
                        success: function (result) {
                            if (result == ""OK"") {
                                Swal.fire(
                                    'Success !',
                                    'Promotion Saved!',
                                    'success'
                                );
                                LoadFrm();
                            }
                            else {
                                Swal.fire(
                                    'Info !',
                                    ''+ result +'',
                                    'error'
                                );
                            }
                        },
                        error: function (e) {
                            Swa");
                WriteLiteral(@"l.fire(
                                'Error !',
                                '' + e + '',
                                'error'
                            );
                        }
                      });
            }
        }
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
