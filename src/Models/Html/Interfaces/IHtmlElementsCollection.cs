using Microsoft.AspNetCore.Html;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace QuickDotNetUI.Models
{
    public interface IHtmlElementsCollection : IEnumerable<IHtmlElement>
    {
        IHtmlElement Get(string uid);
        void Add(IHtmlElement tag);
        void AddBefore(string uid, IHtmlElement tag);
        void AddAfter(string uid, IHtmlElement tag);
        void Remove(string uid);
        void RemoveAll(string name);
		void AddRange(IEnumerable<HtmlElement> enumerable);
	}
}
