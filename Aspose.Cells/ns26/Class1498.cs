using System.Collections;
using Aspose.Cells;
using ns15;
using ns2;
using ns44;

namespace ns26;

internal class Class1498
{
	internal Workbook workbook_0;

	internal ArrayList arrayList_0;

	internal ArrayList arrayList_1;

	internal ArrayList arrayList_2;

	internal ArrayList arrayList_3;

	internal ArrayList arrayList_4;

	internal ArrayList arrayList_5;

	internal Enum214[] enum214_0;

	internal Hashtable hashtable_0;

	private string[] string_0;

	internal Hashtable hashtable_1;

	internal ArrayList arrayList_6;

	private Class1666 class1666_0;

	internal Class1498(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		arrayList_0 = new ArrayList();
		arrayList_4 = new ArrayList();
		arrayList_2 = new ArrayList();
		arrayList_3 = new ArrayList();
		arrayList_4 = new ArrayList();
		arrayList_5 = new ArrayList();
		arrayList_1 = new ArrayList();
		hashtable_0 = new Hashtable();
		string_0 = new string[workbook_0.Worksheets.Count];
		hashtable_1 = new Hashtable();
		arrayList_6 = new ArrayList();
		class1666_0 = new Class1666(workbook_0.Worksheets);
	}

	public string method_0(Cell cell_0)
	{
		byte[] array = cell_0.method_41();
		if (array == null)
		{
			return cell_0.method_17().string_0;
		}
		if (workbook_0.Worksheets.Formula.method_13(1, array))
		{
			workbook_0.Worksheets.Formula.method_14(array, out var row, out var column);
			Cell cell = cell_0.method_4()[row, column];
			if (cell.method_50() != null)
			{
				return class1666_0.method_1(-1, -1, cell.method_50().Formula, cell_0.Row, cell_0.Column, !cell.method_50().method_1());
			}
			return null;
		}
		return class1666_0.method_0(-1, array, cell_0.Row, cell_0.Column, bool_0: false);
	}

	internal void method_1()
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			workbook_0.Worksheets[i].method_7(string_0[i]);
		}
		ICollection keys = hashtable_1.Keys;
		foreach (int item in keys)
		{
			workbook_0.Worksheets.Names[item].method_17((string)hashtable_1[item]);
		}
	}

	internal void method_2()
	{
		object[] array = Class1516.smethod_31(workbook_0);
		for (int i = 0; i < workbook_0.Worksheets.Count; i++)
		{
			Worksheet worksheet = workbook_0.Worksheets[i];
			string_0[i] = worksheet.Name;
			Class1499 @class = new Class1499(this, worksheet);
			@class.method_3(this);
			arrayList_5.Add(@class);
		}
		method_3();
		method_5((ArrayList)array[2]);
		method_6((ArrayList)array[0]);
		method_7((Class1683)array[1]);
	}

	private void method_3()
	{
		NameCollection names = workbook_0.Worksheets.Names;
		for (int i = 0; i < names.Count; i++)
		{
			Name name = names[i];
			if (name.SheetIndex != 0)
			{
				hashtable_1.Add(i, name.Text);
				name.method_17(name.Text + "_" + name.SheetIndex);
			}
		}
	}

	private void method_4(int int_0)
	{
		Class1502 @class = new Class1502();
		arrayList_3.Add(@class);
		@class.string_0 = "N" + int_0;
		@class.enum214_0 = Enum214.const_1;
		Class1506 class2 = new Class1506(Enum213.const_4, null);
		@class.arrayList_1.Add(class2);
		class2.arrayList_0.Add(new string[2] { "min-integer-digits", "1" });
	}

	internal void method_5(ArrayList arrayList_7)
	{
		method_4(0);
		for (int i = 0; i < arrayList_7.Count; i++)
		{
			Struct79 @struct = (Struct79)arrayList_7[i];
			int int_ = @struct.int_0;
			string text = @struct.string_0;
			if (Class1516.smethod_0(text) && int_ > 0)
			{
				text = Class1682.smethod_0(int_);
			}
			if (!Class1516.smethod_0(text))
			{
				if (text.IndexOf("General") != -1)
				{
					method_4(int_);
					continue;
				}
				string[] array = Class1516.smethod_19(text);
				if (array.Length > 1)
				{
					Class1502 @class = null;
					for (int j = 0; j < array.Length; j++)
					{
						string string_ = ((j == array.Length - 1) ? ("N" + int_) : ("N" + int_ + "P" + j));
						@class = new Class1502();
						@class.method_0(string_, int_, array[j]);
						if (j != array.Length - 1)
						{
							@class.arrayList_0.Add(new string[2] { "style:volatile", "true" });
						}
						arrayList_3.Add(@class);
					}
					@class.method_2(array.Length);
				}
				else
				{
					Class1502 class2 = new Class1502();
					class2.method_0("N" + int_, int_, text);
					arrayList_3.Add(class2);
				}
			}
			else if (int_ > 0)
			{
				Class1502 class3 = new Class1502();
				class3.method_1(int_);
				arrayList_3.Add(class3);
			}
		}
	}

	internal void method_6(ArrayList arrayList_7)
	{
		for (int i = 0; i < arrayList_7.Count; i++)
		{
			Font font_ = (Font)arrayList_7[i];
			bool flag = false;
			for (int j = 0; j < arrayList_0.Count; j++)
			{
				Class1500 @class = (Class1500)arrayList_0[j];
				if (@class.Equals(font_))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				arrayList_0.Add(new Class1500(font_));
			}
		}
	}

	internal void method_7(Class1683 class1683_0)
	{
		Hashtable hashtable = new Hashtable();
		for (int num = arrayList_3.Count - 1; num >= 0; num--)
		{
			Class1502 @class = (Class1502)arrayList_3[num];
			if (@class.bool_1)
			{
				int int_ = @class.int_0;
				num--;
				while (num >= 0)
				{
					Class1502 class2 = (Class1502)arrayList_3[num];
					if (class2.int_0 == int_)
					{
						switch (class2.enum214_0)
						{
						default:
							hashtable[@class.int_0] = class2.enum214_0;
							break;
						case Enum214.const_2:
						case Enum214.const_3:
							switch (@class.enum214_0)
							{
							default:
								hashtable[@class.int_0] = class2.enum214_0;
								break;
							case Enum214.const_5:
							case Enum214.const_7:
								hashtable[@class.int_0] = Enum214.const_1;
								break;
							}
							break;
						}
						num--;
						continue;
					}
					num++;
					break;
				}
			}
			else
			{
				hashtable[@class.int_0] = @class.enum214_0;
			}
		}
		enum214_0 = new Enum214[class1683_0.Count];
		for (int i = 0; i < class1683_0.Count; i++)
		{
			Style style = class1683_0[i];
			arrayList_4.Add(new Class1496(style, i));
			object obj = hashtable[style.method_44()];
			if (obj == null)
			{
				enum214_0[i] = Enum214.const_7;
			}
			else
			{
				enum214_0[i] = (Enum214)obj;
			}
		}
	}
}
