using System;
using System.Collections.Generic;
using System.IO;

namespace ns71;

internal class Class3477 : Class3473
{
	private byte byte_0;

	private readonly List<Class3474> list_0 = new List<Class3474>();

	public byte SignatureByte
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

	public List<Class3474> Chunks => list_0;

	internal override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadByte();
		method_0(reader);
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		writer.Write((byte)1);
		method_1(writer);
	}

	private void method_0(BinaryReader reader)
	{
		if (byte_0 != 1)
		{
			throw new InvalidOperationException();
		}
		Class3474 @class = new Class3474();
		@class.vmethod_0(reader);
		list_0.Add(@class);
		while (@class.CompressedHeader.CompressedChunkSize == 4095 && reader.BaseStream.Position != reader.BaseStream.Length)
		{
			@class = new Class3474();
			@class.vmethod_0(reader);
			list_0.Add(@class);
		}
	}

	private void method_1(BinaryWriter writer)
	{
		foreach (Class3474 item in list_0)
		{
			item.vmethod_1(writer);
		}
	}
}
