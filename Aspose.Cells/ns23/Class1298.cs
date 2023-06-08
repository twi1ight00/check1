using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells.Charts;
using Aspose.Cells.Rendering;
using ns19;

namespace ns23;

internal class Class1298 : Interface6
{
	private string string_0 = "";

	private ImageOrPrintOptions imageOrPrintOptions_0;

	private SparklineGroup sparklineGroup_0;

	private Sparkline sparkline_0;

	private int int_0;

	private int int_1;

	private Stream stream_0;

	private Interface42 interface42_0;

	internal Class1298(string string_1, ImageOrPrintOptions imageOrPrintOptions_1, SparklineGroup sparklineGroup_1, Sparkline sparkline_1, int int_2, int int_3)
	{
		string_0 = string_1;
		imageOrPrintOptions_0 = imageOrPrintOptions_1;
		sparklineGroup_0 = sparklineGroup_1;
		sparkline_0 = sparkline_1;
		int_0 = int_2;
		int_1 = int_3;
	}

	internal Class1298(ImageOrPrintOptions imageOrPrintOptions_1, SparklineGroup sparklineGroup_1, Sparkline sparkline_1, int int_2, int int_3)
	{
		imageOrPrintOptions_0 = imageOrPrintOptions_1;
		sparklineGroup_0 = sparklineGroup_1;
		sparkline_0 = sparkline_1;
		int_0 = int_2;
		int_1 = int_3;
	}

	internal Class1298(Stream stream_1, ImageOrPrintOptions imageOrPrintOptions_1, SparklineGroup sparklineGroup_1, Sparkline sparkline_1, int int_2, int int_3)
	{
		stream_0 = stream_1;
		imageOrPrintOptions_0 = imageOrPrintOptions_1;
		sparklineGroup_0 = sparklineGroup_1;
		sparkline_0 = sparkline_1;
		int_0 = int_2;
		int_1 = int_3;
	}

	[SpecialName]
	public Interface42 imethod_0()
	{
		return interface42_0;
	}

	[SpecialName]
	public void imethod_1(Interface42 interface42_1)
	{
		interface42_0 = interface42_1;
	}

	public void imethod_2()
	{
		if (sparklineGroup_0.Type == SparklineType.Line)
		{
			Class1307 @class = new Class1307(sparklineGroup_0, sparkline_0.method_1(), int_0, int_1, null, imethod_0());
			@class.method_1();
		}
		else if (sparklineGroup_0.Type == SparklineType.Column)
		{
			Class1305 class2 = new Class1305(sparklineGroup_0, sparkline_0.method_1(), int_0, int_1, null, imethod_0());
			class2.method_1();
		}
		else if (sparklineGroup_0.Type == SparklineType.Stacked)
		{
			Class1306 class3 = new Class1306(sparklineGroup_0, sparkline_0.method_1(), int_0, int_1, null, imethod_0());
			class3.method_1();
		}
	}
}
