using System;
using System.Collections;
using Aspose.Foundation.sfntly.typography.font.sfntly.table.truetype;
using ns226;
using ns229;

namespace ns231;

internal class Class6030 : Class6027
{
	internal class Class6071 : Class6068
	{
		private ArrayList arrayList_0;

		private ArrayList arrayList_1;

		public static Class6071 smethod_1(Class6110 header, Class6017 data)
		{
			return new Class6071(header, data);
		}

		protected Class6071(Class6110 header, Class6017 data)
			: base(header, data)
		{
		}

		protected Class6071(Class6110 header, Class6016 data)
			: base(header, data)
		{
		}

		public void method_17(ArrayList loca)
		{
			arrayList_1 = new ArrayList(loca);
			method_14(changed: false);
			arrayList_0 = null;
		}

		public ArrayList method_18()
		{
			ArrayList arrayList = new ArrayList(method_20().Count);
			arrayList.Add(0);
			if (method_20().Count == 0)
			{
				arrayList.Add(0);
			}
			else
			{
				int num = 0;
				foreach (Glyph.Class6084 item in method_20())
				{
					int num2 = item.vmethod_4();
					arrayList.Add(num + num2);
					num += num2;
				}
			}
			return arrayList;
		}

		private void method_19(Class6016 data, ArrayList loca)
		{
			arrayList_0 = new ArrayList();
			if (data != null)
			{
				int num = (int)loca[0];
				for (int i = 1; i < loca.Count; i++)
				{
					int num2 = (int)loca[i];
					arrayList_0.Add(Glyph.Class6084.smethod_1(this, data, num, num2 - num));
					num = num2;
				}
			}
		}

		private ArrayList method_20()
		{
			if (arrayList_0 == null)
			{
				if (method_6() != null && arrayList_1 == null)
				{
					throw new InvalidOperationException("Loca values not set - unable to parse glyph data.");
				}
				method_19(method_6(), arrayList_1);
				method_13();
			}
			return arrayList_0;
		}

		public void method_21()
		{
			arrayList_0 = null;
			method_14(changed: false);
		}

		public ArrayList method_22()
		{
			return method_20();
		}

		public void method_23(ArrayList glyphBuilders)
		{
			arrayList_0 = glyphBuilders;
			method_13();
		}

		public Glyph.Class6084 method_24(Class6016 data)
		{
			return Glyph.Class6084.smethod_0(this, data);
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6030(method_16(), data);
		}

		protected override void vmethod_5()
		{
			arrayList_0 = null;
			method_14(changed: false);
		}

		internal override int vmethod_4()
		{
			if (arrayList_0 != null && arrayList_0.Count != 0)
			{
				bool flag = false;
				int num = 0;
				foreach (Glyph.Class6084 item in arrayList_0)
				{
					int num2 = item.vmethod_4();
					num += Math.Abs(num2);
					flag = flag || num2 <= 0;
				}
				if (!flag)
				{
					return num;
				}
				return -num;
			}
			return 0;
		}

		internal override bool vmethod_3()
		{
			if (arrayList_0 == null)
			{
				return false;
			}
			return true;
		}

		internal override int vmethod_2(Class6017 newData)
		{
			int num = 0;
			foreach (Glyph.Class6084 item in arrayList_0)
			{
				num += item.vmethod_2((Class6017)newData.vmethod_1(num));
			}
			return num;
		}
	}

	public enum Enum780
	{
		const_0 = 0,
		const_1 = 2,
		const_2 = 4,
		const_3 = 6,
		const_4 = 8,
		const_5 = 10,
		const_6 = 0,
		const_7 = 2,
		const_8 = 0,
		const_9 = 0,
		const_10 = 2
	}

	private Class6030(Class6110 header, Class6016 data)
		: base(header, data)
	{
	}

	public Glyph method_12(int offset, int length)
	{
		return Glyph.smethod_1(this, class6016_0, offset, length);
	}
}
