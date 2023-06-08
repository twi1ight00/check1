using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns274;

internal class Class6716
{
	private const int int_0 = 20;

	private Guid guid_0 = Guid.Empty;

	private readonly List<Class6717> list_0 = new List<Class6717>();

	public List<Class6717> Sections => list_0;

	public Class6716()
	{
	}

	public Class6716(Stream stream)
	{
		stream.Position = 0L;
		BinaryReader binaryReader = new BinaryReader(stream, Encoding.Unicode);
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
			list_0.Add(new Class6717(array[j], binaryReader));
		}
	}

	public void Save(Stream stream)
	{
		BinaryWriter binaryWriter = new BinaryWriter(stream, Encoding.Unicode);
		binaryWriter.Write((ushort)65534);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(131333u);
		binaryWriter.Write(guid_0.ToByteArray());
		binaryWriter.Write(list_0.Count);
		int num = (int)stream.Position + 20 * list_0.Count;
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < list_0.Count; i++)
		{
			Class6717 @class = list_0[i];
			binaryWriter.Write(@class.FmtId.ToByteArray());
			int value = num + (int)memoryStream.Length;
			binaryWriter.Write(value);
			byte[] array = @class.method_0();
			memoryStream.Write(array, 0, array.Length);
		}
		stream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
	}
}
