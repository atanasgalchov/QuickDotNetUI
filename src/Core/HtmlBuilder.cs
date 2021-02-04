using Microsoft.AspNetCore.Html;
using QuickDotNetUI.Extensions;
using QuickDotNetUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace QuickDotNetUI.Core
{
    public class HtmlBuilder : IHtmlBuilder
    {

        IHtmlStandarts _htmlStandarts;

        /// <summary>
        /// Ctor expect actual state on HTML standarts.
        /// </summary>
        /// <param name="htmlStandarts">Object with HTML standarts.</param>
        public HtmlBuilder(IHtmlStandarts htmlStandarts)
        {
            _htmlStandarts = htmlStandarts;
        }

        /// <summary>
        /// Create standart HTML content from IHtmlTag object.
        /// </summary>
        /// <param name="htmlElement">Object of type IHtmlTag, for convert to standart HTML content.</param>
        /// <returns>Standart HTML content repsresent specified tag.</returns>
        public IHtmlContent CreateElement(IHtmlElement htmlElement) => _CreateElement(htmlElement);
        
        private IHtmlContent _CreateElement(IHtmlElement htmlElement) 
        {
            if (!IsValidHtmlTag(htmlElement.Name))
                throw new ArgumentException(
                    $"{htmlElement.Name} is not valid HTML tag. Standart html tags are {String.Join(',', _htmlStandarts.AllTags)}, " +
                    $"according Html Standarts version {_htmlStandarts.HtmlVersion}");

            if (htmlElement.Children.IsNullOrEmpty())
                return new HtmlString(
                    $"{GetStartHtmlTag(htmlElement.Name)}{htmlElement.Text()}{GetEndHtmlTag(htmlElement.Name)}"
                        .Insert((htmlElement.Name.Length + 1), $" {GetAttributesAsString(htmlElement)}"));

            var childContents = new List<IHtmlContent>();
            foreach (var child in htmlElement.Children)
                childContents.Add(_CreateElement(child));

            return new HtmlString(String.Join("", childContents.Select(x => x.ToString()).ToArray()));
        }

        public string GetStartSelfClosingHtmlTag(string tagName) => $"<{TrimHtmlTag(tagName)} />";
        public string GetStartHtmlTag(string tagName) => IsSelfClosingHtmlTag(tagName) ? GetStartSelfClosingHtmlTag(tagName) : $"<{TrimHtmlTag(tagName)}>";
        public string GetEndHtmlTag(string tagName) => IsSelfClosingHtmlTag(tagName) ? String.Empty : $"</{TrimHtmlTag(tagName)}>";   
        public string TrimHtmlTag(string tagName) => Regex.Replace(tagName, @"\s+|/+", "").TrimStart('<').TrimEnd('>');
        public bool IsValidHtmlTag(string tagName) => _htmlStandarts.AllTags.Any(x => TrimHtmlTag(x).IsEqualIgnoreCase(tagName));
        public bool IsSelfClosingHtmlTag(string tagName) => _htmlStandarts.SelfClosingTags.Any(x => TrimHtmlTag(x).IsEqualIgnoreCase(tagName));
        public bool IsValidHtmlAttribute(string attributeName) => _htmlStandarts.AttributeTags.ContainsKey(attributeName);
        public bool IsValidHtmlAttributeForTag(string attributeName, string tagName)
            => _htmlStandarts.AttributeTags.ContainsKey(attributeName) &&
            (_htmlStandarts.AttributeTags[attributeName].IsNullOrEmpty() || _htmlStandarts.AttributeTags[attributeName].Any(x => TrimHtmlTag(x).IsEqualIgnoreCase(tagName)));
        public string GetAttributesAsString(IHtmlElement htmlTag) 
        {
            string attributesString = String.Empty;
            if (htmlTag.Attributes.IsNullOrEmpty())
                return attributesString;

            foreach (var attribute in htmlTag.Attributes)
            {
                if (!IsValidHtmlAttribute(attribute.Name) || !IsValidHtmlAttributeForTag(attribute.Name, htmlTag.Name))
                    throw new ArgumentException($"{attribute.Name} is not valid attribute for { htmlTag.Name}, according Html Standarts version {_htmlStandarts.HtmlVersion}");

                if (attribute.Value == null)
                    attributesString += $"{attribute.Name} ";
                else
                    attributesString += $"{attribute.Name}=\"{attribute.Value}\" ";
            }

            return attributesString.TrimEnd().TrimStart();
        }
    }
}
