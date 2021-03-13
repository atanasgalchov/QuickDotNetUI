using AgileDotNetHtml;
using AgileDotNetHtml.HtmlAttributes;
using AgileDotNetHtml.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuickDotNetUI.Models;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

namespace QuickDotNetUI.Core
{
	public class AspValidationInjector : IHtmlFormValidationInjector
	{
		private IHtmlHelper _htmlHelper;
		private HtmlFormValidationOptions _options;
		public AspValidationInjector(IHtmlHelper htmlHelper, HtmlFormValidationOptions options)
		{
			_htmlHelper = htmlHelper;
			_options = options;
		}

		public void Inject(IHtmlElement element)
		{
			IHtmlElement input = element.Children.FirstOrDefault(x => x.TagName == "input");
			if (input != null)
			{

				AgileDotNetHtml.Parser.HtmlParser parser = new AgileDotNetHtml.Parser.HtmlParser(new Html5Standarts());
				IHtmlElementsCollection elements = parser.ParseString("<div class=\"form-group\"><label for=\"Name\" class=\"control-label\">Name*:</label><div><input class=\"form-control\" type=\"text\" value=\"Atanas\" data-val=\"true\" data-val-required name=\"Name\"><span><span class=\"field-validation-valid\" data-valmsg-for=\"Name\" data-valmsg-replace=\"true\"></span></span></div></div>");  

				if (input.GetAttribute("name")?.Value != null)
				{
					IHtmlElement validationMessageTag;
					using (var writer = new System.IO.StringWriter())
					{						
						_htmlHelper.ValidationMessage(input.GetAttribute("name").Value, _options?.ValidationMessageAttributes?.ToDictionary()).WriteTo(writer, HtmlEncoder.Default);
						validationMessageTag = parser.ParseString(writer.ToString()).FirstOrDefault();
					}

					using (var writer = new System.IO.StringWriter())
					{
						 _htmlHelper.TextBox(input.GetAttribute("name").Value).WriteTo(writer, HtmlEncoder.Default);
						IHtmlElement textBox = parser.ParseString(writer.ToString()).FirstOrDefault();
						foreach (var attr in textBox.Attributes)						
							if (attr.Name.StartsWith("data"))
								input.AddAttribute(attr);						
					}

					element.Children.AddAfter(input.UId, validationMessageTag);
				}
			}

			int index = 0;
			while (element.Children.Count > index)
			{
				Inject(element.Children[index]);
				index++;
			}
		}
	}
}
