using System;
using System.Collections;
using ns225;
using ns226;
using ns229;
using ns230;

namespace ns231;

internal class Class6040 : Class6026
{
	internal class Class6072 : Class6055
	{
		private Class6031.Enum762 enum762_0 = Class6031.Enum762.const_1;

		private int int_0 = -1;

		private ArrayList arrayList_0;

		public static Class6072 smethod_1(Class6110 header, Class6017 data)
		{
			return new Class6072(header, data);
		}

		private Class6072(Class6110 header, Class6017 data)
			: base(header, data)
		{
		}

		private Class6072(Class6110 header, Class6016 data)
			: base(header, data)
		{
		}

		private void method_17(Class6016 data)
		{
			method_21(nullify: false);
			if (arrayList_0 == null)
			{
				arrayList_0 = new ArrayList();
			}
			if (data != null)
			{
				if (int_0 < 0)
				{
					throw new InvalidOperationException("numglyphs not set on LocaTable Builder.");
				}
				Class6040 @class = new Class6040(method_16(), data, enum762_0, int_0);
				Interface256 @interface = @class.method_18();
				while (@interface.imethod_0())
				{
					arrayList_0.Add(@interface.imethod_1());
				}
			}
		}

		private int method_18(int glyphId)
		{
			if (glyphId < 0 || glyphId > method_19())
			{
				throw new IndexOutOfRangeException("Glyph ID is outside of the allowed range.");
			}
			return glyphId;
		}

		private int method_19()
		{
			if (arrayList_0 == null)
			{
				return int_0 - 1;
			}
			return arrayList_0.Count - 2;
		}

		private ArrayList method_20()
		{
			if (arrayList_0 == null)
			{
				method_17(method_6());
				method_13();
			}
			return arrayList_0;
		}

		private void method_21(bool nullify)
		{
			if (arrayList_0 != null)
			{
				arrayList_0.Clear();
			}
			if (nullify)
			{
				arrayList_0 = null;
			}
			method_14(changed: false);
		}

		public Class6031.Enum762 method_22()
		{
			return enum762_0;
		}

		public void method_23(Class6031.Enum762 formatVersion)
		{
			enum762_0 = formatVersion;
		}

		public ArrayList method_24()
		{
			return method_20();
		}

		public void method_25(ArrayList list)
		{
			arrayList_0 = list;
			method_13();
		}

		public int method_26(int glyphId)
		{
			method_18(glyphId);
			return (int)method_20()[glyphId];
		}

		public int method_27(int glyphId)
		{
			method_18(glyphId);
			return (int)method_20()[glyphId + 1] - (int)method_20()[glyphId];
		}

		public void method_28(int numGlyphs)
		{
			int_0 = numGlyphs;
		}

		public int method_29()
		{
			return method_19() + 1;
		}

		public void method_30()
		{
			arrayList_0 = null;
			method_14(changed: false);
		}

		public int method_31()
		{
			return method_20().Count;
		}

		public int method_32(int index)
		{
			return (int)method_20()[index];
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6040(method_16(), data, enum762_0, int_0);
		}

		protected override void vmethod_5()
		{
			method_17(method_6());
		}

		internal override int vmethod_4()
		{
			if (arrayList_0 == null)
			{
				return 0;
			}
			if (enum762_0 == Class6031.Enum762.const_1)
			{
				return arrayList_0.Count * 4;
			}
			return arrayList_0.Count * 2;
		}

		internal override bool vmethod_3()
		{
			return arrayList_0 != null;
		}

		internal override int vmethod_2(Class6017 newData)
		{
			int num = 0;
			foreach (int item in arrayList_0)
			{
				num = ((enum762_0 != Class6031.Enum762.const_1) ? (num + newData.method_37(num, item / 2)) : (num + newData.method_41(num, item)));
			}
			int_0 = arrayList_0.Count - 1;
			return num;
		}
	}

	private class Class6115 : Interface256
	{
		private int int_0;

		private Class6040 class6040_0;

		public Class6115(Class6040 owner)
		{
			class6040_0 = owner;
		}

		public bool imethod_0()
		{
			if (int_0 <= class6040_0.int_0)
			{
				return true;
			}
			return false;
		}

		public object imethod_1()
		{
			return class6040_0.method_17(int_0++);
		}

		public void Remove()
		{
			throw new NotSupportedException();
		}
	}

	private Class6031.Enum762 enum762_0;

	private int int_0;

	private Class6040(Class6110 header, Class6016 data, Class6031.Enum762 version, int numGlyphs)
		: base(header, data)
	{
		enum762_0 = version;
		int_0 = numGlyphs;
	}

	public Class6031.Enum762 method_12()
	{
		return enum762_0;
	}

	public int method_13()
	{
		return int_0;
	}

	public int method_14(int glyphId)
	{
		if (glyphId < 0 || glyphId >= int_0)
		{
			throw new IndexOutOfRangeException("Glyph ID is out of bounds.");
		}
		return method_17(glyphId);
	}

	public int method_15(int glyphId)
	{
		if (glyphId < 0 || glyphId >= int_0)
		{
			throw new IndexOutOfRangeException("Glyph ID is out of bounds.");
		}
		return method_17(glyphId + 1) - method_17(glyphId);
	}

	public int method_16()
	{
		return int_0 + 1;
	}

	public int method_17(int index)
	{
		if (index > int_0)
		{
			throw new IndexOutOfRangeException();
		}
		if (enum762_0 == Class6031.Enum762.const_0)
		{
			return 2 * class6016_0.method_16(index * 2);
		}
		return class6016_0.method_20(index * 4);
	}

	public Interface256 method_18()
	{
		return new Class6115(this);
	}
}
