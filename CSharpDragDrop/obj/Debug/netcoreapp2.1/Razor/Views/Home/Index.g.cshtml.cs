#pragma checksum "C:\Users\rajde\source\repos\CSharpDragDrop\CSharpDragDrop\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8805f80bcd4901c517e7235cc6535aee968b452"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
#line 4 "C:\Users\rajde\source\repos\CSharpDragDrop\CSharpDragDrop\Views\Home\Index.cshtml"
using System.Collections.Generic;

#line default
#line hidden
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\rajde\source\repos\CSharpDragDrop\CSharpDragDrop\Views\_ViewImports.cshtml"
using CSharpDragDrop;

#line default
#line hidden
#line 2 "C:\Users\rajde\source\repos\CSharpDragDrop\CSharpDragDrop\Views\_ViewImports.cshtml"
using CSharpDragDrop.Models;

#line default
#line hidden
#line 2 "C:\Users\rajde\source\repos\CSharpDragDrop\CSharpDragDrop\Views\Home\Index.cshtml"
using ShieldUI.AspNetCore.Mvc;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8805f80bcd4901c517e7235cc6535aee968b452", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d65e008164a26c3d41fb6d3141b815e5c84bf33e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CSharpDragDrop.Models.Country>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(140, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\Users\rajde\source\repos\CSharpDragDrop\CSharpDragDrop\Views\Home\Index.cshtml"
  
    // Setup data
    List<dynamic> data = new List<dynamic>();
    foreach (Country country in Model)
    {
        dynamic countryObj = new
        {
            text = country.Name,
            expanded = true,
            iconCls = "fa fa-folder",
            items = new List<dynamic>()
        };
        foreach (State state in country.States)
        {
            dynamic stateObj = new
            {
                text = state.Name
            };
            countryObj.items.Add(stateObj);
        }
        data.Add(countryObj);
    }


#line default
#line hidden
            BeginContext(718, 2963, true);
            WriteLiteral(@"    <script type=""text/javascript"">
        $(document).ready(function () {
            // Grid View
            $(""#example"").dataTable({
                ""stripeClasses"": [],
                aLengthMenu: [10],
                ""pagingType"": ""simple""
            });
            $('#example tbody').on('click', 'tr', function () {
                $(this).toggleClass('selected');
            });
            $(""#example tbody"").sortable({
                revert: true,
                helper: function (e, item) {
                    if (!item.hasClass('selected')) item.addClass('selected');
                    var elements = $('.selected').not('.ui-sortable-placeholder').clone();
                    var helper = $('<table />');
                    item.siblings('.selected').addClass('hidden');
                    return helper.append(elements);
                },
                start: function (e, ui) {
                    var elements = ui.item.siblings('.selected.hidden').not('.ui-sortable-p");
            WriteLiteral(@"laceholder');
                    ui.item.data('items', elements);
                },
                update: function (e, ui) {
                    ui.item.after(ui.item.data(""items""));
                },
                stop: function (e, ui) {
                    ui.item.siblings('.selected').removeClass('hidden');
                    $('tr.selected').removeClass('selected');
                }
            });

            // Tree View
            window.droppableOver = function (e) {
                if (!e.valid) {
                    if ($(e.draggable).hasClass('doc-item1') || $(e.draggable).hasClass('doc-item2')) {
                        e.valid = true;
                    }
                }
            };
            window.drop = function (e) {
                console.log(e);
                var valid = e.valid;
                if (!valid) {
                    if ($(e.draggable).hasClass('doc-item1') || $(e.draggable).hasClass('doc-item2')) {
                        valid = ");
            WriteLiteral(@"true;
                    }
                }
                if (valid) {
                    if (e.sourceNode) {
                        this.append(e.sourceNode, e.targetNode);
                    }
                    else {
                        this.append({ text: $(e.draggable).html() }, e.targetNode);
                        $(e.draggable).remove();
                    }
                    e.skipAnimation = true;
                }
            };
            $("".doc-item1 .doc-item2"").shieldDraggable({
                scope: ""treeview-dd-scope"",
                helper: function () {
                    return $(this.element).clone().appendTo(document.body);
                },
                events: {
                    stop: function (e) {
                        e.preventDefault();
                    }
                }
            });
        });
    </script>
");
            EndContext();
            BeginContext(3683, 672, true);
            WriteLiteral(@"    <style>
        table {
            border-collapse: collapse;
        }

            table thead tr {
                margin-left: 20px;
            }

            table tbody tr {
                border: 1px solid #ccc;
            }

        tr-selecting {
            background: #FECA40;
        }

        .selected {
            background: #ff6a00;
            color: white;
            cursor: move;
        }

        .dataTables_filter {
            display: none;
        }

        .dataTables_length {
            display: none !important;
        }

        .hidden {
            display: none;
        }
    </style>
");
            EndContext();
            BeginContext(4357, 141, true);
            WriteLiteral("    <h2>Grid View</h2>\r\n    <table class=\"table\" id=\"example\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(4499, 46, false);
#line 144 "C:\Users\rajde\source\repos\CSharpDragDrop\CSharpDragDrop\Views\Home\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.First().Id));

#line default
#line hidden
            EndContext();
            BeginContext(4545, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(4613, 48, false);
#line 147 "C:\Users\rajde\source\repos\CSharpDragDrop\CSharpDragDrop\Views\Home\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.First().Name));

#line default
#line hidden
            EndContext();
            BeginContext(4661, 97, true);
            WriteLiteral("\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody class=\"doc-item1\">\r\n");
            EndContext();
#line 152 "C:\Users\rajde\source\repos\CSharpDragDrop\CSharpDragDrop\Views\Home\Index.cshtml"
             foreach (var country in Model)
            {

#line default
#line hidden
            BeginContext(4818, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4891, 40, false);
#line 156 "C:\Users\rajde\source\repos\CSharpDragDrop\CSharpDragDrop\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => country.Id));

#line default
#line hidden
            EndContext();
            BeginContext(4931, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(5011, 42, false);
#line 159 "C:\Users\rajde\source\repos\CSharpDragDrop\CSharpDragDrop\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => country.Name));

#line default
#line hidden
            EndContext();
            BeginContext(5053, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 162 "C:\Users\rajde\source\repos\CSharpDragDrop\CSharpDragDrop\Views\Home\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(5120, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
            BeginContext(5154, 115, true);
            WriteLiteral("    <br /><br /><br /><br />\r\n    <h2>Tree View</h2>\r\n    <hr />\r\n    <div id=\"treeview\" class=\"doc-item2\"></div>\r\n");
            EndContext();
            BeginContext(5277, 391, false);
#line 171 "C:\Users\rajde\source\repos\CSharpDragDrop\CSharpDragDrop\Views\Home\Index.cshtml"
Write(Html.ShieldTreeView()
                           .Name("treeview")
                           .DragDrop(true)
                           .DragDropScope("treeview-dd-scope")
                           .DataSource(ds => ds.Data(data.ToArray()))
                           .Events(ev => ev.DroppableOver(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    BeginContext(5590, 13, true);
    WriteLiteral("droppableOver");
    EndContext();
    PopWriter();
}
))
                                                   .Drop(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    BeginContext(5677, 4, true);
    WriteLiteral("drop");
    EndContext();
    PopWriter();
}
)))
    );

#line default
#line hidden
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CSharpDragDrop.Models.Country>> Html { get; private set; }
    }
}
#pragma warning restore 1591
