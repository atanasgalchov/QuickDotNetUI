using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Models
{
	public class HtmlElementOptions
	{
		public string TagName { get; set; }
		public string Text { get; set; }
		public IHtmlAttribute[] Attributes { get; set; }
		public IHtmlContent[] Elements { get; set; }
	}
}
