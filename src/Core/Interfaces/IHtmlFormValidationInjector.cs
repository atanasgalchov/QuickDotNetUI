using AgileDotNetHtml.Interfaces;
using QuickDotNetUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Core
{
	public interface IHtmlFormValidationInjector
	{
		void Inject(IHtmlElement element);
	}
}
