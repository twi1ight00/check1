using System.Drawing;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns22;

namespace ns27;

internal class Class651 : Class538
{
	private Palette palette_0;

	private Line line_0;

	internal Class651(FileFormatType fileFormatType_1, Palette palette_1)
	{
		palette_0 = palette_1;
		method_2(4103);
		fileFormatType_0 = fileFormatType_1;
		method_0(12);
		byte_0 = new byte[12];
		byte_0[6] = byte.MaxValue;
		byte_0[7] = byte.MaxValue;
		byte_0[8] = 9;
		byte_0[10] = 77;
	}

	internal void method_4()
	{
		byte_0[4] = 5;
		byte_0[8] = 8;
		byte_0[10] = 77;
	}

	internal void method_5(Line line_1, int int_0)
	{
		line_0 = line_1;
		if (!line_0.IsVisible)
		{
			byte_0[4] = 5;
			byte_0[6] = byte.MaxValue;
			byte_0[7] = byte.MaxValue;
			byte_0[8] = 8;
			byte_0[10] = 77;
			return;
		}
		if (!Class1178.smethod_0(line_0.Color))
		{
			int num = palette_0.method_2(line_0.Color);
			if (num != -1)
			{
				byte_0[0] = line_0.Color.R;
				byte_0[1] = line_0.Color.G;
				byte_0[2] = line_0.Color.B;
				byte_0[10] = (byte)num;
				byte_0[8] = 0;
			}
			else
			{
				Color color = line_0.Color;
				num = palette_0.method_4(color.R, color.G, color.B);
				byte_0[0] = line_0.Color.R;
				byte_0[1] = line_0.Color.G;
				byte_0[2] = line_0.Color.B;
				byte_0[10] = (byte)num;
				byte_0[8] = 0;
			}
		}
		else if (line_1.IsAuto)
		{
			byte_0[0] = 0;
			byte_0[1] = 0;
			byte_0[2] = 0;
			byte_0[10] = 77;
			byte_0[8] = 9;
		}
		else
		{
			int num2 = (32 + int_0) % 56;
			byte_0[10] = (byte)num2;
			byte_0[8] = 0;
		}
		byte_0[4] = (byte)line_0.Style;
		if (line_0.Weight == WeightType.HairLine)
		{
			byte_0[6] = byte.MaxValue;
			byte_0[7] = byte.MaxValue;
		}
		else
		{
			byte_0[6] = (byte)line_0.Weight;
			byte_0[7] = 0;
		}
		if (line_0.IsAuto)
		{
			byte_0[8] |= 1;
		}
		else
		{
			byte_0[8] &= 254;
		}
	}

	internal void method_6(Line line_1, bool bool_0)
	{
		line_0 = line_1;
		if (!Class1178.smethod_0(line_0.Color))
		{
			Color color = line_0.Color;
			int num = palette_0.method_2(color);
			if (num != -1)
			{
				byte_0[0] = line_0.Color.R;
				byte_0[1] = line_0.Color.G;
				byte_0[2] = line_0.Color.B;
				byte_0[10] = (byte)num;
				byte_0[8] &= 7;
				if (bool_0)
				{
					byte_0[8] = 4;
				}
			}
			else
			{
				num = palette_0.method_4(color.R, color.G, color.B);
				if (num != -1)
				{
					byte_0[0] = line_0.Color.R;
					byte_0[1] = line_0.Color.G;
					byte_0[2] = line_0.Color.B;
					byte_0[10] = (byte)num;
					byte_0[8] &= 7;
					if (bool_0)
					{
						byte_0[8] = 4;
					}
				}
			}
		}
		else
		{
			byte_0[0] = 0;
			byte_0[1] = 0;
			byte_0[2] = 0;
			byte_0[10] = 77;
			byte_0[8] = 9;
		}
		byte_0[4] = (byte)line_0.Style;
		if (!line_0.IsVisible)
		{
			byte_0[4] = 5;
			if (bool_0)
			{
				byte_0[8] = 4;
			}
		}
		if (byte_0[4] != 0 && bool_0)
		{
			byte_0[8] = 4;
		}
		if (line_0.Weight == WeightType.HairLine)
		{
			byte_0[6] = byte.MaxValue;
			byte_0[7] = byte.MaxValue;
		}
		else
		{
			byte_0[6] = (byte)line_0.Weight;
			byte_0[7] = 0;
		}
		if (line_0.IsAuto)
		{
			byte_0[8] |= 1;
		}
		else
		{
			byte_0[8] &= 254;
		}
	}
}
