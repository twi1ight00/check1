using System.IO;
using System.Text;

namespace ns71;

internal class Class3488 : Class3483
{
	private readonly int int_0;

	private uint uint_0;

	private string string_0;

	public override ushort Id => 71;

	public uint SizeOfModuleNameUnicode
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

	public string ModuleNameUnicode
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class3488(int codePage)
	{
		int_0 = codePage;
	}

	protected override void vmethod_2(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		string_0 = Class3522.smethod_3(reader, (int)uint_0, Encoding.Unicode);
	}

	protected override void vmethod_3(BinaryWriter writer)
	{
		Class3523.smethod_2(writer, string_0, Encoding.Unicode);
	}
}
