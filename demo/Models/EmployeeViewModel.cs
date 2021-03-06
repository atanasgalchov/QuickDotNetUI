using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuickDotNetUI.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QiuckDotNetUIDemo.Models
{
	public class EmployeeViewModel
	{
		[Hidden]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[HtmlDropDown]
		public DepartmentsEnum Department { get; set; }
		public JobsEnum? Job { get; set; }
		public double? Salary { get; set; }
		[Disabled]
		public bool? IsFired { get; set; }
		[ReadOnly]
		public DateTime BirthDate { get; set; }
		public DateTime? EndDate { get; set; }
		public TimeSpan CoffeeBreak { get; set; }

		public IFormFile Photo { get; set; }

		[IgonreUI]
		public bool IsInBreak { get; set; }
	}

	public enum DepartmentsEnum
	{
		IT,
		HumanResources,
		Security,
		Support
	}

	public enum JobsEnum
	{
		Director,
		CEO,
		TeamLead,
		Junior
	}
}
