using System;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns2;

namespace ns27;

internal class Class588 : Class538
{
	internal Class588()
	{
		method_2(2173);
	}

	internal void method_4(int int_0, Class1685 class1685_0)
	{
		method_0(20);
		method_0((short)(base.Length + (short)smethod_0(class1685_0)));
		byte_0 = new byte[base.Length];
		byte_0[0] = 125;
		byte_0[1] = 8;
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 14, 2);
		Array.Copy(BitConverter.GetBytes((ushort)class1685_0.Count), 0, byte_0, 18, 2);
		Write(class1685_0, byte_0, 20);
	}

	internal static int smethod_0(Class1685 class1685_0)
	{
		int num = 0;
		for (int i = 0; i < class1685_0.Count; i++)
		{
			switch (class1685_0[i].enum235_0)
			{
			case Enum235.const_6:
				num += (short)(52 + 22 * ((GradientFill)class1685_0[i].object_0).GradientStops.Count);
				break;
			case Enum235.const_4:
			case Enum235.const_5:
			case Enum235.const_7:
			case Enum235.const_8:
			case Enum235.const_9:
			case Enum235.const_10:
			case Enum235.const_11:
			case Enum235.const_13:
				num += 20;
				break;
			case Enum235.const_14:
				num += 5;
				break;
			case Enum235.const_15:
				num += 6;
				break;
			}
		}
		return num;
	}

	internal static int Write(Class1685 class1685_0, byte[] byte_1, int int_0)
	{
		for (int i = 0; i < class1685_0.Count; i++)
		{
			Class1684 @class = class1685_0[i];
			byte_1[int_0] = (byte)@class.enum235_0;
			switch (class1685_0[i].enum235_0)
			{
			case Enum235.const_6:
				int_0 = smethod_1(byte_1, int_0, (GradientFill)@class.object_0);
				break;
			case Enum235.const_4:
			case Enum235.const_5:
			case Enum235.const_7:
			case Enum235.const_8:
			case Enum235.const_9:
			case Enum235.const_10:
			case Enum235.const_11:
			case Enum235.const_13:
			{
				byte_1[int_0 + 2] = 20;
				InternalColor internalColor = (InternalColor)@class.object_0;
				switch (internalColor.ColorType)
				{
				case ColorType.Automatic:
				case ColorType.AutomaticIndex:
					byte_1[int_0 + 4] = 0;
					break;
				case ColorType.RGB:
				{
					byte_1[int_0 + 4] = 2;
					int num = internalColor.method_4();
					byte_1[int_0 + 8] = (byte)((uint)(num >> 16) & 0xFFu);
					byte_1[int_0 + 9] = (byte)((uint)(num >> 8) & 0xFFu);
					byte_1[int_0 + 10] = (byte)((uint)num & 0xFFu);
					byte_1[int_0 + 11] = byte.MaxValue;
					break;
				}
				case ColorType.IndexedColor:
					byte_1[int_0 + 4] = 1;
					Array.Copy(BitConverter.GetBytes(internalColor.method_4()), 0, byte_1, int_0 + 8, 4);
					break;
				case ColorType.Theme:
					byte_1[int_0 + 4] = 3;
					Array.Copy(BitConverter.GetBytes((short)(internalColor.Tint * 32767.0)), 0, byte_1, int_0 + 6, 2);
					Array.Copy(BitConverter.GetBytes(internalColor.method_4()), 0, byte_1, int_0 + 8, 4);
					break;
				}
				int_0 += 20;
				break;
			}
			case Enum235.const_14:
				byte_1[int_0 + 2] = 5;
				byte_1[int_0 + 4] = (byte)@class.object_0;
				int_0 += 5;
				break;
			case Enum235.const_15:
				byte_1[int_0 + 2] = 6;
				Array.Copy(BitConverter.GetBytes((short)@class.object_0), 0, byte_1, int_0 + 4, 2);
				int_0 += 6;
				break;
			}
		}
		return int_0;
	}

	private static int smethod_1(byte[] byte_1, int int_0, GradientFill gradientFill_0)
	{
		byte_1[int_0] = 6;
		Array.Copy(BitConverter.GetBytes((ushort)(52 + 22 * gradientFill_0.GradientStops.Count)), 0, byte_1, int_0 + 2, 2);
		int_0 += 4;
		GradientFillType fillType = gradientFill_0.FillType;
		if (fillType == GradientFillType.Rectangle)
		{
			byte_1[int_0] = 1;
			int_0 += 12;
			Array.Copy(BitConverter.GetBytes((double)gradientFill_0.method_2().int_0 / 100000.0), 0, byte_1, int_0, 8);
			Array.Copy(BitConverter.GetBytes((double)gradientFill_0.method_2().int_3 / 100000.0), 0, byte_1, int_0 + 8, 8);
			Array.Copy(BitConverter.GetBytes((double)gradientFill_0.method_2().int_1 / 100000.0), 0, byte_1, int_0 + 16, 8);
			Array.Copy(BitConverter.GetBytes((double)gradientFill_0.method_2().int_2 / 100000.0), 0, byte_1, int_0 + 24, 8);
		}
		else
		{
			byte_1[int_0] = 0;
			double value = gradientFill_0.Angle;
			Array.Copy(BitConverter.GetBytes(value), 0, byte_1, int_0 + 4, 8);
			int_0 += 12;
			if (gradientFill_0.method_3() != null)
			{
				Array.Copy(BitConverter.GetBytes((double)gradientFill_0.method_3().int_0 / 100000.0), 0, byte_1, int_0, 8);
				Array.Copy(BitConverter.GetBytes((double)gradientFill_0.method_3().int_3 / 100000.0), 0, byte_1, int_0 + 8, 8);
				Array.Copy(BitConverter.GetBytes((double)gradientFill_0.method_3().int_1 / 100000.0), 0, byte_1, int_0 + 16, 8);
				Array.Copy(BitConverter.GetBytes((double)gradientFill_0.method_3().int_2 / 100000.0), 0, byte_1, int_0 + 24, 8);
			}
		}
		int_0 += 32;
		Array.Copy(BitConverter.GetBytes(gradientFill_0.GradientStops.Count), 0, byte_1, int_0, 4);
		int_0 += 4;
		for (int i = 0; i < gradientFill_0.GradientStops.Count; i++)
		{
			GradientStop gradientStop = gradientFill_0.GradientStops[i];
			int num = gradientStop.internalColor_0.method_4();
			switch (gradientStop.internalColor_0.ColorType)
			{
			case ColorType.Automatic:
			case ColorType.AutomaticIndex:
				byte_1[int_0] = 0;
				break;
			case ColorType.RGB:
			{
				int num2 = num & 0xFF;
				int num3 = (num & 0xFF00) >> 8;
				int num4 = (num & 0xFF0000) >> 16;
				num = (num2 << 16) + (num3 << 8) + num4;
				byte_1[int_0] = 2;
				break;
			}
			case ColorType.IndexedColor:
				byte_1[int_0] = 1;
				break;
			case ColorType.Theme:
				byte_1[int_0] = 3;
				break;
			}
			Array.Copy(BitConverter.GetBytes(num), 0, byte_1, int_0 + 2, 4);
			Array.Copy(BitConverter.GetBytes(gradientStop.Position / 100.0), 0, byte_1, int_0 + 6, 8);
			Array.Copy(BitConverter.GetBytes(gradientStop.internalColor_0.Tint), 0, byte_1, int_0 + 14, 8);
			int_0 += 22;
		}
		return int_0;
	}
}
