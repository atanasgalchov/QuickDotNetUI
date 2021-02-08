using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Models
{
    public interface IHtmlElement
    {
        string UId { get; }
        string Name { get; }
        int TextIndex { get; }
        IHtmlElementsCollection Children { get; }
        void Text(HtmlString html);
        HtmlString Text();
        void Append(HtmlElement element);
        IHtmlAttribute[] Attributes { get; set; }
        void AddAttribute(IHtmlAttribute attribute);
        void AddAttributeValue(string Name, string Value);
        bool HasAttribute(string Name);
        IHtmlAttribute GetAttribute(string Name);
        void ReplaceAttributeValue(string Name, string Value);
        void RemoveAttribute(string Name);
        void AddRangeAttributes(IHtmlAttribute[] Attributes);
    }
}
