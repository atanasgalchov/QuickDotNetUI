using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Html
{
	public static class HtmlContentExtensions
	{
		public static IHtmlContent AdjustContent(this IHtmlContent htmlHelper, Func<IHtmlContent, IHtmlContent> func)
		{
			return func(htmlHelper);
		}
	}
}
