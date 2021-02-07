using QuickDotNetUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Models
{
	public class HtmlFormOptions
	{
		public string Action { get; set; }
		public object Model { get; set; }
		/// <summary>
		/// Label Templete as standart .net string format with one place holder for property display name. Exaple "Your text {0}".
		/// </summary>
		public string LabelTemplate { get; set; }
		/// <summary>
		/// Label Templete as Func which return string with parameter display name.
		/// </summary>
		public Func<string, string> LabelTemplateFunc { get; set; }
		/// <summary>
		/// Buttons Templete as Func.
		/// </summary>
		public Func<HtmlElement, HtmlElement> FormFooterTemplateFunc { get; set; }
		
		/// <summary>
		/// Form element attributes.
		/// </summary>
		public IHtmlAttribute[] FormAttributes { get; set; }
		/// <summary>
		/// Form content element attributes.
		/// </summary>
		public IHtmlAttribute[] FormContentAttributes { get; set; }
		/// <summary>
		///  Buttons footer element attributes.
		/// </summary>
		public IHtmlAttribute[] FormFooterAttributes { get; set; }
		/// <summary>
		/// Label element attributes.
		/// </summary>
		public IHtmlAttribute[] LabelAttributes { get; set; }
		/// <summary>
		/// Form group element attributes.
		/// </summary>
		public IHtmlAttribute[] FormGroupAttributes { get; set; }
		/// <summary>
		/// Input wrapper element attributes.
		/// </summary>
		public IHtmlAttribute[] InputWrapperAttributes { get; set; }
		/// <summary>
		/// Input element attributes.
		/// </summary>
		public IHtmlAttribute[] InputAttributes { get; set; }
		/// <summary>
		/// Radio buttons froup wrapper element attributes.
		/// </summary>
		public IHtmlAttribute[] RadioButtonsGroupWrapperAttributes { get; set; }
		/// <summary>
		/// Radio buttons froup label element attributes.
		/// </summary>
		public IHtmlAttribute[] RadioButtonsGroupLabelAttributes { get; set; }
		/// <summary>
		/// Radio buttons froup input element attributes.
		/// </summary>
		public IHtmlAttribute[] RadioButtonsGroupInputAttributes { get; set; }
		/// <summary>
		/// Button element attributes.
		/// </summary>
		public IHtmlAttribute[] ButtonAttributes { get; set; }
	}
}
