using System;
using System.Drawing;
using System.IO;

namespace ns264;

internal class Class6500
{
	private uint uint_0;

	private short short_0;

	private short short_1;

	private short short_2;

	private short short_3;

	private short short_4;

	private short short_5;

	private uint uint_1;

	private short short_6;

	internal bool AreDimensionsValid
	{
		get
		{
			if (short_3 - short_1 > 0)
			{
				return short_4 - short_2 > 0;
			}
			return false;
		}
	}

	internal RectangleF Bounds => new RectangleF(0f, 0f, short_3 - short_1, short_4 - short_2);

	internal int Inch => short_5;

	internal Class6500()
	{
	}

	internal void Read(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		short_0 = reader.ReadInt16();
		short_1 = reader.ReadInt16();
		short_2 = reader.ReadInt16();
		short_3 = reader.ReadInt16();
		short_4 = reader.ReadInt16();
		short_5 = reader.ReadInt16();
		uint_1 = reader.ReadUInt32();
		short_6 = reader.ReadInt16();
		method_0();
	}

	private void method_0()
	{
		short num = 0;
		num = (short)(0 ^ (short)(uint_0 & 0xFFFF));
		num = (short)(num ^ (short)((uint_0 & 0xFFFF0000u) >> 16));
		num = (short)(num ^ short_0);
		num = (short)(num ^ short_1);
		num = (short)(num ^ short_2);
		num = (short)(num ^ short_3);
		num = (short)(num ^ short_4);
		num = (short)(num ^ short_5);
		num = (short)(num ^ (short)(uint_1 & 0xFFFF));
		num = (short)(num ^ (short)((uint_1 & 0xFFFF0000u) >> 16));
		if (num != short_6)
		{
			throw new InvalidOperationException("Metafile checksum is invalid.");
		}
	}
}
