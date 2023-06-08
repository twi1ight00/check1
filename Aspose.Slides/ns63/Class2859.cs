using System.IO;

namespace ns63;

internal class Class2859 : Class2845
{
	public const int int_0 = 3999;

	private Enum449 enum449_0;

	public Enum449 TextType
	{
		get
		{
			return enum449_0;
		}
		set
		{
			enum449_0 = value;
		}
	}

	public Class2859(Class2951 stf)
		: base(stf)
	{
		base.Header.Type = 3999;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		enum449_0 = (Enum449)reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write((int)enum449_0);
	}

	public override int vmethod_2()
	{
		return 4;
	}
}
