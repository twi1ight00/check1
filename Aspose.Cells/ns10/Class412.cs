using System;
using Aspose.Cells;
using ns16;
using ns45;

namespace ns10;

internal class Class412
{
	private Class1218 class1218_0;

	private Workbook workbook_0;

	private Class746 class746_0;

	private Class1547 class1547_0;

	private Class1141 class1141_0;

	private Class1142 class1142_0;

	private int int_0;

	private byte[] byte_0;

	private int int_1;

	private string string_0;

	private Class1212 class1212_0;

	private int int_2;

	internal Class412(Class1218 class1218_1, Class1547 class1547_1, Class1141 class1141_1, string string_1, Class746 class746_1)
	{
		class1218_0 = class1218_1;
		class1547_0 = class1547_1;
		string_0 = string_1;
		class1142_0 = class1547_1.workbook_0.Worksheets.method_89();
		class1141_0 = class1141_1;
		workbook_0 = class1547_1.workbook_0;
		class746_0 = class746_1;
	}

	internal void Read(Class1212 class1212_1)
	{
		int num = 0;
		class1212_0 = class1212_1;
		int num2 = -1;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 34:
				byte_0 = class1218_0.method_0(class1212_0);
				num = 0;
				num2++;
				break;
			case 33:
				method_0();
				int_2++;
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 31:
				byte_0 = class1218_0.method_0(class1212_0);
				if (int_2 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_2]).Length)
				{
					int num4 = 0;
					((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = Class1217.smethod_5(byte_0, ref num4);
					num++;
				}
				break;
			case 26:
				byte_0 = class1218_0.method_0(class1212_0);
				if (int_2 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_2]).Length)
				{
					((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = BitConverter.ToInt32(byte_0, 0);
					num++;
				}
				break;
			case 25:
				byte_0 = class1218_0.method_0(class1212_0);
				if (int_2 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_2]).Length)
				{
					((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = Class1217.smethod_6(byte_0, 0);
					num++;
				}
				break;
			case 24:
				byte_0 = class1218_0.method_0(class1212_0);
				if (int_2 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_2]).Length)
				{
					int num3 = 0;
					((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = Class1217.smethod_5(byte_0, ref num3);
					num++;
				}
				break;
			case 23:
				byte_0 = class1218_0.method_0(class1212_0);
				if (int_2 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_2]).Length)
				{
					switch (byte_0[0])
					{
					case 15:
						((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = "#VALUE!";
						break;
					case 7:
						((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = "#DIV/0!";
						break;
					case 0:
						((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = "#NULL!";
						break;
					case 29:
						((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = "#NAME?";
						break;
					case 23:
						((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = "#REF!";
						break;
					case 42:
						((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = "#N/A";
						break;
					case 36:
						((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = "#NUM!";
						break;
					}
					num++;
				}
				break;
			case 22:
				byte_0 = class1218_0.method_0(class1212_0);
				if (int_2 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_2]).Length)
				{
					((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = byte_0[0] != 0;
					num++;
				}
				break;
			case 21:
				byte_0 = class1218_0.method_0(class1212_0);
				if (int_2 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_2]).Length)
				{
					((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = BitConverter.ToDouble(byte_0, 0);
					num++;
				}
				break;
			case 20:
				byte_0 = class1218_0.method_0(class1212_0);
				if (int_2 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_2]).Length)
				{
					((object[])class1141_0.class1144_0.arrayList_0[num2])[num] = null;
					num++;
				}
				break;
			case 193:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				Class1144 @class = new Class1144(class1141_0, class1141_0.int_3, class1141_0.int_1);
				class1141_0.class1144_0 = @class;
				@class.method_0();
				break;
			}
			case 194:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_0()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		class1141_0.class1144_0.method_2();
		int num = class1141_0.int_1;
		bool[] bool_ = class1141_0.class1144_0.bool_0;
		int i = 0;
		int num2 = 0;
		for (; i < num; i++)
		{
			if (bool_[i])
			{
				int num3 = BitConverter.ToInt32(byte_0, num2);
				if (int_2 < class1141_0.class1144_0.arrayList_0.Count && i < ((object[])class1141_0.class1144_0.arrayList_0[int_2]).Length)
				{
					((object[])class1141_0.class1144_0.arrayList_0[int_2])[i] = num3;
				}
				num2 += 4;
			}
			else
			{
				if (i >= class1141_0.arrayList_0.Count)
				{
					continue;
				}
				Class1161 @class = (Class1161)class1141_0.arrayList_0[i];
				if (int_2 < class1141_0.class1144_0.arrayList_0.Count && i < ((object[])class1141_0.class1144_0.arrayList_0[int_2]).Length)
				{
					if (@class.method_6())
					{
						((object[])class1141_0.class1144_0.arrayList_0[int_2])[i] = BitConverter.ToDouble(byte_0, num2);
						num2 += 8;
					}
					else if (@class.method_14())
					{
						((object[])class1141_0.class1144_0.arrayList_0[int_2])[i] = Class1217.smethod_6(byte_0, num2);
						num2 += 8;
					}
					else
					{
						((object[])class1141_0.class1144_0.arrayList_0[int_2])[i] = Class1217.smethod_5(byte_0, ref num2);
					}
				}
			}
		}
	}
}
