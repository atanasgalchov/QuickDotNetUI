using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Attributes
{
	public interface IHtmlMultipleValuesInputAttribute
	{

		/// <summary>
		/// Property Name in curent object which keep Values of type 'IEnumerable SelectListItem>'.
		/// </summary>
		string SourceProperty { get; set; }

		/// <summary>
		/// Values of type 'SelectListItem'.
		/// </summary>
		SelectListItem[] Values { get; set; }
	}
}
