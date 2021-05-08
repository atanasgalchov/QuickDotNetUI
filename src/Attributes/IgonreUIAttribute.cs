using AgileDotNetHtml.Models;
using AgileDotNetHtml.Models.HtmlElements;

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
