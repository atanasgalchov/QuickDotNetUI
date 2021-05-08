using AgileDotNetHtml;
using AgileDotNetHtml.Interfaces;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;

namespace QuickDotNetUI.Html
{
	public static class HtmlContentExtensions
	{
		public static IHtmlContent AdjustContent(this IHtmlContent htmlContent, Func<IHtmlContent, IHtmlContent> func)
		{
			return func(htmlContent);
		}

		public static IHtmlContent AddAttribute(this IHtmlContent htmlContent, string name, string value = null) 
		{
			IHtmlParser parser = new HtmlParser();
			IHtmlBuilder builder = new HtmlBuilder();
			string html = String.Empty;
			using (var writer = new System.IO.StringWriter())
			{
				htmlContent.WriteTo(writer, HtmlEncoder.Default);
				html = writer.ToString();				
			}

			IHtmlElement element = parser.ParseString(html).FirstOrDefault();
			element.AddAttributeValue(name, value);
			return builder.CreateHtmlContent(element);
		}
	}
}
