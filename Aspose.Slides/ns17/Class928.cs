using Aspose.Slides.Charts;
using ns16;
using ns25;
using ns56;

namespace ns17;

internal class Class928
{
	public static void smethod_0(IUpDownBarsManager upDownBars, Class2137 upDownBarsElementData, Class1341 deserializationContext)
	{
		if (upDownBarsElementData == null)
		{
			upDownBars.HasUpDownBars = false;
			return;
		}
		if (upDownBarsElementData.GapWidth != null)
		{
			upDownBars.GapWidth = upDownBarsElementData.GapWidth.Val;
		}
		if (upDownBarsElementData.UpBars != null)
		{
			Class921.smethod_0(upDownBars.UpBarsFormat, upDownBarsElementData.UpBars.SpPr, deserializationContext);
		}
		if (upDownBarsElementData.DownBars != null)
		{
			Class921.smethod_0(upDownBars.DownBarsFormat, upDownBarsElementData.DownBars.SpPr, deserializationContext);
		}
		upDownBars.HasUpDownBars = true;
		Class328 pPTXUnsupportedProps = ((UpDownBarsManager)upDownBars).PPTXUnsupportedProps;
		pPTXUnsupportedProps.ExtensionList = upDownBarsElementData.ExtLst;
	}

	public static void smethod_1(IUpDownBarsManager upDownBars, Class2137.Delegate2142 addUpDownBars, Class1346 serializationContext)
	{
		if (upDownBars.HasUpDownBars)
		{
			Class2137 @class = addUpDownBars();
			@class.delegate1943_0().Val = (ushort)upDownBars.GapWidth;
			if (Class921.smethod_2(upDownBars.UpBarsFormat))
			{
				Class921.smethod_1(upDownBars.UpBarsFormat, @class.delegate2139_0().delegate1630_0, serializationContext);
			}
			if (Class921.smethod_2(upDownBars.DownBarsFormat))
			{
				Class921.smethod_1(upDownBars.DownBarsFormat, @class.delegate2139_1().delegate1630_0, serializationContext);
			}
			Class328 pPTXUnsupportedProps = ((UpDownBarsManager)upDownBars).PPTXUnsupportedProps;
			@class.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		}
	}
}
