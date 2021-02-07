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

        public static IHtmlContent Form(this IHtmlHelper htmlHelper, HtmlFormOptions options) { return htmlFactory.CreateFormElement(options); }

        // -- input ---------------------------------------------------------------------------------------------------------------------------------

        // -- div ---------------------------------------------------------------------------------------------------------------------------------

        public static IHtmlContent Div(this IHtmlHelper htmlHelper, string text) { 
            return htmlFactory.CreateElement(new HtmlElementOptions { TagName = "div", Text = text });
        }
        public static IHtmlContent Div(this IHtmlHelper htmlHelper, string text, params IHtmlAttribute[] attributes) {            
            return htmlFactory.CreateElement(new HtmlElementOptions { TagName = "div", Text = text, Attributes = attributes });
        }
        public static IHtmlContent Div(this IHtmlHelper htmlHelper, params IHtmlAttribute[] attributes) {
            return htmlFactory.CreateElement(new HtmlElementOptions { TagName = "div", Attributes = attributes });
        }
        public static IHtmlContent Div(this IHtmlHelper htmlHelper, params IHtmlContent[] tags) {
            return htmlFactory.CreateElement(new HtmlElementOptions { TagName = "div", Elements = tags });
        }
        public static IHtmlContent Div(this IHtmlHelper htmlHelper, IHtmlAttribute[] attributes, params IHtmlContent[] tags)
        {
            return htmlFactory.CreateElement(new HtmlElementOptions { TagName = "div", Attributes = attributes, Elements = tags });
        }
        public static IHtmlContent Div(this IHtmlHelper htmlHelper, string text, params IHtmlContent[] tags) {
            return htmlFactory.CreateElement(new HtmlElementOptions { TagName = "div", Text = text, Elements = tags });
        }

        // -- h3 ---------------------------------------------------------------------------------------------------------------------------------

        public static IHtmlContent H3(this IHtmlHelper htmlHelper, string text) { 
            return htmlFactory.CreateElement(new HtmlElementOptions { TagName = "h3", Text = text }); 
        }
    }
}
