using System.IO;
using ns60;

namespace ns63;

internal class Class2767 : Class2765, Interface39, Interface43
{
	internal const int int_0 = 11003;

	protected uint uint_0;

	protected uint uint_1;

	protected uint uint_2;

	protected int int_1;

	protected int int_2;

	public Enum401 VisualType
	{
		get
		{
			return (Enum401)uint_0;
		}
		set
		{
			uint_0 = (uint)value;
		}
	}

	public Enum409 RefType
	{
		get
		{
			return (Enum409)uint_1;
		}
		protected set
		{
			uint_1 = (uint)value;
		}
	}

	internal Class2767()
	{
		base.Header.Type = 11003;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		uint_2 = reader.ReadUInt32();
		int_1 = reader.ReadInt32();
		int_2 = reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(uint_2);
		writer.Write(int_1);
		writer.Write(int_2);
	}

	public override int vmethod_2()
	{
		return 20;
	}
}
