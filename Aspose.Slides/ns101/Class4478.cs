using System.IO;
using System.Text;
using ns102;
using ns127;
using ns157;
using ns99;

namespace ns101;

internal class Class4478 : Class4474
{
	public override void Save()
	{
		if (!(class4408_0 is Class4415))
		{
			return;
		}
		Class4415 @class = (Class4415)class4408_0;
		if (!@class.UsedGlyphs.Contains(Class4507.class4507_0))
		{
			@class.UsedGlyphs.Add(Class4507.class4507_0);
		}
		Stream stream = class4408_0.FontDefinition.FileDefinitions[0].StreamSource.vmethod_0();
		byte[] array;
		using (BinaryReader binaryReader = new BinaryReader(stream))
		{
			array = binaryReader.ReadBytes((int)stream.Length);
		}
		MemoryStream memoryStream = new MemoryStream();
		using BinaryWriter binaryWriter = new BinaryWriter(stream_0);
		byte[] bytes = Encoding.ASCII.GetBytes("currentfile eexec");
		byte[] bytes2 = Encoding.ASCII.GetBytes("/CharStrings");
		byte[] bytes3 = Encoding.ASCII.GetBytes("\r");
		byte[] bytes4 = Encoding.ASCII.GetBytes("\n");
		byte[] bytes5 = Encoding.ASCII.GetBytes("end");
		byte[] bytes6 = Encoding.ASCII.GetBytes("end");
		byte[] bytes7 = Encoding.ASCII.GetBytes("/");
		byte[] bytes8 = Encoding.ASCII.GetBytes("-|");
		byte[] bytes9 = Encoding.ASCII.GetBytes("RD");
		byte[] bytes10 = Encoding.ASCII.GetBytes("|-\r");
		byte[] bytes11 = Encoding.ASCII.GetBytes("|-\n");
		byte[] bytes12 = Encoding.ASCII.GetBytes("ND\r");
		byte[] bytes13 = Encoding.ASCII.GetBytes("ND\n");
		byte[] bytes14 = Encoding.ASCII.GetBytes("0000000000000000000000000000000000000000000000000000000000000000");
		byte[] checkBytes = new byte[2] { 128, 1 };
		byte[] array2 = new byte[65535];
		int num = 0;
		byte[] eexecRaw = ((Class4413)@class.OriginalFont).Type1FontDictionary.EexecRaw;
		num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				binaryWriter.Write(array[num]);
				if (num != array.Length - 1 && Class4554.smethod_4(array, num, bytes))
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		binaryWriter.Write(array, num + 1, bytes.Length - 1);
		num += bytes.Length;
		for (int i = 0; i < 2; i++)
		{
			if (Class4554.smethod_4(array, num, bytes3) || Class4554.smethod_4(array, num, bytes4))
			{
				binaryWriter.Write(array[num]);
				num++;
			}
		}
		using (BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream))
		{
			for (int j = 0; j < eexecRaw.Length; j++)
			{
				if (Class4554.smethod_4(eexecRaw, j, bytes2))
				{
					for (; !Class4554.smethod_4(eexecRaw, j, bytes3) && !Class4554.smethod_4(eexecRaw, j, bytes4); j++)
					{
						binaryWriter2.Write(eexecRaw[j]);
					}
					for (int k = 0; k < 2; k++)
					{
						if (Class4554.smethod_4(eexecRaw, j, bytes3) || Class4554.smethod_4(eexecRaw, j, bytes4))
						{
							binaryWriter2.Write(eexecRaw[j]);
							j++;
						}
					}
					while (j < eexecRaw.Length)
					{
						StringBuilder stringBuilder = new StringBuilder();
						if (!Class4554.smethod_4(eexecRaw, j, bytes5) && !Class4554.smethod_4(eexecRaw, j, bytes6))
						{
							if (Class4554.smethod_4(eexecRaw, j, bytes7))
							{
								int count = 0;
								for (; !Class4554.smethod_4(eexecRaw, j, bytes8) && !Class4554.smethod_4(eexecRaw, j, bytes9); j++)
								{
									array2[count++] = eexecRaw[j];
									stringBuilder.Append((char)eexecRaw[j]);
								}
								bool flag = smethod_1(stringBuilder.ToString(), @class.UsedGlyphsIndexes);
								for (; !Class4554.smethod_4(eexecRaw, j, bytes10) && !Class4554.smethod_4(eexecRaw, j, bytes11) && !Class4554.smethod_4(eexecRaw, j, bytes12) && !Class4554.smethod_4(eexecRaw, j, bytes13); j++)
								{
									if (flag)
									{
										array2[count++] = eexecRaw[j];
									}
								}
								if (flag)
								{
									array2[count++] = eexecRaw[j];
									array2[count++] = eexecRaw[j + 1];
									array2[count++] = eexecRaw[j + 2];
								}
								j += 3;
								for (int l = 0; l < 2; l++)
								{
									if (Class4554.smethod_4(eexecRaw, j, bytes3) || Class4554.smethod_4(eexecRaw, j, bytes4))
									{
										if (flag)
										{
											array2[count++] = eexecRaw[j];
										}
										j++;
									}
								}
								if (flag)
								{
									binaryWriter2.Write(array2, 0, count);
								}
							}
							else
							{
								j++;
							}
							continue;
						}
						binaryWriter2.Write(eexecRaw, j, eexecRaw.Length - j);
						j += eexecRaw.Length - j;
						break;
					}
				}
				else
				{
					binaryWriter2.Write(eexecRaw[j]);
				}
			}
		}
		@class.Type1FontDictionary.EexecRaw = memoryStream.ToArray();
		Class4728 class2 = new Class4728(Class4728.Enum667.const_0);
		byte[] array3 = new byte[@class.Type1FontDictionary.EexecRaw.Length];
		for (int m = 0; m < @class.Type1FontDictionary.EexecRaw.Length; m++)
		{
			array3[m] = class2.Encrypt(@class.Type1FontDictionary.EexecRaw[m]);
		}
		binaryWriter.Write((byte)128);
		binaryWriter.Write((byte)2);
		binaryWriter.Write((byte)array3.Length);
		binaryWriter.Write((byte)(array3.Length >> 8));
		binaryWriter.Write((byte)(array3.Length >> 16));
		binaryWriter.Write((byte)(array3.Length >> 24));
		binaryWriter.Write(array3);
		for (; num != array.Length - 1 && !Class4554.smethod_4(array, num, bytes14); num++)
		{
		}
		if (Class4554.smethod_4(array, num - 6, checkBytes))
		{
			num -= 6;
		}
		binaryWriter.Write(array, num, array.Length - num);
	}

	private static bool smethod_1(string charStringName, Class4503 glyphIDStringMap)
	{
		foreach (string item in glyphIDStringMap)
		{
			if (charStringName.IndexOf(item) != -1)
			{
				return true;
			}
		}
		return false;
	}
}
