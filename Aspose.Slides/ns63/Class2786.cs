using System.IO;
using System.Text;
using ns60;

namespace ns63;

internal class Class2786 : Class2623
{
	internal const int int_0 = 1039;

	private byte[] byte_0;

	public string ColorMapping
	{
		get
		{
			return Encoding.UTF8.GetString(byte_0);
		}
		set
		{
			byte_0 = Encoding.UTF8.GetBytes(value);
		}
	}

	internal Class2786()
	{
		base.Header.Type = 1039;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadBytes(base.Header.Length);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		if (byte_0 != null)
		{
			writer.Write(byte_0);
		}
	}

	public override int vmethod_2()
	{
		if (byte_0 == null)
		{
			return 0;
		}
		return byte_0.Length;
	}
}
