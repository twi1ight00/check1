using System.IO;
using ns60;

namespace ns63;

internal class Class2905 : Class2623
{
	internal const int int_0 = 1022;

	private bool bool_1;

	private bool bool_2;

	public bool FSnapToGrid
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool FSnapToShape
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	internal Class2905()
	{
		base.Header.Type = 1022;
	}

	internal void method_1()
	{
		bool_1 = true;
		bool_2 = false;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		reader.ReadByte();
		bool_1 = reader.ReadByte() != 0;
		bool_2 = reader.ReadByte() != 0;
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write((byte)0);
		writer.Write((byte)(bool_1 ? 1u : 0u));
		writer.Write((byte)(bool_2 ? 1u : 0u));
	}

	public override int vmethod_2()
	{
		return 3;
	}
}
