using System;
using System.IO;
using System.Text;

namespace ns62;

internal class Class2930 : Class2910
{
	private const int int_0 = 6;

	private byte[] byte_0;

	public virtual byte[] Value
	{
		get
		{
			return byte_0;
		}
		protected set
		{
			byte_0 = value;
		}
	}

	public int Size => byte_0.Length;

	public Class2930(Enum426 id, int size)
		: base(id, isBid: false)
	{
		byte_0 = new byte[size];
	}

	public Class2930(Enum426 id, byte[] source)
		: this(id, source, 0, source.Length)
	{
	}

	public Class2930(Enum426 id, byte[] source, int index, int count)
		: base(id, isBid: false)
	{
		byte_0 = new byte[count];
		Array.Copy(source, index, byte_0, 0, count);
	}

	public Class2930(Enum426 id, string source)
		: base(id, isBid: false)
	{
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		byte[] bytes = unicodeEncoding.GetBytes(source);
		int num = bytes.Length + 2;
		byte_0 = new byte[num];
		Array.Copy(bytes, 0, byte_0, 0, bytes.Length);
		byte_0[byte_0.Length - 1] = 0;
		byte_0[byte_0.Length - 2] = 0;
	}

	internal override void Write(BinaryWriter writer)
	{
		int id = (int)base.Id;
		id |= (base.IsBid ? 16384 : 0);
		id |= 0x8000;
		writer.Write((short)id);
		writer.Write(byte_0.Length);
	}

	internal virtual void vmethod_1(BinaryReader reader)
	{
		reader.Read(byte_0, 0, byte_0.Length);
	}

	internal virtual void vmethod_2(BinaryWriter writer)
	{
		writer.Write(byte_0);
	}

	internal override int vmethod_0()
	{
		return 6 + Value.Length;
	}

	protected void method_0(int size)
	{
		byte[] array = byte_0;
		Value = new byte[size];
		Array.Copy(array, byte_0, (array.Length < byte_0.Length) ? array.Length : byte_0.Length);
	}
}
