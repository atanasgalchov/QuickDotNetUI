using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Attributes
{
	public class HtmlInputAttribute : Attribute
	{
		public HtmlInputAttribute(string name)
		{
			Name = name;
		}
		public string Name { get; set; }
	}


	public class DisabledAttribute : HtmlInputAttribute
	{
		public DisabledAttribute() : base("disabled")
		{

		}
	}
	public class ReadOnlyAttribute : HtmlInputAttribute
	{
		public ReadOnlyAttribute() : base("readonly")
		{

		}
	}
}
