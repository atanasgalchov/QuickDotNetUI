using AgileDotNetHtml.Models;
using System;

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
		/// Form group Templete as Func.
		/// </summary>
		public Func<HtmlElement, HtmlElement> FormGroupTemplateFunc { get; set; }
		
		/// <summary>
		/// ASP Validation opttions.
		/// </summary>
		public HtmlFormValidationOptions FormValidationOptions { get; set; }
		/// <summary>
		/// Form element attributes.
		/// </summary>
		public HtmlAttributesCollection FormAttributes { get; set; }
		/// <summary>
		/// Form content element attributes.
		/// </summary>
		public HtmlAttributesCollection FormContentAttributes { get; set; }
		/// <summary>
		///  Buttons footer element attributes.
		/// </summary>
		public HtmlAttributesCollection FormFooterAttributes { get; set; }
		/// <summary>
		/// Label element attributes.
		/// </summary>
		public HtmlAttributesCollection LabelAttributes { get; set; }
		/// <summary>
		/// Form group element attributes.
		/// </summary>
		public HtmlAttributesCollection FormGroupAttributes { get; set; }
		/// <summary>
		/// Input wrapper element attributes.
		/// </summary>
		public HtmlAttributesCollection InputWrapperAttributes { get; set; }
		/// <summary>
		/// Input element attributes.
		/// </summary>
		public HtmlAttributesCollection InputAttributes { get; set; }
		/// <summary>
		/// Radio buttons wrapper element attributes.
		/// </summary>
		public HtmlAttributesCollection RadioButtonsWrapperAttributes { get; set; }
		/// <summary>
		/// Radio buttons group wrapper element attributes.
		/// </summary>
		public HtmlAttributesCollection RadioButtonsGroupWrapperAttributes { get; set; }
		/// <summary>
		/// Radio buttons group label element attributes.
		/// </summary>
		public HtmlAttributesCollection RadioButtonsGroupLabelAttributes { get; set; }
		/// <summary>
		/// Radio buttons group input element attributes.
		/// </summary>
		public HtmlAttributesCollection RadioButtonsGroupInputAttributes { get; set; }
		/// <summary>
		/// Submit Button element attributes.
		/// </summary>
		public HtmlAttributesCollection SubmitButtonAttributes { get; set; }
		/// <summary>
		/// Reset Button element attributes.
		/// </summary>
		public HtmlAttributesCollection ResetButtonAttributes { get; set; }
	}

	public class HtmlFormValidationOptions 
	{
		/// <summary>
		/// Allow validation.Default true.
		/// </summary>
		public bool AllowValidation { get; set; } = true;
		/// <summary>
		/// Use validation summary.Default false.
		/// </summary>
		public bool UseSummary { get; set; }
		/// <summary>
		/// Validation Message element attributes.
		/// </summary>
		public HtmlAttributesCollection ValidationMessageAttributes { get; set; }
		/// <summary>
		/// Validation Message element template.
		/// </summary>
		public Func<HtmlElement, HtmlElement> ValidationMessageElementTemplate { get; set; }
	}
}
