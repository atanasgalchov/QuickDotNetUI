using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Models
{
	public interface IHtmlElementDefinition
	{
		string TagName { get; set; }
		string Text { get; set; }
		IHtmlAttribute[] Attributes { get; set; }
		IHtmlContent[] Elements { get; set; }
	}
}
