using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns22;

namespace ns18;

internal class Class1204 : Class1201
{
	private readonly HatchBrush hatchBrush_0;

	private static readonly byte[] byte_2;

	internal override Image Image => null;

	internal override int Width => 8;

	internal override int Height => 8;

	private Class1204()
	{
	}

	internal Class1204(HatchBrush hatchBrush_1)
	{
		hatchBrush_0 = hatchBrush_1;
		method_3();
	}

	private void method_3()
	{
		byte_0 = new byte[8];
		Array.Copy(byte_2, (int)hatchBrush_0.HatchStyle * 8, byte_0, 0, 8);
		color_0 = new Color[2];
		ref Color reference = ref color_0[0];
		reference = hatchBrush_0.BackgroundColor;
		ref Color reference2 = ref color_0[1];
		reference2 = hatchBrush_0.ForegroundColor;
		if (vmethod_2())
		{
			byte_1 = new byte[64];
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					int num = (((byte_0[i] & (128 >> j)) > 0) ? 1 : 0);
					byte_1[j + i * 8] = color_0[num].A;
				}
			}
		}
		else
		{
			byte_1 = new byte[0];
		}
	}

	[SpecialName]
	internal override int vmethod_0()
	{
		return 1;
	}

	[SpecialName]
	internal override Class1439 vmethod_1()
	{
		return Class1439.smethod_2();
	}

	[SpecialName]
	internal override bool vmethod_2()
	{
		if (hatchBrush_0.BackgroundColor.A >= byte.MaxValue)
		{
			return hatchBrush_0.ForegroundColor.A < byte.MaxValue;
		}
		return true;
	}

	[SpecialName]
	internal override bool vmethod_3()
	{
		return !vmethod_2();
	}

	static Class1204()
	{
		byte_2 = Class1186.smethod_3();
	}
}
