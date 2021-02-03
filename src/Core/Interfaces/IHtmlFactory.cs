using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Core
{
    public interface IHtmlFactory
    {
        IHtmlBuilder HtmlBuilder { get; }
    }
}
