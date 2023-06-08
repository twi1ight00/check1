using System.Collections.Generic;
using System.IO;

namespace ns235;

internal class Class6265
{
	public class Class6267
	{
		private int[] int_0;

		private int[] int_1;

		private int[] int_2;

		private int[] int_3;

		private Class6265 class6265_0;

		public Class6267(Class6265 indices)
		{
			class6265_0 = indices;
			int_0 = new int[indices.byte_0.Length];
			int_1 = new int[indices.byte_0.Length];
			int_2 = new int[indices.byte_0.Length];
			int_3 = new int[indices.byte_0.Length];
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < indices.byte_0.Length; i++)
			{
				byte b = indices.byte_0[i];
				if ((b & 1) == 1)
				{
					int_0[i] = num;
					num++;
				}
				else
				{
					int_0[i] = -1;
				}
				if ((b & 2) == 2)
				{
					int_1[i] = num2;
					num2++;
				}
				else
				{
					int_1[i] = -1;
				}
				if ((b & 4) == 4)
				{
					int_2[i] = num3;
					num3++;
				}
				else
				{
					int_2[i] = -1;
				}
				if ((b & 8) == 8)
				{
					int_3[i] = num4;
					num4++;
				}
				else
				{
					int_3[i] = -1;
				}
			}
		}

		public int method_0()
		{
			return class6265_0.byte_0.Length;
		}

		public float method_1(int index)
		{
			if (int_0[index] == -1)
			{
				return -1f;
			}
			return class6265_0.float_0[int_0[index]];
		}

		public float method_2(int index)
		{
			if (int_1[index] == -1)
			{
				return 0f;
			}
			return class6265_0.float_1[int_1[index]];
		}

		public float method_3(int index)
		{
			if (int_2[index] == -1)
			{
				return 0f;
			}
			return class6265_0.float_2[int_2[index]];
		}

		public Class6266 method_4(int index)
		{
			if (int_3[index] == -1)
			{
				return null;
			}
			return class6265_0.class6266_0[int_3[index]];
		}
	}

	public class Class6266
	{
		private int int_0 = 1;

		private int int_1 = 1;

		private int int_2;

		public int ClusterCodeUnitCount
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		public int CusterGlyphCount
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		public int GlyphIndex
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}
	}

	public class Class6269
	{
		private List<float> list_0 = new List<float>();

		private List<float> list_1 = new List<float>();

		private List<float> list_2 = new List<float>();

		private List<Class6266> list_3 = new List<Class6266>();

		private List<byte> list_4 = new List<byte>();

		public List<Class6266> GlyphsMappings => list_3;

		public List<float> AdvanceWidths => list_0;

		public List<float> UOffsets => list_1;

		public List<float> VOffsets => list_2;

		public List<byte> IndicesMap => list_4;

		public void method_0(float advanceWidth)
		{
			method_1(null, advanceWidth, 0f, 0f);
		}

		public void method_1(Class6266 glyphsMapping, float advanceWidth, float uOffset, float vOffset)
		{
			byte b = 0;
			if (advanceWidth > 0f)
			{
				list_0.Add(advanceWidth);
				b = (byte)(b | 1u);
			}
			if (uOffset != 0f)
			{
				list_1.Add(uOffset);
				b = (byte)(b | 2u);
			}
			if (vOffset != 0f)
			{
				list_2.Add(vOffset);
				b = (byte)(b | 4u);
			}
			if (glyphsMapping != null)
			{
				list_3.Add(glyphsMapping);
				b = (byte)(b | 8u);
			}
			list_4.Add(b);
		}

		public Class6265 method_2()
		{
			return new Class6265(this);
		}
	}

	private float[] float_0;

	private float[] float_1;

	private float[] float_2;

	private Class6266[] class6266_0;

	private byte[] byte_0;

	public Class6265()
	{
	}

	private Class6265(Class6269 maker)
	{
		float_0 = maker.AdvanceWidths.ToArray();
		float_1 = maker.UOffsets.ToArray();
		float_2 = maker.VOffsets.ToArray();
		class6266_0 = maker.GlyphsMappings.ToArray();
		byte_0 = maker.IndicesMap.ToArray();
	}

	private static void smethod_0(float[] array, BinaryWriter writer)
	{
		if (array != null)
		{
			writer.Write(array.Length);
			foreach (float value in array)
			{
				writer.Write(value);
			}
		}
		else
		{
			writer.Write(0);
		}
	}

	private static void smethod_1(out float[] array, BinaryReader reader)
	{
		array = null;
		int num = reader.ReadInt32();
		if (num != 0)
		{
			array = new float[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = reader.ReadSingle();
			}
		}
	}

	public void method_0(Stream stream)
	{
		BinaryWriter binaryWriter = new BinaryWriter(stream);
		smethod_0(float_0, binaryWriter);
		smethod_0(float_1, binaryWriter);
		smethod_0(float_2, binaryWriter);
		if (class6266_0 != null)
		{
			binaryWriter.Write(class6266_0.Length);
			Class6266[] array = class6266_0;
			foreach (Class6266 @class in array)
			{
				binaryWriter.Write(@class.ClusterCodeUnitCount);
				binaryWriter.Write(@class.CusterGlyphCount);
				binaryWriter.Write(@class.GlyphIndex);
			}
		}
		else
		{
			binaryWriter.Write(0);
		}
		if (byte_0 != null)
		{
			binaryWriter.Write(byte_0.Length);
			binaryWriter.Write(byte_0);
		}
		else
		{
			binaryWriter.Write(0);
		}
	}

	public bool method_1()
	{
		return byte_0 == null;
	}

	public void method_2(Stream stream)
	{
		BinaryReader binaryReader = new BinaryReader(stream);
		smethod_1(out float_0, binaryReader);
		smethod_1(out float_1, binaryReader);
		smethod_1(out float_2, binaryReader);
		int num = binaryReader.ReadInt32();
		if (num != 0)
		{
			class6266_0 = new Class6266[num];
			for (int i = 0; i < num; i++)
			{
				Class6266 @class = new Class6266();
				@class.ClusterCodeUnitCount = binaryReader.ReadInt32();
				@class.CusterGlyphCount = binaryReader.ReadInt32();
				@class.GlyphIndex = binaryReader.ReadInt32();
				class6266_0[i] = @class;
			}
		}
		num = binaryReader.ReadInt32();
		if (num != 0)
		{
			byte_0 = binaryReader.ReadBytes(num);
		}
	}
}
