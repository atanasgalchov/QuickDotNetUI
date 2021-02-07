using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Models
{
    public interface IHtmlAttribute
    {
        string Name { get; }
        string Value { get; set; }
    }
}
