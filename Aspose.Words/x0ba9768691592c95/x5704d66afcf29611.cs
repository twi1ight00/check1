using System;
using System.Collections;
using System.IO;
using System.Text;
using x13f1efc79617a47b;

namespace x0ba9768691592c95;

internal class x5704d66afcf29611
{
	private const int xc7b5a1e533c51648 = 20;

	private Guid x31394132931742a3 = Guid.Empty;

	private readonly ArrayList x601fbccbb289d983 = new ArrayList();

	public ArrayList x31ded3025bcd2eb4 => x601fbccbb289d983;

	public x5704d66afcf29611()
	{
	}

	public x5704d66afcf29611(Stream stream)
	{
		stream.Position = 0L;
		BinaryReader binaryReader = new BinaryReader(stream, Encoding.Unicode);
		binaryReader.ReadUInt16();
		if (binaryReader.ReadUInt16() != 0)
		{
			throw new NotSupportedException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("baaombhogcoodcfpbcmpdcdammjalbbblaibeapbeagcnlmckaedjalddacebajedppenpgfmpnfopegcklgcpchbojhnoaigjhimnoionfjnimjondkpmkknmblenilohplbmgmhmnmhmenpllnalcoamjohhap", 1760419774)));
		}
		binaryReader.ReadUInt32();
		x31394132931742a3 = new Guid(binaryReader.ReadBytes(16));
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
			x601fbccbb289d983.Add(new x77d7a46711f04d5d(array[j], binaryReader));
		}
	}

	public void x0acd3c2012ea2ee8(Stream xcf18e5243f8d5fd3)
	{
		BinaryWriter binaryWriter = new BinaryWriter(xcf18e5243f8d5fd3, Encoding.Unicode);
		binaryWriter.Write((ushort)65534);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(131333u);
		binaryWriter.Write(x31394132931742a3.ToByteArray());
		binaryWriter.Write(x601fbccbb289d983.Count);
		int num = (int)xcf18e5243f8d5fd3.Position + 20 * x601fbccbb289d983.Count;
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < x601fbccbb289d983.Count; i++)
		{
			x77d7a46711f04d5d x77d7a46711f04d5d2 = (x77d7a46711f04d5d)x601fbccbb289d983[i];
			binaryWriter.Write(x77d7a46711f04d5d2.x11f221c54c2b65e6.ToByteArray());
			int value = num + (int)memoryStream.Length;
			binaryWriter.Write(value);
			byte[] array = x77d7a46711f04d5d2.x2797b998ab68f4ab();
			memoryStream.Write(array, 0, array.Length);
		}
		xcf18e5243f8d5fd3.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
	}
}
