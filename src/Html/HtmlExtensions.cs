using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;
using QuickDotNetUI.Core;
using Newtonsoft.Json;
using QuickDotNetUI.Models;

namespace QuickDotNetUI.Html
{
    public static class HtmlExtensions
    {
        private static HtmlFactory htmlFactory = new HtmlFactory(new HtmlBuilder(new Html5Standarts()));


        // -- Input ---------------------------------------------------------------------------------------------------------------------------------
        
        public static IHtmlContent Input(this IHtmlHelper htmlHelper) { return Input(htmlHelper, null); }
        public static IHtmlContent Input(this IHtmlHelper htmlHelper, string name) { return htmlFactory.CreateHtmlElement("input"); }
        public static IHtmlContent Div(this IHtmlHelper htmlHelper, string text) { return htmlFactory.CreateHtmlElement("div", text); ; }
        public static IHtmlContent Element(this IHtmlHelper htmlHelper, string tagName) { return htmlFactory.CreateHtmlElement(tagName); ; }
    }
}
