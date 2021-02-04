using Microsoft.AspNetCore.Html;
using QuickDotNetUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IHtmlContent CreateElement(HtmlElementDefinition htmlElemenDefinition) 
        {
            string text = $"{htmlElemenDefinition.Text}" +
                $"{(htmlElemenDefinition.Elements != null ? String.Join(' ', htmlElemenDefinition.Elements.Select(x => x.ToString())) : String.Empty)}";
            return HtmlBuilder.CreateElement(
                new HtmlElement(htmlElemenDefinition.TagName, text) 
                { 
                    Attributes = htmlElemenDefinition.Attributes
                }
             );
        }

        public IHtmlContent CreateHtmlElement(string tagName, string text, IHtmlContent[] tags)
        {
            return HtmlBuilder.CreateElement(new HtmlElement(tagName, text) {  } );
        }
        public IHtmlContent CreateHtmlElement(string tagName, IHtmlContent[] tags)
        {
            return HtmlBuilder.CreateElement(new HtmlElement(tagName));
        }
        public IHtmlContent CreateHtmlElement(string tagName, IHtmlAttribute[] attributes)
        {
            return HtmlBuilder.CreateElement(new HtmlElement(tagName) { Attributes = attributes });
        }
        public IHtmlContent CreateHtmlElement(string tagName, string text) 
        {
            return HtmlBuilder.CreateElement(new HtmlElement(tagName, text));
        }
        public IHtmlContent CreateHtmlElement(string tagName)
        {
            return CreateHtmlElement(tagName, null, null);
        }

        //public IHtmlContent CreateHtmlForm(Type type)
        //{
        //    HtmlElement form = new HtmlElement("form");

        //    foreach (var prop in type.GetProperties()) 
        //    {
        //        HtmlElement field = new HtmlElement("input");
        //        field.Children = new HtmlElementsCollection();
               
        //    }

        //    return HtmlBuilder.CreateElement(form);
        //}
    }
}
