using System;
using System.Collections.Generic;
using System.IO;

namespace ns71;

internal class Class3475 : Class3473
{
	private byte[] byte_0;

	private readonly uint uint_0;

	private List<Class3481> list_0 = new List<Class3481>();

	private readonly bool bool_0;

	public byte[] Data
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

	public List<Class3481> TokenSequences
	{
		get
		{
			if (!bool_0)
			{
				throw new InvalidOperationException();
			}
			return list_0;
		}
		set
		{
			if (!bool_0)
			{
				throw new InvalidOperationException();
			}
			list_0 = value;
		}
	}

	public Class3475(uint size, bool compressed)
	{
		uint_0 = size;
		bool_0 = compressed;
	}

	internal override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadBytes((int)uint_0);
		if (bool_0)
		{
			method_0();
		}
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		if (bool_0)
		{
			foreach (Class3481 item in list_0)
			{
				item.vmethod_1(writer);
			}
			return;
		}
		writer.Write(byte_0);
	}

	private void method_0()
	{
		using MemoryStream input = new MemoryStream(byte_0);
		using BinaryReader binaryReader = new BinaryReader(input);
		while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
		{
			Class3481 @class = new Class3481();
			@class.vmethod_0(binaryReader);
			list_0.Add(@class);
		}
	}
}
