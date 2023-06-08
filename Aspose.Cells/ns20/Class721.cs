using System;
using System.Collections;
using System.IO;
using Aspose.Cells;
using ns13;
using ns2;
using ns27;
using ns57;
using ns59;

namespace ns20;

internal class Class721
{
	private Worksheet worksheet_0;

	private Class982 class982_0;

	private readonly bool bool_0;

	private MemoryStream memoryStream_0;

	private string string_0;

	internal int int_0;

	internal int int_1;

	internal int int_2;

	internal int int_3;

	internal Class933 class933_0 = new Class933();

	internal readonly int int_4;

	internal Class721(Class982 class982_1, int int_5)
	{
		class982_0 = class982_1;
		worksheet_0 = class982_1.class521_0.workbook_0.Worksheets[int_5];
		bool_0 = false;
		int num = -1;
		if (class982_1.class978_0 != null)
		{
			Interface0 @interface = class982_1.class978_0.method_0(worksheet_0);
			if (@interface != null)
			{
				bool_0 = true;
				if (class982_1.string_0 != null)
				{
					string_0 = class982_1.string_0 + "_Cells" + int_5 + ".dat";
					Stream stream = File.Create(string_0);
					Class1725 class1725_ = new Class1725(stream);
					method_1(class1725_, @interface);
					num = (int)stream.Length;
					stream.Close();
				}
				else
				{
					memoryStream_0 = new MemoryStream(1024000);
					Class1725 class1725_2 = new Class1725(memoryStream_0);
					method_1(class1725_2, @interface);
					num = (int)memoryStream_0.Length;
					if ((memoryStream_0.Capacity - num) * 10 > num)
					{
						byte[] array = new byte[num];
						Array.Copy(memoryStream_0.GetBuffer(), array, (int)memoryStream_0.Length);
						memoryStream_0 = new MemoryStream(array, 0, array.Length, writable: false, publiclyVisible: true);
					}
				}
			}
		}
		int_4 = num;
		if (bool_0)
		{
			return;
		}
		RowCollection rows = worksheet_0.Cells.Rows;
		if (rows.Count <= 0)
		{
			return;
		}
		int num2 = -1;
		int num3 = rows.Count - 1;
		while (num3 > -1)
		{
			Row rowByIndex = rows.GetRowByIndex(num3);
			if (rowByIndex.int_0 > 65535)
			{
				num3--;
				continue;
			}
			num2 = rowByIndex.int_0;
			break;
		}
		if (num2 > -1)
		{
			int num4 = num2 / 32 - rows.GetRowByIndex(0).int_0 / 32 + 1;
			for (int i = 0; i < num4; i++)
			{
				class933_0.Add(0);
			}
		}
	}

	internal void method_0(Class1725 class1725_0)
	{
		if (bool_0)
		{
			if (string_0 != null)
			{
				Stream stream = File.OpenRead(string_0);
				Class1321.smethod_3(stream, class1725_0.method_0());
				stream.Close();
				File.Delete(string_0);
			}
			else if (memoryStream_0 != null)
			{
				memoryStream_0.Seek(0L, SeekOrigin.Begin);
				memoryStream_0.WriteTo(class1725_0.method_0());
			}
		}
		else
		{
			method_1(class1725_0, new Class11(worksheet_0));
		}
	}

	private void method_1(Class1725 class1725_0, Interface0 interface0_0)
	{
		class982_0.class521_0.method_0(worksheet_0);
		class933_0.Clear();
		int_1 = 0;
		int_3 = 0;
		Row row = interface0_0.NextRow();
		if (row == null)
		{
			int_0 = 0;
			int_2 = 0;
			return;
		}
		MemoryStream memoryStream = new MemoryStream(128000);
		Class1725 @class = new Class1725(memoryStream);
		MemoryStream memoryStream2 = new MemoryStream(640);
		Class1725 class1725_ = new Class1725(memoryStream2);
		int int_ = (int)class1725_0.method_10();
		int_0 = -1;
		int_2 = -1;
		int index = row.Index;
		int i = index - index % 32 + 31;
		int num = -1;
		int num2 = 0;
		int num3 = 0;
		ArrayList arrayList = new ArrayList();
		Class933 class2 = new Class933();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		do
		{
			worksheet_0.Workbook.method_30();
			bool flag = row.method_27();
			int num4 = row.method_10();
			if (bool_0 && flag && !(row is Class981))
			{
				num4 = class982_0.class978_0.method_3(num4);
			}
			if (num4 >= 4095)
			{
				num4 = 15;
			}
			for (index = row.Index; index > i; i += 32)
			{
				method_2(arrayList3, memoryStream, memoryStream2, class1725_0, int_);
			}
			if (index > 65535)
			{
				break;
			}
			num2 = 0;
			num3 = 0;
			Cell cell = interface0_0.NextCell();
			if (cell != null)
			{
				num2 = cell.Column;
				if (num2 < int_2 || int_2 < 0)
				{
					int_2 = num2;
				}
				do
				{
					worksheet_0.Workbook.method_30();
					Class977 class3 = null;
					num = cell.Column;
					if (num > 255)
					{
						break;
					}
					if (num > num3 && arrayList.Count > 0)
					{
						method_3(@class, arrayList, class2, arrayList2, index, num3);
					}
					double cellValue;
					Enum198 @enum = cell.method_19(out cellValue);
					if (arrayList.Count > 0)
					{
						if (@enum != Enum198.const_2)
						{
							method_3(@class, arrayList, class2, arrayList2, index, num3);
						}
					}
					else if (class2.Count > 0)
					{
						if (@enum != Enum198.const_6)
						{
							method_4(@class, class2, index, num3);
						}
						else if (num - num3 > 3)
						{
							method_4(@class, class2, index, num3);
						}
						else
						{
							for (int j = num3; j < num; j++)
							{
								if (num4 != 15)
								{
									class2.Add(num4);
								}
								else
								{
									class2.Add(class982_0.class521_0.method_1(j));
								}
							}
						}
					}
					int num5 = cell.int_1;
					if (num5 == -1)
					{
						num5 = ((!flag) ? class982_0.class521_0.method_1(num) : num4);
					}
					else if (bool_0 && num5 > 15)
					{
						if (cell is Class977)
						{
							class3 = (Class977)cell;
						}
						else
						{
							num5 = class982_0.class978_0.method_3(num5);
						}
					}
					if (num5 >= 4095)
					{
						num5 = 15;
					}
					switch (@enum)
					{
					case Enum198.const_0:
					case Enum198.const_1:
						@class.method_7(517);
						@class.method_7(8);
						@class.method_6((ushort)index);
						@class.method_7((short)num);
						@class.method_7((short)num5);
						if (@enum == Enum198.const_0)
						{
							@class.WriteByte((byte)cellValue);
							@class.WriteByte(0);
						}
						else
						{
							@class.WriteByte((byte)cellValue);
							@class.WriteByte(1);
						}
						break;
					case Enum198.const_2:
						arrayList.Add(cellValue);
						class2.Add(num5);
						arrayList2.Add(@enum);
						break;
					case Enum198.const_3:
						@class.method_7(515);
						@class.method_7(14);
						@class.method_6((ushort)index);
						@class.method_7((short)num);
						@class.method_7((short)num5);
						@class.method_3(BitConverter.GetBytes(cellValue));
						break;
					case Enum198.const_4:
					{
						Class1655 class4 = (Class1655)cell.object_0;
						if (class4.byte_0 == null)
						{
							break;
						}
						object object_ = class4.object_0;
						Class640 class5 = new Class640(class4.byte_0);
						class5.method_4((ushort)index, (byte)num, (ushort)num5, object_, cell.method_46(), worksheet_0.Workbook.Settings.byte_0, worksheet_0.Workbook.Settings.Date1904);
						class5.vmethod_0(@class);
						if (class4.method_0() != null)
						{
							if (class4.method_0().method_1())
							{
								Class596 class6 = new Class596();
								class6.SetArrayFormula(class4.method_0());
								class6.vmethod_0(@class);
							}
							else
							{
								Class703 class7 = new Class703();
								class7.method_4(class4.method_0());
								class7.vmethod_0(@class);
							}
						}
						else if (class4.method_2() != null)
						{
							Class712 class8 = new Class712(class4.method_2());
							class8.vmethod_0(@class);
						}
						if (object_ == null)
						{
							break;
						}
						string text = null;
						if (object_ is string)
						{
							text = (string)object_;
							if (Class1673.smethod_7(text))
							{
								text = null;
							}
						}
						else if (object_ is Class1719)
						{
							text = ((Class1719)object_).string_0;
						}
						if (text != null)
						{
							Class707 class9 = new Class707(text);
							class9.vmethod_0(@class);
						}
						break;
					}
					case Enum198.const_5:
					{
						@class.method_7(253);
						@class.method_7(10);
						@class.method_6((ushort)index);
						@class.method_7((short)num);
						@class.method_7((short)num5);
						int num6 = (int)cellValue;
						if (num6 < 0)
						{
							num6 = 0;
							if (bool_0)
							{
								if (class3 == null)
								{
									if (cell is Class977)
									{
										class3 = (Class977)cell;
										num6 = class982_0.class978_0.method_6((string)cell.object_0, class3.bool_0);
									}
								}
								else
								{
									num6 = class982_0.class978_0.method_6((string)cell.object_0, class3.bool_0);
								}
							}
						}
						else if (class982_0.class978_0 != null && num6 >= class982_0.class978_0.int_2)
						{
							num6 = class982_0.class978_0.method_5(((Class1719)cell.object_0).string_0);
						}
						@class.method_5(num6);
						break;
					}
					case Enum198.const_6:
						class2.Add(num5);
						break;
					}
					num3 = num;
					num3++;
					cell = interface0_0.NextCell();
				}
				while (cell != null);
				if (arrayList.Count > 0)
				{
					method_3(@class, arrayList, class2, arrayList2, index, num3);
				}
				else if (class2.Count > 0)
				{
					method_4(@class, class2, index, num3);
				}
			}
			Class692 class10 = new Class692();
			if (num4 != row.method_10())
			{
				int num7 = row.method_10();
				row.method_11(num4);
				num4 = num7;
			}
			class10.method_4(row, num2, num3);
			if (arrayList3.Count < 1)
			{
				arrayList3.Add((uint)class1725_0.method_10());
				long position = memoryStream2.Position;
				class10.vmethod_0(class1725_);
				arrayList3.Add((uint)(memoryStream2.Position - position));
				arrayList3.Add(0u);
			}
			else
			{
				class10.vmethod_0(class1725_);
			}
			if (num4 != row.method_10())
			{
				row.method_11(num4);
			}
			if (num3 > 0)
			{
				if (num3 > int_3)
				{
					int_3 = num3;
				}
				if (int_0 < 0)
				{
					int_0 = index;
				}
				int_1 = index;
				arrayList3.Add((uint)memoryStream.Position);
			}
			row = interface0_0.NextRow();
		}
		while (row != null);
		method_2(arrayList3, memoryStream, memoryStream2, class1725_0, int_);
		if (int_0 < 0)
		{
			int_0 = 0;
			int_2 = 0;
		}
		else
		{
			int_1++;
		}
	}

	private void method_2(ArrayList arrayList_0, MemoryStream memoryStream_1, MemoryStream memoryStream_2, Class1725 class1725_0, int int_5)
	{
		if (arrayList_0.Count > 0)
		{
			arrayList_0[1] = (uint)((uint)arrayList_0[1] - memoryStream_2.Position);
			if (memoryStream_1.Length < 1)
			{
				arrayList_0.RemoveRange(2, arrayList_0.Count - 2);
			}
			else
			{
				arrayList_0.RemoveAt(arrayList_0.Count - 1);
			}
			Stream stream = class1725_0.method_0();
			memoryStream_2.WriteTo(stream);
			memoryStream_2.SetLength(0L);
			memoryStream_1.WriteTo(stream);
			memoryStream_1.SetLength(0L);
		}
		class933_0.Add((int)class1725_0.method_10() - int_5);
		Class624 @class = new Class624();
		@class.method_4(arrayList_0);
		@class.vmethod_0(class1725_0);
		arrayList_0.Clear();
	}

	private void method_3(Class1725 class1725_0, ArrayList arrayList_0, Class933 class933_1, ArrayList arrayList_1, int int_5, int int_6)
	{
		int count = arrayList_0.Count;
		int_6 -= count;
		if (count == 1)
		{
			class1725_0.method_7(515);
			class1725_0.method_7(14);
			class1725_0.method_6((ushort)int_5);
			class1725_0.method_7((short)int_6);
			class1725_0.method_7((short)class933_1[0]);
			class1725_0.method_3(BitConverter.GetBytes((double)arrayList_0[0]));
		}
		else
		{
			class1725_0.method_7(189);
			class1725_0.method_7((short)(6 + 6 * count));
			class1725_0.method_6((ushort)int_5);
			class1725_0.method_7((short)int_6);
			for (int i = 0; i < count; i++)
			{
				class1725_0.method_7((short)class933_1[i]);
				class1725_0.method_3(Class657.smethod_0((double)arrayList_0[i]));
				int_6++;
			}
			class1725_0.method_7((short)(int_6 - 1));
		}
		arrayList_0.Clear();
		class933_1.Clear();
		arrayList_1.Clear();
	}

	private void method_4(Class1725 class1725_0, Class933 class933_1, int int_5, int int_6)
	{
		int count = class933_1.Count;
		int_6 -= count;
		if (count == 1)
		{
			class1725_0.method_7(513);
			class1725_0.method_7(6);
			class1725_0.method_6((ushort)int_5);
			class1725_0.method_7((short)int_6);
			class1725_0.method_7((short)class933_1[0]);
		}
		else
		{
			class1725_0.method_7(190);
			class1725_0.method_7((short)(6 + 2 * count));
			class1725_0.method_6((ushort)int_5);
			class1725_0.method_7((short)int_6);
			for (int i = 0; i < count; i++)
			{
				class1725_0.method_7((short)class933_1[i]);
				int_6++;
			}
			class1725_0.method_7((short)(int_6 - 1));
		}
		class933_1.Clear();
	}
}
