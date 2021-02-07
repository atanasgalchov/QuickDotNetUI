﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickDotNetUI.Models
{
    public class HtmlElementsCollection : IHtmlElementsCollection
    {
        private List<IHtmlElement> _List = new List<IHtmlElement>();
        protected List<IHtmlElement> List { get { return _List; } }

		public HtmlElementsCollection()
		{

		}
		public HtmlElementsCollection(IHtmlElement[] elements)
		{
            _List.AddRange(elements);

        }
        public IHtmlElement this[int index]
        {
            get
            {
                return (IHtmlElement)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }
        public void Add(IHtmlElement tag)
        {
            _List.Add(tag);
        }
        public void AddRange(IEnumerable<HtmlElement> enumerable)
        {
            _List.AddRange(enumerable);
        }
        public void AddAfter(string uid, IHtmlElement tag)
        {
            throw new NotImplementedException();
        }
        public void AddBefore(string uid, IHtmlElement tag)
        {
            throw new NotImplementedException();
        }
        public IHtmlElement Get(string uid)
        {
            IHtmlElement htmlElement = List.FirstOrDefault(x => x.UId == uid);
            if (htmlElement != null)
                return htmlElement;

            foreach (var element in List)
            {
                htmlElement = element.Children?.Get(uid);
                if (htmlElement != null)
                    break;
            }

            return htmlElement;
        }
        public void Remove(string uid)
        {
            throw new NotImplementedException();
        }
        public void RemoveAll(string name)
        {
            throw new NotImplementedException();
        }
     
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<IHtmlElement> GetEnumerator()
        {
            foreach (var element in List)
            {
                yield return element;
            }
        }
	}
}
