using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ns57;

internal class Class1324
{
	private Guid guid_0 = Guid.Empty;

	private Class1299 class1299_0 = new Class1299();

	internal Class1324()
	{
	}

	internal Class1324(Stream stream_0)
	{
		stream_0.Position = 0L;
		BinaryReader binaryReader = new BinaryReader(stream_0, Encoding.Unicode);
		binaryReader.ReadUInt16();
		if (binaryReader.ReadUInt16() != 0)
		{
			throw new NotSupportedException("Cannot read property set in this format.");
		}
		binaryReader.ReadUInt32();
		guid_0 = new Guid(binaryReader.ReadBytes(16));
		int num = binaryReader.ReadInt32();
		Guid[] array = new Guid[num];
		int[] array2 = new int[num];
		for (int i = 0; i < num; i++)
		{
			ref Guid reference = ref array[i];
			reference = new Guid(binaryReader.ReadBytes(16));
			array2[i] = binaryReader.ReadInt32();
		}
		for (int j = 0; j < num; j++)
		{
			binaryReader.BaseStream.Position = array2[j];
			class1299_0.Add(new Class1325(array[j], binaryReader));
		}
	}

	internal void Save(Stream stream_0)
	{
		BinaryWriter binaryWriter = new BinaryWriter(stream_0, Encoding.Unicode);
		binaryWriter.Write((ushort)65534);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(131333u);
		binaryWriter.Write(guid_0.ToByteArray());
		binaryWriter.Write(class1299_0.Count);
		int num = (int)stream_0.Position + 20 * class1299_0.Count;
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < class1299_0.Count; i++)
		{
			binaryWriter.Write(class1299_0[i].method_1().ToByteArray());
			int value = num + (int)memoryStream.Length;
			binaryWriter.Write(value);
			byte[] array = class1299_0[i].method_0();
			memoryStream.Write(array, 0, array.Length);
		}
		stream_0.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
	}

	[SpecialName]
	internal Class1299 method_0()
	{
		return class1299_0;
	}
}
