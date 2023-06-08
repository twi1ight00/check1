using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using ns33;

namespace ns28;

internal class Class368
{
	private static string[] string_0;

	private static string[] string_1;

	private static Dictionary<string, object[]> dictionary_0;

	private static string[] string_2;

	private static int smethod_0(LineArrowheadStyle style, LineArrowheadLength length, LineArrowheadWidth width)
	{
		if (width < LineArrowheadWidth.Narrow)
		{
			width = LineArrowheadWidth.Medium;
		}
		if (length < LineArrowheadLength.Short)
		{
			length = LineArrowheadLength.Medium;
		}
		return (int)(style - 1) * 9 + (int)length * 3 + (int)width;
	}

	private static void smethod_1(LineArrowheadStyle style, LineArrowheadLength length, LineArrowheadWidth width, string viewBox, string path)
	{
		int num = smethod_0(style, length, width);
		if (string_0[num] == null)
		{
			string_0[num] = path;
			string_1[num] = viewBox;
		}
		dictionary_0.Add(path, new object[3] { style, length, width });
	}

	internal static string smethod_2(LineArrowheadStyle style, LineArrowheadLength length, LineArrowheadWidth width)
	{
		return string_0[smethod_0(style, length, width)];
	}

	internal static string smethod_3(LineArrowheadStyle style)
	{
		int num = (int)(style - 1);
		if (num >= 0 && num < string_2.Length)
		{
			return string_2[num];
		}
		return "Marker_";
	}

	internal static string smethod_4(LineArrowheadStyle style, LineArrowheadLength length, LineArrowheadWidth width)
	{
		return string_1[smethod_0(style, length, width)];
	}

	internal static void smethod_5(string path, string viewbox, double lineWidth, double arrowheadWidth, out LineArrowheadStyle style, out LineArrowheadLength length, out LineArrowheadWidth width)
	{
		style = LineArrowheadStyle.NotDefined;
		if (dictionary_0.TryGetValue(path, out var value))
		{
			style = (LineArrowheadStyle)value[0];
			length = (LineArrowheadLength)value[1];
			width = (LineArrowheadWidth)value[2];
			double num = (double)(1 + (1 << Math.Max(0, (int)width))) * lineWidth * 1.2;
			if (arrowheadWidth > num * 0.97 && arrowheadWidth < num * 1.03)
			{
				return;
			}
		}
		if (style == LineArrowheadStyle.NotDefined)
		{
			style = LineArrowheadStyle.Triangle;
		}
		arrowheadWidth /= lineWidth;
		if (arrowheadWidth < 2.5)
		{
			width = LineArrowheadWidth.Narrow;
		}
		else if (arrowheadWidth > 4.5)
		{
			width = LineArrowheadWidth.Wide;
		}
		else
		{
			width = LineArrowheadWidth.Medium;
		}
		length = (LineArrowheadLength)width;
		RectangleF rectangleF = Class1171.smethod_0(viewbox);
		if ((double)rectangleF.Width > (double)rectangleF.Height * 1.8)
		{
			length = (LineArrowheadLength)(width - 2);
		}
		else if ((double)rectangleF.Width > (double)rectangleF.Height * 1.2)
		{
			length = (LineArrowheadLength)(width - 1);
		}
		else if ((double)rectangleF.Height > (double)rectangleF.Width * 1.8)
		{
			length = (LineArrowheadLength)(width + 2);
		}
		else if ((double)rectangleF.Height > (double)rectangleF.Width * 1.2)
		{
			length = (LineArrowheadLength)(width + 1);
		}
		if (length < LineArrowheadLength.Short)
		{
			length = LineArrowheadLength.Short;
		}
		if (length > LineArrowheadLength.Long)
		{
			length = LineArrowheadLength.Long;
		}
	}

	static Class368()
	{
		string_0 = new string[45];
		string_1 = new string[45];
		dictionary_0 = new Dictionary<string, object[]>();
		string_2 = new string[5] { "msArrowEnd_", "msArrowOpenEnd_", "msArrowStealthEnd_", "msArrowDiamondEnd_", "msArrowOvalEnd_" };
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.Short, LineArrowheadWidth.Narrow, "0 0 352 352", "m176 0 176 352h-352z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.Medium, LineArrowheadWidth.Narrow, "0 0 352 528", "m176 0 176 528h-352z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.Long, LineArrowheadWidth.Narrow, "0 0 352 880", "m176 0 176 880h-352z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.Short, LineArrowheadWidth.Medium, "0 0 528 352", "m264 0 264 352h-528z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.Medium, LineArrowheadWidth.Medium, "0 0 528 528", "m264 0 264 528h-528z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.Long, LineArrowheadWidth.Medium, "0 0 528 880", "m264 0 264 880h-528z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.Short, LineArrowheadWidth.Wide, "0 0 880 352", "m440 0 440 352h-880z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.Medium, LineArrowheadWidth.Wide, "0 0 880 528", "m440 0 440 528h-880z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.Long, LineArrowheadWidth.Wide, "0 0 880 880", "m440 0 440 880h-880z");
		smethod_1(LineArrowheadStyle.Open, LineArrowheadLength.Short, LineArrowheadWidth.Narrow, "0 0 616 616", "m308 0 308 561-92 55-216-394-216 394-92-55z");
		smethod_1(LineArrowheadStyle.Open, LineArrowheadLength.Medium, LineArrowheadWidth.Narrow, "0 0 616 792", "m308 0 308 721-92 71-216-507-216 507-92-71z");
		smethod_1(LineArrowheadStyle.Open, LineArrowheadLength.Long, LineArrowheadWidth.Narrow, "0 0 616 1056", "m308 0 308 961-92 95-216-676-216 676-92-95z");
		smethod_1(LineArrowheadStyle.Open, LineArrowheadLength.Short, LineArrowheadWidth.Medium, "0 0 792 616", "m396 0 396 561-119 55-277-394-277 394-119-55z");
		smethod_1(LineArrowheadStyle.Open, LineArrowheadLength.Medium, LineArrowheadWidth.Medium, "0 0 792 792", "m396 0 396 721-119 71-277-507-277 507-119-71z");
		smethod_1(LineArrowheadStyle.Open, LineArrowheadLength.Long, LineArrowheadWidth.Medium, "0 0 792 1056", "m396 0 396 961-119 95-277-676-277 676-119-95z");
		smethod_1(LineArrowheadStyle.Open, LineArrowheadLength.Short, LineArrowheadWidth.Wide, "0 0 1056 616", "m528 0 528 561-158 55-370-394-370 394-158-55z");
		smethod_1(LineArrowheadStyle.Open, LineArrowheadLength.Medium, LineArrowheadWidth.Wide, "0 0 1056 792", "m528 0 528 721-158 71-370-507-370 507-158-71z");
		smethod_1(LineArrowheadStyle.Open, LineArrowheadLength.Long, LineArrowheadWidth.Wide, "0 0 1056 1056", "m528 0 528 961-158 95-370-676-370 676-158-95z");
		smethod_1(LineArrowheadStyle.Stealth, LineArrowheadLength.Short, LineArrowheadWidth.Narrow, "0 0 352 352", "m176 0 176 352-176-141-176 141z");
		smethod_1(LineArrowheadStyle.Stealth, LineArrowheadLength.Medium, LineArrowheadWidth.Narrow, "0 0 352 528", "m176 0 176 528-176-211-176 211z");
		smethod_1(LineArrowheadStyle.Stealth, LineArrowheadLength.Long, LineArrowheadWidth.Narrow, "0 0 352 880", "m176 0 176 880-176-352-176 352z");
		smethod_1(LineArrowheadStyle.Stealth, LineArrowheadLength.Short, LineArrowheadWidth.Medium, "0 0 528 352", "m264 0 264 352-264-141-264 141z");
		smethod_1(LineArrowheadStyle.Stealth, LineArrowheadLength.Medium, LineArrowheadWidth.Medium, "0 0 528 528", "m264 0 264 528-264-211-264 211z");
		smethod_1(LineArrowheadStyle.Stealth, LineArrowheadLength.Long, LineArrowheadWidth.Medium, "0 0 528 880", "m264 0 264 880-264-352-264 352z");
		smethod_1(LineArrowheadStyle.Stealth, LineArrowheadLength.Short, LineArrowheadWidth.Wide, "0 0 880 352", "m440 0 440 352-440-141-440 141z");
		smethod_1(LineArrowheadStyle.Stealth, LineArrowheadLength.Medium, LineArrowheadWidth.Wide, "0 0 880 528", "m440 0 440 528-440-211-440 211z");
		smethod_1(LineArrowheadStyle.Stealth, LineArrowheadLength.Long, LineArrowheadWidth.Wide, "0 0 880 880", "m440 0 440 880-440-352-440 352z");
		smethod_1(LineArrowheadStyle.Diamond, LineArrowheadLength.Short, LineArrowheadWidth.Narrow, "0 0 352 352", "m176 0 176 176-176 176-176-176z");
		smethod_1(LineArrowheadStyle.Diamond, LineArrowheadLength.Medium, LineArrowheadWidth.Narrow, "0 0 352 528", "m176 0 176 264-176 264-176-264z");
		smethod_1(LineArrowheadStyle.Diamond, LineArrowheadLength.Long, LineArrowheadWidth.Narrow, "0 0 352 880", "m176 0 176 440-176 440-176-440z");
		smethod_1(LineArrowheadStyle.Diamond, LineArrowheadLength.Short, LineArrowheadWidth.Medium, "0 0 528 352", "m264 0 264 176-264 176-264-176z");
		smethod_1(LineArrowheadStyle.Diamond, LineArrowheadLength.Medium, LineArrowheadWidth.Medium, "0 0 528 528", "m264 0 264 264-264 264-264-264z");
		smethod_1(LineArrowheadStyle.Diamond, LineArrowheadLength.Long, LineArrowheadWidth.Medium, "0 0 528 880", "m264 0 264 440-264 440-264-440z");
		smethod_1(LineArrowheadStyle.Diamond, LineArrowheadLength.Short, LineArrowheadWidth.Wide, "0 0 880 352", "m440 0 440 176-440 176-440-176z");
		smethod_1(LineArrowheadStyle.Diamond, LineArrowheadLength.Medium, LineArrowheadWidth.Wide, "0 0 880 528", "m440 0 440 264-440 264-440-264z");
		smethod_1(LineArrowheadStyle.Diamond, LineArrowheadLength.Long, LineArrowheadWidth.Wide, "0 0 880 880", "m440 0 440 440-440 440-440-440z");
		smethod_1(LineArrowheadStyle.Oval, LineArrowheadLength.Short, LineArrowheadWidth.Narrow, "0 0 352 352", "m352 0c0-97-79-176-176-176s-176 79-176 176 79 176 176 176 176-79 176-176z");
		smethod_1(LineArrowheadStyle.Oval, LineArrowheadLength.Medium, LineArrowheadWidth.Narrow, "0 0 352 528", "m352 0c0-145-79-264-176-264s-176 119-176 264 79 264 176 264 176-119 176-264z");
		smethod_1(LineArrowheadStyle.Oval, LineArrowheadLength.Long, LineArrowheadWidth.Narrow, "0 0 352 880", "m352 0c0-243-79-440-176-440s-176 197-176 440 79 440 176 440 176-197 176-440z");
		smethod_1(LineArrowheadStyle.Oval, LineArrowheadLength.Short, LineArrowheadWidth.Medium, "0 0 528 352", "m528 0c0-97-119-176-264-176s-264 79-264 176 119 176 264 176 264-79 264-176z");
		smethod_1(LineArrowheadStyle.Oval, LineArrowheadLength.Medium, LineArrowheadWidth.Medium, "0 0 528 528", "m528 0c0-145-119-264-264-264s-264 119-264 264 119 264 264 264 264-119 264-264z");
		smethod_1(LineArrowheadStyle.Oval, LineArrowheadLength.Long, LineArrowheadWidth.Medium, "0 0 528 880", "m528 0c0-243-119-440-264-440s-264 197-264 440 119 440 264 440 264-197 264-440z");
		smethod_1(LineArrowheadStyle.Oval, LineArrowheadLength.Short, LineArrowheadWidth.Wide, "0 0 880 352", "m880 0c0-97-197-176-440-176s-440 79-440 176 197 176 440 176 440-79 440-176z");
		smethod_1(LineArrowheadStyle.Oval, LineArrowheadLength.Medium, LineArrowheadWidth.Wide, "0 0 880 528", "m880 0c0-145-197-264-440-264s-440 119-440 264 197 264 440 264 440-119 440-264z");
		smethod_1(LineArrowheadStyle.Oval, LineArrowheadLength.Long, LineArrowheadWidth.Wide, "0 0 880 880", "m880 0c0-243-197-440-440-440s-440 197-440 440 197 440 440 440 440-197 440-440z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.NotDefined, LineArrowheadWidth.NotDefined, null, "m10 0-10 30h20z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.NotDefined, LineArrowheadWidth.NotDefined, null, "m1321 3493h-1321l702-3493z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.NotDefined, LineArrowheadWidth.NotDefined, null, "m737 1131h394l-564-1131-567 1131h398l-398 787h1131z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.NotDefined, LineArrowheadWidth.NotDefined, null, "m1009 1050-449-1008-22-30-29-12-34 12-21 26-449 1012-5 13v8l5 21 12 21 17 13 21 4h903l21-4 21-13 9-21 4-21v-8z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.NotDefined, LineArrowheadWidth.NotDefined, null, "m564 0-564 902h1131z");
		smethod_1(LineArrowheadStyle.Triangle, LineArrowheadLength.NotDefined, LineArrowheadWidth.NotDefined, null, "m1127 2120-449-2006-9-42-25-39-38-25-38-8-43 8-38 25-25 39-9 42-449 2006v13l-4 9 9 42 25 38 38 25 42 9h903l42-9 38-25 26-38 8-42v-9z");
		smethod_1(LineArrowheadStyle.Diamond, LineArrowheadLength.NotDefined, LineArrowheadWidth.NotDefined, null, "m0 0h10v10h-10z");
		smethod_1(LineArrowheadStyle.Diamond, LineArrowheadLength.NotDefined, LineArrowheadWidth.NotDefined, null, "m0 564 564 567 567-567-567-564z");
		smethod_1(LineArrowheadStyle.Open, LineArrowheadLength.NotDefined, LineArrowheadWidth.NotDefined, null, "m0 2108v17 17l12 42 30 34 38 21 43 4 29-8 30-21 25-26 13-34 343-1532 339 1520 13 42 29 34 39 21 42 4 42-12 34-30 21-42v-39-12l-4 4-440-1998-9-42-25-39-38-25-43-8-42 8-38 25-26 39-8 42z");
		smethod_1(LineArrowheadStyle.Oval, LineArrowheadLength.NotDefined, LineArrowheadWidth.NotDefined, null, "m462 1118-102-29-102-51-93-72-72-93-51-102-29-102-13-105 13-102 29-106 51-102 72-89 93-72 102-50 102-34 106-9 101 9 106 34 98 50 93 72 72 89 51 102 29 106 13 102-13 105-29 102-51 102-72 93-93 72-98 51-106 29-101 13z");
		smethod_1(LineArrowheadStyle.Stealth, LineArrowheadLength.NotDefined, LineArrowheadWidth.NotDefined, null, "m1013 1491 118 89-567-1580-564 1580 114-85 136-68 148-46 161-17 161 13 153 46z");
	}
}
