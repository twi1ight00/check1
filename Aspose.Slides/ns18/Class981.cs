using ns24;
using ns56;

namespace ns18;

internal class Class981
{
	public static void smethod_0(Class1148 relativeRect, Class1915 relativeRectElementData)
	{
		if (relativeRectElementData != null)
		{
			relativeRect.X = relativeRectElementData.L / 100f;
			relativeRect.Y = relativeRectElementData.T / 100f;
			relativeRect.Width = 1f - relativeRectElementData.R / 100f - relativeRect.X;
			relativeRect.Height = 1f - relativeRectElementData.B / 100f - relativeRect.Y;
		}
		else
		{
			relativeRect.X = 0f;
			relativeRect.Y = 0f;
			relativeRect.Width = 1f;
			relativeRect.Height = 1f;
		}
	}

	public static void smethod_1(Class1148 relativeRect, Class1915.Delegate1612 addFillRect)
	{
		if (relativeRect.method_3())
		{
			Class1915 @class = addFillRect();
			@class.L = relativeRect.X * 100f;
			@class.T = relativeRect.Y * 100f;
			@class.R = (1f - relativeRect.Width - relativeRect.X) * 100f;
			@class.B = (1f - relativeRect.Height - relativeRect.Y) * 100f;
		}
	}
}
