using Aspose.Slides;
using ns62;
using ns7;

namespace ns15;

internal class Class230
{
	internal static Class154 smethod_0(Class2669 shapeContainer)
	{
		Class154 @class = new Class154();
		smethod_2(@class, shapeContainer);
		return @class;
	}

	internal static Class155 smethod_1(Class2669 shapeContainer)
	{
		Class155 @class = new Class155();
		smethod_2(@class, shapeContainer);
		Class2836 shapeGroup = shapeContainer.ShapeGroup;
		if (shapeGroup != null)
		{
			@class.method_5((double)shapeGroup.X / 12700.0, (double)shapeGroup.Y / 12700.0, (double)shapeGroup.Width / 12700.0, (double)shapeGroup.Height / 12700.0);
		}
		return @class;
	}

	private static void smethod_2(Class154 targetTransform, Class2669 shapeContainer)
	{
		double num = double.NaN;
		double num2 = double.NaN;
		double num3 = double.NaN;
		double num4 = double.NaN;
		float num5 = 0f;
		NullableBool nullableBool = NullableBool.NotDefined;
		NullableBool nullableBool2 = NullableBool.NotDefined;
		Interface41 childAnchor = shapeContainer.ChildAnchor;
		if (childAnchor != null)
		{
			num = (double)childAnchor.X / 12700.0;
			num2 = (double)childAnchor.Y / 12700.0;
			num3 = (double)childAnchor.Width / 12700.0;
			num4 = (double)childAnchor.Height / 12700.0;
		}
		else
		{
			childAnchor = shapeContainer.ClientAnchor;
			num = (double)childAnchor.X / 8.0;
			num2 = (double)childAnchor.Y / 8.0;
			num3 = (double)childAnchor.Width / 8.0;
			num4 = (double)childAnchor.Height / 8.0;
		}
		if (shapeContainer.ShapeProp != null)
		{
			nullableBool = (shapeContainer.ShapeProp.FFlipH ? NullableBool.True : NullableBool.False);
			nullableBool2 = (shapeContainer.ShapeProp.FFlipV ? NullableBool.True : NullableBool.False);
		}
		if (shapeContainer.ShapePrimaryOptions != null && shapeContainer.ShapePrimaryOptions.Properties[Enum426.const_394] is Class2911 @class)
		{
			uint num6 = @class.Value >> 16;
			if ((num6 & 0x8000u) != 0)
			{
				num6 = 360 - (65535 - num6 + 1);
			}
			num5 = (int)num6;
			num5 %= 360f;
			if (num5 < 0f)
			{
				num5 += 360f;
			}
			if ((num5 >= 45f && num5 < 135f) || (num5 >= 225f && num5 < 315f))
			{
				num += (num3 - num4) / 2.0;
				num2 += (num4 - num3) / 2.0;
				double num7 = num3;
				num3 = num4;
				num4 = num7;
				NullableBool nullableBool3 = nullableBool;
				nullableBool = nullableBool2;
				nullableBool2 = nullableBool3;
			}
		}
		targetTransform.method_1(num, num2, num3, num4, num5, nullableBool, nullableBool2);
	}
}
