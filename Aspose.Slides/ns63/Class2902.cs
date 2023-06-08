using System.IO;
using ns60;

namespace ns63;

internal class Class2902 : Class2623
{
	internal const int int_0 = 1045;

	private Class2965 class2965_0 = new Class2965();

	private Class2965 class2965_1 = new Class2965();

	private Enum405 enum405_0 = Enum405.const_1;

	private Enum405 enum405_1 = Enum405.const_1;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	public Class2965 LeftPortion
	{
		get
		{
			return class2965_0;
		}
		set
		{
			class2965_0 = value;
		}
	}

	public Class2965 TopPortion
	{
		get
		{
			return class2965_1;
		}
		set
		{
			class2965_1 = value;
		}
	}

	public Enum405 VertBarState
	{
		get
		{
			return enum405_0;
		}
		set
		{
			enum405_0 = value;
		}
	}

	public Enum405 HorizBarState
	{
		get
		{
			return enum405_1;
		}
		set
		{
			enum405_1 = value;
		}
	}

	public bool FPreferSingleSet
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

	public bool FHideThumbnails
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

	public bool FBarSnapped
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	internal Class2902()
	{
		base.Header.Type = 1045;
	}

	internal void method_1()
	{
		class2965_0 = new Class2965(-156200006, 1000000000);
		class2965_1 = new Class2965(-946600019, 1000000000);
		enum405_0 = Enum405.const_1;
		enum405_1 = Enum405.const_1;
		bool_1 = false;
		bool_2 = false;
		bool_3 = false;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		class2965_0.method_0(reader);
		class2965_1.method_0(reader);
		enum405_0 = (Enum405)reader.ReadByte();
		enum405_1 = (Enum405)reader.ReadByte();
		bool_1 = reader.ReadByte() != 0;
		byte b = reader.ReadByte();
		bool_2 = (b & 1) != 0;
		bool_3 = (b & 2) != 0;
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		class2965_0.method_1(writer);
		class2965_1.method_1(writer);
		writer.Write((byte)enum405_0);
		writer.Write((byte)enum405_1);
		writer.Write((byte)(bool_1 ? 1u : 0u));
		writer.Write((byte)((bool_2 ? 1 : 0) + (bool_3 ? 2 : 0)));
	}

	public override int vmethod_2()
	{
		return 20;
	}
}
