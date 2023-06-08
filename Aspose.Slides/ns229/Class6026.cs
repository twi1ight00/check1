using System.Text;
using ns226;
using ns227;
using ns230;
using ns231;

namespace ns229;

internal class Class6026 : Class6025
{
	internal abstract class Class6055 : Class6054
	{
		private Class6110 class6110_0;

		protected Class6055(Class6110 header, Class6017 data)
			: base(data)
		{
			class6110_0 = header;
		}

		protected Class6055(Class6110 header, Class6016 data)
			: base(data)
		{
			class6110_0 = header;
		}

		protected Class6055(Class6110 header)
			: this(header, null)
		{
		}

		public string method_15()
		{
			return "Table Builder for - " + class6110_0.method_7();
		}

		public Class6110 method_16()
		{
			return class6110_0;
		}

		protected override void vmethod_1(Class6025 table)
		{
			if (method_10() || method_9())
			{
				Class6110 @class = new Class6110(method_16().method_0(), table.method_2());
				((Class6026)table).class6110_0 = @class;
			}
		}

		public static Class6055 smethod_0(Class6110 header, Class6017 tableData)
		{
			int num = header.method_0();
			if (num == Class6116.int_1)
			{
				return Class6028.Class6069.smethod_1(header, tableData);
			}
			if (num == Class6116.int_2)
			{
				return Class6031.Class6060.smethod_1(header, tableData);
			}
			if (num == Class6116.int_3)
			{
				return Class6033.Class6062.smethod_1(header, tableData);
			}
			if (num == Class6116.int_4)
			{
				return Class6034.Class6063.smethod_1(header, tableData);
			}
			if (num == Class6116.int_5)
			{
				return Class6035.Class6064.smethod_1(header, tableData);
			}
			if (num == Class6116.int_6)
			{
				return Class6029.Class6070.smethod_1(header, tableData);
			}
			if (num == Class6116.int_7)
			{
				return Class6036.Class6065.smethod_1(header, tableData);
			}
			if (num == Class6116.int_8)
			{
				return Class6037.Class6066.smethod_1(header, tableData);
			}
			if (num == Class6116.int_9)
			{
				return Class6039.Class6059.smethod_1(header, tableData);
			}
			if (num == Class6116.int_11)
			{
				return Class6030.Class6071.smethod_1(header, tableData);
			}
			if (num == Class6116.int_12)
			{
				return Class6040.Class6072.smethod_1(header, tableData);
			}
			if (num == Class6116.int_13)
			{
				return Class6038.Class6058.smethod_1(header, tableData);
			}
			if (num != Class6116.int_16 && num != Class6116.int_17 && num != Class6116.int_18)
			{
				if (num == Class6116.int_26)
				{
					return Class6032.Class6061.smethod_1(header, tableData);
				}
				if (num == Class6116.int_45)
				{
					return Class6031.Class6060.smethod_1(header, tableData);
				}
				if (num == Class6116.int_46)
				{
				}
			}
			return Class6067.smethod_1(header, tableData);
		}
	}

	protected Class6110 class6110_0;

	internal Class6026(Class6110 header, Class6016 data)
		: base(data)
	{
		class6110_0 = header;
	}

	public long method_5()
	{
		return class6016_0.method_8();
	}

	public Class6110 method_6()
	{
		return class6110_0;
	}

	public int method_7()
	{
		return method_6().method_0();
	}

	public int method_8()
	{
		return method_6().method_1();
	}

	public int method_9()
	{
		return method_6().method_3();
	}

	public long method_10()
	{
		return method_6().method_5();
	}

	public string method_11()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		stringBuilder.Append(Class6116.smethod_3(class6110_0.method_0()));
		stringBuilder.Append(", cs=0x");
		stringBuilder.Append($"{class6110_0.method_5():x}");
		stringBuilder.Append(", offset=0x");
		stringBuilder.Append($"{class6110_0.method_1():x}");
		stringBuilder.Append(", size=0x");
		stringBuilder.Append($"{class6110_0.method_3():x}");
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}
}
