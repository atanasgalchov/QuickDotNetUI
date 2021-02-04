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


        // -- input ---------------------------------------------------------------------------------------------------------------------------------
        
        public static IHtmlContent Input(this IHtmlHelper htmlHelper) { return Input(htmlHelper, null); }
        public static IHtmlContent Input(this IHtmlHelper htmlHelper, string name) { return htmlFactory.CreateHtmlElement("input"); }
        // -- div ---------------------------------------------------------------------------------------------------------------------------------

        public static IHtmlContent Div(this IHtmlHelper htmlHelper, string text) { 
            return htmlFactory.CreateElement(new HtmlElementDefinition { TagName = "div", Text = text });
        }
        public static IHtmlContent Div(this IHtmlHelper htmlHelper, string text, params IHtmlAttribute[] attributes) {            
            return htmlFactory.CreateElement(new HtmlElementDefinition { TagName = "div", Text = text, Attributes = attributes });
        }
        public static IHtmlContent Div(this IHtmlHelper htmlHelper, params IHtmlAttribute[] attributes) {
            return htmlFactory.CreateElement(new HtmlElementDefinition { TagName = "div", Attributes = attributes });
        }
        public static IHtmlContent Div(this IHtmlHelper htmlHelper, params IHtmlContent[] tags) {
            return htmlFactory.CreateElement(new HtmlElementDefinition { TagName = "div", Elements = tags });
        }
        public static IHtmlContent Div(this IHtmlHelper htmlHelper, IHtmlAttribute[] attributes, params IHtmlContent[] tags)
        {
            return htmlFactory.CreateElement(new HtmlElementDefinition { TagName = "div", Attributes = attributes, Elements = tags });
        }
        public static IHtmlContent Div(this IHtmlHelper htmlHelper, string text, params IHtmlContent[] tags) {
            return htmlFactory.CreateElement(new HtmlElementDefinition { TagName = "div", Text = text, Elements = tags });
        }

        // -- h3 ---------------------------------------------------------------------------------------------------------------------------------

        public static IHtmlContent H3(this IHtmlHelper htmlHelper, string text) { 
            return htmlFactory.CreateElement(new HtmlElementDefinition { TagName = "h3", Text = text }); 
        }

        public static IHtmlContent Element(this IHtmlHelper htmlHelper, string tagName, string text, params IHtmlAttribute[] attributes) { return htmlFactory.CreateHtmlElement(tagName); ; }
        public static IHtmlContent Element(this IHtmlHelper htmlHelper, string tagName, string text, IHtmlAttribute[] attributes, params IHtmlContent[] tags) { return htmlFactory.CreateHtmlElement(tagName); ; }
        public static IHtmlContent Element(this IHtmlHelper htmlHelper, string tagName, string text, IHtmlContent[] tags, params IHtmlAttribute[] attributes) { return htmlFactory.CreateHtmlElement(tagName); ; }
    }
}
