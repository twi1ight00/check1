using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Effects;
using ns33;
using ns4;
using ns62;
using ns63;

namespace ns15;

internal class Class1038 : Class1037
{
	internal static void smethod_15(PictureFrame targetShape, Class2670 esspContainer, Class854 slideDeserializationContext)
	{
		Class1037.smethod_12(targetShape, esspContainer, slideDeserializationContext);
		targetShape.Geometry.Preset = ShapeType.Rectangle;
		targetShape.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
		Class1052.smethod_0(targetShape.fillFormat_0, esspContainer, slideDeserializationContext);
		IShapeFrame frame = targetShape.Frame;
		Class1056.smethod_0(targetShape.LineFormat, esspContainer, slideDeserializationContext, Class232.smethod_7(targetShape.Geometry.Preset), (frame.FlipH == NullableBool.True) ^ (frame.FlipV == NullableBool.True));
		Class1061.smethod_0((PictureFillFormat)targetShape.PictureFormat, esspContainer.ShapePrimaryOptions, uint.MaxValue, slideDeserializationContext);
		if (esspContainer.ShapePrimaryOptions != null && esspContainer.ShapePrimaryOptions.Properties[Enum426.const_434] is Class2911 @class)
		{
			Color color = Class1165.smethod_7(@class.Value);
			Color colorTo = Color.FromArgb(0, color);
			targetShape.PictureFormat.Picture.ImageTransform.Add(new ColorChange(color, colorTo, useAlpha: true, null));
		}
		if (esspContainer.ClientData != null && esspContainer.ClientData.RecolorInfoAtom != null)
		{
			Class2792 recolorInfoAtom = esspContainer.ClientData.RecolorInfoAtom;
			byte[] array = recolorInfoAtom.method_1();
			if (array != null && array.Length >= 12)
			{
				int num = Class1162.smethod_1(array, 2);
				int num2 = Class1162.smethod_1(array, 4);
				if (num <= 64 && num2 <= 64 && (num + num2) * 44 + 12 == array.Length)
				{
					int num3 = 12;
					int num4 = num;
					for (int i = 0; i < 2; i++)
					{
						while (num4 > 0)
						{
							int num5 = Class1162.smethod_1(array, num3);
							num3 += 2;
							if (((uint)num5 & (true ? 1u : 0u)) != 0)
							{
								byte red = array[num3 + 1];
								byte green = array[num3 + 3];
								byte blue = array[num3 + 5];
								num3 += 6;
								long num6 = Class1162.smethod_8(array, num3);
								num3 += 4;
								Color colorTo2 = Color.Empty;
								SchemeColor schemeColor = SchemeColor.NotDefined;
								if ((num6 & 0xFFFFL) < 8L)
								{
									schemeColor = Class232.smethod_13((int)(num6 & 0xFFFFL));
								}
								else
								{
									colorTo2 = Color.FromArgb(red, green, blue);
								}
								red = array[num3 + 1];
								green = array[num3 + 3];
								blue = array[num3 + 5];
								num3 += 6;
								num3 += 4;
								num3 += 22;
								Color colorFrom = Color.FromArgb(red, green, blue);
								if (schemeColor != SchemeColor.NotDefined)
								{
									targetShape.PictureFormat.Picture.ImageTransform.Add(new ColorChange(colorFrom, schemeColor, useAlpha: false, null));
								}
								else
								{
									targetShape.PictureFormat.Picture.ImageTransform.Add(new ColorChange(colorFrom, colorTo2, useAlpha: false, null));
								}
							}
							else
							{
								num3 += 42;
							}
							num4--;
						}
						num4 = num2;
					}
				}
			}
		}
		if (esspContainer == null || esspContainer.ShapePrimaryOptions == null)
		{
			return;
		}
		double num7 = 0.0;
		if (esspContainer.ShapePrimaryOptions.Properties[Enum426.const_436] is Class2911 class2)
		{
			num7 = Math.Round(Class1162.smethod_35(class2.Value) * 200.0);
		}
		double num8 = 0.0;
		if (esspContainer.ShapePrimaryOptions.Properties[Enum426.const_435] is Class2911 class3)
		{
			num8 = smethod_16(class3.Value);
		}
		if (num8 != 0.0 || num7 != 0.0)
		{
			targetShape.PictureFormat.Picture.ImageTransform.Add(new Luminance((float)num7, (float)num8, null));
		}
		if (esspContainer.ShapePrimaryOptions.Properties[Enum426.const_456] is Class2911 class4)
		{
			switch (class4.Value & 6)
			{
			case 4u:
				targetShape.PictureFormat.Picture.ImageTransform.Add(new GrayScale(null));
				break;
			case 6u:
				targetShape.PictureFormat.Picture.ImageTransform.Add(new GrayScale(null));
				targetShape.PictureFormat.Picture.ImageTransform.Add(new BiLevel(50f, null));
				break;
			case 5u:
				break;
			}
		}
	}

	private static double smethod_16(uint value)
	{
		if (value == 65536)
		{
			return 0.0;
		}
		if (value == 0)
		{
			return -100.0;
		}
		if (value > 65536)
		{
			return Math.Round(100.0 - 6553600.0 / (double)value);
		}
		return Math.Round((float)(value * 100) / 65536f - 100f);
	}
}
