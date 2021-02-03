using System;
using System.Collections.Generic;
using System.Text;

namespace QuickDotNetUI.Models
{
    public interface IHtmlStandarts
    {
        string HtmlVersion { get;  }
        string[] AllTags { get;}
        IDictionary<string, string[]> AttributeTags { get; }
        string[] SelfClosingTags { get;}

        void Read();
    }
}
