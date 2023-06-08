using System.Drawing;
using System.IO;

namespace x1a62aaf14e3c5909;

internal class x1f112a7e89020b14 : xddf6304144fd3863
{
	private Point x3bb6d9a800d1fec3 = Point.Empty;

	private Size x39cd19e537ba51a9 = Size.Empty;

	internal Point x48269779ca77dbce
	{
		get
		{
			return x3bb6d9a800d1fec3;
		}
		set
		{
			x3bb6d9a800d1fec3 = value;
		}
	}

	internal Size x82f47b4c4fcc123d
	{
		get
		{
			return x39cd19e537ba51a9;
		}
		set
		{
			x39cd19e537ba51a9 = value;
		}
	}

	internal x1f112a7e89020b14()
		: base(x773fe540042dad03.x873e507a3bc924e4, 1)
	{
	}

	protected override void DoRead(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		int num2 = reader.ReadInt32();
		int num3 = reader.ReadInt32();
		int num4 = reader.ReadInt32();
		x3bb6d9a800d1fec3 = new Point(num, num2);
		x39cd19e537ba51a9 = new Size(num3 - num, num4 - num2);
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		writer.Write(x3bb6d9a800d1fec3.X);
		writer.Write(x3bb6d9a800d1fec3.Y);
		writer.Write(x3bb6d9a800d1fec3.X + x39cd19e537ba51a9.Width);
		writer.Write(x3bb6d9a800d1fec3.Y + x39cd19e537ba51a9.Height);
	}
}
