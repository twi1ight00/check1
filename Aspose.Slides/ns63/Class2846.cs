using System.IO;

namespace ns63;

internal abstract class Class2846 : Class2845
{
	private int int_0;

	public int Position
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(Position);
	}

	public override int vmethod_2()
	{
		return 4;
	}

	protected Class2846(Class2951 parentFrame)
		: base(parentFrame)
	{
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		Position = reader.ReadInt32();
	}
}
