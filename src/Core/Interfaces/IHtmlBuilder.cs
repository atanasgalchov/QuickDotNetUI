using Microsoft.AspNetCore.Html;
using QuickDotNetUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Core
{
    public interface IHtmlBuilder
    {
        IHtmlContent CreateElement(IHtmlElement element);
    }
}
