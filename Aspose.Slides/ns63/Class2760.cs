using System.IO;
using ns60;

namespace ns63;

internal abstract class Class2760 : Class2623
{
	internal const int int_0 = 61762;

	private byte byte_0;

	private byte[] byte_1;

	public Enum400 TimeVariantType
	{
		get
		{
			return (Enum400)byte_0;
		}
		protected set
		{
			byte_0 = (byte)value;
		}
	}

	public byte[] RawValue
	{
		get
		{
			return byte_1;
		}
		protected set
		{
			byte_1 = value;
		}
	}

	internal Class2760()
	{
		base.Header.Type = 61762;
		base.Header.Version = 0;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadByte();
		byte_1 = reader.ReadBytes(base.Header.Length - 1);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(byte_0);
		writer.Write(byte_1);
	}

	public override int vmethod_2()
	{
		return 1 + byte_1.Length;
	}

	protected abstract void vmethod_5();
}
