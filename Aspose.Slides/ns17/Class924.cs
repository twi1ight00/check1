using Aspose.Slides.Charts;
using ns16;
using ns25;
using ns56;

namespace ns17;

internal class Class924
{
	public static void smethod_0(IMarker marker, Class2091 markerElementData, Class1341 deserializationContext)
	{
		marker.Symbol = MarkerStyleType.NotDefined;
		if (markerElementData != null)
		{
			if (markerElementData.Symbol != null)
			{
				marker.Symbol = markerElementData.Symbol.Val;
			}
			if (markerElementData.Size != null)
			{
				marker.Size = markerElementData.Size.Val;
			}
			Class921.smethod_0(marker.Format, markerElementData.SpPr, deserializationContext);
			Class325 pPTXUnsupportedProps = ((Marker)marker).PPTXUnsupportedProps;
			pPTXUnsupportedProps.ExtensionList = markerElementData.ExtLst;
		}
	}

	public static void smethod_1(IMarker marker, Class2091.Delegate1991 addMarker, Class1346 serializationContext)
	{
		if (addMarker != null && smethod_2(marker))
		{
			Class2091 @class = addMarker();
			if (marker.Symbol != MarkerStyleType.NotDefined)
			{
				@class.delegate1997_0().Val = marker.Symbol;
			}
			if (marker.Size != 5 && marker.Size != 0)
			{
				@class.delegate1994_0().Val = (ushort)marker.Size;
			}
			Class921.smethod_1(marker.Format, @class.delegate1630_0, serializationContext);
			Class325 pPTXUnsupportedProps = ((Marker)marker).PPTXUnsupportedProps;
			@class.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		}
	}

	internal static bool smethod_2(IMarker marker)
	{
		if (!Class921.smethod_2(marker.Format) && marker.Size == 0)
		{
			return marker.Symbol != MarkerStyleType.NotDefined;
		}
		return true;
	}
}
