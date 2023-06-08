using System.IO;
using ns60;

namespace ns62;

internal class Class2900 : Class2623
{
	internal const int int_0 = 61726;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	public uint FillColor
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public uint LineColor
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public uint ShadowColor
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public uint Color3D
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	internal Class2900()
		: base(61726, 0)
	{
	}

	public Class2900(uint cfill, uint cline, uint cshadow, uint c3d)
		: base(61726, 0)
	{
		uint_0 = cfill;
		uint_1 = cline;
		uint_2 = cshadow;
		uint_3 = c3d;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		uint_2 = reader.ReadUInt32();
		uint_3 = reader.ReadUInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(uint_2);
		writer.Write(uint_3);
	}

	public override int vmethod_2()
	{
		return 16;
	}
}
