using AgileDotNetHtml;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlElements;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuickDotNetUI.Models;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

namespace QuickDotNetUI.Core
{
	internal class AspValidationInjector : IHtmlFormValidationInjector
	{
		private IHtmlHelper _htmlHelper;
		private HtmlFormValidationOptions _options;
		internal AspValidationInjector(IHtmlHelper htmlHelper, HtmlFormValidationOptions options)
		{
			_htmlHelper = htmlHelper;
			_options = options;
		}

		public void Inject(HtmlNodeElement element)
		{
			IHtmlElement input = element.Children.FirstOrDefault(x => x.TagName == "input");
			if (input != null)
			{

				HtmlParser parser = new HtmlParser();

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

					element.AddAfter(input.UId, validationMessageTag);
				}
			}

			int index = 0;
			while (element.Children.Count > index)
			{
				if(element.Children[index] is IHtmlNodeElement)
					Inject((HtmlNodeElement)element.Children[index]);
				index++;
			}
		}
	}
}
