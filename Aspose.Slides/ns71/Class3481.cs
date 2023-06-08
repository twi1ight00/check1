using System.Collections.Generic;
using System.IO;

namespace ns71;

internal class Class3481 : Class3473
{
	private byte byte_0;

	private readonly List<Class3478> list_0 = new List<Class3478>();

	public byte FlagByte
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public List<Class3478> Tokens => list_0;

	internal override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadByte();
		method_0(reader);
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(byte_0);
		method_1(writer);
	}

	private void method_0(BinaryReader reader)
	{
		for (int i = 0; i < 8; i++)
		{
			if (reader.BaseStream.Position == reader.BaseStream.Length)
			{
				break;
			}
			if (((byte_0 >> i) & 1) == 0)
			{
				Class3480 @class = new Class3480();
				@class.vmethod_0(reader);
				list_0.Add(@class);
			}
			else
			{
				Class3479 class2 = new Class3479();
				class2.vmethod_0(reader);
				list_0.Add(class2);
			}
		}
	}

	private void method_1(BinaryWriter writer)
	{
		foreach (Class3478 item in list_0)
		{
			item.vmethod_1(writer);
		}
	}
}
