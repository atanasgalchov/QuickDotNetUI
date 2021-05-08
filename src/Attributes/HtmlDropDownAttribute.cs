using Microsoft.AspNetCore.Mvc.Rendering;

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

		/// <summary>
		/// An flag indicates whether drop down control will be multiple. Default is false.
		/// </summary>
		public bool IsMultiple { get; set; }

		/// <summary>
		/// Property Name in curent object which keep Values of type 'IEnumerable whit type SelectListItem.
		/// </summary>
		public string SourceProperty { get; set; }

		/// <summary>
		/// Values of type 'SelectListItem'.
		/// </summary>
		public SelectListItem[] Values { get; set; }
	}
}
