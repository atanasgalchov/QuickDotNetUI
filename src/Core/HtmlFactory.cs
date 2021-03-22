using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuickDotNetUI.Models;
using System;
using System.Linq;

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
            return HtmlBuilder.CreateHtmlContent(
                new HtmlElement(htmlElemenDefinition.TagName, text) 
                { 
                    Attributes = htmlElemenDefinition.Attributes
                }
             );
        }
		public IHtmlContent CreateFormElement(IHtmlHelper htmlHelper ,HtmlFormOptions options)
		{
            var formGenerator = new HtmlFormGenerator(options);
            IHtmlElement formElement = formGenerator.GenerateFormElement();

            AspValidationInjector aspValidationInjector = new AspValidationInjector(htmlHelper, options.FormValidationOptions);
            aspValidationInjector.Inject(formElement);

       
            

            return HtmlBuilder.CreateHtmlContent(formElement);
		}
    }
}
