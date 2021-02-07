using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuickDotNetUI.Attributes;
using QuickDotNetUI.Extensions;
using QuickDotNetUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
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

        public IHtmlContent CreateElement(HtmlElementOptions htmlElemenDefinition) 
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
		public IHtmlContent CreateFormElement(HtmlFormOptions options)
		{
            var formGenerator = new HtmlFormGenerator(options);
            var formElement = formGenerator.GenerateFormElement();
            return HtmlBuilder.CreateElement(formElement);
		}
    }
}
