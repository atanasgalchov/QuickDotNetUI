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
				
				

				if (input.GetAttribute("name")?.Value != null)
				{
					HtmlElement validationMessageTag = new HtmlElement("span");
					using (var writer = new System.IO.StringWriter())
					{						
						_htmlHelper.ValidationMessage(input.GetAttribute("name").Value, _options?.ValidationMessageAttributes?.ToDictionary()).WriteTo(writer, HtmlEncoder.Default);
						validationMessageTag.Text(new HtmlString(writer.ToString()));
					}

					using (var writer = new System.IO.StringWriter())
					{
						_htmlHelper.TextBox(input.GetAttribute("name").Value).WriteTo(writer, HtmlEncoder.Default);

						foreach (var item in Regex.Match(writer.ToString(), @"(\S+)=[""']?((?:.(?![""']?\s + (?:\S +)=|\s *\/?[> ""']))+.)[""']?").Captures)		
							input.AddAttributeValue(item.ToString().Split("=")[0], item.ToString().Split("=")[1]);

						foreach (var item in Regex.Match(writer.ToString(), @"\s([a-zA-Z]+)[\s />]").Captures)						
							input.AddAttribute(new Name(item.ToString()));
							
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
