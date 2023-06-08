using System.IO;
using ns218;

namespace ns273;

internal class Class6653
{
	private const int int_0 = 4;

	private const int int_1 = 268435456;

	private const short short_0 = 20556;

	private const int int_2 = 65536;

	private const int int_3 = 131073;

	private const int int_4 = 131074;

	private const byte byte_0 = 80;

	public static byte[] smethod_0(byte[] eotFile)
	{
		if (eotFile != null && eotFile.Length != 0)
		{
			using (MemoryStream input = new MemoryStream(eotFile))
			{
				using BinaryReader binaryReader = new BinaryReader(input);
				int num = binaryReader.ReadInt32();
				if (num != binaryReader.BaseStream.Length)
				{
					return null;
				}
				int num2 = binaryReader.ReadInt32();
				Enum881 @enum = smethod_1(binaryReader.ReadInt32());
				if (@enum == Enum881.const_0)
				{
					return null;
				}
				int curValue = binaryReader.ReadInt32();
				binaryReader.BaseStream.Position += 18L;
				short num3 = binaryReader.ReadInt16();
				if (num3 != 20556)
				{
					return null;
				}
				binaryReader.BaseStream.Position += 46L;
				short num4 = binaryReader.ReadInt16();
				binaryReader.BaseStream.Position += num4 + 2;
				short num5 = binaryReader.ReadInt16();
				binaryReader.BaseStream.Position += num5 + 2;
				short num6 = binaryReader.ReadInt16();
				binaryReader.BaseStream.Position += num6 + 2;
				short num7 = binaryReader.ReadInt16();
				binaryReader.BaseStream.Position += num7;
				if (@enum == Enum881.const_2 || @enum == Enum881.const_3)
				{
					binaryReader.BaseStream.Position += 2L;
					short num8 = binaryReader.ReadInt16();
					binaryReader.BaseStream.Position += num8;
					if (@enum == Enum881.const_3)
					{
						binaryReader.BaseStream.Position += 10L;
						short num9 = binaryReader.ReadInt16();
						binaryReader.BaseStream.Position += num9;
						binaryReader.BaseStream.Position += 4L;
						int num10 = binaryReader.ReadInt32();
						binaryReader.BaseStream.Position += num10;
					}
				}
				if (binaryReader.BaseStream.Position + num2 != binaryReader.BaseStream.Length)
				{
					return null;
				}
				if (Class5952.smethod_5(curValue, 4))
				{
					return null;
				}
				byte[] array = binaryReader.ReadBytes(num2);
				if (Class5952.smethod_5(curValue, 268435456))
				{
					smethod_2(array);
				}
				return array;
			}
		}
		return null;
	}

	private static Enum881 smethod_1(int version)
	{
		return version switch
		{
			131073 => Enum881.const_2, 
			131074 => Enum881.const_3, 
			65536 => Enum881.const_1, 
			_ => Enum881.const_0, 
		};
	}

	private static void smethod_2(byte[] fontData)
	{
		for (int i = 0; i < fontData.Length; i++)
		{
			fontData[i] = (byte)(fontData[i] ^ 0x50u);
		}
	}
}
