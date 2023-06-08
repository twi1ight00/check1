using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using ns183;
using ns187;

namespace ns204;

internal class Class5438
{
	public static Class5619 class5619_0 = new Class5619("http://xmlgraphics.apache.org/fop/extensions", null, "bleed");

	public static Class5619 class5619_1 = new Class5619("http://xmlgraphics.apache.org/fop/extensions", null, "crop-offset");

	public static Class5619 class5619_2 = new Class5619("http://xmlgraphics.apache.org/fop/extensions", null, "crop-box");

	private static string string_0 = "^(-?\\d*\\.?\\d*)(px|in|cm|mm|pt|pc|mpt)$";

	private static string string_1 = "\\s+";

	private RectangleF rectangleF_0;

	private RectangleF rectangleF_1;

	private RectangleF rectangleF_2;

	private RectangleF rectangleF_3;

	public Class5438(SizeF pageSize, string bleed, string cropOffset, string cropBoxSelector)
	{
		method_0(pageSize, bleed, cropOffset, cropBoxSelector);
	}

	public Class5438(SizeF pageSize, Hashtable foreignAttributes)
	{
		string bleed = (string)foreignAttributes[class5619_0];
		string cropOffset = (string)foreignAttributes[class5619_1];
		string cropBoxSelector = (string)foreignAttributes[class5619_2];
		method_0(pageSize, bleed, cropOffset, cropBoxSelector);
	}

	private void method_0(SizeF pageSize, string bleed, string cropOffset, string cropBoxSelector)
	{
		rectangleF_0 = new RectangleF(new Point(0, 0), pageSize);
		rectangleF_1 = smethod_0(rectangleF_0, bleed);
		RectangleF b = smethod_1(rectangleF_0, cropOffset);
		rectangleF_2 = RectangleF.Union(RectangleF.Union(rectangleF_0, rectangleF_1), b);
		if ("trim-box".Equals(cropBoxSelector))
		{
			rectangleF_3 = rectangleF_0;
			return;
		}
		if ("bleed-box".Equals(cropBoxSelector))
		{
			rectangleF_3 = rectangleF_1;
			return;
		}
		if (!"media-box".Equals(cropBoxSelector) && !string.IsNullOrEmpty(cropBoxSelector))
		{
			string format = "The crop-box has invalid value: {0}, possible values of crop-box: (trim-box|bleed-box|media-box)";
			throw new ArgumentException(string.Format(format, new object[1] { cropBoxSelector }));
		}
		rectangleF_3 = rectangleF_2;
	}

	public RectangleF method_1()
	{
		return rectangleF_0;
	}

	public RectangleF method_2()
	{
		return rectangleF_1;
	}

	public RectangleF method_3()
	{
		return rectangleF_2;
	}

	public RectangleF method_4()
	{
		return rectangleF_3;
	}

	private static RectangleF smethod_0(RectangleF trimBox, string bleed)
	{
		return smethod_2(trimBox, bleed);
	}

	private static RectangleF smethod_1(RectangleF trimBox, string cropOffsets)
	{
		return smethod_2(trimBox, cropOffsets);
	}

	private static RectangleF smethod_2(RectangleF originalRect, string offset)
	{
		if (!string.IsNullOrEmpty(offset) && !originalRect.IsEmpty)
		{
			string[] array = Regex.Split(offset, string_1);
			int[] array2 = new int[4];
			switch (array.Length)
			{
			default:
				throw new ArgumentException("Too many arguments");
			case 1:
				array2[0] = smethod_3(array[0]);
				array2[1] = array2[0];
				array2[2] = array2[0];
				array2[3] = array2[0];
				break;
			case 2:
				array2[0] = smethod_3(array[0]);
				array2[1] = smethod_3(array[1]);
				array2[2] = array2[0];
				array2[3] = array2[1];
				break;
			case 3:
				array2[0] = smethod_3(array[0]);
				array2[1] = smethod_3(array[1]);
				array2[2] = smethod_3(array[2]);
				array2[3] = array2[1];
				break;
			case 4:
				array2[0] = smethod_3(array[0]);
				array2[1] = smethod_3(array[1]);
				array2[2] = smethod_3(array[2]);
				array2[3] = smethod_3(array[3]);
				break;
			}
			return new RectangleF(originalRect.X - (float)array2[3], originalRect.Y - (float)array2[0], originalRect.Width + (float)array2[3] + (float)array2[1], originalRect.Height + (float)array2[0] + (float)array2[2]);
		}
		return originalRect;
	}

	private static int smethod_3(string length)
	{
		Match match = Regex.Match(length, string_0, RegexOptions.IgnoreCase);
		string format = "Incorrect length value: {0}";
		if (!match.Success)
		{
			throw new ArgumentException(string.Format(format, length));
		}
		return Class5036.smethod_1(double.Parse(match.Groups[1].Value, NumberStyles.Any, Class4985.smethod_0().Ci), match.Groups[2].Value).vmethod_0().imethod_5();
	}
}
