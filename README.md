# QuickDotNetUI (demo version)

.Net Core library for help you to create quick UI for your website.

This library can help you to create dynamically from basic Html elements like div, span and ect to composite Html components like forms, grids, listviews and etc., writing only C#.

Form

C#

```C#
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
```

Razor

```HTML+Razor

@model EmployeeViewModel

@Html.FormFor(x => x)

```

Result

![alt text](https://github.com/atanasgalchov/QuickDotNetUI/blob/master/image.jpg?raw=true)
