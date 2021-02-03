using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Models
{
    public interface IHtmlElement : IHtml
    {
        string UId { get; }
        string Name { get; }
        IHtmlElementsCollection Children { get; }
        void Text(HtmlString html);
        HtmlString Text();
        void Append(HtmlString Html);
        IHtmlAttribute[] Attributes { get; set; }
        void AddAttribute(IHtmlAttribute attribute);
        void AddAttributeValue(string Name, string Value);
        void ReplaceAttributeValue(string Name, string Value);
        void RemoveAttribute(string Name);
        void HasAttribute(string Name);
        void GetAttribute(string Name);
        void MergeAttributes(IHtmlAttribute[] Attributes);
    }
}
