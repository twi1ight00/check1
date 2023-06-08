using System.IO;
using ns60;

namespace ns63;

internal class Class2787 : Class2623
{
	internal const int int_0 = 1061;

	private byte byte_0;

	public bool FCompressPicturesOnSave
	{
		get
		{
			return (byte_0 & 1) == 1;
		}
		set
		{
			if (value)
			{
				byte_0 |= 1;
			}
			else
			{
				byte_0 = (byte)(byte_0 & 0xFFFFFFFEu);
			}
		}
	}

	internal Class2787()
	{
		base.Header.Type = 1061;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadByte();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(byte_0);
	}

	public override int vmethod_2()
	{
		return 1;
	}
}
