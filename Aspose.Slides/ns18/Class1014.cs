using System;
using System.Xml;
using Aspose.Slides.Animation;
using ns56;

namespace ns18;

internal class Class1014
{
	public static void smethod_0(IPointCollection points, Class2300 pointsElementData)
	{
		if (pointsElementData == null)
		{
			return;
		}
		Class2299[] tavList = pointsElementData.TavList;
		foreach (Class2299 @class in tavList)
		{
			float time = ((@class.Tm == "indefinite") ? float.NaN : ((@class.Tm == null) ? 0f : ((float)XmlConvert.ToInt32(@class.Tm) / 1000f)));
			string formula = ((@class.Fmla == null) ? "" : @class.Fmla);
			if (@class.Val != null)
			{
				((PointCollection)points).Add(new Point(time, Class1016.smethod_0(@class.Val), formula));
			}
		}
	}

	public static void smethod_1(IPointCollection points, Class2300 pointsElementData)
	{
		foreach (IPoint point in points)
		{
			Class2299 @class = pointsElementData.delegate2644_0();
			if (!float.IsNaN(point.Time))
			{
				@class.Tm = XmlConvert.ToString((int)Math.Round(point.Time * 1000f));
			}
			@class.Fmla = point.Formula;
			Class1016.smethod_1(point.Value, @class.delegate2563_0());
		}
	}
}
