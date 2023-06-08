using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns71;

internal static class Class3517
{
	[CompilerGenerated]
	private sealed class Class3518
	{
		public int int_0;

		public void method_0(Class3516 c)
		{
			int_0 += c.Data.Length;
		}
	}

	public static byte[] smethod_0(byte[] byteArray)
	{
		if (byteArray == null)
		{
			throw new ArgumentNullException();
		}
		Class3477 compressedContainer = smethod_6(byteArray);
		return smethod_5(compressedContainer);
	}

	public static byte[] smethod_1(byte[] byteArray)
	{
		if (byteArray != null && byteArray.Length != 0)
		{
			Class3477 @class = new Class3477();
			@class.SignatureByte = 1;
			List<Class3516> list = smethod_4(byteArray);
			foreach (Class3516 item2 in list)
			{
				Class3474 item = smethod_2(item2);
				@class.Chunks.Add(item);
			}
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter writer = new BinaryWriter(memoryStream);
			@class.vmethod_1(writer);
			return memoryStream.ToArray();
		}
		throw new ArgumentNullException();
	}

	private static Class3474 smethod_2(Class3516 decompressedChunk)
	{
		List<Class3481> list = new List<Class3481>();
		int num = 0;
		int decompressedPos = 0;
		while (decompressedPos < decompressedChunk.Data.Length)
		{
			Class3481 @class = new Class3481();
			num++;
			for (int i = 0; i < 8; i++)
			{
				if (decompressedPos >= decompressedChunk.Data.Length)
				{
					break;
				}
				Class3478 class2 = smethod_3(decompressedChunk.Data, ref decompressedPos);
				num++;
				if (class2 is Class3479)
				{
					@class.FlagByte |= (byte)(1 << i);
					num++;
				}
				@class.Tokens.Add(class2);
			}
			list.Add(@class);
		}
		Class3474 class3 = new Class3474();
		Class3476 class5 = (class3.CompressedHeader = new Class3476());
		class5.CompressedChunkFlag = 1;
		class5.CompressedChunkSignature = 3;
		class5.CompressedChunkSize = (uint)num;
		Class3475 class7 = (class3.CompressedData = new Class3475(class5.CompressedChunkSize, compressed: true));
		class7.TokenSequences = list;
		return class3;
	}

	private static Class3478 smethod_3(byte[] data, ref int decompressedPos)
	{
		int num = decompressedPos - 1;
		int num2 = 0;
		int num3 = 0;
		while (num >= 0)
		{
			int num4 = num;
			int i = decompressedPos;
			int num5 = 0;
			for (; i < data.Length && data[i] == data[num4]; i++)
			{
				num5++;
				num4++;
			}
			if (num5 > num2)
			{
				num2 = num5;
				num3 = num;
			}
			num--;
		}
		if (num2 >= 3)
		{
			Class3479 @class = new Class3479();
			int num6 = @class.method_0(num2, decompressedPos - num3, decompressedPos);
			decompressedPos += num6;
			return @class;
		}
		Class3480 class2 = new Class3480();
		class2.Value = data[decompressedPos];
		decompressedPos++;
		return class2;
	}

	private static List<Class3516> smethod_4(byte[] buffer)
	{
		List<Class3516> list = new List<Class3516>();
		int num;
		for (int i = 0; i < buffer.Length; i += num)
		{
			num = ((i + 4096 >= buffer.Length) ? (buffer.Length - i) : 4096);
			byte[] array = new byte[num];
			Buffer.BlockCopy(buffer, i, array, 0, num);
			Class3516 item = new Class3516(array);
			list.Add(item);
		}
		return list;
	}

	private static byte[] smethod_5(Class3477 compressedContainer)
	{
		if (compressedContainer.Chunks.Count == 0)
		{
			throw new InvalidOperationException();
		}
		using MemoryStream memoryStream = new MemoryStream();
		using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
		{
			foreach (Class3474 chunk in compressedContainer.Chunks)
			{
				_ = chunk.CompressedHeader.CompressedChunkSize;
				if (chunk.CompressedHeader.CompressedChunkFlag == 1)
				{
					if (chunk.CompressedData.TokenSequences.Count == 0)
					{
						throw new InvalidOperationException();
					}
					int num = 0;
					foreach (Class3481 tokenSequence in chunk.CompressedData.TokenSequences)
					{
						num++;
						foreach (Class3478 token in tokenSequence.Tokens)
						{
							token.vmethod_2(binaryWriter);
						}
					}
				}
				else
				{
					binaryWriter.Write(chunk.CompressedData.Data);
				}
			}
		}
		return memoryStream.ToArray();
	}

	private static Class3477 smethod_6(byte[] data)
	{
		using MemoryStream input = new MemoryStream(data);
		using BinaryReader reader = new BinaryReader(input);
		Class3477 @class = new Class3477();
		@class.vmethod_0(reader);
		return @class;
	}

	[Conditional("DEBUG")]
	private static void smethod_7(List<Class3516> decompressedChunks, int bufferLength)
	{
		int int_0 = 0;
		decompressedChunks.ForEach(delegate(Class3516 c)
		{
			int_0 += c.Data.Length;
		});
	}
}
