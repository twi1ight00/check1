using System.IO;
using ns60;

namespace ns63;

internal class Class2748 : Class2623
{
	internal const int int_0 = 61749;

	private int int_1;

	private Class2937 class2937_0;

	private Class2937 class2937_1;

	private Class2937 class2937_2;

	public Class2937 ColorBy
	{
		get
		{
			return class2937_0;
		}
		set
		{
			class2937_0 = value;
		}
	}

	public Class2937 ColorFrom
	{
		get
		{
			return class2937_1;
		}
		set
		{
			class2937_1 = value;
		}
	}

	public Class2937 ColorTo
	{
		get
		{
			return class2937_2;
		}
		set
		{
			class2937_2 = value;
		}
	}

	public bool FByPropertyUsed
	{
		get
		{
			return (int_1 & 1) == 1;
		}
		set
		{
			if (value)
			{
				int_1 |= 1;
			}
			else
			{
				int_1 &= -2;
			}
		}
	}

	public bool FFromPropertyUsed
	{
		get
		{
			return (int_1 & 2) == 2;
		}
		set
		{
			if (value)
			{
				int_1 |= 2;
			}
			else
			{
				int_1 &= -3;
			}
		}
	}

	public bool FToPropertyUsed
	{
		get
		{
			return (int_1 & 4) == 4;
		}
		set
		{
			if (value)
			{
				int_1 |= 4;
			}
			else
			{
				int_1 &= -5;
			}
		}
	}

	public bool FColorSpacePropertyUsed
	{
		get
		{
			return (int_1 & 8) == 8;
		}
		set
		{
			if (value)
			{
				int_1 |= 8;
			}
			else
			{
				int_1 &= -9;
			}
		}
	}

	public bool FDirectionPropertyUsed
	{
		get
		{
			return (int_1 & 0x10) == 16;
		}
		set
		{
			if (value)
			{
				int_1 |= 16;
			}
			else
			{
				int_1 &= -17;
			}
		}
	}

	public Class2748()
	{
		base.Header.Type = 61749;
		class2937_0 = new Class2937();
		class2937_1 = new Class2937();
		class2937_2 = new Class2937();
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		class2937_0.method_0(reader);
		class2937_1.method_0(reader);
		class2937_2.method_0(reader);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(int_1);
		class2937_0.method_1(writer);
		class2937_1.method_1(writer);
		class2937_2.method_1(writer);
	}

	public override int vmethod_2()
	{
		return 52;
	}
}
