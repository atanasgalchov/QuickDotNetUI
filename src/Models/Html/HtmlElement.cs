using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickDotNetUI.Models
{
   public class HtmlElement : IHtmlElement
    {
        private string _uid;
        private string _name;
        private HtmlString _text = HtmlString.Empty;
        private int _textIndex;
        private List<IHtmlAttribute> _attributes { get; set; } = new List<IHtmlAttribute>();
        public HtmlElement(string tagName)
        {
            _uid = Guid.NewGuid().ToString().Replace("-","");
            _name = tagName;
        }
		public HtmlElement(string tagName, string text): this (tagName)
		{
            _text = new HtmlString(text);
        }
        public string UId => _uid;
        public string Name => _name;
        public int TextIndex => _textIndex;
        public IHtmlElementsCollection Children { get; set; } = new HtmlElementsCollection();
        public IHtmlAttribute[] Attributes 
        {
            get 
            { 
                return _attributes.ToArray(); 
            } 
            set 
            {        
                 _attributes = new List<IHtmlAttribute>(value != null ? value : new HtmlAttribute[] { });
            } 
        }
        public void AddAttribute(IHtmlAttribute attribute)
        {
            if (attribute != null) 
            {
                _attributes.RemoveAll(x => x.Name == attribute.Name);

                _attributes.Add(attribute);
            }
        }
        public void AddAttribute(string name)
        {
            AddAttribute(new HtmlAttribute(name));
        }
        public void AddAttributeValue(string Name, string Value)
        {
            if (!_attributes.Any(x => x.Name == Name))
                _attributes.Add(new HtmlAttribute(Name));

            _attributes.Find(x => x.Name == Name).Value = Value;
        }
        public void AddRangeAttributes(IHtmlAttribute[] Attributes)
        {
            _attributes.AddRange(Attributes);
        }
        public IHtmlAttribute GetAttribute(string Name)
        {
            return _attributes.FirstOrDefault(x => x.Name == Name);
        }

        public bool HasAttribute(string Name)
        {
            return _attributes.Any(x => x.Name == Name);
        }

        public void Append(HtmlElement element)
        {
            Children.Add(element);
        }
        public void Text(HtmlString html)
        {
            _text = html;
            _textIndex = 0;
        }
        public void Text(HtmlString html, int index)
        {
            _text = html;
            _textIndex = index;
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
