using AgileDotNetHtml;
using QuickDotNetUI.Models;
using System;

namespace QuickDotNetUI.Attributes
{
	public class IgonreUIAttribute: UIModelAttribute
	{
		public IgonreUIAttribute()
		{
		}
		public IgonreUIAttribute(HtmlElement[] allowedElements)
		{
			AllowedElements = allowedElements;
		}
		public HtmlElement[] AllowedElements { get; set; }
	}
}
