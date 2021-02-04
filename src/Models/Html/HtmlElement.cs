using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Models
{
   public class HtmlElement : IHtmlElement
    {
        private string _uid;
        private string _name;
        private HtmlString _text = HtmlString.Empty;
        public HtmlElement(string tagName)
        {
            _uid = new Guid().ToString();
            _name = tagName;
        }
		public HtmlElement(string tagName, string text): this (tagName)
		{
            _text = new HtmlString(text);
        }
        public string UId => _uid;
        public string Name => _name;


        public IHtmlElementsCollection Children { get; set; }

        public IHtmlAttribute[] Attributes { get; set; }

        public void AddAttribute(IHtmlAttribute attribute)
        {
            throw new NotImplementedException();
        }

        public void AddAttributeValue(string Name, string Value)
        {
            throw new NotImplementedException();
        }

        public void Append(HtmlString Html)
        {
            throw new NotImplementedException();
        }

        public void GetAttribute(string Name)
        {
            throw new NotImplementedException();
        }

        public void HasAttribute(string Name)
        {
            throw new NotImplementedException();
        }

        public void Text(HtmlString html)
        {
            _text = html;
        }

        public HtmlString Text()
        {
            return _text;
        }

        public void MergeAttributes(IHtmlAttribute[] Attributes)
        {
            throw new NotImplementedException();
        }

        public void RemoveAttribute(string Name)
        {
            throw new NotImplementedException();
        }

        public void ReplaceAttributeValue(string Name, string Value)
        {
            throw new NotImplementedException();
        }

        public HtmlString ToHtmlString()
        {
            throw new NotImplementedException();
        }
    }
}
