using System.IO;

namespace ns63;

internal class Class2857 : Class2845
{
	internal const int int_0 = 4008;

	protected byte[] byte_0 = new byte[0];

	public byte[] TextData => byte_0;

	public virtual string Text
	{
		get
		{
			if (byte_0.Length > 0)
			{
				char[] array = new char[byte_0.Length];
				for (int i = 0; i < base.Header.Length; i++)
				{
					array[i] = (char)byte_0[i];
				}
				return new string(array);
			}
			return "";
		}
		set
		{
			if (value != null)
			{
				byte_0 = new byte[value.Length];
				for (int i = 0; i < byte_0.Length; i++)
				{
					byte_0[i] = (byte)(value[i] & 0xFFu);
				}
			}
		}
	}

	internal Class2857(Class2951 subTextFrame)
		: base(subTextFrame)
	{
		base.Header.Type = 4008;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadBytes(base.Header.Length);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(byte_0);
	}

	public override int vmethod_2()
	{
		return byte_0.Length;
	}
}
