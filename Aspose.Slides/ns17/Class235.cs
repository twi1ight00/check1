using Aspose.Slides.Charts;
using ns46;
using ns56;

namespace ns17;

internal class Class235
{
	public static void smethod_0(IChart chart, Class1777 styleElementData)
	{
		if (styleElementData == null)
		{
			chart.Style = StyleType.Style2;
		}
		else if (Class1120.list_0.Contains("http://schemas.microsoft.com/office/drawing/2007/8/2/chart") && styleElementData.Choice_c14 != null)
		{
			chart.Style = (StyleType)(styleElementData.Choice_c14.Val - 1 - 100);
		}
		else
		{
			chart.Style = (StyleType)(styleElementData.Fallback.Val - 1);
		}
	}

	public static void smethod_1(IChart chart, Class1777 styleElementData)
	{
		styleElementData.delegate27_0().Val = (byte)((byte)chart.Style + 1 + 100);
		styleElementData.delegate2094_0().Val = (byte)((byte)chart.Style + 1);
	}
}
