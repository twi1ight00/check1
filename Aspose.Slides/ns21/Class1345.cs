using Aspose.Slides.Charts;
using Aspose.Slides.Warnings;
using ns49;
using ns53;
using ns54;

namespace ns21;

internal class Class1345 : Class1344
{
	private readonly ChartDataWorkbook chartDataWorkbook_0;

	private int int_0;

	private int int_1;

	public new Class1185 Package => (Class1185)base.Package;

	public Class1345(Class1185 package, ChartDataWorkbook workbook)
		: base(package)
	{
		chartDataWorkbook_0 = workbook;
	}

	internal void method_0(string description, WarningType warningType)
	{
		if (chartDataWorkbook_0.LoadOptions != null && chartDataWorkbook_0.LoadOptions.WarningCallback != null)
		{
			Class1176 @class = new Class1176(description, warningType);
			@class.SendWarning(chartDataWorkbook_0.LoadOptions.WarningCallback);
		}
	}

	public int method_1()
	{
		return ++int_0;
	}

	public int method_2()
	{
		return ++int_1;
	}

	public int method_3()
	{
		return int_1;
	}
}
