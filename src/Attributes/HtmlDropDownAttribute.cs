using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Attributes
{
	public class HtmlDropDownAttribute : UIModelAttribute, IHtmlMultipleValuesInputAttribute
	{
		public HtmlDropDownAttribute()
		{
		}
		public HtmlDropDownAttribute(SelectListItem[] values)
		{
			Values = values;
		}
		public HtmlDropDownAttribute(string sourceProperty)
		{
			SourceProperty = sourceProperty;
		}
		public HtmlDropDownAttribute(string sourceProperty, SelectListItem[] values)
		{
			SourceProperty = sourceProperty;
			Values = values;
		}
		public bool IsMultiple { get; set; }

		/// <summary>
		/// Property Name in curent object which keep Values of type 'IEnumerable SelectListItem>'.
		/// </summary>
		public string SourceProperty { get; set; }

		/// <summary>
		/// Values of type 'SelectListItem'.
		/// </summary>
		public SelectListItem[] Values { get; set; }
	}
}
