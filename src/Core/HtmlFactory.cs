using Microsoft.AspNetCore.Html;
using QuickDotNetUI.Models;
using QuickDotNetUI.Models.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Core
{
    public class HtmlFactory : IHtmlFactory
    {
        private IHtmlBuilder _htmlBuilder { get; set; }
        public HtmlFactory(IHtmlBuilder htmlBuilder)
        {
            _htmlBuilder = htmlBuilder;
        }
        public IHtmlBuilder HtmlBuilder { get { return _htmlBuilder; } }

        public IHtmlContent CreateHtmlElement(string tagName)
        {
            return CreateHtmlElement(tagName, null);
        }
        public IHtmlContent CreateHtmlElement(string tagName, string text) 
        {
            return HtmlBuilder.CreateElement(new HtmlElement(tagName, text));
        }

        public IHtmlContent CreateHtmlForm(Type type)
        {
            HtmlElement form = new HtmlElement("form");

            foreach (var prop in type.GetProperties()) 
            {
                HtmlElement field = new HtmlElement("input");
                field.Children = new HtmlElementsCollection();
               
            }

            return HtmlBuilder.CreateElement(form);
        }
    }
}
