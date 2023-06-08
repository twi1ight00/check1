using System;
using ns62;

namespace ns15;

internal class Class866
{
	internal static Struct54 smethod_0(Class2911 propShadowOffsetX, Class2911 propShadowOffsetY)
	{
		uint num = propShadowOffsetX?.Value ?? 25400;
		uint num2 = propShadowOffsetY?.Value ?? 25400;
		double num3 = ((propShadowOffsetX != null) ? ((double)(int)num / 12700.0) : 2.0);
		double num4 = ((propShadowOffsetY != null) ? ((double)(int)num2 / 12700.0) : 2.0);
		Struct54 result = default(Struct54);
		result.double_0 = Math.Sqrt(num3 * num3 + num4 * num4);
		result.float_0 = (float)(Math.Acos(num3 / result.double_0) * 180.0 / Math.PI);
		if (num4 < 0.0)
		{
			result.float_0 = 360f - result.float_0;
		}
		if (float.IsNaN(result.float_0))
		{
			result.float_0 = 0f;
		}
		return result;
	}

	internal static void smethod_1(Struct54 distanceDirection, Class2834 fopt)
	{
		Class2944 properties = fopt.Properties;
		double num = distanceDirection.double_0 * Math.Cos((double)distanceDirection.float_0 * Math.PI / 180.0);
		double num2 = distanceDirection.double_0 * Math.Sin((double)distanceDirection.float_0 * Math.PI / 180.0);
		uint num3 = (uint)(num * 12700.0 + (double)Math.Sign(num) * 0.5);
		uint num4 = (uint)(num2 * 12700.0 + (double)Math.Sign(num2) * 0.5);
		if (num3 != 25400)
		{
			properties.method_0(new Class2911(Enum426.const_300, num3));
		}
		if (num4 != 25400)
		{
			properties.method_0(new Class2911(Enum426.const_301, num4));
		}
	}
}
