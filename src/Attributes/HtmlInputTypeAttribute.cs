using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Attributes
{
	public class HtmlInputTypeAttribute : UIModelAttribute
	{
		public HtmlInputTypeAttribute(string type)
		{
			Type = type;
		}

		public string Type { get; set; }
	}
	public class HiddenAttribute : HtmlInputTypeAttribute
	{
		public HiddenAttribute(): base("hidden")
		{
		}
	}
	public class PhoneAttribute : HtmlInputTypeAttribute 
	{
		public PhoneAttribute(): base("phone")
		{

		}
		public PhoneAttribute(string patern) : base("tel")
		{
			Patern = patern;
		}
		public string Patern { get; set; }
	}
	public class RadioButtonAttribute : HtmlInputTypeAttribute, IHtmlMultipleValuesInputAttribute
	{
		public RadioButtonAttribute() : base("radio")
		{				
		}
		public RadioButtonAttribute(SelectListItem[] values) : base("radio")
		{
			Values = values;
		}
		public RadioButtonAttribute(string source) : base("radio")
		{
			SourceProperty = source;
		}
		public RadioButtonAttribute(string sourceProperty, SelectListItem[] values) : base("radio")
		{
			SourceProperty = sourceProperty;
			Values = values;
		}
		/// <summary>
		/// Property Name in curent object which keep Values of type 'SelectListItem'.
		/// </summary>
		public string SourceProperty { get; set; }

		/// <summary>
		/// Values of type 'SelectListItem'.
		/// </summary>
		public SelectListItem[] Values { get; set; }
	}

	public class ColorAttribute : HtmlInputTypeAttribute { public ColorAttribute() : base("color") { } }
	public class DateAttribute : HtmlInputTypeAttribute { public DateAttribute() : base("date") { } }
	public class DatetimeLocalAttribute : HtmlInputTypeAttribute { public DatetimeLocalAttribute() : base("datetime-local") { } }
	public class EmailAttribute : HtmlInputTypeAttribute { public EmailAttribute() : base("email") { } }
	public class FileAttribute : HtmlInputTypeAttribute { public FileAttribute() : base("file") { } }
	public class ImageAttribute : HtmlInputTypeAttribute { public ImageAttribute() : base("image") { } }
	public class MonthAttribute : HtmlInputTypeAttribute { public MonthAttribute() : base("month") { } }
	public class NumberAttribute : HtmlInputTypeAttribute { public NumberAttribute() : base("number") { } }
	public class PasswordAttribute : HtmlInputTypeAttribute { public PasswordAttribute() : base("password") { } }
	public class RangeAttribute : HtmlInputTypeAttribute { public RangeAttribute() : base("range") { } }
	public class SearchAttribute : HtmlInputTypeAttribute { public SearchAttribute() : base("search") { } }
	public class TelAttribute : HtmlInputTypeAttribute { public TelAttribute() : base("tel") { } }
	public class TextAttribute : HtmlInputTypeAttribute { public TextAttribute() : base("text") { } }
	public class TimeAttribute : HtmlInputTypeAttribute { public TimeAttribute() : base("time") { } }
	public class UrlAttribute : HtmlInputTypeAttribute { public UrlAttribute() : base("url") { } }
}
