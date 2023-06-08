using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns2;
using ns21;

namespace ns52;

internal class Class1714
{
	private Shape shape_0;

	private Class1701 class1701_0;

	private Class1713 class1713_0;

	private Class1711 class1711_0;

	private Class1698 class1698_0;

	private Class1711 class1711_1;

	private ArrayList arrayList_0;

	internal int Length
	{
		get
		{
			int num = 0;
			if (class1713_0 != null)
			{
				num += method_9().Length + 8;
			}
			if (!shape_0.method_32())
			{
				num += method_7().Length + 8;
			}
			if (class1711_0 != null)
			{
				num += method_2().Length + 8;
			}
			if (class1711_1 != null && class1711_1.Count > 0)
			{
				num += class1711_1.Length + 8;
			}
			if (shape_0.IsGroup)
			{
				num += 24;
			}
			if (shape_0.method_11())
			{
				num += 8;
			}
			if (arrayList_0 != null)
			{
				foreach (byte[] item in arrayList_0)
				{
					num += item.Length;
				}
			}
			return num;
		}
	}

	internal Class1714(Shape shape_1, Class1701 class1701_1)
	{
		shape_0 = shape_1;
		class1701_0 = class1701_1;
		class1713_0 = new Class1713(shape_1.MsoDrawingType, 1025, 2560);
	}

	[SpecialName]
	internal Shape method_0()
	{
		return shape_0;
	}

	[SpecialName]
	internal ArrayList method_1()
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		return arrayList_0;
	}

	internal void Copy(Class1714 class1714_0)
	{
		if (class1714_0.class1711_0 != null)
		{
			method_2().Copy(class1714_0.method_2());
		}
		if (class1714_0.class1711_1 != null)
		{
			method_5().Copy(class1714_0.class1711_1);
		}
		if (class1714_0.class1698_0 != null)
		{
			method_7().Copy(class1714_0.method_7());
		}
		if (class1714_0.class1713_0 != null)
		{
			method_9().Copy(class1714_0.class1713_0);
		}
		if (class1714_0.arrayList_0 == null || class1714_0.arrayList_0.Count == 0)
		{
			return;
		}
		arrayList_0 = new ArrayList();
		foreach (byte[] item in class1714_0.arrayList_0)
		{
			byte[] array2 = new byte[item.Length];
			Array.Copy(item, 0, array2, 0, array2.Length);
			arrayList_0.Add(array2);
		}
	}

	[SpecialName]
	internal Class1711 method_2()
	{
		if (class1711_0 == null)
		{
			class1711_0 = new Class1711(this);
		}
		return class1711_0;
	}

	internal Class1711 method_3()
	{
		return class1711_1;
	}

	internal void method_4()
	{
		class1711_1 = null;
	}

	[SpecialName]
	internal Class1711 method_5()
	{
		if (class1711_1 == null)
		{
			class1711_1 = new Class1711(this);
		}
		return class1711_1;
	}

	[SpecialName]
	internal Class1701 method_6()
	{
		return class1701_0;
	}

	[SpecialName]
	internal Class1698 method_7()
	{
		if (class1698_0 == null)
		{
			class1698_0 = new Class1698(this);
		}
		return class1698_0;
	}

	[SpecialName]
	internal void method_8(Class1698 class1698_1)
	{
		class1698_0 = class1698_1;
	}

	[SpecialName]
	internal Class1713 method_9()
	{
		return class1713_0;
	}

	internal ArrayList method_10()
	{
		Class1136 @class = method_2()[49477];
		Class1136 class2 = method_2()[49478];
		if (class2 == null)
		{
			return null;
		}
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		byte[] array;
		if (@class != null)
		{
			array = (byte[])@class.method_4();
			int num = BitConverter.ToUInt16(array, 0);
			bool flag = false;
			if (array[4] == 240 && array[5] == byte.MaxValue)
			{
				flag = true;
			}
			int num2 = 6;
			for (int i = 0; i < num; i++)
			{
				if (flag)
				{
					arrayList2.Add(new Point(BitConverter.ToInt16(array, num2), BitConverter.ToInt16(array, num2 + 2)));
					num2 += 4;
				}
				else
				{
					arrayList2.Add(new Point(BitConverter.ToInt32(array, num2), BitConverter.ToInt32(array, num2 + 4)));
					num2 += 8;
				}
			}
		}
		array = (byte[])class2.method_4();
		int num3 = BitConverter.ToUInt16(array, 0);
		int num4 = 6;
		int num5 = 0;
		GeomPathInfo geomPathInfo = new GeomPathInfo();
		for (int j = 0; j < num3; j++)
		{
			MsoPathType msoPathType = Class1673.smethod_15((array[num4 + 1] & 0xE0) >> 5);
			if (msoPathType != MsoPathType.Unknown)
			{
				int num6 = ((array[num4 + 1] & 0x1F) << 8) + array[num4];
				switch (msoPathType)
				{
				case MsoPathType.MsopathLineTo:
				{
					for (int l = 0; l < num6; l++)
					{
						if (num5 + 1 <= arrayList2.Count - 1)
						{
							MsoPathInfo segment = new MsoPathInfo(MsoPathType.MsopathLineTo);
							segment.PointList.Add(arrayList2[num5++]);
							segment.PointList.Add(arrayList2[num5]);
							geomPathInfo.AddSegment(segment);
							continue;
						}
						arrayList.Clear();
						break;
					}
					break;
				}
				case MsoPathType.MsopathCurveTo:
				{
					for (int k = 0; k < num6; k++)
					{
						if (num5 + 3 <= arrayList2.Count - 1)
						{
							MsoPathInfo segment = new MsoPathInfo(MsoPathType.MsopathCurveTo);
							segment.PointList.Add(arrayList2[num5++]);
							segment.PointList.Add(arrayList2[num5++]);
							segment.PointList.Add(arrayList2[num5++]);
							segment.PointList.Add(arrayList2[num5]);
							geomPathInfo.AddSegment(segment);
							continue;
						}
						arrayList.Clear();
						break;
					}
					break;
				}
				case MsoPathType.MsopathMoveTo:
				{
					MsoPathInfo segment = new MsoPathInfo(MsoPathType.MsopathMoveTo);
					segment.PointList.Add(arrayList2[num5]);
					geomPathInfo.AddSegment(segment);
					break;
				}
				case MsoPathType.MsopathClose:
				{
					MsoPathInfo segment = new MsoPathInfo(MsoPathType.MsopathClose);
					geomPathInfo.AddSegment(segment);
					break;
				}
				case MsoPathType.MsopathEnd:
				{
					MsoPathInfo segment = new MsoPathInfo(MsoPathType.MsopathEnd);
					geomPathInfo.AddSegment(segment);
					num5++;
					arrayList.Add(geomPathInfo);
					geomPathInfo = new GeomPathInfo();
					break;
				}
				case MsoPathType.MsopathEscape:
					switch (array[num4 + 1] & 0x1F)
					{
					case 10:
						geomPathInfo.enum131_0 = Enum131.const_4;
						geomPathInfo.bool_0 = false;
						break;
					case 11:
						geomPathInfo.bool_1 = false;
						geomPathInfo.bool_0 = false;
						break;
					}
					break;
				}
			}
			num4 += 2;
		}
		return arrayList;
	}

	internal void method_11()
	{
		if (shape_0.AutoShapeType == AutoShapeType.NotPrimitive)
		{
			GeomPathsInfo pathsInfo = shape_0.PathsInfo;
			ArrayList arrayList = pathsInfo.method_0();
			if (arrayList != null && arrayList.Count > 0)
			{
				pathsInfo.method_1();
				method_2().method_1(320, Enum183.const_0, 0);
				method_2().method_1(321, Enum183.const_0, 0);
				method_2().method_1(322, Enum183.const_0, (int)pathsInfo.long_1);
				method_2().method_1(323, Enum183.const_0, (int)pathsInfo.long_0);
				method_2().method_1(324, Enum183.const_0, 4);
				ArrayList arrayList2 = new ArrayList();
				for (int i = 0; i < arrayList.Count; i++)
				{
					GeomPathInfo geomPathInfo = (GeomPathInfo)arrayList[i];
					for (int j = 0; j < geomPathInfo.PathSegementList.Count; j++)
					{
						MsoPathInfo msoPathInfo = (MsoPathInfo)geomPathInfo.PathSegementList[j];
						switch (msoPathInfo.Type)
						{
						case MsoPathType.MsopathLineTo:
							arrayList2.Add((Point)msoPathInfo.PointList[1]);
							break;
						case MsoPathType.MsopathCurveTo:
							arrayList2.Add((Point)msoPathInfo.PointList[1]);
							arrayList2.Add((Point)msoPathInfo.PointList[2]);
							arrayList2.Add((Point)msoPathInfo.PointList[3]);
							break;
						case MsoPathType.MsopathMoveTo:
							if (j == 0)
							{
								arrayList2.Add((Point)msoPathInfo.PointList[0]);
							}
							break;
						}
					}
				}
				byte[] array;
				int num;
				if (arrayList2.Count > 0)
				{
					array = ((!pathsInfo.bool_0) ? new byte[8 * arrayList2.Count + 6] : new byte[4 * arrayList2.Count + 6]);
					Array.Copy(BitConverter.GetBytes(arrayList2.Count), 0, array, 0, 2);
					Array.Copy(BitConverter.GetBytes(arrayList2.Count), 0, array, 2, 2);
					if (pathsInfo.bool_0)
					{
						array[4] = 240;
						array[5] = byte.MaxValue;
					}
					else
					{
						Array.Copy(BitConverter.GetBytes(8), 0, array, 4, 2);
					}
					num = 6;
					for (int k = 0; k < arrayList2.Count; k++)
					{
						Point point = (Point)arrayList2[k];
						if (pathsInfo.bool_0)
						{
							Array.Copy(BitConverter.GetBytes(point.X), 0, array, num, 2);
							Array.Copy(BitConverter.GetBytes(point.Y), 0, array, num + 2, 2);
							num += 4;
						}
						else
						{
							Array.Copy(BitConverter.GetBytes(point.X), 0, array, num, 4);
							Array.Copy(BitConverter.GetBytes(point.Y), 0, array, num + 4, 4);
							num += 8;
						}
					}
					method_2().method_1(49477, Enum183.const_5, array);
				}
				array = new byte[pathsInfo.Length + 6];
				int value = pathsInfo.Length / 2;
				Array.Copy(BitConverter.GetBytes(value), 0, array, 0, 2);
				Array.Copy(BitConverter.GetBytes(value), 0, array, 2, 2);
				Array.Copy(BitConverter.GetBytes(2), 0, array, 4, 2);
				num = 6;
				for (int l = 0; l < arrayList.Count; l++)
				{
					GeomPathInfo geomPathInfo2 = (GeomPathInfo)arrayList[l];
					for (int m = 0; m < geomPathInfo2.PathSegementList.Count; m++)
					{
						MsoPathInfo msoPathInfo2 = (MsoPathInfo)geomPathInfo2.PathSegementList[m];
						int num2 = 0;
						int num3 = Class1673.smethod_16(msoPathInfo2.Type);
						switch (msoPathInfo2.Type)
						{
						case MsoPathType.MsopathLineTo:
							num2 = 1;
							break;
						case MsoPathType.MsopathCurveTo:
							num2 = 1;
							break;
						case MsoPathType.MsopathClose:
							num2 = 1;
							break;
						}
						Array.Copy(BitConverter.GetBytes((num3 << 13) + num2), 0, array, num, 2);
						num += 2;
						if (msoPathInfo2.Type == MsoPathType.MsopathMoveTo)
						{
							if (geomPathInfo2.enum131_0 == Enum131.const_4)
							{
								array[num++] = 0;
								array[num++] = 170;
							}
							if (!geomPathInfo2.bool_1)
							{
								array[num++] = 0;
								array[num++] = 171;
							}
						}
					}
				}
				method_2().method_1(49478, Enum183.const_5, array);
			}
		}
		method_13();
	}

	private void method_12()
	{
		method_2().Remove(384, 447);
		method_2().method_1(385, Enum183.const_0, 134217793);
	}

	private void method_13()
	{
		FillFormat fillFormat = shape_0.method_7();
		if (fillFormat == null)
		{
			return;
		}
		method_12();
		MsoFillFormatHelper msoFillFormatHelper = shape_0.method_6();
		if (fillFormat.Type == FillType.Automatic)
		{
			if (shape_0.Style != null && shape_0.Style.class1111_2 != null)
			{
				msoFillFormatHelper.method_1(Enum176.const_0);
				msoFillFormatHelper.ForeColor = shape_0.Style.class1111_2.internalColor_0.method_6(shape_0.method_25().Workbook);
			}
		}
		else if (fillFormat.Type == FillType.None)
		{
			method_2().method_1(447, Enum183.const_0, 1048576);
		}
		else if (fillFormat.Type == FillType.Solid)
		{
			msoFillFormatHelper.method_1(Enum176.const_0);
			msoFillFormatHelper.ForeColor = fillFormat.SolidFill.Color;
			msoFillFormatHelper.Transparency = fillFormat.SolidFill.Transparency;
		}
		else if (fillFormat.Type == FillType.Pattern)
		{
			byte[] array = MsoFillFormatHelper.smethod_74(fillFormat.PatternFill.Pattern);
			if (array != null)
			{
				msoFillFormatHelper.method_1(Enum176.const_1);
				msoFillFormatHelper.method_19(array);
				msoFillFormatHelper.ForeColor = fillFormat.PatternFill.ForegroundColor;
				msoFillFormatHelper.Transparency = fillFormat.PatternFill.method_2();
				msoFillFormatHelper.BackColor = fillFormat.PatternFill.BackgroundColor;
				msoFillFormatHelper.method_6(1.0 - fillFormat.PatternFill.method_6());
			}
		}
		else if (fillFormat.Type == FillType.Texture)
		{
			TextureFill textureFill = fillFormat.TextureFill;
			if (textureFill.Type == TextureType.Unknown)
			{
				msoFillFormatHelper.method_1(Enum176.const_3);
			}
			else
			{
				msoFillFormatHelper.method_1(Enum176.const_2);
			}
			if (textureFill.method_0() != null)
			{
				msoFillFormatHelper.method_19(textureFill.method_0().method_2());
			}
			msoFillFormatHelper.Transparency = textureFill.Transparency;
		}
		else
		{
			if (fillFormat.Type != FillType.Gradient)
			{
				return;
			}
			GradientFill gradientFill = fillFormat.GradientFill;
			byte[] array2 = null;
			if (gradientFill.GradientColorType == GradientColorType.PresetColors)
			{
				if (gradientFill.PresetColor == GradientPresetType.Unknown)
				{
					GradientStopCollection gradientStops = gradientFill.GradientStops;
					array2 = new byte[gradientStops.Count * 8 + 6];
					Array.Copy(BitConverter.GetBytes((ushort)gradientStops.Count), 0, array2, 0, 2);
					Array.Copy(BitConverter.GetBytes((ushort)gradientStops.Count), 0, array2, 2, 2);
					array2[4] = 8;
					int num = 6;
					for (int i = 0; i < gradientStops.Count; i++)
					{
						GradientStop gradientStop = gradientStops[i];
						Color color = gradientStop.internalColor_0.method_6(shape_0.method_25().Workbook);
						array2[num] = color.R;
						array2[num + 1] = color.G;
						array2[num + 2] = color.B;
						int num2 = (int)(gradientStop.Position / 100.0);
						Array.Copy(BitConverter.GetBytes((ushort)((gradientStop.Position / 100.0 - (double)num2) * 65536.0)), 0, array2, num + 4, 2);
						Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array2, num + 6, 2);
						num += 8;
					}
				}
				else
				{
					array2 = MsoFillFormatHelper.smethod_49(gradientFill.PresetColor);
				}
			}
			if (array2 != null)
			{
				msoFillFormatHelper.method_22(array2);
			}
			switch (gradientFill.GradientStyle)
			{
			default:
				msoFillFormatHelper.method_1(Enum176.const_7);
				break;
			case GradientStyleType.FromCenter:
				msoFillFormatHelper.method_1(Enum176.const_6);
				break;
			case GradientStyleType.FromCorner:
				msoFillFormatHelper.method_1(Enum176.const_5);
				break;
			}
			switch (gradientFill.GradientColorType)
			{
			case GradientColorType.OneColor:
			case GradientColorType.TwoColors:
				msoFillFormatHelper.ForeColor = gradientFill.GradientColor1;
				break;
			}
			switch (gradientFill.GradientColorType)
			{
			case GradientColorType.OneColor:
			{
				byte[] array3 = method_14(gradientFill.GradientDegree);
				int int_ = 268435456 + (array3[1] << 16) + (array3[0] << 8) + 240;
				msoFillFormatHelper.method_5(int_);
				break;
			}
			case GradientColorType.TwoColors:
				msoFillFormatHelper.BackColor = gradientFill.GradientColor2;
				break;
			}
			switch (gradientFill.GradientStyle)
			{
			case GradientStyleType.DiagonalDown:
				msoFillFormatHelper.Angle = -45f;
				break;
			case GradientStyleType.DiagonalUp:
				msoFillFormatHelper.Angle = -135f;
				break;
			case GradientStyleType.Vertical:
				msoFillFormatHelper.Angle = 90f;
				break;
			}
			switch (gradientFill.GradientStyle)
			{
			case GradientStyleType.DiagonalDown:
				switch (gradientFill.method_7())
				{
				case 2:
					msoFillFormatHelper.method_9(1f);
					break;
				case 3:
					msoFillFormatHelper.method_9(42949670f);
					break;
				case 4:
					msoFillFormatHelper.method_9(0.5f);
					break;
				}
				break;
			default:
				switch (gradientFill.method_7())
				{
				case 1:
					msoFillFormatHelper.method_9(1f);
					break;
				case 3:
					msoFillFormatHelper.method_9(42949670f);
					break;
				case 4:
					msoFillFormatHelper.method_9(0.5f);
					break;
				}
				break;
			case GradientStyleType.FromCorner:
				msoFillFormatHelper.method_9(1f);
				break;
			case GradientStyleType.Horizontal:
				if (gradientFill.GradientColorType == GradientColorType.PresetColors)
				{
					switch (gradientFill.method_7())
					{
					case 1:
						msoFillFormatHelper.method_9(1f);
						break;
					case 3:
						msoFillFormatHelper.method_9(0.5f);
						break;
					case 4:
						msoFillFormatHelper.method_9(42949670f);
						break;
					}
				}
				else
				{
					switch (gradientFill.method_7())
					{
					case 1:
						msoFillFormatHelper.method_9(1f);
						break;
					case 3:
						msoFillFormatHelper.method_9(42949670f);
						break;
					case 4:
						msoFillFormatHelper.method_9(0.5f);
						break;
					}
				}
				break;
			}
			if (gradientFill.GradientStyle == GradientStyleType.FromCenter)
			{
				msoFillFormatHelper.method_11(32768);
			}
			else if (gradientFill.GradientStyle == GradientStyleType.FromCorner && (gradientFill.method_7() == 2 || gradientFill.method_7() == 4))
			{
				msoFillFormatHelper.method_11(65536);
			}
			if (gradientFill.GradientStyle == GradientStyleType.FromCenter)
			{
				msoFillFormatHelper.method_13(32768);
			}
			else if (gradientFill.GradientStyle == GradientStyleType.FromCorner && (gradientFill.method_7() == 3 || gradientFill.method_7() == 4))
			{
				msoFillFormatHelper.method_13(65536);
			}
			if (gradientFill.GradientStyle == GradientStyleType.FromCenter)
			{
				msoFillFormatHelper.method_15(32768);
			}
			else if (gradientFill.GradientStyle == GradientStyleType.FromCorner && (gradientFill.method_7() == 2 || gradientFill.method_7() == 4))
			{
				msoFillFormatHelper.method_15(65536);
			}
			if (gradientFill.GradientStyle == GradientStyleType.FromCenter)
			{
				msoFillFormatHelper.method_17(32768);
			}
			else if (gradientFill.GradientStyle == GradientStyleType.FromCorner && (gradientFill.method_7() == 3 || gradientFill.method_7() == 4))
			{
				msoFillFormatHelper.method_17(65536);
			}
			switch (gradientFill.GradientColorType)
			{
			case GradientColorType.OneColor:
				msoFillFormatHelper.method_26(1073741835);
				break;
			case GradientColorType.PresetColors:
				msoFillFormatHelper.method_26(0);
				break;
			case GradientColorType.TwoColors:
				msoFillFormatHelper.method_26(1073741827);
				break;
			}
		}
	}

	private byte[] method_14(double double_0)
	{
		byte[] array = new byte[2];
		if (double_0 < 0.5)
		{
			array[0] = 1;
			array[1] = (byte)(double_0 * 512.0);
		}
		else if (double_0 == 0.5)
		{
			array[0] = 1;
			array[1] = byte.MaxValue;
		}
		else
		{
			array[0] = 2;
			array[1] = (byte)((1.0 - double_0) * 512.0);
		}
		return array;
	}

	internal int method_15(byte[] byte_0, int int_0, Class1114 class1114_0)
	{
		byte_0[int_0] = 15;
		byte_0[int_0 + 2] = 4;
		byte_0[int_0 + 3] = 240;
		Array.Copy(BitConverter.GetBytes(Length), 0, byte_0, int_0 + 4, 4);
		int_0 += 8;
		ushort num = 0;
		if (shape_0.IsGroup)
		{
			byte_0[int_0] = 1;
			byte_0[int_0 + 2] = 9;
			byte_0[int_0 + 3] = 240;
			byte_0[int_0 + 4] = 16;
			int_0 += 8;
			Array.Copy(BitConverter.GetBytes(class1114_0.int_0), 0, byte_0, int_0, 4);
			Array.Copy(BitConverter.GetBytes(class1114_0.int_2), 0, byte_0, int_0 + 4, 4);
			Array.Copy(BitConverter.GetBytes(class1114_0.int_1 + class1114_0.int_0), 0, byte_0, int_0 + 8, 4);
			Array.Copy(BitConverter.GetBytes(class1114_0.int_3 + class1114_0.int_2), 0, byte_0, int_0 + 12, 4);
			int_0 += 16;
		}
		if (class1713_0 != null)
		{
			num = 2;
			num = (ushort)(2u | (ushort)(method_9().method_0() << 4));
			Array.Copy(BitConverter.GetBytes(num), 0, byte_0, int_0, 2);
			byte_0[int_0 + 2] = 10;
			byte_0[int_0 + 3] = 240;
			byte_0[int_0 + 4] = 8;
			int_0 += 8;
			Array.Copy(BitConverter.GetBytes(method_9().method_2()), 0, byte_0, int_0, 4);
			Array.Copy(BitConverter.GetBytes(method_9().method_4()), 0, byte_0, int_0 + 4, 4);
			int_0 += 8;
		}
		if (class1711_0 != null)
		{
			int_0 += method_2().method_11(shape_0, byte_0, int_0, bool_0: false);
		}
		if (class1711_1 != null && class1711_1.Count > 0)
		{
			int_0 += class1711_1.method_11(shape_0, byte_0, int_0, bool_0: true);
		}
		if (arrayList_0 != null)
		{
			foreach (byte[] item in arrayList_0)
			{
				Array.Copy(item, 0, byte_0, int_0, item.Length);
				int_0 += item.Length;
			}
		}
		return int_0;
	}
}
