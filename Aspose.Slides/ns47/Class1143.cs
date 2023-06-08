using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ns4;

namespace ns47;

internal class Class1143 : Interface37
{
	private readonly ushort ushort_0 = 1252;

	private readonly SortedList<string, uint> sortedList_0 = new SortedList<string, uint>(StringComparer.InvariantCultureIgnoreCase);

	public SortedList<string, uint> Entries => sortedList_0;

	public bool IsEmpty => sortedList_0.Count == 0;

	internal Class1143()
	{
		ushort_0 = 1200;
	}

	internal Class1143(byte[] bytes, ushort codepage)
	{
		ushort_0 = codepage;
		int num = (int)Class1162.smethod_8(bytes, 0);
		int num2 = 4;
		for (int i = 0; i < num; i++)
		{
			uint value = (uint)Class1162.smethod_8(bytes, num2);
			uint num3 = (uint)Class1162.smethod_8(bytes, num2 + 4);
			num2 += 8;
			StringBuilder stringBuilder = new StringBuilder((int)num3);
			for (int j = 0; j < num3; j++)
			{
				if (codepage == 1200)
				{
					stringBuilder.Append((char)Class1162.smethod_1(bytes, num2 + j * 2));
					continue;
				}
				stringBuilder.Append(Encoding.GetEncoding(codepage).GetChars(new byte[1] { bytes[num2 + j] }));
			}
			while (stringBuilder[stringBuilder.Length - 1] == '\0')
			{
				stringBuilder.Length--;
			}
			if (codepage == 1200)
			{
				if (num3 % 2u == 1)
				{
					num3++;
				}
				num2 += (int)(num3 + num3);
			}
			else
			{
				num2 += (int)num3;
			}
			sortedList_0[stringBuilder.ToString()] = value;
		}
	}

	public byte[] Write()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		int count = sortedList_0.Count;
		binaryWriter.Write((uint)count);
		foreach (KeyValuePair<string, uint> item in sortedList_0)
		{
			binaryWriter.Write(item.Value);
			string key = item.Key;
			int num = key.Length + 1;
			binaryWriter.Write((uint)num);
			if (ushort_0 == 1200)
			{
				if (num % 2 == 1)
				{
					num++;
				}
				num += num;
			}
			byte[] array = new byte[num];
			byte[] bytes = Encoding.GetEncoding(ushort_0).GetBytes(key);
			Array.Copy(bytes, array, bytes.Length);
			binaryWriter.Write(array);
		}
		int num2 = (int)memoryStream.Length % 4;
		if (num2 > 0)
		{
			binaryWriter.Write(new byte[num2]);
		}
		binaryWriter.Close();
		return memoryStream.ToArray();
	}
}
