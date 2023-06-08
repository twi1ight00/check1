using Aspose.Slides.Charts;
using ns16;
using ns25;
using ns56;

namespace ns17;

internal class Class907
{
	public static void smethod_0(IChartDataPoint dataPoint, Class2071 dPtElementData, Class1341 deserializationContext)
	{
		if (dPtElementData != null)
		{
			if (dPtElementData.Bubble3D != null)
			{
				dataPoint.IsBubble3D = dPtElementData.Bubble3D.Val;
			}
			if (dPtElementData.Explosion != null)
			{
				dataPoint.Explosion = (int)dPtElementData.Explosion.Val;
			}
			Class921.smethod_0(dataPoint.Format, dPtElementData.SpPr, deserializationContext);
			Class924.smethod_0(dataPoint.Marker, dPtElementData.Marker, deserializationContext);
			smethod_1(dataPoint, dPtElementData);
		}
	}

	private static void smethod_1(IChartDataPoint dataPoint, Class2071 dPtElementData)
	{
		Class310 pPTXUnsupportedProps = ((ChartDataPoint)dataPoint).PPTXUnsupportedProps;
		if (dPtElementData.InvertIfNegative != null)
		{
			pPTXUnsupportedProps.InvertIfNegative = dPtElementData.InvertIfNegative.Val;
		}
		pPTXUnsupportedProps.PictureOptions = dPtElementData.PictureOptions;
		pPTXUnsupportedProps.ExtensionListOfDataPointProperties = dPtElementData.ExtLst;
	}

	public static void smethod_2(IChartDataPoint dataPoint, Class2071.Delegate1927 addDPt, uint idx, Class1346 serializationContext)
	{
		if (addDPt != null && smethod_4(dataPoint))
		{
			Class2071 @class = addDPt();
			@class.Idx.Val = idx;
			if (dataPoint.IsBubble3D)
			{
				@class.delegate2763_1();
			}
			if (dataPoint.Explosion != -1)
			{
				@class.delegate2136_0().Val = (uint)dataPoint.Explosion;
			}
			Class921.smethod_1(dataPoint.Format, @class.delegate1630_0, serializationContext);
			Class924.smethod_1(dataPoint.Marker, @class.delegate1991_0, serializationContext);
			smethod_3(dataPoint, @class);
		}
	}

	private static void smethod_3(IChartDataPoint dataPoint, Class2071 dPtElementData)
	{
		Class310 pPTXUnsupportedProps = ((ChartDataPoint)dataPoint).PPTXUnsupportedProps;
		if (pPTXUnsupportedProps.InvertIfNegative)
		{
			dPtElementData.delegate2763_0();
		}
		dPtElementData.delegate384_0(pPTXUnsupportedProps.PictureOptions);
		dPtElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfDataPointProperties);
	}

	private static bool smethod_4(IChartDataPoint dataPoint)
	{
		Class310 pPTXUnsupportedProps = ((ChartDataPoint)dataPoint).PPTXUnsupportedProps;
		if (!dataPoint.IsBubble3D && dataPoint.Explosion == -1 && !Class921.smethod_2(dataPoint.Format) && !Class924.smethod_2(dataPoint.Marker) && !pPTXUnsupportedProps.InvertIfNegative && pPTXUnsupportedProps.PictureOptions == null)
		{
			return pPTXUnsupportedProps.ExtensionListOfDataPointProperties != null;
		}
		return true;
	}
}
