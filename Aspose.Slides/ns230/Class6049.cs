using System;
using System.Collections;
using ns225;
using ns226;
using ns228;
using ns229;

namespace ns230;

internal class Class6049 : Class6042
{
	internal class Class6081 : Class6074
	{
		internal class Class6093
		{
			private int int_0;

			private int int_1;

			private int int_2;

			private int int_3;

			public static ArrayList smethod_0(ArrayList original)
			{
				ArrayList arrayList = new ArrayList(original.Count);
				foreach (Class6093 item in original)
				{
					arrayList.Add(new Class6093(item));
				}
				return arrayList;
			}

			public Class6093()
			{
			}

			public Class6093(Class6093 other)
				: this(other.int_0, other.int_1, other.int_2, other.int_3)
			{
			}

			public Class6093(int startCount, int endCount, int idDelta, int idRangeOffset)
			{
				int_0 = startCount;
				int_1 = endCount;
				int_2 = idDelta;
				int_3 = idRangeOffset;
			}

			public int method_0()
			{
				return int_0;
			}

			public void method_1(int startCount)
			{
				int_0 = startCount;
			}

			public int method_2()
			{
				return int_1;
			}

			public void method_3(int endCount)
			{
				int_1 = endCount;
			}

			public int method_4()
			{
				return int_2;
			}

			public void method_5(int idDelta)
			{
				int_2 = idDelta;
			}

			public int method_6()
			{
				return int_3;
			}

			public void method_7(int idRangeOffset)
			{
				int_3 = idRangeOffset;
			}

			public string method_8()
			{
				return $"[{int_0,10:X} - {int_1,10:X}, delta = {int_2,10:X}, rangeOffset = {int_3,10:X}";
			}
		}

		private ArrayList arrayList_0;

		private ArrayList arrayList_1;

		internal Class6081(Class6017 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6017)data.vmethod_0(offset, data.method_16(offset + 2))), Enum756.const_2, cmapId)
		{
		}

		internal Class6081(Class6016 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6016)data.vmethod_0(offset, data.method_16(offset + 2))), Enum756.const_2, cmapId)
		{
		}

		private void Initialize(Class6016 data)
		{
			arrayList_0 = new ArrayList();
			arrayList_1 = new ArrayList();
			if (data != null && data.method_2() != 0)
			{
				int num = Class6049.smethod_1(data);
				for (int i = 0; i < num; i++)
				{
					Class6093 @class = new Class6093();
					@class.method_1(smethod_2(data, num, i));
					@class.method_3(smethod_4(data, num, i));
					@class.method_5(smethod_5(data, num, i));
					@class.method_7(smethod_7(data, num, i));
					arrayList_0.Add(@class);
				}
				int num2 = Class6049.smethod_0(data) - smethod_9(num);
				for (int j = 0; j < num2; j += 2)
				{
					arrayList_1.Add(data.method_16(j + smethod_9(num)));
				}
			}
		}

		public ArrayList method_23()
		{
			if (arrayList_0 == null)
			{
				Initialize(method_6());
				method_13();
			}
			return arrayList_0;
		}

		public void method_24(ArrayList segments)
		{
			arrayList_0 = Class6093.smethod_0(segments);
			method_13();
		}

		public ArrayList method_25()
		{
			if (arrayList_1 == null)
			{
				Initialize(method_6());
				method_13();
			}
			return arrayList_1;
		}

		public void method_26(ArrayList glyphIdArray)
		{
			arrayList_1 = new ArrayList(glyphIdArray);
			method_13();
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6049(data, method_16());
		}

		protected override void vmethod_5()
		{
			arrayList_0 = null;
			arrayList_1 = null;
			method_14(changed: false);
		}

		internal override int vmethod_4()
		{
			if (!method_10())
			{
				return base.vmethod_4();
			}
			return 16 + arrayList_0.Count * 8 + arrayList_1.Count * 2;
		}

		internal override bool vmethod_3()
		{
			if (!method_10())
			{
				return base.vmethod_3();
			}
			if (arrayList_0 != null)
			{
				return true;
			}
			return false;
		}

		internal override int vmethod_2(Class6017 newData)
		{
			if (!method_10())
			{
				return base.vmethod_2(newData);
			}
			int num = 0;
			num = 0 + newData.method_37(0, 4);
			num += 2;
			num += newData.method_37(num, method_20());
			int count = arrayList_0.Count;
			num += newData.method_37(num, count * 2);
			int num2 = Class6024.smethod_0(arrayList_0.Count);
			int num3 = 1 << num2 + 1;
			num += newData.method_37(num, num3);
			int us = num2;
			num += newData.method_37(num, us);
			int us2 = 2 * count - num3;
			num += newData.method_37(num, us2);
			for (int i = 0; i < count; i++)
			{
				num += newData.method_37(num, ((Class6093)arrayList_0[i]).method_2());
			}
			num += 2;
			for (int j = 0; j < count; j++)
			{
				num += newData.method_37(num, ((Class6093)arrayList_0[j]).method_0());
			}
			for (int k = 0; k < count; k++)
			{
				num += newData.method_39(num, ((Class6093)arrayList_0[k]).method_4());
			}
			for (int l = 0; l < count; l++)
			{
				num += newData.method_37(num, ((Class6093)arrayList_0[l]).method_6());
			}
			for (int m = 0; m < arrayList_1.Count; m++)
			{
				num += newData.method_37(num, (int)arrayList_1[m]);
			}
			newData.method_37(2, num);
			return num;
		}
	}

	internal class Class6092 : Interface256
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private bool bool_0;

		private Class6049 class6049_0;

		public Class6092(Class6049 owner)
		{
			int_0 = 0;
			int_1 = -1;
			class6049_0 = owner;
		}

		public bool imethod_0()
		{
			if (bool_0)
			{
				return true;
			}
			while (true)
			{
				if (int_0 < class6049_0.int_2)
				{
					if (int_1 >= 0)
					{
						if (int_3 < int_2)
						{
							break;
						}
						int_0++;
						int_1 = -1;
						continue;
					}
					int_1 = class6049_0.method_13(int_0);
					int_2 = class6049_0.method_14(int_0);
					int_3 = int_1;
					bool_0 = true;
					return true;
				}
				return false;
			}
			int_3++;
			bool_0 = true;
			return true;
		}

		public object imethod_1()
		{
			if (!bool_0 && !imethod_0())
			{
				throw new InvalidOperationException("No more characters to iterate.");
			}
			bool_0 = false;
			return int_3;
		}

		public void Remove()
		{
			throw new NotSupportedException("Unable to remove a character from cmap.");
		}
	}

	private int int_2;

	private int int_3;

	protected Class6049(Class6016 data, Class6028.Class6096 cmapId)
		: base(data, 4, cmapId)
	{
		int_2 = class6016_0.method_16(6) / 2;
		int_3 = smethod_9(int_2);
	}

	public override int vmethod_2(int character)
	{
		int num = class6016_0.method_28(smethod_3(int_2), 2, 14, 2, int_2, character);
		if (num == -1)
		{
			return Class6028.int_0;
		}
		int startCode = method_13(num);
		return method_11(num, startCode, character);
	}

	public int method_11(int segment, int startCode, int character)
	{
		if (character < startCode)
		{
			return Class6028.int_0;
		}
		int num = method_17(segment);
		if (num == 0)
		{
			return (character + method_16(segment)) % 65536;
		}
		return class6016_0.method_16(num + method_18(segment) + 2 * (character - startCode));
	}

	public int method_12()
	{
		return int_2;
	}

	public int method_13(int segment)
	{
		method_15(segment);
		return smethod_2(class6016_0, int_2, segment);
	}

	private static int smethod_0(Class6016 data)
	{
		return data.method_16(2);
	}

	private static int smethod_1(Class6016 data)
	{
		return data.method_16(6) / 2;
	}

	private static int smethod_2(Class6016 data, int segCount, int index)
	{
		return data.method_16(smethod_3(segCount) + index * 2);
	}

	private static int smethod_3(int segCount)
	{
		return 16 + segCount * 2;
	}

	private static int smethod_4(Class6016 data, int segCount, int index)
	{
		return data.method_16(14 + index * 2);
	}

	private static int smethod_5(Class6016 data, int segCount, int index)
	{
		return data.method_17(smethod_6(segCount) + index * 2);
	}

	private static int smethod_6(int segCount)
	{
		return 14 + (2 * segCount + 1) * 2;
	}

	private static int smethod_7(Class6016 data, int segCount, int index)
	{
		return data.method_16(smethod_8(segCount) + index * 2);
	}

	private static int smethod_8(int segCount)
	{
		return 14 + (2 * segCount + 1) * 2 + segCount * 2;
	}

	private static int smethod_9(int segCount)
	{
		return 14 + (3 * segCount + 1) * 2 + segCount * 2;
	}

	public int method_14(int segment)
	{
		method_15(segment);
		return smethod_4(class6016_0, int_2, segment);
	}

	private void method_15(int segment)
	{
		if (segment < 0 || segment >= int_2)
		{
			throw new InvalidOperationException();
		}
	}

	public int method_16(int segment)
	{
		method_15(segment);
		return smethod_5(class6016_0, int_2, segment);
	}

	public int method_17(int segment)
	{
		method_15(segment);
		return class6016_0.method_16(method_18(segment));
	}

	public int method_18(int segment)
	{
		method_15(segment);
		return smethod_8(int_2) + segment * 2;
	}

	private int method_19(int index)
	{
		return class6016_0.method_16(int_3 + index * 2);
	}

	public override int vmethod_1()
	{
		return class6016_0.method_16(4);
	}

	public override Interface256 imethod_0()
	{
		return new Class6092(this);
	}
}
