using System.Collections.Generic;
using System.IO;
using ns218;
using ns224;
using ns233;
using ns234;
using ns249;
using ns250;
using ns252;

namespace ns254;

internal class Class6346 : Interface282
{
	private Class6360 class6360_0;

	private Class6343 class6343_0;

	private Class6347 class6347_0;

	private Class6348 class6348_0;

	private Class6345 class6345_0;

	public void imethod_0(Class5995 textureBrush, Class6360 brushRenderingContext, List<Interface281> effects)
	{
		if (!smethod_0(effects))
		{
			Initialize(brushRenderingContext, effects);
			method_0(textureBrush);
			method_2(textureBrush);
		}
	}

	private static bool smethod_0(List<Interface281> effects)
	{
		if (effects != null)
		{
			return effects.Count == 0;
		}
		return true;
	}

	private void Initialize(Class6360 brushRenderingContext, List<Interface281> effects)
	{
		class6360_0 = brushRenderingContext;
		class6343_0 = null;
		class6347_0 = null;
		class6348_0 = null;
		class6345_0 = null;
		foreach (Interface281 effect in effects)
		{
			if (effect is Class6343 @class)
			{
				class6343_0 = @class;
			}
			else if (effect is Class6347 class2)
			{
				class6347_0 = class2;
			}
			else if (effect is Class6348 class3)
			{
				class6348_0 = class3;
			}
			else if (effect is Class6345 class4)
			{
				class6345_0 = class4;
			}
		}
	}

	private void method_0(Class5995 textureBrush)
	{
		if (class6345_0 != null)
		{
			Class5998[] colorMap = new Class5998[2]
			{
				method_1(class6345_0.ColorFrom),
				method_1(class6345_0.ColorTo)
			};
			textureBrush.ColorMap = colorMap;
		}
	}

	private Class5998 method_1(Interface274 colorFrom)
	{
		return colorFrom.imethod_1(class6360_0.ThemeProvider, class6360_0.AdditionalColorModifier);
	}

	private void method_2(Class5995 textureBrush)
	{
		Enum788 imageType = Class6148.smethod_0(textureBrush.ImageBytes);
		using Class6150 @class = new Class6150(textureBrush);
		textureBrush.ColorMap = null;
		Class6144 colorSettings = method_3();
		@class.method_19(colorSettings);
		byte[] imageBytes = smethod_1(@class, imageType);
		textureBrush.ImageBytes = imageBytes;
	}

	private static byte[] smethod_1(Class6150 bitmap, Enum788 imageType)
	{
		using MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, imageType);
		return Class5964.smethod_11(memoryStream);
	}

	private Class6144 method_3()
	{
		Enum787 colorMode = method_4();
		float brightness = method_5();
		float contrast = method_6();
		return new Class6144(colorMode, brightness, contrast);
	}

	private Enum787 method_4()
	{
		if (class6343_0 != null)
		{
			return Enum787.const_2;
		}
		if (class6347_0 != null)
		{
			return Enum787.const_1;
		}
		return Enum787.const_0;
	}

	private float method_5()
	{
		if (class6348_0 == null)
		{
			return 0.5f;
		}
		return smethod_2(class6348_0.Brightness);
	}

	private float method_6()
	{
		if (class6348_0 == null)
		{
			return 0.5f;
		}
		return smethod_2(class6348_0.Contrast);
	}

	private static float smethod_2(Class6329 percentage)
	{
		float num = (float)percentage.Fraction;
		return (num + 1f) / 2f;
	}
}
