using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Models
{
	public class HtmlAttributes : IHtmlAttribute
	{
		public HtmlAttributes(string name)
		{
			Name = name;
		}
		public HtmlAttributes(string name, string value) : this(name)
		{
			Value = value;
		}

		public string Name { get; set; }
		public string Value { get; set; }
	}
	public class Class : HtmlAttributes
	{
		public Class(string value): base("class", value)
		{
		}
	}
	public class Name : HtmlAttributes
	{
		public Name(string value) : base("name", value)
		{
		}
	}
	public class Id : HtmlAttributes
	{
		public Id(string value) : base("id", value)
		{
		}
	}
	public class Type : HtmlAttributes
	{
		public Type(string value) : base("type", value)
		{
		}
	}
}
