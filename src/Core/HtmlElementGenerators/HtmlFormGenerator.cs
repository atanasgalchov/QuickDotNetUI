using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuickDotNetUI.Attributes;
using QuickDotNetUI.Extensions;
using QuickDotNetUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace QuickDotNetUI.Core
{
	public class HtmlFormGenerator
	{
		private HtmlFormOptions _options;
		public HtmlFormGenerator(HtmlFormOptions options)
		{
			_options = options;
		}

        public HtmlElement GenerateFormElement()
        {

            HtmlElement formContent = new HtmlElement("div");
            formContent.Children = GetHtmlFormGroups();
            
            HtmlElement formFooter = new HtmlElement("div");       
            formFooter.Append(GetFormButtons());

            if (_options.FormFooterAttributes != null)
                formFooter.AddRangeAttributes(_options.FormFooterAttributes);

            if (_options != null && _options.FormFooterTemplateFunc != null)
                formFooter = _options.FormFooterTemplateFunc(formFooter);

            HtmlElement form = new HtmlElement("form");
            form.AddAttributeValue("action", _options.Action);
            form.Attributes = _options?.FormAttributes;
            form.Append(formContent);
            form.Append(formFooter);

            return form;
        }

        private HtmlElement GetInputByAttribute(PropertyInfo propInfo)
        {
            HtmlElement input;
            if (propInfo.GetCustomAttribute<HtmlDropDownAttribute>() != null)
            {
                HtmlDropDownAttribute dropDownAttribute = propInfo.GetCustomAttribute<HtmlDropDownAttribute>();
                IEnumerable<SelectListItem> values = (IEnumerable<SelectListItem>)_options.Model.GetType().GetProperty(dropDownAttribute.SourceProperty).GetValue(_options.Model);

                input = GetSelect(propInfo.Name, values, (string)propInfo.GetValue(_options.Model), dropDownAttribute.IsMultiple);
            }
            else
            {
                HtmlInputTypeAttribute inputTypeAttribute = propInfo.GetCustomAttribute<HtmlInputTypeAttribute>();
                input = GetInput(inputTypeAttribute.Type, propInfo.Name, propInfo.GetValue(_options.Model), null, null);
            }

            return input;
        }
        private HtmlElement GetInputByPropertyInfo(PropertyInfo propInfo)
        {
            string type = "text";
            string dateFormat = (propInfo.GetCustomAttribute<DisplayFormatAttribute>() != null &&
                propInfo.GetCustomAttribute<DisplayFormatAttribute>().DataFormatString != null) ?
                propInfo.GetCustomAttribute<DisplayFormatAttribute>().DataFormatString :
                "yyyy-MM-dd";
            List<SelectListItem> values = null;

            if (propInfo.PropertyType.IsNumbericType())
                type = "number";
            if (propInfo.PropertyType.IsEqualTypeIgnoreNullable(typeof(DateTime)))
                type = "date";
            if (propInfo.PropertyType.IsEqualTypeIgnoreNullable(typeof(TimeSpan)))
                type = "time";
            if (propInfo.PropertyType.IsEqualTypeIgnoreNullable(typeof(bool)))
                type = "checkbox";
            if (propInfo.PropertyType.IsEqualTypeIgnoreNullable(typeof(IFormFile)))
                type = "file";
            if (propInfo.PropertyType.IsEnum ||
                (propInfo.PropertyType.IsNullable() && Nullable.GetUnderlyingType(propInfo.PropertyType).IsEnum))
            {
                type = "radio";
                values = GetValuesFromEnum(propInfo.PropertyType);
            }


            // TODO Implement


            return GetInput(type, propInfo.Name, propInfo.GetValue(_options.Model), values, dateFormat);
        }
        private HtmlElementsCollection GetHtmlFormGroups()
        {
            HtmlElementsCollection formElements = new HtmlElementsCollection();
            PropertyInfo[] propertiesInfo = _options.Model.GetType().GetProperties();

            foreach (var propInfo in propertiesInfo)
            {
                bool isSourceProperty = propertiesInfo.Any(
                    prop => prop.GetCustomAttributes().Any(
                        attr => attr.GetType().GetProperty(nameof(IHtmlMultipleValuesInputAttribute.SourceProperty))?.GetValue(attr) == propInfo.Name));

                // TODO Test
                if (propInfo.GetCustomAttribute<IgonreUIAttribute>() != null || isSourceProperty)
                    continue;

                // if Type is class, should generate inputs for him properties
                if (!propInfo.PropertyType.IsPrimitive && propInfo.PropertyType != typeof(string) && propInfo.PropertyType != typeof(DateTime))
                {

                    //foreach (var fieldSet in GetHtmlFormFiledSets<T>(definition))
                    //    formFieldSets.Add(fieldSet);
                }

                if (propInfo.GetCustomAttribute<HiddenAttribute>() != null)
                    formElements.Add(GetProperInput(propInfo));
                else
                    formElements.Add(GetFormGroup(propInfo));
            }

            return formElements;
        }
        private HtmlElement GetLabel(PropertyInfo propInfo)
        {
            DisplayAttribute displayAttr = propInfo.GetCustomAttribute<DisplayAttribute>();
            bool IsRequired = propInfo.GetCustomAttribute<RequiredAttribute>() != null;
            string labelText = $"{(displayAttr != null ? displayAttr.Name : propInfo.Name)}{(IsRequired ? "*" : "")}:";

            if (_options != null && _options.LabelTemplate != null)
                labelText = String.Format(_options.LabelTemplate, labelText);
            else if (_options != null && _options.LabelTemplateFunc != null)
                labelText = _options.LabelTemplateFunc(labelText);

            HtmlElement label = new HtmlElement("label", labelText);
            label.Attributes = new IHtmlAttribute[] { new HtmlAttribute("for", propInfo.Name)};
           
            if(_options.LabelAttributes != null)
                label.AddRangeAttributes(_options.LabelAttributes);
           
            return label;
        }
        private HtmlElement GetProperInput(PropertyInfo propInfo)
        {
            if (propInfo.GetCustomAttribute<UIModelAttribute>() != null)
                return GetInputByAttribute(propInfo);

            return GetInputByPropertyInfo(propInfo);
        }
        private HtmlElement GetInput(string type, string name, object value, List<SelectListItem> values, string format = null)
        {
            HtmlElement input = new HtmlElement("input");
            input.AddAttribute(new Name(name));

            if (_options.InputAttributes != null)
                input.AddRangeAttributes(_options.InputAttributes);

            switch (type)
            {
                case "checkbox":
                    input.AddAttributeValue("type", "checkbox");
                    input.AddAttributeValue("value", "true");
                    if ((bool)value == true)
                        input.AddAttribute(new HtmlAttribute("checked"));
                    break;
                case "color":
                    input.AddAttributeValue("type", "color");
                    input.AddAttributeValue("value", value != null ? value.ToString() : "");
                    break;
                case "date":
                    input.AddAttributeValue("type", "date");
                    input.AddAttributeValue("value", value != null ? ((DateTime)value).ToString(format) : "");
                    input.AddAttributeValue("data-format", format);
                    break;
                case "datetime-local":
                    input.AddAttributeValue("type", "datetime-local");
                    input.AddAttributeValue("value", value != null ? ((DateTime)value).ToString(format) : "");
                    input.AddAttributeValue("data-format", format);
                    break;
                case "email":
                    input.AddAttributeValue("type", "email");
                    input.AddAttributeValue("value", value != null ? value.ToString() : "");
                    break;
                case "file":
                    input.AddAttributeValue("type", "file");
                    break;
                case "hidden":
                    input.AddAttributeValue("type", "hidden");
                    input.AddAttributeValue("value", value != null ? value.ToString() : "");
                    break;
                case "month":
                    input.AddAttributeValue("type", "month");
                    input.AddAttributeValue("value", value != null ? value.ToString() : "");
                    input.AddAttributeValue("data-format", format);
                    break;
                case "number":
                    input.AddAttributeValue("type", "number");
                    input.AddAttributeValue("value", value != null ? value.ToString() : "");
                    break;
                case "password":
                    input.AddAttributeValue("type", "password");
                    input.AddAttributeValue("value", value != null ? value.ToString() : "");
                    break;
                case "radio":
                    input = GeRadioButtonsGroup(name, values, value != null ? value.ToString() : "");
                    break;
                case "range":
                    input.AddAttributeValue("type", "range");
                    input.AddAttributeValue("value", value != null ? value.ToString() : "");
                    break;
                case "search":
                    input.AddAttributeValue("type", "search");
                    input.AddAttributeValue("value", value != null ? value.ToString() : "");
                    break;
                case "tel":
                    input.AddAttributeValue("type", "tel");
                    input.AddAttributeValue("value", value != null ? value.ToString() : "");
                    break;
                case "time":
                    input.AddAttributeValue("type", "time");
                    input.AddAttributeValue("value", value != null ? value.ToString() : "");
                    break;
                case "url":
                    input.AddAttributeValue("type", "url");
                    input.AddAttributeValue("value", value != null ? value.ToString() : "");
                    break;

                default:
                    input.AddAttributeValue("type", "text");
                    input.AddAttributeValue("value", value != null ? value.ToString() : "");
                    break;
            }

            return input;
        }
        private HtmlElement GetSelect(string name, IEnumerable<SelectListItem> values, string value, bool isMultiple = false)
        {
            HtmlElement select = new HtmlElement("select");
            select.AddAttribute(new Name(name));
            if (isMultiple)
                select.AddAttribute("multiple");

            if (_options.InputAttributes != null)
                select.AddRangeAttributes(_options.InputAttributes);

            foreach (var item in values)
            {
                var option = new HtmlElement("option")
                {
                    Attributes = new IHtmlAttribute[]
                    {
                        new HtmlAttribute("value", item.Value)
                    }
                };

                option.Text(new HtmlString(item.Text));

                if (item.Selected || (value != null && item.Value == value.ToString()))
                    option.AddAttribute("selected");

                select.Append(option);
            }

            return select;
        }
        private HtmlElement GeRadioButtonsGroup(string name, IEnumerable<SelectListItem> values, string value, bool isMultiple = false)
        {
            HtmlElement wrapper = new HtmlElement("div");
          
            if (_options.RadioButtonsWrapperAttributes != null)
                wrapper.AddRangeAttributes(_options.RadioButtonsWrapperAttributes);

            foreach (var item in values)
            {
               
                var label = new HtmlElement("label");
                label.Text(new HtmlString(item.Text), 1);

                if (_options.RadioButtonsGroupLabelAttributes != null)
                    label.AddRangeAttributes(_options.RadioButtonsGroupLabelAttributes);

                var radioInput = new HtmlElement("input")
                {
                    Attributes = new IHtmlAttribute[]
                    {
                        new HtmlAttribute("name", name),
                        new HtmlAttribute("value", item.Value),
                        new HtmlAttribute("type", isMultiple ? "checkbox" : "radio")
                    }
                };

                if (_options.RadioButtonsGroupInputAttributes != null)
                    radioInput.AddRangeAttributes(_options.RadioButtonsGroupInputAttributes);

                if (item.Selected || (value != null && item.Value == value.ToString()))
                    radioInput.AddAttribute(new HtmlAttribute("checked"));

                label.Append(radioInput);
               
                var div = new HtmlElement("div");
                div.Append(label);

                if (_options.RadioButtonsGroupWrapperAttributes != null)
                    div.AddRangeAttributes(_options.RadioButtonsGroupWrapperAttributes);

                wrapper.Append(div);
            }

            return wrapper;
        }
        private HtmlElement GetFormGroup(PropertyInfo propInfo)
        {         
            HtmlElement input = GetProperInput(propInfo);
            HtmlElement inputWrapper = new HtmlElement("div");
            inputWrapper.Append(input);
            // TODO Add validation element

            if (_options.InputWrapperAttributes != null)
                inputWrapper.AddRangeAttributes(_options.InputWrapperAttributes);

            HtmlElement label = GetLabel(propInfo);

            HtmlElement formGroup = new HtmlElement("div");
            formGroup.Append(label);

            if (_options.FormGroupAttributes != null)
                formGroup.AddRangeAttributes(_options.FormGroupAttributes);
           
            formGroup.Append(inputWrapper);

            if (_options.FormGroupTemplateFunc != null)
                formGroup = _options.FormGroupTemplateFunc(formGroup);

            return formGroup;
        }
        private HtmlElement GetFormButtons()
        {
            HtmlElement submit = new HtmlElement("input");
            submit.AddAttribute(new QuickDotNetUI.Models.Type("submit"));
          
            HtmlElement reset = new HtmlElement("input");
            reset.AddAttribute(new QuickDotNetUI.Models.Type("reset"));

            if (_options.SubmitButtonAttributes != null)          
                submit.AddRangeAttributes(_options.SubmitButtonAttributes);
                           
            if (_options.ResetButtonAttributes != null)
                reset.AddRangeAttributes(_options.ResetButtonAttributes);

            HtmlElement wrapper = new HtmlElement("span");
            wrapper.Append(submit);
            wrapper.Append(reset);

            return wrapper;
        }
        private List<SelectListItem> GetValuesFromEnum(System.Type enumType)
        {
            List<SelectListItem> values = new List<SelectListItem>();
            if (Nullable.GetUnderlyingType(enumType) != null)
            {
                values.Add(new SelectListItem() { Text = "None", Value = null });
                enumType = Nullable.GetUnderlyingType(enumType);
            }

            foreach (var item in Enum.GetValues(enumType))
                values.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });

            return values;
        }
    }
}
