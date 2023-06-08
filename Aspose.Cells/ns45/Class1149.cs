using System;
using System.Collections;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Pivot;
using Aspose.Cells.Tables;
using ns16;
using ns2;
using ns58;

namespace ns45;

internal class Class1149
{
	private PivotTable pivotTable_0;

	private Cells cells_0;

	private Class1154 class1154_0;

	private Class1154 class1154_1;

	internal ArrayList arrayList_0;

	private int[][] int_0;

	private bool[] bool_0;

	private PivotFieldType pivotFieldType_0;

	private int int_1;

	private bool bool_1;

	private bool[] bool_2;

	private bool[] bool_3;

	private bool bool_4;

	private bool bool_5;

	internal bool bool_6;

	internal bool bool_7;

	internal bool bool_8;

	private int int_2 = 1;

	private int int_3;

	private int int_4;

	private Hashtable hashtable_0 = new Hashtable();

	private ArrayList arrayList_1 = new ArrayList();

	private Hashtable hashtable_1 = new Hashtable();

	internal static int int_5 = 50;

	internal bool bool_9;

	internal int int_6;

	private int int_7;

	private bool bool_10;

	private int int_8;

	private int int_9;

	private Hashtable[,] hashtable_2;

	private Hashtable[,] hashtable_3;

	private ArrayList arrayList_2;

	private ArrayList arrayList_3;

	private ArrayList arrayList_4;

	private ArrayList arrayList_5;

	private ArrayList arrayList_6;

	private ArrayList arrayList_7;

	private ArrayList arrayList_8;

	private int[][] int_10;

	private int[][] int_11;

	private void method_0()
	{
		if (pivotTable_0.ColumnFields.Count == 0 && pivotTable_0.RowFields.Count == 0 && pivotTable_0.DataFields.Count == 0)
		{
			bool_7 = true;
			bool_6 = true;
			return;
		}
		bool_8 = true;
		if (pivotTable_0.DataFields.Count == 0 && !pivotTable_0.DisplayImmediateItems)
		{
			bool_8 = false;
		}
		if (pivotTable_0.AutoFormatType == PivotTableAutoFormatType.Classic)
		{
			bool_6 = true;
		}
		else if (pivotTable_0.ColumnFields.Count == 0)
		{
			bool_6 = true;
		}
		else if (pivotTable_0.ColumnFields.Count == 1)
		{
			if (pivotTable_0.DataFields.Count > 1 && pivotTable_0.DataField == pivotTable_0.ColumnFields[0])
			{
				bool_6 = false;
			}
			else
			{
				bool_6 = true;
			}
		}
		else
		{
			bool_6 = true;
		}
		if (pivotTable_0.pivotField_0 != null)
		{
			pivotFieldType_0 = pivotTable_0.pivotField_0.pivotFieldType_0;
			int_1 = pivotTable_0.pivotField_0.Position;
		}
		if (pivotTable_0.class1141_0.class988_0 != null && pivotTable_0.class1141_0.class988_0.Count != 0)
		{
			for (int i = 0; i < pivotTable_0.RowFields.Count; i++)
			{
				PivotField pivotField = pivotTable_0.RowFields[i];
				for (int j = 0; j < pivotField.PivotItems.Count; j++)
				{
					PivotItem pivotItem = pivotField.PivotItems[j];
					if (pivotItem.IsFormula)
					{
						bool_1 = true;
						bool_4 = true;
						break;
					}
				}
			}
			for (int k = 0; k < pivotTable_0.ColumnFields.Count; k++)
			{
				PivotField pivotField2 = pivotTable_0.ColumnFields[k];
				for (int l = 0; l < pivotField2.PivotItems.Count; l++)
				{
					PivotItem pivotItem2 = pivotField2.PivotItems[l];
					if (pivotItem2.IsFormula)
					{
						bool_1 = true;
						bool_5 = true;
						break;
					}
				}
			}
			bool_1 = true;
		}
		for (int m = 0; m < pivotTable_0.RowFields.Count; m++)
		{
			PivotField pivotField3 = pivotTable_0.RowFields[m];
			if ((!pivotField3.ShowInOutlineForm || !pivotField3.ShowCompact) && m != pivotTable_0.RowFields.Count - 1)
			{
				int_2++;
			}
		}
		if (!pivotTable_0.IsGridDropZones && pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.FileFormat != FileFormatType.Default && int_2 == 1 && pivotTable_0.DataFields.Count == 0)
		{
			int_2 = 0;
		}
	}

	internal Class1149(PivotTable pivotTable_1)
	{
		pivotTable_0 = pivotTable_1;
		cells_0 = pivotTable_1.pivotTableCollection_0.worksheet_0.Cells;
		method_0();
	}

	internal void FormatAll(Style style_0)
	{
		Class1163 @class = new Class1163(pivotTable_0.class1164_0);
		pivotTable_0.class1164_0.Add(@class);
		@class.int_0 = pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Add(style_0);
		Class1171 class2 = (@class.class1171_0 = new Class1171());
		class2.method_1(bool_1: false);
		class2.method_3(bool_1: false);
		class2.method_13(3);
		method_85(@class);
	}

	internal void Format(int int_12, int int_13, Style style_0)
	{
		bool flag = false;
		bool flag2 = false;
		if (int_12 >= pivotTable_0.int_0 && int_12 <= pivotTable_0.int_1 && int_13 >= pivotTable_0.int_2 && int_13 <= pivotTable_0.int_3)
		{
			flag = true;
		}
		if (pivotTable_0.PageFields.Count > 0)
		{
			int num = pivotTable_0.int_0 - pivotTable_0.PageFields.Count - 1;
			int num2 = pivotTable_0.int_0 - 2;
			int num3 = pivotTable_0.int_2;
			int num4 = pivotTable_0.int_2 + 1;
			if (int_12 >= num && int_12 <= num2 && int_13 >= num3 && int_13 <= num4)
			{
				flag2 = true;
				flag = true;
			}
		}
		if (!flag)
		{
			return;
		}
		if (arrayList_7 == null || arrayList_8 == null)
		{
			int_0 = method_134(-1);
			method_121();
			method_130();
			method_108();
		}
		if (flag2)
		{
			if (int_13 == pivotTable_0.int_2)
			{
				Class1163 @class = new Class1163(pivotTable_0.class1164_0);
				pivotTable_0.class1164_0.Add(@class);
				@class.int_0 = pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Add(style_0);
				Class1171 class2 = (@class.class1171_0 = new Class1171());
				class2.byte_0 = (byte)(int_12 - (pivotTable_0.int_0 - 1 - pivotTable_0.PageFields.Count));
				class2.method_11(4);
				class2.method_1(bool_1: false);
				class2.method_3(bool_1: true);
				class2.byte_1 = (byte)pivotTable_0.PageFields[class2.byte_0].BaseIndex;
				class2.method_13(5);
				method_85(@class);
			}
			else
			{
				Class1163 class3 = new Class1163(pivotTable_0.class1164_0);
				pivotTable_0.class1164_0.Add(class3);
				class3.int_0 = pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Add(style_0);
				Class1171 class4 = (class3.class1171_0 = new Class1171());
				class4.method_1(bool_1: false);
				class4.method_3(bool_1: true);
				Class1162 class5 = new Class1162();
				class4.arrayList_0.Add(class5);
				class5.Function = 1;
				class5.method_2((ushort)pivotTable_0.PageFields[int_12 - (pivotTable_0.int_0 - 1 - pivotTable_0.PageFields.Count)].BaseIndex);
				method_85(class3);
			}
			return;
		}
		if (pivotTable_0.ColumnFields.Count > 0)
		{
			int num5 = pivotTable_0.int_5 - 2;
			if (pivotTable_0.RowFields.Count == 0)
			{
				num5 = pivotTable_0.int_5 - 1;
			}
			if (int_12 >= pivotTable_0.int_0 && int_12 <= num5 && int_13 >= pivotTable_0.int_2 && int_13 <= pivotTable_0.int_6 - 1)
			{
				Class1163 class6 = new Class1163(pivotTable_0.class1164_0);
				pivotTable_0.class1164_0.Add(class6);
				class6.int_0 = pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Add(style_0);
				Class1171 class7 = (class6.class1171_0 = new Class1171());
				class7.method_1(bool_1: false);
				class7.method_3(bool_1: true);
				class7.method_13(4);
				class7.method_17(bool_1: true);
				class7.byte_2 = (class7.byte_3 = (byte)(int_12 - pivotTable_0.int_0));
				class7.byte_4 = (class7.byte_5 = (byte)(int_13 - pivotTable_0.int_2));
				method_85(class6);
				return;
			}
			if (int_12 == pivotTable_0.int_0 && int_13 >= pivotTable_0.int_6 && int_13 <= pivotTable_0.int_6 + pivotTable_0.ColumnFields.Count - 1)
			{
				Class1163 class8 = new Class1163(pivotTable_0.class1164_0);
				pivotTable_0.class1164_0.Add(class8);
				class8.int_0 = pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Add(style_0);
				Class1171 class9 = (class8.class1171_0 = new Class1171());
				class9.method_1(bool_1: false);
				class9.method_3(bool_1: true);
				class9.method_13(5);
				class9.byte_0 = (byte)(int_13 - pivotTable_0.int_6);
				class9.method_11(2);
				class9.byte_1 = (byte)pivotTable_0.ColumnFields[class9.byte_0].BaseIndex;
				method_85(class8);
				return;
			}
			if (int_12 == pivotTable_0.int_0 && int_13 >= pivotTable_0.int_6 + pivotTable_0.ColumnFields.Count && int_13 <= pivotTable_0.int_3)
			{
				Class1163 class10 = new Class1163(pivotTable_0.class1164_0);
				pivotTable_0.class1164_0.Add(class10);
				class10.int_0 = pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Add(style_0);
				Class1171 class11 = (class10.class1171_0 = new Class1171());
				class11.method_1(bool_1: false);
				class11.method_3(bool_1: true);
				class11.method_13(6);
				class11.method_17(bool_1: true);
				byte b = (class11.byte_3 = 0);
				class11.byte_2 = 0;
				class11.byte_4 = (class11.byte_5 = (byte)(int_13 - pivotTable_0.int_6 - pivotTable_0.ColumnFields.Count));
				method_85(class10);
				return;
			}
			if (int_12 > pivotTable_0.int_0 && int_12 < pivotTable_0.int_5 && int_13 >= pivotTable_0.int_6)
			{
				int num6 = int_13 - pivotTable_0.int_6;
				if (num6 < arrayList_8.Count)
				{
					Class1163 class12 = new Class1163(pivotTable_0.class1164_0);
					pivotTable_0.class1164_0.Add(class12);
					class12.int_0 = pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Add(style_0);
					Class1171 class13 = (class12.class1171_0 = new Class1171());
					class13.method_1(bool_1: false);
					class13.method_3(bool_1: true);
					class13.method_9(bool_1: false);
					Class1165 class14 = (Class1165)arrayList_8[num6];
					if (class14.enum185_0 == Enum185.const_13)
					{
						class13.method_7(bool_1: true);
						class13.method_17(bool_1: true);
						byte b = (class13.byte_5 = byte.MaxValue);
						class13.byte_4 = byte.MaxValue;
						class13.byte_2 = (class13.byte_3 = (byte)(int_12 - pivotTable_0.int_0 - 1 - class14.int_0));
						method_85(class12);
						return;
					}
					if (int_12 - pivotTable_0.int_0 - 1 >= class14.int_0)
					{
						bool flag3 = false;
						int num7 = Math.Min(int_12 - pivotTable_0.int_0 - 1, class14.int_1 - 1);
						for (int i = 0; i <= num7; i++)
						{
							Class1162 class15 = new Class1162();
							class13.arrayList_0.Add(class15);
							class15.method_2((ushort)pivotTable_0.ColumnFields[i].BaseIndex);
							class15.method_4((byte)i);
							class15.method_3(2);
							class15.method_6(bool_14: true);
							if (i == class14.int_1 - 1)
							{
								if (class14.enum185_0 != 0 && class14.enum185_0 != Enum185.const_14 && class14.enum185_0 != Enum185.const_13)
								{
									flag3 = true;
									class15.Function = method_2(class14.enum185_0);
								}
								else
								{
									class15.Function = 1;
								}
							}
							else
							{
								class15.Function = 1;
							}
							class15.arrayList_0.Add(class14.int_2[i]);
						}
						if (flag3)
						{
							class13.method_17(bool_1: true);
							byte b = (class13.byte_5 = byte.MaxValue);
							class13.byte_4 = byte.MaxValue;
							class13.byte_2 = (class13.byte_3 = (byte)(int_12 - pivotTable_0.int_0 - 1 - class14.int_0));
						}
					}
					else
					{
						int num8 = int_12 - pivotTable_0.int_0 - 1;
						int num9 = method_91(num6, num8, PivotFieldType.Column);
						class14 = (Class1165)arrayList_8[num9];
						for (int j = 0; j <= num8; j++)
						{
							Class1162 class16 = new Class1162();
							class13.arrayList_0.Add(class16);
							class16.method_2((ushort)pivotTable_0.ColumnFields[j].BaseIndex);
							class16.method_4((byte)j);
							class16.method_3(2);
							class16.method_6(bool_14: true);
							class16.Function = 1;
							class16.arrayList_0.Add(class14.int_2[j]);
						}
						class13.method_17(bool_1: true);
						class13.byte_4 = (class13.byte_5 = (byte)(num6 - num9));
						byte b = (class13.byte_3 = byte.MaxValue);
						class13.byte_2 = byte.MaxValue;
					}
					method_85(class12);
					return;
				}
			}
		}
		if (pivotTable_0.ColumnFields.Count == 0 && pivotTable_0.RowFields.Count > 0 && pivotFieldType_0 != PivotFieldType.Row && int_12 == pivotTable_0.int_5 - 1 && int_13 >= pivotTable_0.int_6)
		{
			Class1163 class17 = new Class1163(pivotTable_0.class1164_0);
			pivotTable_0.class1164_0.Add(class17);
			class17.int_0 = pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Add(style_0);
			Class1171 class18 = (class17.class1171_0 = new Class1171());
			class18.method_1(bool_1: false);
			class18.method_11(8);
			class18.byte_0 = (byte)(int_13 - pivotTable_0.int_6);
			method_85(class17);
			return;
		}
		if (pivotTable_0.RowFields.Count > 0)
		{
			if (int_12 == pivotTable_0.int_5 - 1 && int_13 < pivotTable_0.int_6)
			{
				Class1163 class19 = new Class1163(pivotTable_0.class1164_0);
				pivotTable_0.class1164_0.Add(class19);
				class19.int_0 = pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Add(style_0);
				Class1171 class20 = (class19.class1171_0 = new Class1171());
				class20.method_1(bool_1: false);
				class20.method_3(bool_1: true);
				class20.method_13(5);
				class20.byte_0 = (byte)(int_13 - pivotTable_0.int_2);
				class20.method_11(1);
				class20.byte_1 = (byte)pivotTable_0.RowFields[class20.byte_0].BaseIndex;
				method_85(class19);
				return;
			}
			if (int_12 >= pivotTable_0.int_5 && int_13 < pivotTable_0.int_6)
			{
				int num10 = int_12 - pivotTable_0.int_5;
				if (num10 >= arrayList_7.Count)
				{
					return;
				}
				Class1163 class21 = new Class1163(pivotTable_0.class1164_0);
				pivotTable_0.class1164_0.Add(class21);
				class21.int_0 = pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Add(style_0);
				Class1171 class22 = (class21.class1171_0 = new Class1171());
				class22.method_1(bool_1: false);
				class22.method_3(bool_1: true);
				Class1165 class23 = (Class1165)arrayList_7[num10];
				int num11 = method_77(class23.int_0);
				if (class23.enum185_0 == Enum185.const_13)
				{
					class22.method_5(bool_1: true);
					class22.method_17(bool_1: true);
					class22.byte_4 = (class22.byte_5 = (byte)(int_13 - pivotTable_0.int_2 - num11));
					byte b = (class22.byte_3 = byte.MaxValue);
					class22.byte_2 = byte.MaxValue;
					method_85(class21);
					return;
				}
				if (int_13 - pivotTable_0.int_2 >= num11)
				{
					int num12 = Math.Min(class23.int_1 - 1, int_13 - pivotTable_0.int_2);
					bool flag4 = false;
					for (int k = 0; k <= num12; k++)
					{
						Class1162 class24 = new Class1162();
						class22.arrayList_0.Add(class24);
						class24.method_2((ushort)pivotTable_0.RowFields[k].BaseIndex);
						class24.method_4((byte)k);
						class24.method_3(1);
						class24.method_6(bool_14: true);
						if (k == class23.int_1 - 1)
						{
							if (class23.enum185_0 != 0 && class23.enum185_0 != Enum185.const_14 && class23.enum185_0 != Enum185.const_13)
							{
								flag4 = true;
								class24.Function = method_2(class23.enum185_0);
							}
							else
							{
								class24.Function = 1;
							}
						}
						else
						{
							class24.Function = 1;
						}
						class24.arrayList_0.Add(class23.int_2[k]);
					}
					if (flag4 || (num12 < pivotTable_0.RowFields.Count - 1 && pivotTable_0.RowFields[num12].ShowInOutlineForm))
					{
						class22.method_17(bool_1: true);
						class22.byte_4 = (class22.byte_5 = (byte)(int_13 - pivotTable_0.int_2 - num11));
						byte b = (class22.byte_3 = byte.MaxValue);
						class22.byte_2 = byte.MaxValue;
					}
				}
				else
				{
					int int_14 = int_13 - pivotTable_0.int_2;
					int int_15 = method_1(int_14);
					int num13 = method_91(num10, int_15, PivotFieldType.Row);
					class23 = (Class1165)arrayList_7[num13];
					for (int l = 0; l < class23.int_1; l++)
					{
						Class1162 class25 = new Class1162();
						class22.arrayList_0.Add(class25);
						class25.method_2((ushort)pivotTable_0.RowFields[l].BaseIndex);
						class25.method_4((byte)l);
						class25.method_3(1);
						class25.method_6(bool_14: true);
						class25.Function = 1;
						class25.arrayList_0.Add(class23.int_2[l]);
					}
					class22.method_17(bool_1: true);
					byte b = (class22.byte_5 = byte.MaxValue);
					class22.byte_4 = byte.MaxValue;
					class22.byte_2 = (class22.byte_3 = (byte)(num10 - num13));
				}
				method_85(class21);
				return;
			}
		}
		if (pivotTable_0.RowFields.Count == 0 && pivotTable_0.ColumnFields.Count > 0 && pivotFieldType_0 != PivotFieldType.Column && int_12 == pivotTable_0.int_5 && int_13 == pivotTable_0.int_6 - 1)
		{
			Class1163 class26 = new Class1163(pivotTable_0.class1164_0);
			pivotTable_0.class1164_0.Add(class26);
			class26.int_0 = pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Add(style_0);
			Class1171 class27 = (class26.class1171_0 = new Class1171());
			class27.method_1(bool_1: false);
			class27.method_3(bool_1: true);
			class27.method_11(8);
			class27.byte_0 = 0;
			method_85(class26);
		}
		else
		{
			if ((pivotTable_0.RowFields.Count <= 0 && pivotTable_0.ColumnFields.Count <= 0) || int_12 < pivotTable_0.int_5 || int_13 < pivotTable_0.int_6)
			{
				return;
			}
			int num14 = int_12 - pivotTable_0.int_5;
			int num15 = int_13 - pivotTable_0.int_6;
			Class1163 class28 = new Class1163(pivotTable_0.class1164_0);
			pivotTable_0.class1164_0.Add(class28);
			class28.int_0 = pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Add(style_0);
			Class1171 class29 = (class28.class1171_0 = new Class1171());
			class29.method_1(bool_1: true);
			class29.method_3(bool_1: false);
			if (num14 < arrayList_7.Count && pivotTable_0.RowFields.Count > 0)
			{
				Class1165 class30 = (Class1165)arrayList_7[num14];
				if (class30.enum185_0 == Enum185.const_13)
				{
					class29.method_5(bool_1: true);
				}
				else
				{
					for (int m = 0; m < class30.int_1; m++)
					{
						Class1162 class31 = new Class1162();
						class29.arrayList_0.Add(class31);
						class31.method_2((ushort)pivotTable_0.RowFields[m].BaseIndex);
						class31.method_4((byte)m);
						class31.method_3(1);
						if (m == class30.int_1 - 1)
						{
							if (class30.enum185_0 != 0 && class30.enum185_0 != Enum185.const_14 && class30.enum185_0 != Enum185.const_13)
							{
								class31.Function = method_2(class30.enum185_0);
							}
							else
							{
								class29.bool_0 = true;
								class31.Function = 1;
							}
						}
						else
						{
							class31.Function = 1;
						}
						class31.arrayList_0.Add(class30.int_2[m]);
					}
				}
			}
			if (num15 < arrayList_8.Count && pivotTable_0.ColumnFields.Count > 0)
			{
				Class1165 class32 = (Class1165)arrayList_8[num15];
				if (class32.enum185_0 == Enum185.const_13)
				{
					class29.method_7(bool_1: true);
				}
				else
				{
					for (int n = 0; n < class32.int_1; n++)
					{
						Class1162 class33 = new Class1162();
						class29.arrayList_0.Add(class33);
						class33.method_2((ushort)pivotTable_0.ColumnFields[n].BaseIndex);
						class33.method_4((byte)n);
						class33.method_3(2);
						if (n == class32.int_1 - 1)
						{
							if (class32.enum185_0 != 0 && class32.enum185_0 != Enum185.const_14 && class32.enum185_0 != Enum185.const_13)
							{
								class33.Function = method_2(class32.enum185_0);
							}
							else
							{
								class33.Function = 1;
							}
						}
						else
						{
							class33.Function = 1;
						}
						class33.arrayList_0.Add(class32.int_2[n]);
					}
				}
			}
			method_85(class28);
		}
	}

	private int method_1(int int_12)
	{
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < pivotTable_0.RowFields.Count - 1)
			{
				if (!pivotTable_0.RowFields[num2].ShowInOutlineForm || !pivotTable_0.RowFields[num2].ShowCompact)
				{
					num++;
					if (num > int_12)
					{
						break;
					}
				}
				num2++;
				continue;
			}
			return pivotTable_0.RowFields.Count - 1;
		}
		return num2;
	}

	private ushort method_2(Enum185 enum185_0)
	{
		ushort result = 1;
		switch (enum185_0)
		{
		case Enum185.const_1:
			result = 2;
			break;
		case Enum185.const_2:
			result = 4;
			break;
		case Enum185.const_3:
			result = 8;
			break;
		case Enum185.const_4:
			result = 256;
			break;
		case Enum185.const_5:
			result = 16;
			break;
		case Enum185.const_6:
			result = 32;
			break;
		case Enum185.const_7:
			result = 64;
			break;
		case Enum185.const_8:
			result = 128;
			break;
		case Enum185.const_9:
			result = 512;
			break;
		case Enum185.const_10:
			result = 1024;
			break;
		case Enum185.const_11:
			result = 2048;
			break;
		case Enum185.const_12:
			result = 4096;
			break;
		}
		return result;
	}

	internal void method_3(Chart chart_0, string string_0)
	{
		if (pivotTable_0.class1141_0.class1144_0 != null)
		{
			int_0 = method_134(-1);
			method_121();
			method_130();
			method_108();
			method_110();
			method_4(chart_0, string_0);
		}
	}

	internal void method_4(Chart chart_0, string string_0)
	{
		if (pivotTable_0.ColumnFields.Count == 0 || pivotTable_0.RowFields.Count == 0)
		{
			if (pivotTable_0.DataFields.Count == 0)
			{
				chart_0.NSeries.Clear();
				return;
			}
			if (pivotTable_0.ColumnFields.Count == 0 && pivotTable_0.RowFields.Count == 0)
			{
				if (chart_0.NSeries.Count > 1)
				{
					chart_0.NSeries.RemoveRange(1, chart_0.NSeries.Count - 1);
				}
				Series series = null;
				CellArea dataBodyRange = pivotTable_0.DataBodyRange;
				string text = method_6(bool_11: true, string_0, dataBodyRange.StartRow, dataBodyRange.StartColumn, dataBodyRange.EndRow, dataBodyRange.EndColumn);
				if (chart_0.NSeries.Count < 1)
				{
					chart_0.NSeries.Add(text, isVertical: true);
					series = chart_0.NSeries[0];
				}
				else
				{
					series = chart_0.NSeries[0];
					series.Values = text;
				}
				series.XValues = method_6(bool_11: true, string_0, dataBodyRange.StartRow - 1, dataBodyRange.StartColumn, dataBodyRange.StartRow - 1, dataBodyRange.EndColumn);
				series.Name = method_6(bool_11: false, string_0, dataBodyRange.StartRow - 1, dataBodyRange.StartColumn, dataBodyRange.StartRow - 1, dataBodyRange.EndColumn);
				return;
			}
			if (pivotTable_0.ColumnFields.Count == 0)
			{
				if (chart_0.NSeries.Count > 1)
				{
					chart_0.NSeries.RemoveRange(1, chart_0.NSeries.Count - 1);
				}
				CellArea dataBodyRange2 = pivotTable_0.DataBodyRange;
				CellArea rowRange = pivotTable_0.RowRange;
				string text2 = method_6(bool_11: true, string_0, dataBodyRange2.StartRow, dataBodyRange2.StartColumn, dataBodyRange2.EndRow, dataBodyRange2.EndColumn);
				Series series2 = null;
				if (chart_0.NSeries.Count < 1)
				{
					chart_0.NSeries.Add(text2, isVertical: true);
					series2 = chart_0.NSeries[0];
				}
				else
				{
					series2 = chart_0.NSeries[0];
					series2.Values = text2;
				}
				series2.XValues = method_6(bool_11: true, string_0, dataBodyRange2.StartRow, rowRange.StartColumn, dataBodyRange2.EndRow, rowRange.EndColumn);
				series2.Name = method_6(bool_11: false, string_0, dataBodyRange2.StartRow - 1, dataBodyRange2.StartColumn, dataBodyRange2.StartRow - 1, dataBodyRange2.EndColumn);
				ArrayList arrayList = new ArrayList();
				ArrayList arrayList2 = new ArrayList();
				ArrayList arrayList3 = new ArrayList();
				for (int i = 0; i < pivotTable_0.arrayList_0.Count; i++)
				{
					Class1165 @class = new Class1165((int[])pivotTable_0.arrayList_0[i]);
					if (@class.method_2() || @class.method_3() || @class.enum185_0 == Enum185.const_13)
					{
						continue;
					}
					for (int j = @class.int_0; j < @class.int_1; j++)
					{
						int index = @class.int_2[j];
						PivotItem pivotItem = pivotTable_0.RowFields[j].PivotItems[index];
						if (pivotItem.Value != null)
						{
							if (@class.int_0 + 1 == pivotTable_0.RowFields.Count)
							{
								arrayList.Add(pivotItem.Value.ToString());
								arrayList2.Add(method_5(arrayList));
								arrayList = new ArrayList();
							}
							else
							{
								arrayList.Add(pivotItem.Value.ToString());
								arrayList.Add("\n");
							}
						}
					}
				}
				series2.method_18().imethod_3(arrayList2);
				for (int k = 0; k < arrayList_5.Count; k++)
				{
					Class1165 class2 = (Class1165)arrayList_5[k];
					if (class2.enum185_0 != Enum185.const_14 && class2.int_1 == pivotTable_0.RowFields.Count && class2.enum185_0 != Enum185.const_13)
					{
						PivotField pivotField = method_102(class2, null);
						ArrayList arrayList_ = method_123(class2.arrayList_0, class2, pivotFieldType_0 == PivotFieldType.Row, pivotTable_0.RowFields);
						if (pivotField != null)
						{
							object object_ = method_137(null, null, arrayList_, bool_11: true, pivotField, 0, null);
							object_ = method_104(object_);
							arrayList3.Add(object_);
						}
					}
				}
				series2.method_16().imethod_3(arrayList3);
				return;
			}
		}
		CellArea rowRange2 = pivotTable_0.RowRange;
		CellArea dataBodyRange3 = pivotTable_0.DataBodyRange;
		CellArea columnRange = pivotTable_0.ColumnRange;
		ArrayList arrayList4 = pivotTable_0.arrayList_1;
		int num = 0;
		ArrayList arrayList5 = new ArrayList();
		ArrayList arrayList6 = new ArrayList();
		for (int l = 0; l < arrayList4.Count; l++)
		{
			arrayList6 = new ArrayList();
			int[] array = (int[])arrayList4[l];
			Class1165 class3 = new Class1165(array);
			if (array[2] <= 0 || array[1] != 0)
			{
				continue;
			}
			Series series3 = null;
			string text3 = method_6(bool_11: true, string_0, dataBodyRange3.StartRow, dataBodyRange3.StartColumn + l, dataBodyRange3.EndRow, dataBodyRange3.StartColumn + l);
			if (num >= chart_0.NSeries.Count)
			{
				chart_0.NSeries.Add(text3, isVertical: true);
				series3 = chart_0.NSeries[num];
			}
			else
			{
				series3 = chart_0.NSeries[num];
				series3.Values = text3;
			}
			if (pivotTable_0.RowFields.Count != 0 && (pivotTable_0.ColumnFields.Count != 1 || pivotTable_0.ColumnFields[0].int_1 != -2))
			{
				series3.XValues = method_6(bool_11: true, string_0, rowRange2.StartRow + 1, rowRange2.StartColumn, rowRange2.EndRow, rowRange2.EndColumn);
			}
			else
			{
				series3.XValues = method_6(bool_11: true, string_0, rowRange2.StartRow, rowRange2.StartColumn, rowRange2.EndRow, rowRange2.EndColumn);
			}
			series3.Name = method_6(bool_11: true, string_0, columnRange.StartRow, columnRange.StartColumn + l, columnRange.EndRow, columnRange.StartColumn + l);
			StringBuilder stringBuilder = new StringBuilder();
			for (int m = 0; m < class3.int_1; m++)
			{
				int index2 = class3.int_2[m];
				PivotItem pivotItem2 = pivotTable_0.ColumnFields[m].PivotItems[index2];
				if (pivotItem2.Value != null)
				{
					stringBuilder.Append(pivotItem2.Value.ToString());
					if (class3.int_1 > 0 && m != class3.int_1 - 1)
					{
						stringBuilder.Append(" - ");
					}
				}
				else if (pivotItem2.pivotField_0 != null && pivotItem2.pivotField_0.int_1 < pivotTable_0.DataFields.Count)
				{
					stringBuilder.Append(pivotTable_0.DataFields[pivotItem2.pivotField_0.int_1].DisplayName);
				}
			}
			series3.string_0 = stringBuilder.ToString();
			ArrayList arrayList7 = new ArrayList();
			new StringBuilder();
			arrayList5 = new ArrayList();
			for (int n = 0; n < pivotTable_0.arrayList_0.Count; n++)
			{
				Class1165 class4 = new Class1165((int[])pivotTable_0.arrayList_0[n]);
				if (class4.method_2() || class4.method_3() || class4.enum185_0 == Enum185.const_13)
				{
					continue;
				}
				for (int num2 = class4.int_0; num2 < class4.int_1; num2++)
				{
					int index3 = class4.int_2[num2];
					PivotItem pivotItem3 = pivotTable_0.RowFields[num2].PivotItems[index3];
					if (pivotItem3.Value != null)
					{
						if (class4.int_0 + 1 == pivotTable_0.RowFields.Count)
						{
							arrayList7.Add(pivotItem3.Value.ToString());
							arrayList5.Add(method_5(arrayList7));
							arrayList7 = new ArrayList();
						}
						else
						{
							arrayList7.Add(pivotItem3.Value.ToString());
							arrayList7.Add("\n");
						}
					}
				}
			}
			series3.method_18().imethod_3(arrayList5);
			for (int num3 = 0; num3 < arrayList_5.Count; num3++)
			{
				Class1165 class5 = (Class1165)arrayList_5[num3];
				if (class5.enum185_0 != Enum185.const_14 && class5.int_1 == pivotTable_0.RowFields.Count && class5.enum185_0 != Enum185.const_13)
				{
					Class1165 class6 = (Class1165)arrayList_6[l];
					PivotField pivotField2 = method_102(class5, class6);
					ArrayList arrayList_2 = method_123(class5.arrayList_0, class6, pivotFieldType_0 == PivotFieldType.Column, pivotTable_0.ColumnFields);
					if (pivotField2 != null)
					{
						object object_2 = method_137(null, null, arrayList_2, bool_11: true, pivotField2, l, class6);
						object_2 = method_104(object_2);
						arrayList6.Add(object_2);
					}
				}
			}
			series3.method_16().imethod_3(arrayList6);
			num++;
		}
	}

	private string method_5(ArrayList arrayList_9)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int num = arrayList_9.Count - 1; num >= 0; num--)
		{
			string value = (string)arrayList_9[num];
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}

	private string method_6(bool bool_11, string string_0, int int_12, int int_13, int int_14, int int_15)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('=');
		stringBuilder.Append(string_0);
		stringBuilder.Append('!');
		stringBuilder.Append(CellsHelper.CellIndexToName(int_12, int_13));
		if (bool_11)
		{
			stringBuilder.Append(':');
			stringBuilder.Append(CellsHelper.CellIndexToName(int_14, int_15));
		}
		return stringBuilder.ToString();
	}

	internal void CalculateData()
	{
		if (pivotTable_0.class1141_0.class1144_0 == null)
		{
			return;
		}
		method_128();
		method_8();
		int_0 = method_134(-1);
		method_121();
		method_130();
		method_108();
		method_110();
		method_83();
		method_111();
		CreateStyle();
		SetStyle();
		method_84();
		pivotTable_0.bool_20 = true;
		if (pivotTable_0.IsAutoFormat)
		{
			for (int i = pivotTable_0.int_2; i <= pivotTable_0.int_3; i++)
			{
				pivotTable_0.pivotTableCollection_0.worksheet_0.AutoFitColumn(i, pivotTable_0.int_0, pivotTable_0.int_1);
			}
		}
	}

	internal void method_7()
	{
		if (pivotTable_0.class1141_0.class1144_0 != null)
		{
			int_0 = method_119();
			method_121();
			method_130();
			method_108();
			method_110();
		}
	}

	private void method_8()
	{
		pivotTable_0.style_0 = null;
		pivotTable_0.style_1 = null;
		for (int i = pivotTable_0.int_0; i <= pivotTable_0.int_1; i++)
		{
			for (int j = pivotTable_0.int_2; j <= pivotTable_0.int_3; j++)
			{
				pivotTable_0.pivotTableCollection_0.worksheet_0.Cells.GetCell(i, j, bool_2: false)?.method_30(new Style(pivotTable_0.pivotTableCollection_0.worksheet_0.method_2()));
			}
		}
		if (pivotTable_0.PageFields.Count <= 0)
		{
			return;
		}
		int num = pivotTable_0.int_0 - pivotTable_0.PageFields.Count - 1;
		int num2 = pivotTable_0.int_0 - 2;
		int num3 = pivotTable_0.int_2;
		int num4 = pivotTable_0.int_2 + 1;
		for (int k = num; k <= num2; k++)
		{
			for (int l = num3; l <= num4; l++)
			{
				pivotTable_0.pivotTableCollection_0.worksheet_0.Cells.GetCell(k, l, bool_2: false)?.method_30(new Style(pivotTable_0.pivotTableCollection_0.worksheet_0.method_2()));
			}
		}
	}

	internal void method_9()
	{
		if (pivotTable_0.class1141_0.class1144_0 == null)
		{
			return;
		}
		try
		{
			int_0 = method_120();
			method_121();
			method_130();
			method_111();
			CreateStyle();
			SetStyle();
			method_108();
			method_84();
			pivotTable_0.bool_20 = true;
		}
		catch (Exception)
		{
			pivotTable_0.style_1 = null;
			pivotTable_0.style_0 = null;
		}
	}

	private void SetStyle()
	{
		if (pivotTable_0.style_0 != null)
		{
			for (int i = pivotTable_0.int_0; i <= pivotTable_0.int_1; i++)
			{
				for (int j = pivotTable_0.int_2; j <= pivotTable_0.int_3; j++)
				{
					Cell cell = pivotTable_0.pivotTableCollection_0.worksheet_0.Cells.GetCell(i, j, bool_2: false);
					Style style = new Style(pivotTable_0.pivotTableCollection_0.worksheet_0.method_2());
					style.Copy(pivotTable_0.style_0[i - pivotTable_0.int_0, j - pivotTable_0.int_2]);
					Class1627.smethod_1(style, cell.GetStyle());
					cell.method_30(style);
				}
			}
		}
		if (pivotTable_0.style_1 == null || pivotTable_0.PageFields.Count <= 0)
		{
			return;
		}
		for (int k = 0; k < pivotTable_0.PageFields.Count; k++)
		{
			for (int l = 0; l < 2; l++)
			{
				Cell cell2 = pivotTable_0.pivotTableCollection_0.worksheet_0.Cells.GetCell(pivotTable_0.int_0 - 1 - pivotTable_0.PageFields.Count + k, pivotTable_0.int_2 + l, bool_2: false);
				cell2.method_30(pivotTable_0.style_1[k, l]);
			}
		}
	}

	private void method_10()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		bool_10 = pivotTable_0.PageFields.Count > 0;
		if (bool_10)
		{
			int_7 = pivotTable_0.int_0 - pivotTable_0.PageFields.Count - 1;
			pivotTable_0.style_1 = new Style[pivotTable_0.PageFields.Count, 2];
			hashtable_3 = new Hashtable[pivotTable_0.PageFields.Count, 2];
			for (int i = 0; i < pivotTable_0.PageFields.Count; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					pivotTable_0.style_1[i, j] = new Style(worksheets);
					hashtable_3[i, j] = new Hashtable();
					hashtable_3[i, j].Add(BorderType.TopBorder, -1);
					hashtable_3[i, j].Add(BorderType.BottomBorder, -1);
					hashtable_3[i, j].Add(BorderType.LeftBorder, -1);
					hashtable_3[i, j].Add(BorderType.RightBorder, -1);
				}
			}
		}
		int_8 = pivotTable_0.int_1 - pivotTable_0.int_0 + 1;
		int_9 = pivotTable_0.int_3 - pivotTable_0.int_2 + 1;
		pivotTable_0.style_0 = new Style[int_8, int_9];
		hashtable_2 = new Hashtable[int_8, int_9];
		for (int k = 0; k < int_8; k++)
		{
			for (int l = 0; l < int_9; l++)
			{
				pivotTable_0.style_0[k, l] = new Style(worksheets);
				hashtable_2[k, l] = new Hashtable();
				hashtable_2[k, l].Add(BorderType.TopBorder, -1);
				hashtable_2[k, l].Add(BorderType.BottomBorder, -1);
				hashtable_2[k, l].Add(BorderType.LeftBorder, -1);
				hashtable_2[k, l].Add(BorderType.RightBorder, -1);
			}
		}
	}

	private void CreateStyle()
	{
		method_10();
		method_70();
		if (pivotTable_0.bool_19)
		{
			method_69();
			if (pivotTable_0.method_10() == null)
			{
				return;
			}
			TableStyleElement tableStyleElement = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.WholeTable];
			if (tableStyleElement != null && tableStyleElement.method_1() != null)
			{
				method_49(tableStyleElement.method_1());
			}
			tableStyleElement = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.PageFieldLabels];
			if (tableStyleElement != null && tableStyleElement.method_1() != null)
			{
				method_50(tableStyleElement.method_1());
			}
			tableStyleElement = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.PageFieldValues];
			if (tableStyleElement != null && tableStyleElement.method_1() != null)
			{
				method_51(tableStyleElement.method_1());
			}
			TableStyleElement tableStyleElement2 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.FirstColumnStripe];
			TableStyleElement tableStyleElement3 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.SecondColumnStripe];
			if ((tableStyleElement2 != null && tableStyleElement2.method_1() != null) || (tableStyleElement3 != null && tableStyleElement3.method_1() != null))
			{
				Style style = null;
				Style style2 = null;
				if (tableStyleElement2 != null && tableStyleElement2.method_1() != null)
				{
					style = tableStyleElement2.method_1();
				}
				if (tableStyleElement3 != null && tableStyleElement3.method_1() != null)
				{
					style2 = tableStyleElement3.method_1();
				}
				int int_ = 1;
				if (style != null)
				{
					int_ = tableStyleElement2.Size;
				}
				int int_2 = 1;
				if (style2 != null)
				{
					int_2 = tableStyleElement3.Size;
				}
				method_52(style, style2, int_, int_2);
			}
			tableStyleElement2 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.FirstRowStripe];
			tableStyleElement3 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.SecondRowStripe];
			if ((tableStyleElement2 != null && tableStyleElement2.method_1() != null) || (tableStyleElement3 != null && tableStyleElement3.method_1() != null))
			{
				Style style_ = null;
				Style style_2 = null;
				if (tableStyleElement2 != null && tableStyleElement2.method_1() != null)
				{
					style_ = tableStyleElement2.method_1();
				}
				if (tableStyleElement3 != null && tableStyleElement3.method_1() != null)
				{
					style_2 = tableStyleElement3.method_1();
				}
				int int_3 = 1;
				if (tableStyleElement2 != null)
				{
					int_3 = tableStyleElement2.Size;
				}
				int int_4 = 1;
				if (tableStyleElement3 != null)
				{
					int_4 = tableStyleElement3.Size;
				}
				method_53(style_, style_2, int_3, int_4);
			}
			tableStyleElement = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.FirstColumn];
			if (tableStyleElement != null && tableStyleElement.method_1() != null)
			{
				method_54(tableStyleElement.method_1());
			}
			tableStyleElement = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.HeaderRow];
			if (tableStyleElement != null && tableStyleElement.method_1() != null)
			{
				method_55(tableStyleElement.method_1());
			}
			tableStyleElement = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.FirstHeaderCell];
			if (tableStyleElement != null && tableStyleElement.method_1() != null)
			{
				method_56(tableStyleElement.method_1());
			}
			tableStyleElement2 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.FirstSubtotalColumn];
			tableStyleElement3 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.SecondSubtotalColumn];
			TableStyleElement tableStyleElement4 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.ThirdSubtotalColumn];
			if ((tableStyleElement2 != null && tableStyleElement2.method_1() != null) || (tableStyleElement3 != null && tableStyleElement3.method_1() != null) || (tableStyleElement4 != null && tableStyleElement4.method_1() != null))
			{
				Style style_3 = null;
				Style style_4 = null;
				Style style_5 = null;
				if (tableStyleElement2 != null && tableStyleElement2.method_1() != null)
				{
					style_3 = tableStyleElement2.method_1();
				}
				if (tableStyleElement3 != null && tableStyleElement3.method_1() != null)
				{
					style_4 = tableStyleElement3.method_1();
				}
				if (tableStyleElement4 != null && tableStyleElement4.method_1() != null)
				{
					style_5 = tableStyleElement4.method_1();
				}
				method_57(style_3, style_4, style_5);
			}
			tableStyleElement = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.BlankRow];
			if (tableStyleElement != null && tableStyleElement.method_1() != null)
			{
				method_59(tableStyleElement.method_1());
			}
			tableStyleElement2 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.FirstSubtotalRow];
			tableStyleElement3 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.SecondSubtotalRow];
			tableStyleElement4 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.ThirdSubtotalRow];
			if ((tableStyleElement2 != null && tableStyleElement2.method_1() != null) || (tableStyleElement3 != null && tableStyleElement3.method_1() != null) || (tableStyleElement4 != null && tableStyleElement4.method_1() != null))
			{
				Style style_6 = null;
				Style style_7 = null;
				Style style_8 = null;
				if (tableStyleElement2 != null && tableStyleElement2.method_1() != null)
				{
					style_6 = tableStyleElement2.method_1();
				}
				if (tableStyleElement3 != null && tableStyleElement3.method_1() != null)
				{
					style_7 = tableStyleElement3.method_1();
				}
				if (tableStyleElement4 != null && tableStyleElement4.method_1() != null)
				{
					style_8 = tableStyleElement4.method_1();
				}
				method_60(style_6, style_7, style_8);
			}
			tableStyleElement2 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.FirstColumnSubheading];
			tableStyleElement3 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.SecondColumnSubheading];
			tableStyleElement4 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.ThirdColumnSubheading];
			if ((tableStyleElement2 != null && tableStyleElement2.method_1() != null) || (tableStyleElement3 != null && tableStyleElement3.method_1() != null) || (tableStyleElement4 != null && tableStyleElement4.method_1() != null))
			{
				Style style_9 = null;
				Style style_10 = null;
				Style style_11 = null;
				if (tableStyleElement2 != null && tableStyleElement2.method_1() != null)
				{
					style_9 = tableStyleElement2.method_1();
				}
				if (tableStyleElement3 != null && tableStyleElement3.method_1() != null)
				{
					style_10 = tableStyleElement3.method_1();
				}
				if (tableStyleElement4 != null && tableStyleElement4.method_1() != null)
				{
					style_11 = tableStyleElement4.method_1();
				}
				method_65(style_9, style_10, style_11);
			}
			tableStyleElement2 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.FirstRowSubheading];
			tableStyleElement3 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.SecondRowSubheading];
			tableStyleElement4 = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.ThirdRowSubheading];
			if ((tableStyleElement2 != null && tableStyleElement2.method_1() != null) || (tableStyleElement3 != null && tableStyleElement3.method_1() != null) || (tableStyleElement4 != null && tableStyleElement4.method_1() != null))
			{
				Style style_12 = null;
				Style style_13 = null;
				Style style_14 = null;
				if (tableStyleElement2 != null && tableStyleElement2.method_1() != null)
				{
					style_12 = tableStyleElement2.method_1();
				}
				if (tableStyleElement3 != null && tableStyleElement3.method_1() != null)
				{
					style_13 = tableStyleElement3.method_1();
				}
				if (tableStyleElement4 != null && tableStyleElement4.method_1() != null)
				{
					style_14 = tableStyleElement4.method_1();
				}
				method_67(style_12, style_13, style_14);
			}
			tableStyleElement = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.GrandTotalColumn];
			if (tableStyleElement != null && tableStyleElement.method_1() != null)
			{
				method_72(tableStyleElement.method_1());
			}
			tableStyleElement = pivotTable_0.method_10().TableStyleElements[TableStyleElementType.GrandTotalRow];
			if (tableStyleElement != null && tableStyleElement.method_1() != null)
			{
				method_75(tableStyleElement.method_1());
			}
		}
		else
		{
			switch (pivotTable_0.class1176_0.AutoFormatType)
			{
			case PivotTableAutoFormatType.None:
				method_32();
				break;
			case PivotTableAutoFormatType.Classic:
				method_31();
				break;
			case PivotTableAutoFormatType.Report1:
				method_11();
				break;
			case PivotTableAutoFormatType.Report2:
				method_12();
				break;
			case PivotTableAutoFormatType.Report3:
				method_13();
				break;
			case PivotTableAutoFormatType.Report4:
				method_14();
				break;
			case PivotTableAutoFormatType.Report5:
				method_15();
				break;
			case PivotTableAutoFormatType.Report6:
				method_16();
				break;
			case PivotTableAutoFormatType.Report7:
				method_17();
				break;
			case PivotTableAutoFormatType.Report8:
				method_18();
				break;
			case PivotTableAutoFormatType.Report9:
				method_19();
				break;
			case PivotTableAutoFormatType.Report10:
				method_20();
				break;
			case PivotTableAutoFormatType.Table1:
				method_21();
				break;
			case PivotTableAutoFormatType.Table2:
				method_22();
				break;
			case PivotTableAutoFormatType.Table3:
				method_23();
				break;
			case PivotTableAutoFormatType.Table4:
				method_24();
				break;
			case PivotTableAutoFormatType.Table5:
				method_25();
				break;
			case PivotTableAutoFormatType.Table6:
				method_26();
				break;
			case PivotTableAutoFormatType.Table7:
				method_27();
				break;
			case PivotTableAutoFormatType.Table8:
				method_28();
				break;
			case PivotTableAutoFormatType.Table9:
				method_29();
				break;
			case PivotTableAutoFormatType.Table10:
				method_30();
				break;
			}
		}
		if (bool_10)
		{
			method_41(pivotTable_0.style_1, hashtable_3, pivotTable_0.PageFields.Count, 2);
		}
		method_41(pivotTable_0.style_0, hashtable_2, int_8, int_9);
	}

	private void method_11()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_207(worksheets);
		method_50(style_);
		method_51(style_);
		Style style_2 = Class1138.smethod_208(worksheets);
		method_46(style_2);
		Style style_3 = Class1138.smethod_209(worksheets);
		method_34(style_3);
		Style style_4 = Class1138.smethod_210(worksheets);
		Style style_5 = Class1138.smethod_211(worksheets);
		Style style_6 = Class1138.smethod_212(worksheets);
		Style style_7 = Class1138.smethod_213(worksheets);
		Style style_8 = Class1138.smethod_214(worksheets);
		Style style_9 = Class1138.smethod_215(worksheets);
		Style style_10 = Class1138.smethod_216(worksheets);
		Style style_11 = Class1138.smethod_217(worksheets);
		method_71(style_4, style_5, style_6, style_7, null, style_8, style_9, style_10, style_11, null, null);
		Style style_12 = Class1138.smethod_218(worksheets);
		method_75(style_12);
		Style style_13 = Class1138.smethod_219(worksheets);
		method_74(style_13);
	}

	private void method_12()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_231(worksheets);
		method_49(style_);
		Style style_2 = Class1138.smethod_220(worksheets);
		method_50(style_2);
		method_51(style_2);
		Style style_3 = Class1138.smethod_221(worksheets);
		method_46(style_3);
		Style style_4 = Class1138.smethod_222(worksheets);
		method_34(style_4);
		Style style_5 = Class1138.smethod_232(worksheets);
		Style style_6 = Class1138.smethod_233(worksheets);
		Style style_7 = Class1138.smethod_234(worksheets);
		method_60(style_5, style_6, style_7);
		Style style_8 = Class1138.smethod_223(worksheets);
		Style style_9 = Class1138.smethod_224(worksheets);
		Style style_10 = Class1138.smethod_225(worksheets);
		Style style_11 = Class1138.smethod_226(worksheets);
		Style style_12 = Class1138.smethod_227(worksheets);
		Style style_13 = Class1138.smethod_228(worksheets);
		Style style_14 = Class1138.smethod_229(worksheets);
		method_71(style_8, null, null, style_9, null, style_10, style_11, null, style_12, style_13, style_14);
		Style style_15 = Class1138.smethod_230(worksheets);
		method_75(style_15);
	}

	private void method_13()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_235(worksheets);
		method_50(style_);
		method_51(style_);
		Style style_2 = Class1138.smethod_236(worksheets);
		method_46(style_2);
		Style style_3 = Class1138.smethod_237(worksheets);
		method_34(style_3);
		Style style = Class1138.smethod_238(worksheets);
		Style style_4 = Class1138.smethod_239(worksheets);
		Style style2 = Class1138.smethod_240(worksheets);
		Style style_5 = Class1138.smethod_241(worksheets);
		Style style_6 = Class1138.smethod_242(worksheets);
		Style style_7 = Class1138.smethod_243(worksheets);
		method_71(style, style_4, style, style2, null, style2, style_5, style_6, style_7, null, null);
		Style style_8 = Class1138.smethod_244(worksheets);
		method_75(style_8);
	}

	private void method_14()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_245(worksheets);
		method_50(style_);
		method_51(style_);
		Style style_2 = Class1138.smethod_246(worksheets);
		method_46(style_2);
		Style style_3 = Class1138.smethod_247(worksheets);
		method_34(style_3);
		Style style_4 = Class1138.smethod_248(worksheets);
		Style style_5 = Class1138.smethod_249(worksheets);
		Style style_6 = Class1138.smethod_250(worksheets);
		method_60(style_4, style_5, style_6);
		Style style_7 = Class1138.smethod_251(worksheets);
		Style style_8 = Class1138.smethod_252(worksheets);
		Style style_9 = Class1138.smethod_253(worksheets);
		Style style_10 = Class1138.smethod_254(worksheets);
		Style style_11 = Class1138.smethod_255(worksheets);
		Style style_12 = Class1138.smethod_256(worksheets);
		method_71(style_7, null, null, style_8, null, null, style_9, null, style_10, style_11, style_12);
		Style style_13 = Class1138.smethod_257(worksheets);
		method_75(style_13);
	}

	private void method_15()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_258(worksheets);
		method_50(style_);
		method_51(style_);
		Style style_2 = Class1138.smethod_259(worksheets);
		method_46(style_2);
		Style style_3 = Class1138.smethod_260(worksheets);
		method_34(style_3);
		Style style_4 = Class1138.smethod_261(worksheets);
		Style style_5 = Class1138.smethod_262(worksheets);
		Style style_6 = Class1138.smethod_263(worksheets);
		method_60(style_4, style_5, style_6);
		Style style_7 = Class1138.smethod_264(worksheets);
		Style style_8 = Class1138.smethod_265(worksheets);
		Style style_9 = Class1138.smethod_266(worksheets);
		Style style_10 = Class1138.smethod_267(worksheets);
		Style style_11 = Class1138.smethod_268(worksheets);
		Style style_12 = Class1138.smethod_269(worksheets);
		Style style_13 = Class1138.smethod_270(worksheets);
		method_71(style_7, null, null, style_8, null, style_9, style_10, null, style_11, style_12, style_13);
		Style style_14 = Class1138.smethod_271(worksheets);
		method_75(style_14);
	}

	private void method_16()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_272(worksheets);
		method_49(style_);
		Style style_2 = Class1138.smethod_273(worksheets);
		method_50(style_2);
		method_51(style_2);
		Style style_3 = Class1138.smethod_274(worksheets);
		method_46(style_3);
		Style style_4 = Class1138.smethod_275(worksheets);
		method_34(style_4);
		Style style_5 = Class1138.smethod_276(worksheets);
		Style style_6 = Class1138.smethod_277(worksheets);
		Style style_7 = Class1138.smethod_278(worksheets);
		Style style_8 = Class1138.smethod_279(worksheets);
		Style style_9 = Class1138.smethod_280(worksheets);
		Style style_10 = Class1138.smethod_281(worksheets);
		Style style_11 = Class1138.smethod_282(worksheets);
		Style style_12 = Class1138.smethod_283(worksheets);
		Style style_13 = Class1138.smethod_284(worksheets);
		Style style_14 = Class1138.smethod_285(worksheets);
		method_71(style_5, style_6, style_7, style_8, style_9, style_10, style_11, null, style_12, style_13, style_14);
		Style style_15 = Class1138.smethod_286(worksheets);
		method_75(style_15);
	}

	private void method_17()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_287(worksheets);
		method_49(style_);
		Style style_2 = Class1138.smethod_288(worksheets);
		method_50(style_2);
		method_51(style_2);
		Style style_3 = Class1138.smethod_289(worksheets);
		method_46(style_3);
		Style style_4 = Class1138.smethod_290(worksheets);
		method_34(style_4);
		Style style_5 = Class1138.smethod_291(worksheets);
		Style style_6 = Class1138.smethod_292(worksheets);
		Style style_7 = Class1138.smethod_293(worksheets);
		method_60(style_5, style_6, style_7);
		Style style_8 = Class1138.smethod_294(worksheets);
		Style style_9 = Class1138.smethod_295(worksheets);
		Style style_10 = Class1138.smethod_296(worksheets);
		Style style_11 = Class1138.smethod_297(worksheets);
		Style style_12 = Class1138.smethod_298(worksheets);
		Style style_13 = Class1138.smethod_299(worksheets);
		method_71(style_8, null, null, style_9, null, null, style_10, null, style_11, style_12, style_13);
		Style style_14 = Class1138.smethod_300(worksheets);
		method_75(style_14);
	}

	private void method_18()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_301(worksheets);
		method_50(style_);
		method_51(style_);
		Style style_2 = Class1138.smethod_302(worksheets);
		method_46(style_2);
		Style style_3 = Class1138.smethod_303(worksheets);
		method_34(style_3);
		Style style_4 = Class1138.smethod_304(worksheets);
		Style style_5 = Class1138.smethod_305(worksheets);
		Style style_6 = Class1138.smethod_306(worksheets);
		method_62(style_4, TableStyleElementType.FirstSubtotalRow, style_5, TableStyleElementType.ThirdSubtotalRow, style_6, TableStyleElementType.SecondSubtotalRow);
		Style style_7 = Class1138.smethod_307(worksheets);
		Style style_8 = Class1138.smethod_308(worksheets);
		Style style_9 = Class1138.smethod_308(worksheets);
		Style style_10 = Class1138.smethod_309(worksheets);
		Style style_11 = Class1138.smethod_310(worksheets);
		Style style_12 = Class1138.smethod_311(worksheets);
		Style style_13 = Class1138.smethod_312(worksheets);
		method_71(style_7, null, null, style_8, null, style_9, style_10, null, style_11, style_12, style_13);
		Style style_14 = Class1138.smethod_313(worksheets);
		method_75(style_14);
	}

	private void method_19()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_314(worksheets);
		method_50(style_);
		method_51(style_);
		Style style_2 = Class1138.smethod_315(worksheets);
		method_46(style_2);
		Style style_3 = Class1138.smethod_316(worksheets);
		method_34(style_3);
		Style style = Class1138.smethod_317(worksheets);
		Style style_4 = Class1138.smethod_318(worksheets);
		Style style_5 = Class1138.smethod_319(worksheets);
		Style style_6 = Class1138.smethod_320(worksheets);
		Style style_7 = Class1138.smethod_321(worksheets);
		Style style_8 = Class1138.smethod_322(worksheets);
		method_71(style, style, null, style_4, style_5, null, style_6, style_7, null, style_8, null);
		Style style_9 = Class1138.smethod_323(worksheets);
		method_75(style_9);
	}

	private void method_20()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_337(worksheets);
		method_49(style_);
		Style style_2 = Class1138.smethod_324(worksheets);
		method_50(style_2);
		method_51(style_2);
		Style style_3 = Class1138.smethod_325(worksheets);
		method_46(style_3);
		Style style_4 = Class1138.smethod_326(worksheets);
		method_34(style_4);
		Style style_5 = Class1138.smethod_327(worksheets);
		Style style_6 = Class1138.smethod_328(worksheets);
		Style style_7 = Class1138.smethod_329(worksheets);
		Style style_8 = Class1138.smethod_330(worksheets);
		Style style_9 = Class1138.smethod_331(worksheets);
		Style style = Class1138.smethod_332(worksheets);
		Style style_10 = Class1138.smethod_333(worksheets);
		Style style_11 = Class1138.smethod_334(worksheets);
		Style style_12 = Class1138.smethod_335(worksheets);
		method_71(style_5, null, style_6, style_7, style_8, style_9, style, style, style_10, style_11, style_12);
		Style style_13 = Class1138.smethod_336(worksheets);
		method_75(style_13);
	}

	private void method_21()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_12(worksheets);
		method_49(style_);
		Style style_2 = Class1138.smethod_7(worksheets);
		method_50(style_2);
		Style style_3 = Class1138.smethod_17(worksheets);
		method_45(style_3);
		Style style_4 = Class1138.smethod_18(worksheets);
		method_46(style_4);
		Style style_5 = Class1138.smethod_4(worksheets);
		method_55(style_5);
		Style style_6 = Class1138.smethod_3(worksheets);
		method_54(style_6);
		Style style_7 = Class1138.smethod_13(worksheets);
		method_56(style_7);
		Style style = Class1138.smethod_19(worksheets);
		method_57(style, style, style);
		Style style_8 = Class1138.smethod_8(worksheets);
		int num = pivotTable_0.int_6 - pivotTable_0.int_2;
		int num2 = 0;
		if (pivotTable_0.ColumnFields.Count > 0)
		{
			num2 = 1;
		}
		for (int i = num; i < int_9; i++)
		{
			Class1686 class1686_ = new Class1686();
			Class1627.ApplyStyle(pivotTable_0.style_0[num2, i], style_8, class1686_, 22, hashtable_2[num2, i]);
		}
		Style style_9 = Class1138.smethod_9(worksheets);
		Style style2 = Class1138.smethod_10(worksheets);
		Style style_10 = style2;
		method_65(style_9, style2, style_10);
		Class1138.smethod_11(worksheets);
		method_48(style_);
		Style style_11 = Class1138.smethod_14(worksheets);
		method_47(style_11);
		bool flag = method_40(pivotTable_0.RowFields);
		Style style3 = Class1138.smethod_15(worksheets, flag);
		Style style_12 = Class1138.smethod_16(worksheets, flag);
		Style style_13 = style3;
		method_67(style3, style_12, style_13);
		Style style_14 = Class1138.smethod_21(worksheets);
		Style style_15 = Class1138.smethod_22(worksheets);
		Style style_16 = Class1138.smethod_23(worksheets);
		method_60(style_14, style_15, style_16);
		if (flag)
		{
			Style style_17 = Class1138.smethod_205(worksheets);
			method_68(style_17);
		}
		Style style_18 = Class1138.smethod_5(worksheets);
		method_33(style_18);
		Style style_19 = Class1138.smethod_25(worksheets);
		method_72(style_19);
		Style style_20 = Class1138.smethod_24(worksheets);
		method_59(style_20);
		Style style_21 = Class1138.smethod_26(worksheets);
		method_75(style_21);
	}

	private void method_22()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_29(worksheets);
		method_49(style_);
		Style style_2 = Class1138.smethod_28(worksheets);
		method_55(style_2);
		Style style_3 = Class1138.smethod_27(worksheets);
		method_54(style_3);
		Style style_4 = Class1138.smethod_30(worksheets);
		method_45(style_4);
		Style style_5 = Class1138.smethod_31(worksheets);
		method_46(style_5);
		Style style_6 = Class1138.smethod_32(worksheets);
		method_56(style_6);
		Style style = Class1138.smethod_36(worksheets);
		method_57(style, style, style);
		Style style_7 = Class1138.smethod_33(worksheets);
		int num = pivotTable_0.int_6 - pivotTable_0.int_2;
		int num2 = 0;
		if (pivotTable_0.ColumnFields.Count > 0)
		{
			num2 = 1;
		}
		for (int i = num; i < int_9; i++)
		{
			Class1686 class1686_ = new Class1686();
			Class1627.ApplyStyle(pivotTable_0.style_0[num2, i], style_7, class1686_, 22, hashtable_2[num2, i]);
		}
		Style style_8 = Class1138.smethod_34(worksheets);
		Style style2 = Class1138.smethod_35(worksheets);
		Style style_9 = style2;
		method_65(style_8, style2, style_9);
		bool flag = method_40(pivotTable_0.RowFields);
		Style style3 = Class1138.smethod_38(worksheets, flag);
		Style style_10 = Class1138.smethod_39(worksheets, flag);
		Style style_11 = style3;
		method_67(style3, style_10, style_11);
		Style style_12 = Class1138.smethod_37(worksheets);
		method_47(style_12);
		Style style_13 = Class1138.smethod_44(worksheets);
		method_72(style_13);
		if (flag)
		{
			Style style_14 = Class1138.smethod_205(worksheets);
			method_68(style_14);
		}
		Style style_15 = Class1138.smethod_5(worksheets);
		method_33(style_15);
		Style style_16 = Class1138.smethod_40(worksheets);
		Style style_17 = Class1138.smethod_41(worksheets);
		Style style_18 = Class1138.smethod_42(worksheets);
		method_60(style_16, style_17, style_18);
		Style style_19 = Class1138.smethod_43(worksheets);
		method_75(style_19);
	}

	private void method_23()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_45(worksheets);
		method_49(style_);
		Style style_2 = Class1138.smethod_46(worksheets);
		method_50(style_2);
		Style style_3 = Class1138.smethod_47(worksheets);
		method_54(style_3);
		Style style_4 = Class1138.smethod_48(worksheets);
		method_56(style_4);
		Style style_5 = Class1138.smethod_49(worksheets);
		method_46(style_5);
		Style style_6 = Class1138.smethod_50(worksheets);
		method_45(style_6);
		Style style = Class1138.smethod_51(worksheets);
		Style style_7 = style;
		Style style_8 = style;
		method_65(style, style_7, style_8);
		Style style_9 = Class1138.smethod_52(worksheets);
		method_47(style_9);
		Style style_10 = Class1138.smethod_53(worksheets);
		Style style2 = Class1138.smethod_54(worksheets);
		Style style_11 = style2;
		method_60(style_10, style2, style_11);
		Style style_12 = Class1138.smethod_1(worksheets);
		method_37(style_12);
		Style style_13 = Class1138.smethod_0(worksheets);
		method_38(style_13);
		Style style_14 = Class1138.smethod_0(worksheets);
		method_35(style_14);
		Style style_15 = Class1138.smethod_59(worksheets);
		method_75(style_15);
		Style style_16 = Class1138.smethod_64(worksheets);
		method_72(style_16);
		Style style_17 = Class1138.smethod_63(worksheets);
		method_42(style_17, bool_11: false);
		int num = pivotTable_0.int_5 - pivotTable_0.int_0;
		if (pivotTable_0.ColumnFields.Count >= 2)
		{
			int num2 = pivotTable_0.int_6 - pivotTable_0.int_2;
			int num3 = num2;
			int i = num2;
			bool flag = true;
			while (num3 < int_9)
			{
				string text = (string)hashtable_1[num3 - num2];
				if (text != null && text.StartsWith("columnsubtitle"))
				{
					int[] array = method_80(text.Substring("columnsubtitle".Length).Split('+'));
					if (array[0] == 1)
					{
						if (!flag)
						{
							flag = true;
						}
						else
						{
							flag = false;
							for (i = num3 + 1; i < int_9; i++)
							{
								text = (string)hashtable_1[i - num2];
								if (text == null)
								{
									continue;
								}
								if (text == "columnsubtotal1")
								{
									break;
								}
								if (text.StartsWith("columnsubtitle"))
								{
									array = method_80(text.Substring("columnsubtitle".Length).Split('+'));
									if (array[0] == 1)
									{
										break;
									}
								}
							}
							if (i == int_9)
							{
								i = int_9 - 1;
							}
							Style style_18 = Class1138.smethod_55(worksheets);
							Style style3 = Class1138.smethod_56(worksheets);
							Style style4 = Class1138.smethod_57(worksheets);
							Style style5 = null;
							for (int j = num3; j < i; j++)
							{
								Class1686 class1686_ = new Class1686();
								Class1627.ApplyStyle(pivotTable_0.style_0[1, j], style_18, class1686_, 3, hashtable_2[1, j]);
								num = pivotTable_0.int_5 - pivotTable_0.int_0;
								text = (string)hashtable_1[j - num2];
								style5 = ((text == null || !text.StartsWith("columnsubtitle")) ? style4 : style3);
								for (int k = num; k < int_8; k++)
								{
									string text2 = (string)hashtable_0[k - num];
									if (text2 == null || !(text2 == "blank"))
									{
										Class1627.ApplyStyle(pivotTable_0.style_0[k, j], style5, class1686_, 3, hashtable_2[k, j]);
									}
								}
							}
						}
					}
				}
				i++;
				num3 = i;
			}
		}
		num = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int l = num; l < int_8; l++)
		{
			string text3 = (string)hashtable_0[l - num];
			if (text3 == null || !text3.StartsWith("rowsubtitle"))
			{
				continue;
			}
			int[] array2 = method_80(text3.Substring("rowsubtitle".Length).Split('+'));
			if (array2[0] == 1)
			{
				Style style_19 = Class1138.smethod_60(worksheets);
				for (int m = 0; m < int_9; m++)
				{
					Class1686 @class = new Class1686();
					@class.bool_0 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[l, m], style_19, @class, int_5, hashtable_2[l, m]);
				}
			}
			if (array2[array2.Length - 1] == pivotTable_0.RowFields.Count)
			{
				Style style_20 = Class1138.smethod_61(worksheets);
				for (int n = pivotTable_0.int_6 - pivotTable_0.int_2; n < int_9; n++)
				{
					Class1686 class2 = new Class1686();
					method_82(class2, n, pivotTable_0.int_6 - pivotTable_0.int_2, int_9 - 1);
					class2.bool_1 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[l, n], style_20, class2, 0, hashtable_2[l, n]);
				}
			}
		}
		if (pivotTable_0.ColumnFields.Count >= 3)
		{
			int num4 = pivotTable_0.int_6 - pivotTable_0.int_2;
			int num5 = num4;
			int num6 = num4;
			while (num5 < int_9)
			{
				string text4 = (string)hashtable_1[num5 - num4];
				if (text4 != null && text4.StartsWith("columnsubtitle"))
				{
					int[] array3 = method_80(text4.Substring("columnsubtitle".Length).Split('+'));
					if (array3[0] == 2 || (array3.Length >= 2 && array3[1] == 2))
					{
						for (num6 = num5 + 1; num6 < int_9; num6++)
						{
							text4 = (string)hashtable_1[num6 - num4];
							if (text4 == null)
							{
								continue;
							}
							if (text4 == "columnsubtotal2")
							{
								break;
							}
							if (text4.StartsWith("columnsubtitle"))
							{
								array3 = method_80(text4.Substring("columnsubtitle".Length).Split('+'));
								if (array3[0] == 2 || (array3.Length >= 2 && array3[1] == 2))
								{
									break;
								}
							}
						}
						if (num6 == int_9)
						{
							num6 = int_9 - 1;
						}
						Style style_21 = Class1138.smethod_58(worksheets);
						for (int num7 = num5; num7 < num6; num7++)
						{
							Class1686 class3 = new Class1686();
							class3.bool_2 = true;
							Class1627.ApplyStyle(pivotTable_0.style_0[2, num7], style_21, class3, int_5, hashtable_2[1, num7]);
							num = pivotTable_0.int_5 - pivotTable_0.int_0;
							for (int num8 = num; num8 < int_8; num8++)
							{
								Class1627.ApplyStyle(pivotTable_0.style_0[num8, num7], style_21, class3, int_5, hashtable_2[num8, num7]);
							}
						}
					}
				}
				num6++;
				num5 = num6;
			}
		}
		if (pivotTable_0.RowFields.Count < 3)
		{
			return;
		}
		int num9 = (pivotTable_0.RowFields.Count - 1) / 2;
		ArrayList arrayList = new ArrayList();
		int num10 = -1;
		for (int num11 = 0; num11 < num9; num11++)
		{
			num10 += 2;
			arrayList.Add(num10);
		}
		for (int num12 = num; num12 < int_8; num12++)
		{
			string text5 = (string)hashtable_0[num12 - num];
			if (text5 == null || !text5.StartsWith("rowsubtitle"))
			{
				continue;
			}
			int[] array4 = method_80(text5.Substring("rowsubtitle".Length).Split('+'));
			bool flag2 = false;
			for (int num13 = 0; num13 < array4.Length; num13++)
			{
				flag2 = false;
				if (array4[num13] - 1 == 0)
				{
					flag2 = true;
				}
				if (arrayList.Contains(array4[num13] - 1))
				{
					flag2 = true;
				}
				if (flag2)
				{
					Style style_22 = Class1138.smethod_62(worksheets);
					Class1686 class4 = new Class1686();
					class4.bool_2 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[num12, array4[num13] - 1], style_22, class4, int_5, hashtable_2[num12, array4[num13] - 1]);
				}
			}
		}
	}

	private void method_24()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_65(worksheets);
		method_49(style_);
		Style style_2 = Class1138.smethod_66(worksheets);
		method_50(style_2);
		Style style_3 = Class1138.smethod_3(worksheets);
		method_54(style_3);
		Style style_4 = Class1138.smethod_67(worksheets);
		method_56(style_4);
		Style style_5 = Class1138.smethod_68(worksheets);
		method_46(style_5);
		Style style_6 = Class1138.smethod_69(worksheets);
		method_45(style_6);
		Style style = Class1138.smethod_70(worksheets);
		Style style_7 = style;
		Style style_8 = style;
		method_65(style, style_7, style_8);
		Style style_9 = null;
		Style style_10 = Class1138.smethod_78(worksheets);
		Style style_11 = null;
		method_67(style_9, style_10, style_11);
		Style style_12 = Class1138.smethod_71(worksheets);
		method_47(style_12);
		Style style_13 = Class1138.smethod_72(worksheets);
		Style style_14 = Class1138.smethod_73(worksheets);
		Style style_15 = null;
		method_60(style_13, style_14, style_15);
		Style style_16 = Class1138.smethod_74(worksheets);
		method_59(style_16);
		Style style_17 = Class1138.smethod_20(worksheets);
		method_44(style_17);
		Style style_18 = Class1138.smethod_75(worksheets);
		method_75(style_18);
		Style style_19 = Class1138.smethod_77(worksheets);
		method_72(style_19);
		Style style_20 = Class1138.smethod_76(worksheets);
		method_42(style_20, bool_11: false);
		int num = pivotTable_0.int_5 - pivotTable_0.int_0;
		if (pivotTable_0.ColumnFields.Count >= 2)
		{
			int num2 = pivotTable_0.int_6 - pivotTable_0.int_2;
			int num3 = num2;
			int i = num2;
			bool flag = false;
			Style style_21 = Class1138.smethod_81(worksheets);
			while (num3 < int_9)
			{
				string text = (string)hashtable_1[num3 - num2];
				if (text != null && text.StartsWith("columnsubtitle"))
				{
					int[] array = method_80(text.Substring("columnsubtitle".Length).Split('+'));
					if (array[0] != 1)
					{
						method_39(style_21, num, num3, bool_11: false);
					}
					else if (!flag)
					{
						method_39(style_21, num, num3, bool_11: true);
						flag = true;
					}
					else
					{
						flag = false;
						for (i = num3 + 1; i < int_9; i++)
						{
							text = (string)hashtable_1[i - num2];
							if (text == null)
							{
								continue;
							}
							if (text == "columnsubtotal1")
							{
								break;
							}
							if (text.StartsWith("columnsubtitle"))
							{
								array = method_80(text.Substring("columnsubtitle".Length).Split('+'));
								if (array[0] == 1)
								{
									break;
								}
							}
						}
						if (i == int_9)
						{
							i = int_9 - 1;
						}
						Style style2 = Class1138.smethod_79(worksheets);
						Style style3 = Class1138.smethod_80(worksheets);
						Style style4 = null;
						for (int j = num3; j < i; j++)
						{
							if (j == num3)
							{
								method_39(style_21, num, j, bool_11: true);
							}
							else
							{
								method_39(style_21, num, j, bool_11: false);
							}
							Class1686 class1686_ = new Class1686();
							Class1627.ApplyStyle(pivotTable_0.style_0[1, j], style2, class1686_, 3, hashtable_2[1, j]);
							text = (string)hashtable_1[j - num2];
							style4 = ((text == null || !text.StartsWith("columnsubtitle")) ? style2 : style3);
							num = pivotTable_0.int_5 - pivotTable_0.int_0;
							for (int k = num; k < int_8; k++)
							{
								switch ((string)hashtable_0[k - num])
								{
								case "blank":
								case "rowsubtotal1":
									continue;
								}
								Class1627.ApplyStyle(pivotTable_0.style_0[k, j], style4, class1686_, 3, hashtable_2[k, j]);
							}
						}
						method_39(style_21, num, i, bool_11: false);
					}
				}
				else
				{
					method_39(style_21, num, num3, bool_11: false);
				}
				i++;
				num3 = i;
			}
		}
		for (int l = num; l < int_8; l++)
		{
			string text2 = (string)hashtable_0[l - num];
			if (text2 == null || !text2.StartsWith("rowsubtitle"))
			{
				continue;
			}
			int[] array2 = method_80(text2.Substring("rowsubtitle".Length).Split('+'));
			if (array2[0] == 1)
			{
				Style style_22 = Class1138.smethod_82(worksheets);
				for (int m = 0; m < int_9; m++)
				{
					Class1686 @class = new Class1686();
					@class.bool_0 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[l, m], style_22, @class, int_5, hashtable_2[l, m]);
				}
			}
		}
	}

	private void method_25()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_83(worksheets);
		method_50(style_);
		Style style_2 = Class1138.smethod_84(worksheets);
		method_51(style_2);
		Style style_3 = Class1138.smethod_85(worksheets);
		method_56(style_3);
		Style style_4 = Class1138.smethod_91(worksheets);
		method_46(style_4);
		Style style_5 = Class1138.smethod_92(worksheets);
		method_45(style_5);
		Style style = Class1138.smethod_86(worksheets);
		Style style_6 = style;
		Style style_7 = style;
		method_57(style, style_6, style_7);
		Style style_8 = Class1138.smethod_87(worksheets);
		int num = pivotTable_0.int_6 - pivotTable_0.int_2;
		int num2 = 0;
		if (pivotTable_0.ColumnFields.Count > 0)
		{
			num2 = 1;
		}
		for (int i = num; i < int_9; i++)
		{
			bool flag = false;
			string text = (string)hashtable_1[i - num];
			if (text != null)
			{
				if (text.StartsWith("columnsubtitle"))
				{
					int[] array = method_80(text.Substring("columnsubtitle".Length).Split('+'));
					if (array[0] == 1)
					{
						flag = true;
					}
				}
				else if (text == "columnsubtotal1")
				{
					flag = true;
				}
				else if (text == "grandtotalcolumn")
				{
					flag = true;
				}
			}
			if (flag)
			{
				Class1686 class1686_ = new Class1686();
				Class1627.ApplyStyle(pivotTable_0.style_0[num2, i], style_8, class1686_, 22, hashtable_2[num2, i]);
			}
		}
		Style style_9 = Class1138.smethod_88(worksheets);
		Style style2 = Class1138.smethod_89(worksheets);
		Style style_10 = style2;
		method_65(style_9, style2, style_10);
		Style style_11 = Class1138.smethod_90(worksheets);
		method_48(style_11);
		Style style_12 = Class1138.smethod_93(worksheets);
		method_67(style_12, null, null);
		if (pivotTable_0.RowFields.Count > 1)
		{
			num = pivotTable_0.int_6 - 1 - pivotTable_0.int_2;
			num2 = pivotTable_0.int_5 - pivotTable_0.int_0 - 1;
			Style style_13 = Class1138.smethod_99(worksheets);
			for (int j = num; j < int_9; j++)
			{
				Class1686 @class = new Class1686();
				@class.bool_1 = true;
				Class1627.ApplyStyle(pivotTable_0.style_0[num2, j], style_13, @class, 22, hashtable_2[num2, j]);
			}
		}
		Style style_14 = Class1138.smethod_0(worksheets);
		method_38(style_14);
		Style style_15 = Class1138.smethod_0(worksheets);
		method_35(style_15);
		Style style_16 = Class1138.smethod_94(worksheets);
		method_60(style_16, null, null);
		Style style3 = Class1138.smethod_95(worksheets);
		method_61(null, style3, style3);
		num = pivotTable_0.int_6 - pivotTable_0.int_2;
		int int_ = pivotTable_0.int_5 - pivotTable_0.int_0;
		Style style_17 = Class1138.smethod_96(worksheets, CellBorderType.Thin);
		Style style_18 = Class1138.smethod_96(worksheets, CellBorderType.Medium);
		Style style_19 = Class1138.smethod_96(worksheets, CellBorderType.Thick);
		method_39(style_17, int_, num, bool_11: true);
		if (pivotTable_0.ColumnFields.Count > 1)
		{
			for (int k = num; k < int_9; k++)
			{
				string text2 = (string)hashtable_1[k - num];
				if (text2 != null && text2.StartsWith("columnsubtitle"))
				{
					int[] array2 = method_80(text2.Substring("columnsubtitle".Length).Split('+'));
					if (array2[0] == 1)
					{
						method_39(style_18, 1, k, bool_11: true);
					}
					if (array2[0] == 2 || (array2.Length >= 2 && array2[1] == 2))
					{
						method_39(style_19, 2, k, bool_11: true);
					}
				}
			}
		}
		Style style_20 = Class1138.smethod_97(worksheets);
		method_72(style_20);
		Style style_21 = Class1138.smethod_98(worksheets);
		method_75(style_21);
	}

	private void method_26()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_100(worksheets);
		method_49(style_);
		Style style_2 = Class1138.smethod_101(worksheets);
		method_50(style_2);
		method_51(style_2);
		Style style_3 = Class1138.smethod_102(worksheets);
		method_54(style_3);
		Style style_4 = Class1138.smethod_103(worksheets);
		method_56(style_4);
		Style style_5 = Class1138.smethod_104(worksheets);
		method_46(style_5);
		Style style_6 = Class1138.smethod_105(worksheets);
		method_45(style_6);
		Style style_7 = Class1138.smethod_106(worksheets);
		int num = pivotTable_0.int_6 - pivotTable_0.int_2;
		int num2 = 0;
		if (pivotTable_0.ColumnFields.Count > 0)
		{
			num2 = 1;
		}
		for (int i = num; i < int_9; i++)
		{
			Class1686 class1686_ = new Class1686();
			Class1627.ApplyStyle(pivotTable_0.style_0[num2, i], style_7, class1686_, 22, hashtable_2[num2, i]);
		}
		Style style = Class1138.smethod_107(worksheets);
		method_57(style, style, style);
		Style style_8 = Class1138.smethod_108(worksheets);
		method_42(style_8, bool_11: true);
		Style style2 = Class1138.smethod_109(worksheets);
		method_67(style2, style2, style2);
		Style style_9 = Class1138.smethod_110(worksheets);
		Style style3 = Class1138.smethod_111(worksheets);
		method_60(style_9, style3, style3);
		if (method_40(pivotTable_0.RowFields))
		{
			Style style_10 = Class1138.smethod_205(worksheets);
			method_68(style_10);
		}
		Style style_11 = Class1138.smethod_116(worksheets);
		method_59(style_11);
		Style style_12 = Class1138.smethod_113(worksheets);
		method_75(style_12);
		Style style_13 = Class1138.smethod_112(worksheets);
		method_72(style_13);
		if (pivotTable_0.ColumnFields.Count <= 1)
		{
			return;
		}
		Style style_14 = Class1138.smethod_114(worksheets);
		Style style_15 = Class1138.smethod_115(worksheets);
		num = pivotTable_0.int_6 - pivotTable_0.int_2;
		for (int j = num; j < int_9; j++)
		{
			string text = (string)hashtable_1[j - num];
			if (text == null)
			{
				continue;
			}
			if (text.StartsWith("columnsubtitle"))
			{
				int[] array = method_80(text.Substring("columnsubtitle".Length).Split('+'));
				if (array[0] == 1)
				{
					method_39(style_14, 1, j, bool_11: true);
				}
			}
			else if (text == "grandtotalcolumn")
			{
				method_39(style_14, 1, j, bool_11: true);
			}
			else if (text == "columnsubtotal1")
			{
				method_39(style_15, 1, j, bool_11: true);
			}
		}
	}

	private void method_27()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_117(worksheets);
		method_50(style_);
		method_51(style_);
		Style style_2 = Class1138.smethod_118(worksheets);
		method_56(style_2);
		Style style_3 = Class1138.smethod_119(worksheets);
		method_46(style_3);
		Style style_4 = Class1138.smethod_120(worksheets);
		method_45(style_4);
		if (pivotTable_0.ColumnFields.Count >= 2)
		{
			Style style_5 = Class1138.smethod_121(worksheets);
			int num = pivotTable_0.int_6 - pivotTable_0.int_2;
			int num2 = 1;
			for (int i = num; i < int_9; i++)
			{
				switch ((string)hashtable_1[i - num])
				{
				case "columnsubtotal1":
				case "grandtotalcolumn":
					continue;
				}
				Class1686 class1686_ = new Class1686();
				Class1627.ApplyStyle(pivotTable_0.style_0[num2, i], style_5, class1686_, 22, hashtable_2[num2, i]);
			}
		}
		Style style = Class1138.smethod_122(worksheets);
		method_65(style, style, style);
		Style style_6 = Class1138.smethod_123(worksheets);
		method_48(style_6);
		Style style_7 = Class1138.smethod_124(worksheets);
		Style style_8 = Class1138.smethod_125(worksheets);
		Style style_9 = Class1138.smethod_126(worksheets);
		method_60(style_7, style_8, style_9);
		bool flag = method_40(pivotTable_0.RowFields);
		Style style2 = Class1138.smethod_127(worksheets, flag);
		Style style_10 = Class1138.smethod_128(worksheets, flag);
		method_67(style2, style2, style_10);
		Style style_11 = Class1138.smethod_1(worksheets);
		method_37(style_11);
		Style style_12 = Class1138.smethod_132(worksheets);
		method_75(style_12);
		Style style_13 = Class1138.smethod_131(worksheets);
		method_43(style_13, bool_11: false);
		Style style_14 = Class1138.smethod_130(worksheets);
		method_72(style_14);
		Style style_15 = Class1138.smethod_129(worksheets);
		method_42(style_15, bool_11: false);
		Style style_16 = Class1138.smethod_133(worksheets);
		if (pivotTable_0.RowFields.Count > 1)
		{
			method_39(style_16, pivotTable_0.int_5 - pivotTable_0.int_0, 0, bool_11: true);
		}
		if (pivotTable_0.ColumnFields.Count > 1)
		{
			int num3 = pivotTable_0.int_6 - pivotTable_0.int_2;
			for (int j = num3; j < int_9; j++)
			{
				string text = (string)hashtable_1[j - num3];
				if (text == null)
				{
					continue;
				}
				if (text.StartsWith("columnsubtitle"))
				{
					int[] array = method_80(text.Substring("columnsubtitle".Length).Split('+'));
					if (array[0] == 1)
					{
						method_39(style_16, 1, j, bool_11: true);
					}
				}
				else if (text == "columnsubtotal1")
				{
					method_39(style_16, 1, j, bool_11: true);
				}
			}
		}
		Style style_17 = Class1138.smethod_137(worksheets);
		method_59(style_17);
		if (flag)
		{
			Style style_18 = Class1138.smethod_205(worksheets);
			method_68(style_18);
		}
		Style style_19 = Class1138.smethod_134(worksheets);
		method_36(style_19);
		int num4 = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int k = num4; k < int_8; k++)
		{
			string text2 = (string)hashtable_0[k - num4];
			if (text2 != null && text2.StartsWith("rowsubtitle"))
			{
				int[] array2 = method_80(text2.Substring("rowsubtitle".Length).Split('+'));
				if (array2[0] == 1 && pivotTable_0.RowFields.Count > 1 && array2[array2.Length - 1] == pivotTable_0.RowFields.Count)
				{
					Style style_20 = Class1138.smethod_135(worksheets);
					int num5 = pivotTable_0.int_6 - 1 - pivotTable_0.int_2;
					Class1686 @class = new Class1686();
					@class.bool_2 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[k, num5], style_20, @class, int_5, hashtable_2[k, num5]);
				}
			}
		}
		if (pivotTable_0.RowFields.Count <= 2 || pivotTable_0.ColumnFields.Count <= 2)
		{
			return;
		}
		num4 = pivotTable_0.int_5 - pivotTable_0.int_0;
		int num6 = pivotTable_0.int_6 - pivotTable_0.int_2;
		style_16 = Class1138.smethod_136(worksheets);
		for (int l = num4; l < int_8; l++)
		{
			string text3 = (string)hashtable_0[l - num4];
			if (text3 == null || !text3.StartsWith("rowsubtotal"))
			{
				continue;
			}
			int num7 = int.Parse(text3.Substring("rowsubtotal".Length));
			if (num7 == 1)
			{
				continue;
			}
			for (int m = num6; m < int_9; m++)
			{
				string text4 = (string)hashtable_1[m - num6];
				if (text4 != null && text4.StartsWith("columnsubtotal"))
				{
					int num8 = int.Parse(text4.Substring("columnsubtotal".Length));
					if (num8 != 1)
					{
						Class1686 class2 = new Class1686();
						class2.bool_2 = true;
						Class1627.ApplyStyle(pivotTable_0.style_0[l, m], style_16, class2, int_5, hashtable_2[l, m]);
					}
				}
			}
		}
	}

	private void method_28()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_138(worksheets);
		method_50(style_);
		method_51(style_);
		int int_ = pivotTable_0.int_5 - pivotTable_0.int_0;
		int int_2 = pivotTable_0.int_6 - pivotTable_0.int_2;
		Style style_2 = Class1138.smethod_151(worksheets);
		method_39(style_2, int_, int_2, bool_11: true);
		method_39(style_2, int_, 0, bool_11: true);
		Style style_3 = Class1138.smethod_139(worksheets);
		method_46(style_3);
		Style style_4 = Class1138.smethod_140(worksheets);
		if (pivotTable_0.ColumnFields.Count == 1)
		{
			style_4 = Class1138.smethod_141(worksheets);
		}
		Style style = Class1138.smethod_142(worksheets);
		method_65(style_4, style, style);
		Style style_5 = Class1138.smethod_143(worksheets);
		method_42(style_5, bool_11: true);
		Style style2 = Class1138.smethod_144(worksheets);
		method_57(style2, style2, style2);
		Style style_6 = Class1138.smethod_145(worksheets);
		Style style3 = Class1138.smethod_146(worksheets);
		method_60(style_6, style3, style3);
		bool flag = method_40(pivotTable_0.RowFields);
		Style style4 = Class1138.smethod_147(worksheets, flag);
		method_67(style4, style4, style4);
		Style style_7 = Class1138.smethod_155(worksheets);
		method_59(style_7);
		Style style_8 = Class1138.smethod_1(worksheets);
		method_37(style_8);
		Style style_9 = Class1138.smethod_148(worksheets);
		method_75(style_9);
		Style style_10 = Class1138.smethod_150(worksheets);
		method_72(style_10);
		Style style_11 = Class1138.smethod_149(worksheets);
		method_73(style_11);
		if (flag)
		{
			Style style_12 = Class1138.smethod_205(worksheets);
			method_68(style_12);
		}
		if (pivotTable_0.ColumnFields.Count <= 1)
		{
			return;
		}
		style_2 = Class1138.smethod_152(worksheets);
		Style style5 = Class1138.smethod_153(worksheets);
		Style style6 = Class1138.smethod_154(worksheets);
		int int_3 = pivotTable_0.int_5 - pivotTable_0.int_0;
		if (pivotTable_0.ColumnFields.Count <= 1)
		{
			return;
		}
		int_2 = pivotTable_0.int_6 - pivotTable_0.int_2;
		for (int i = int_2; i < int_9; i++)
		{
			string text = (string)hashtable_1[i - int_2];
			if (text == null)
			{
				continue;
			}
			if (text.StartsWith("columnsubtitle"))
			{
				int[] array = method_80(text.Substring("columnsubtitle".Length).Split('+'));
				if (array[0] == 1)
				{
					method_39(style_2, 1, i, bool_11: true);
				}
				if (pivotTable_0.ColumnFields.Count >= 3 && array[1] == 2)
				{
					Class1686 @class = new Class1686();
					@class.bool_2 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[2, i], style5, @class, int_5, hashtable_2[2, i]);
				}
				if (pivotTable_0.ColumnFields.Count >= 4 && (array[2] == 3 || array[1] == 3))
				{
					Class1686 class2 = new Class1686();
					class2.bool_2 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[3, i], style6, class2, int_5, hashtable_2[3, i]);
				}
				if (pivotTable_0.ColumnFields.Count >= 3 && array[0] == 2)
				{
					Class1686 class3 = new Class1686();
					class3.bool_2 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[2, i], style5, class3, int_5, hashtable_2[2, i]);
					method_39(style5, int_3, i, bool_11: true);
				}
				if (pivotTable_0.ColumnFields.Count >= 4 && array[0] == 3)
				{
					Class1686 class4 = new Class1686();
					class4.bool_2 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[3, i], style6, class4, int_5, hashtable_2[3, i]);
					method_39(style6, int_3, i, bool_11: true);
				}
			}
			else if (text == "columnsubtotal1")
			{
				method_39(style_2, 1, i, bool_11: true);
			}
		}
	}

	private void method_29()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_156(worksheets);
		method_50(style_);
		method_51(style_);
		Style style_2 = Class1138.smethod_6(worksheets);
		method_55(style_2);
		Style style_3 = Class1138.smethod_157(worksheets);
		method_56(style_3);
		Style style_4 = Class1138.smethod_158(worksheets);
		method_46(style_4);
		Style style_5 = Class1138.smethod_159(worksheets);
		method_45(style_5);
		int num = pivotTable_0.int_6 - pivotTable_0.int_2;
		if (pivotTable_0.ColumnFields.Count >= 2)
		{
			Style style_6 = Class1138.smethod_160(worksheets);
			int num2 = 1;
			for (int i = num; i < int_9; i++)
			{
				string text = (string)hashtable_1[i - num];
				if (text != null && text.StartsWith("columnsubtitle"))
				{
					int[] array = method_80(text.Substring("columnsubtitle".Length).Split('+'));
					if (array[0] == 1)
					{
						Class1686 class1686_ = new Class1686();
						Class1627.ApplyStyle(pivotTable_0.style_0[num2, i], style_6, class1686_, 22, hashtable_2[num2, i]);
					}
				}
			}
		}
		Style style_7 = Class1138.smethod_161(worksheets);
		Style style = Class1138.smethod_162(worksheets);
		method_65(style_7, style, style);
		Style style_8 = Class1138.smethod_175(worksheets);
		method_59(style_8);
		Style style_9 = Class1138.smethod_163(worksheets);
		method_48(style_9);
		Style style2 = Class1138.smethod_164(worksheets);
		method_57(style2, style2, style2);
		int int_ = pivotTable_0.int_5 - pivotTable_0.int_0;
		num = pivotTable_0.int_6 - pivotTable_0.int_2;
		Style style_10 = Class1138.smethod_165(worksheets);
		method_39(style_10, int_, num, bool_11: true);
		method_39(style_10, int_, 0, bool_11: true);
		Style style_11 = Class1138.smethod_166(worksheets);
		Style style_12 = Class1138.smethod_167(worksheets);
		Style style_13 = Class1138.smethod_168(worksheets);
		method_60(style_11, style_12, style_13);
		bool flag = method_40(pivotTable_0.RowFields);
		Style style_14 = Class1138.smethod_169(worksheets, flag);
		Style style3 = Class1138.smethod_170(worksheets, flag);
		method_67(style_14, style3, style3);
		if (flag)
		{
			Style style_15 = Class1138.smethod_205(worksheets);
			method_68(style_15);
		}
		Style style_16 = Class1138.smethod_1(worksheets);
		method_37(style_16);
		Style style_17 = Class1138.smethod_173(worksheets);
		method_75(style_17);
		Style style_18 = Class1138.smethod_172(worksheets);
		method_72(style_18);
		Style style_19 = Class1138.smethod_171(worksheets);
		method_42(style_19, bool_11: false);
		if (pivotTable_0.ColumnFields.Count <= 1)
		{
			return;
		}
		Style style4 = Class1138.smethod_174(worksheets);
		num = pivotTable_0.int_6 - pivotTable_0.int_2;
		for (int j = num; j < int_9; j++)
		{
			string text2 = (string)hashtable_1[j - num];
			if (text2 == null)
			{
				continue;
			}
			if (text2.StartsWith("columnsubtitle"))
			{
				int[] array2 = method_80(text2.Substring("columnsubtitle".Length).Split('+'));
				if (array2[0] != pivotTable_0.ColumnFields.Count)
				{
					method_39(style4, array2[0], j, bool_11: true);
					continue;
				}
				Class1686 @class = new Class1686();
				@class.bool_2 = true;
				Class1627.ApplyStyle(pivotTable_0.style_0[array2[0], j], style4, @class, int_5, hashtable_2[array2[0], j]);
			}
			else if (text2 == "columnsubtotal1")
			{
				method_39(style4, 1, j, bool_11: true);
			}
		}
	}

	private void method_30()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_176(worksheets);
		method_50(style_);
		method_51(style_);
		Style style_2 = Class1138.smethod_177(worksheets);
		method_56(style_2);
		Style style_3 = Class1138.smethod_178(worksheets);
		method_46(style_3);
		Style style_4 = Class1138.smethod_179(worksheets);
		method_45(style_4);
		Style style_5 = Class1138.smethod_180(worksheets);
		int num = pivotTable_0.int_6 - pivotTable_0.int_2;
		int num2 = 0;
		if (pivotTable_0.ColumnFields.Count > 0)
		{
			num2 = 1;
		}
		for (int i = num; i < int_9; i++)
		{
			Class1686 class1686_ = new Class1686();
			Class1627.ApplyStyle(pivotTable_0.style_0[num2, i], style_5, class1686_, 22, hashtable_2[num2, i]);
		}
		Style style = Class1138.smethod_181(worksheets);
		method_65(style, style, style);
		Style style_6 = Class1138.smethod_182(worksheets);
		method_59(style_6);
		Style style_7 = Class1138.smethod_183(worksheets);
		method_48(style_7);
		Style style2 = Class1138.smethod_184(worksheets);
		method_57(style2, style2, style2);
		int int_ = pivotTable_0.int_5 - pivotTable_0.int_0;
		num = pivotTable_0.int_6 - pivotTable_0.int_2;
		Style style_8 = Class1138.smethod_185(worksheets);
		method_39(style_8, int_, num, bool_11: true);
		method_39(style_8, int_, 0, bool_11: true);
		Style style_9 = Class1138.smethod_186(worksheets);
		Style style3 = Class1138.smethod_187(worksheets);
		method_60(style_9, style3, style3);
		bool flag = method_40(pivotTable_0.RowFields);
		Style style4 = Class1138.smethod_188(worksheets, flag);
		method_67(style4, style4, style4);
		if (flag)
		{
			Style style_10 = Class1138.smethod_205(worksheets);
			method_68(style_10);
		}
		Style style_11 = Class1138.smethod_1(worksheets);
		method_37(style_11);
		Style style_12 = Class1138.smethod_189(worksheets);
		method_75(style_12);
		Style style_13 = Class1138.smethod_190(worksheets);
		method_72(style_13);
		if (pivotTable_0.ColumnFields.Count <= 1)
		{
			return;
		}
		style_8 = Class1138.smethod_185(worksheets);
		Style style5 = Class1138.smethod_191(worksheets);
		Style style6 = Class1138.smethod_192(worksheets);
		num2 = pivotTable_0.int_5 - pivotTable_0.int_0;
		if (pivotTable_0.ColumnFields.Count <= 1)
		{
			return;
		}
		num = pivotTable_0.int_6 - pivotTable_0.int_2;
		for (int j = num; j < int_9; j++)
		{
			string text = (string)hashtable_1[j - num];
			if (text == null)
			{
				continue;
			}
			if (text.StartsWith("columnsubtitle"))
			{
				int[] array = method_80(text.Substring("columnsubtitle".Length).Split('+'));
				if (array[0] == 1)
				{
					method_39(style_8, 1, j, bool_11: true);
				}
				if (pivotTable_0.ColumnFields.Count >= 3 && array[1] == 2)
				{
					Class1686 @class = new Class1686();
					@class.bool_2 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[2, j], style5, @class, int_5, hashtable_2[2, j]);
				}
				if (pivotTable_0.ColumnFields.Count >= 4 && (array[2] == 3 || array[1] == 3))
				{
					Class1686 class2 = new Class1686();
					class2.bool_2 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[3, j], style6, class2, int_5, hashtable_2[3, j]);
				}
				if (pivotTable_0.ColumnFields.Count >= 3 && array[0] == 2)
				{
					Class1686 class3 = new Class1686();
					class3.bool_2 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[2, j], style5, class3, int_5, hashtable_2[2, j]);
					method_39(style5, num2, j, bool_11: true);
				}
				if (pivotTable_0.ColumnFields.Count >= 4 && array[0] == 3)
				{
					Class1686 class4 = new Class1686();
					class4.bool_2 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[3, j], style6, class4, int_5, hashtable_2[3, j]);
					method_39(style6, num2, j, bool_11: true);
				}
			}
			else if (text == "columnsubtotal1")
			{
				method_39(style_8, 1, j, bool_11: true);
			}
		}
	}

	private void method_31()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_193(worksheets);
		method_49(style_);
		Style style_2 = Class1138.smethod_194(worksheets);
		method_50(style_2);
		Style style_3 = Class1138.smethod_195(worksheets);
		method_56(style_3);
		Style style_4 = Class1138.smethod_4(worksheets);
		method_55(style_4);
		Style style_5 = Class1138.smethod_3(worksheets);
		method_54(style_5);
		Style style_6 = Class1138.smethod_196(worksheets);
		method_46(style_6);
		Style style_7 = Class1138.smethod_197(worksheets);
		method_45(style_7);
		Style style = Class1138.smethod_198(worksheets);
		method_65(style, style, style);
		Style style_8 = Class1138.smethod_199(worksheets);
		method_59(style_8);
		Style style2 = Class1138.smethod_200(worksheets);
		method_57(style2, style2, style2);
		Style style3 = Class1138.smethod_201(worksheets);
		method_60(style3, style3, style3);
		bool flag = method_40(pivotTable_0.RowFields);
		Style style4 = Class1138.smethod_202(worksheets, flag);
		method_67(style4, style4, style4);
		if (flag)
		{
			Style style_9 = Class1138.smethod_205(worksheets);
			method_68(style_9);
		}
		Style style_10 = Class1138.smethod_203(worksheets);
		method_75(style_10);
		Style style_11 = Class1138.smethod_204(worksheets);
		method_72(style_11);
		Style style_12 = Class1138.smethod_5(worksheets);
		method_33(style_12);
	}

	private void method_32()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		Style style_ = Class1138.smethod_206(worksheets);
		method_50(style_);
		method_51(style_);
	}

	private void method_33(Style style_0)
	{
		if (pivotTable_0.ColumnFields.Count <= 1)
		{
			return;
		}
		int num = pivotTable_0.int_6 - pivotTable_0.int_2;
		for (int i = num; i < int_9; i++)
		{
			string text = (string)hashtable_1[i - num];
			if (text != null && text.StartsWith("columnsubtitle"))
			{
				int[] array = method_80(text.Substring("columnsubtitle".Length).Split('+'));
				if (array[0] == 1)
				{
					method_39(style_0, 1, i, bool_11: true);
				}
			}
		}
	}

	private void method_34(Style style_0)
	{
		Class1686 @class = new Class1686();
		@class.bool_0 = true;
		@class.bool_1 = true;
		@class.bool_2 = true;
		@class.bool_3 = true;
		Class1627.ApplyStyle(pivotTable_0.style_0[0, int_9 - 1], style_0, @class, int_5, hashtable_2[0, int_9 - 1]);
	}

	private void method_35(Style style_0)
	{
		if (pivotTable_0.RowFields.Count <= 0)
		{
			return;
		}
		int num = pivotTable_0.int_6 - 1 - pivotTable_0.int_2;
		int num2 = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int i = num2; i < int_9; i++)
		{
			string text = (string)hashtable_0[i - num2];
			if (text != null && text.StartsWith("rowsubtitle"))
			{
				int[] array = method_80(text.Substring("rowsubtitle".Length).Split('+'));
				if (array[array.Length - 1] == pivotTable_0.RowFields.Count)
				{
					Class1686 class1686_ = new Class1686();
					Class1627.ApplyStyle(pivotTable_0.style_0[i, num], style_0, class1686_, int_5, hashtable_2[i, num]);
				}
			}
		}
	}

	private void method_36(Style style_0)
	{
		if (pivotTable_0.RowFields.Count <= 1)
		{
			return;
		}
		int num = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int i = num; i < int_8; i++)
		{
			string text = (string)hashtable_0[i - num];
			if (text == null || !text.StartsWith("rowsubtitle"))
			{
				continue;
			}
			int[] array = method_80(text.Substring("rowsubtitle".Length).Split('+'));
			if (array[0] == 1)
			{
				for (int j = 0; j < int_9; j++)
				{
					Class1686 @class = new Class1686();
					@class.bool_0 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[i, j], style_0, @class, int_5, hashtable_2[i, j]);
				}
			}
		}
	}

	private void method_37(Style style_0)
	{
		int num = pivotTable_0.int_6 - pivotTable_0.int_2;
		int num2 = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int i = num; i < int_9; i++)
		{
			string text = (string)hashtable_1[i - num];
			if (text != null && text.StartsWith("columnsubtitle"))
			{
				for (int j = num2; j < int_8; j++)
				{
					Class1686 class1686_ = new Class1686();
					Class1627.ApplyStyle(pivotTable_0.style_0[j, i], style_0, class1686_, int_5, hashtable_2[j, i]);
				}
			}
		}
	}

	private void method_38(Style style_0)
	{
		int num = pivotTable_0.int_6 - pivotTable_0.int_2;
		int num2 = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int i = num; i < int_9; i++)
		{
			for (int j = num2; j < int_8; j++)
			{
				string text = (string)hashtable_0[j - num2];
				if (text == null || (!text.StartsWith("rowsubtotal") && !(text == "grandtotalrow")))
				{
					Class1686 class1686_ = new Class1686();
					Class1627.ApplyStyle(pivotTable_0.style_0[j, i], style_0, class1686_, int_5, hashtable_2[j, i]);
				}
			}
		}
	}

	private void method_39(Style style_0, int int_12, int int_13, bool bool_11)
	{
		int num = int_8 - 1;
		if (!bool_11 && pivotTable_0.ColumnGrand)
		{
			if (pivotFieldType_0 == PivotFieldType.Row)
			{
				if (pivotTable_0.RowFields.Count > 1)
				{
					num -= pivotTable_0.DataFields.Count;
				}
			}
			else
			{
				num--;
			}
		}
		for (int i = int_12; i <= num; i++)
		{
			Class1686 @class = new Class1686();
			@class.bool_2 = true;
			Class1627.ApplyStyle(pivotTable_0.style_0[i, int_13], style_0, @class, int_5, hashtable_2[i, int_13]);
		}
	}

	private bool method_40(PivotFieldCollection pivotFieldCollection_0)
	{
		int num = 0;
		while (true)
		{
			if (num < pivotFieldCollection_0.Count)
			{
				if (pivotFieldCollection_0[num].ShowInOutlineForm)
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private void method_41(Style[,] style_0, Hashtable[,] hashtable_4, int int_12, int int_13)
	{
		for (int i = 1; i < int_12; i++)
		{
			for (int j = 0; j < int_13; j++)
			{
				if (style_0[i, j].IsModified(StyleModifyFlag.TopBorder) && (int)hashtable_4[i, j][BorderType.TopBorder] > (int)hashtable_4[i - 1, j][BorderType.BottomBorder])
				{
					style_0[i - 1, j].Borders[BorderType.BottomBorder].Copy(style_0[i, j].Borders[BorderType.TopBorder]);
					style_0[i - 1, j].method_36(StyleModifyFlag.BottomBorder);
				}
				if (style_0[i - 1, j].IsModified(StyleModifyFlag.BottomBorder) && (int)hashtable_4[i - 1, j][BorderType.BottomBorder] > (int)hashtable_4[i, j][BorderType.TopBorder])
				{
					style_0[i, j].Borders[BorderType.TopBorder].Copy(style_0[i - 1, j].Borders[BorderType.BottomBorder]);
					style_0[i, j].method_36(StyleModifyFlag.TopBorder);
				}
			}
		}
		for (int k = 0; k < int_12; k++)
		{
			for (int l = 1; l < int_13; l++)
			{
				if (style_0[k, l].IsModified(StyleModifyFlag.LeftBorder) && (int)hashtable_4[k, l][BorderType.LeftBorder] > (int)hashtable_4[k, l - 1][BorderType.RightBorder])
				{
					style_0[k, l - 1].Borders[BorderType.RightBorder].Copy(style_0[k, l].Borders[BorderType.LeftBorder]);
					style_0[k, l - 1].method_36(StyleModifyFlag.RightBorder);
				}
				if (style_0[k, l - 1].IsModified(StyleModifyFlag.RightBorder) && (int)hashtable_4[k, l - 1][BorderType.RightBorder] > (int)hashtable_4[k, l][BorderType.LeftBorder])
				{
					style_0[k, l].Borders[BorderType.LeftBorder].Copy(style_0[k, l - 1].Borders[BorderType.RightBorder]);
					style_0[k, l].method_36(StyleModifyFlag.LeftBorder);
				}
			}
		}
	}

	private void method_42(Style style_0, bool bool_11)
	{
		int num = pivotTable_0.int_5 - 1 - pivotTable_0.int_0;
		int num2 = pivotTable_0.int_6 - pivotTable_0.int_2;
		for (int i = num2; i < int_9; i++)
		{
			string text = (string)hashtable_1[i - num2];
			string value = "columnsubtotal";
			if (!bool_11)
			{
				value = "grandtotalcolumn";
			}
			if (text != null && text.StartsWith(value))
			{
				for (int j = 1; j <= num; j++)
				{
					Class1686 @class = new Class1686();
					method_81(@class, j, 1, num);
					@class.bool_2 = true;
					@class.bool_3 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[j, i], style_0, @class, int_5, hashtable_2[j, i]);
				}
			}
		}
	}

	private void method_43(Style style_0, bool bool_11)
	{
		int num = pivotTable_0.int_6 - 1 - pivotTable_0.int_2;
		int num2 = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int i = num2; i < int_8; i++)
		{
			string text = (string)hashtable_0[i - num2];
			string value = "rowsubtotal";
			if (!bool_11)
			{
				value = "grandtotalrow";
			}
			if (text != null && text.StartsWith(value))
			{
				for (int j = 0; j <= num; j++)
				{
					Class1686 @class = new Class1686();
					method_82(@class, j, 0, num);
					@class.bool_0 = true;
					@class.bool_1 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[i, j], style_0, @class, 19, hashtable_2[i, j]);
				}
			}
		}
	}

	private void method_44(Style style_0)
	{
		int num = pivotTable_0.int_6 - 1 - pivotTable_0.int_2;
		int num2 = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int i = num2; i < int_8; i++)
		{
			string text = (string)hashtable_0[i - num2];
			if (text != null && text.StartsWith("blank"))
			{
				for (int j = 0; j <= num; j++)
				{
					Class1686 @class = new Class1686();
					method_82(@class, j, 0, num);
					@class.bool_0 = true;
					@class.bool_1 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[i, j], style_0, @class, 19, hashtable_2[i, j]);
				}
			}
		}
	}

	private void method_45(Style style_0)
	{
		if (pivotTable_0.ColumnFields.Count > 0)
		{
			int num = pivotTable_0.int_6 - pivotTable_0.int_2;
			int num2 = 0;
			for (int i = num; i < int_9; i++)
			{
				Class1686 @class = new Class1686();
				method_82(@class, i, num, int_9 - 1);
				@class.bool_0 = true;
				@class.bool_1 = true;
				Class1627.ApplyStyle(pivotTable_0.style_0[num2, i], style_0, @class, 22, hashtable_2[num2, i]);
			}
		}
	}

	private void method_46(Style style_0)
	{
		if (pivotTable_0.RowFields.Count > 0)
		{
			int num = pivotTable_0.int_6 - 1 - pivotTable_0.int_2;
			int num2 = pivotTable_0.int_5 - 1 - pivotTable_0.int_0;
			for (int i = 0; i <= num; i++)
			{
				Class1686 @class = new Class1686();
				method_82(@class, i, 0, num);
				@class.bool_0 = true;
				@class.bool_1 = true;
				Class1627.ApplyStyle(pivotTable_0.style_0[num2, i], style_0, @class, 22, hashtable_2[num2, i]);
			}
		}
	}

	private void method_47(Style style_0)
	{
		if (pivotTable_0.RowFields.Count <= 1)
		{
			return;
		}
		int num = pivotTable_0.int_5 - pivotTable_0.int_0;
		int num2 = int_8 - 1;
		if (pivotTable_0.ColumnGrand)
		{
			if (pivotFieldType_0 == PivotFieldType.Row)
			{
				if (pivotTable_0.RowFields.Count > 1)
				{
					num2 -= pivotTable_0.DataFields.Count;
				}
			}
			else
			{
				num2--;
			}
		}
		for (int i = num; i <= num2; i++)
		{
			string text = (string)hashtable_0[i - num];
			if (text == null || !text.StartsWith("rowsubtitle"))
			{
				continue;
			}
			int[] array = method_80(text.Substring("rowsubtitle".Length).Split('+'));
			if (array != null && array.Length != 0 && array[0] == 1)
			{
				Class1686 @class = new Class1686();
				@class.bool_1 = true;
				@class.bool_2 = true;
				@class.bool_3 = true;
				@class.bool_0 = true;
				int num3 = 0;
				int num4 = 0;
				if (array.Length == 1 && !arrayList_1.Contains(i - num))
				{
					num4 = pivotTable_0.int_6 - 1 - pivotTable_0.int_2;
				}
				for (int j = num3; j <= num4; j++)
				{
					Class1627.ApplyStyle(pivotTable_0.style_0[i, j], style_0, @class, int_5, hashtable_2[i, j]);
				}
			}
		}
	}

	private void method_48(Style style_0)
	{
		int num = pivotTable_0.int_6 - pivotTable_0.int_2;
		int num2 = 0;
		if (pivotTable_0.ColumnFields.Count > 0)
		{
			num2 = pivotTable_0.ColumnFields.Count;
		}
		for (int i = num; i < int_9; i++)
		{
			string text = (string)hashtable_1[i - num];
			if (text == null || (!text.StartsWith("columnsubtotal") && !text.StartsWith("grandtotalcolumn")))
			{
				Class1686 class1686_ = new Class1686();
				Class1627.ApplyStyle(pivotTable_0.style_0[num2, i], style_0, class1686_, 24, hashtable_2[num2, i]);
			}
		}
	}

	private void method_49(Style style_0)
	{
		if (bool_10)
		{
			for (int i = 0; i < pivotTable_0.PageFields.Count; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					Class1686 class1686_ = new Class1686();
					method_81(class1686_, i, 0, pivotTable_0.PageFields.Count - 1);
					method_82(class1686_, j, 0, 1);
					Class1627.ApplyStyle(pivotTable_0.style_1[i, j], style_0, class1686_, 0, hashtable_3[i, j]);
				}
			}
		}
		for (int k = 0; k < int_8; k++)
		{
			for (int l = 0; l < int_9; l++)
			{
				Class1686 class1686_2 = new Class1686();
				method_81(class1686_2, k, 0, int_8 - 1);
				method_82(class1686_2, l, 0, int_9 - 1);
				Class1627.ApplyStyle(pivotTable_0.style_0[k, l], style_0, class1686_2, 0, hashtable_2[k, l]);
			}
		}
	}

	private void method_50(Style style_0)
	{
		if (bool_10)
		{
			for (int i = 0; i < pivotTable_0.PageFields.Count; i++)
			{
				Class1686 @class = new Class1686();
				@class.bool_2 = true;
				@class.bool_3 = true;
				method_81(@class, i, 0, pivotTable_0.PageFields.Count - 1);
				Class1627.ApplyStyle(pivotTable_0.style_1[i, 0], style_0, @class, 1, hashtable_3[i, 0]);
			}
		}
	}

	private void method_51(Style style_0)
	{
		if (bool_10)
		{
			for (int i = 0; i < pivotTable_0.PageFields.Count; i++)
			{
				Class1686 @class = new Class1686();
				@class.bool_2 = true;
				@class.bool_3 = true;
				method_81(@class, i, 0, pivotTable_0.PageFields.Count - 1);
				Class1627.ApplyStyle(pivotTable_0.style_1[i, 1], style_0, @class, 2, hashtable_3[i, 1]);
			}
		}
	}

	private void method_52(Style style_0, Style style_1, int int_12, int int_13)
	{
		if (!pivotTable_0.ShowPivotStyleColumnStripes)
		{
			return;
		}
		int num = int_12 + int_13;
		int num2 = pivotTable_0.int_6 - pivotTable_0.int_2;
		int num3 = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int i = num2; i < int_9; i++)
		{
			int num4 = (i - num2) % num;
			if (num4 >= 0 && num4 < int_12 && style_0 != null)
			{
				Class1686 class1686_ = new Class1686();
				method_82(class1686_, num4, 0, int_12 - 1);
				for (int j = num3; j < int_8; j++)
				{
					method_81(class1686_, j, num3, int_8 - 1);
					Class1627.ApplyStyle(pivotTable_0.style_0[j, i], style_0, class1686_, 3, hashtable_2[j, i]);
				}
			}
			int num5 = num4 - int_12;
			if (num5 >= 0 && num5 < int_13 && style_1 != null)
			{
				Class1686 class1686_2 = new Class1686();
				method_82(class1686_2, num5, 0, int_13 - 1);
				for (int k = num3; k < int_8; k++)
				{
					method_81(class1686_2, k, num3, int_8 - 1);
					Class1627.ApplyStyle(pivotTable_0.style_0[k, i], style_1, class1686_2, 4, hashtable_2[k, i]);
				}
			}
		}
	}

	private void method_53(Style style_0, Style style_1, int int_12, int int_13)
	{
		if (!pivotTable_0.ShowPivotStyleRowStripes)
		{
			return;
		}
		int num = int_12 + int_13;
		int num2 = 0;
		int num3 = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int i = num3; i < int_8; i++)
		{
			int num4 = (i - num3) % num;
			if (num4 >= 0 && num4 < int_12 && style_0 != null)
			{
				Class1686 class1686_ = new Class1686();
				method_81(class1686_, num4, 0, int_12 - 1);
				for (int j = num2; j < int_9; j++)
				{
					method_82(class1686_, j, num2, int_9 - 1);
					Class1627.ApplyStyle(pivotTable_0.style_0[i, j], style_0, class1686_, 5, hashtable_2[i, j]);
				}
			}
			int num5 = num4 - int_12;
			if (num5 >= 0 && num5 < int_13 && style_1 != null)
			{
				Class1686 class1686_2 = new Class1686();
				method_81(class1686_2, num5, 0, int_13 - 1);
				for (int k = num2; k < int_9; k++)
				{
					method_82(class1686_2, k, num2, int_9 - 1);
					Class1627.ApplyStyle(pivotTable_0.style_0[i, k], style_1, class1686_2, 6, hashtable_2[i, k]);
				}
			}
		}
	}

	private void method_54(Style style_0)
	{
		if (!pivotTable_0.ShowPivotStyleRowHeader || (pivotTable_0.RowFields.Count <= 0 && pivotTable_0.ColumnFields.Count <= 0))
		{
			return;
		}
		int num = pivotTable_0.int_6 - 1 - pivotTable_0.int_2;
		for (int i = 0; i < int_8; i++)
		{
			for (int j = 0; j <= num; j++)
			{
				Class1686 class1686_ = new Class1686();
				method_81(class1686_, i, 0, int_8 - 1);
				method_82(class1686_, j, 0, num);
				Class1627.ApplyStyle(pivotTable_0.style_0[i, j], style_0, class1686_, 8, hashtable_2[i, j]);
			}
		}
	}

	private void method_55(Style style_0)
	{
		if (!pivotTable_0.ShowPivotStyleColumnHeader)
		{
			return;
		}
		int num = pivotTable_0.int_5 - 1 - pivotTable_0.int_0;
		for (int i = 0; i <= num; i++)
		{
			for (int j = 0; j < int_9; j++)
			{
				Class1686 class1686_ = new Class1686();
				method_81(class1686_, i, 0, num);
				method_82(class1686_, j, 0, int_9 - 1);
				Class1627.ApplyStyle(pivotTable_0.style_0[i, j], style_0, class1686_, 9, hashtable_2[i, j]);
			}
		}
	}

	private void method_56(Style style_0)
	{
		if (!pivotTable_0.ShowPivotStyleRowHeader || !pivotTable_0.ShowPivotStyleColumnHeader || pivotTable_0.ColumnFields.Count <= 0)
		{
			return;
		}
		int num = pivotTable_0.int_5 - 2 - pivotTable_0.int_0;
		int num2 = pivotTable_0.int_6 - 1 - pivotTable_0.int_2;
		for (int i = 0; i <= num; i++)
		{
			for (int j = 0; j <= num2; j++)
			{
				Class1686 class1686_ = new Class1686();
				method_81(class1686_, i, 0, num);
				method_82(class1686_, j, 0, num2);
				Class1627.ApplyStyle(pivotTable_0.style_0[i, j], style_0, class1686_, 11, hashtable_2[i, j]);
			}
		}
	}

	private void method_57(Style style_0, Style style_1, Style style_2)
	{
		if (pivotTable_0.ColumnFields.Count <= 1)
		{
			return;
		}
		int num = pivotTable_0.int_6 - pivotTable_0.int_2;
		for (int i = num; i < int_9; i++)
		{
			string text = (string)hashtable_1[i - num];
			if (text == null || !text.StartsWith("columnsubtotal"))
			{
				continue;
			}
			int num2 = int.Parse(text.Substring("columnsubtotal".Length));
			object[] array = method_58(num2, new Style[3] { style_0, style_1, style_2 });
			Style style = (Style)array[0];
			int num3 = (int)array[1];
			if (style != null)
			{
				int num4 = num2;
				for (int j = num4; j < int_8; j++)
				{
					Class1686 @class = new Class1686();
					method_81(@class, j, num4, int_8 - 1);
					@class.bool_2 = true;
					@class.bool_3 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[j, i], style, @class, num3, hashtable_2[j, i]);
				}
			}
		}
	}

	private object[] method_58(int int_12, Style[] style_0)
	{
		Style style = null;
		int num = 0;
		if (int_12 == 1)
		{
			style = style_0[0];
			num = 15;
		}
		else if (int_12 == 2)
		{
			style = style_0[1];
			num = 16;
		}
		else if (int_12 == 3)
		{
			style = style_0[2];
			num = 17;
		}
		else if (int_12 > 0)
		{
			if (int_12 % 2 == 0)
			{
				style = style_0[1];
				num = 16;
			}
			else
			{
				style = style_0[2];
				num = 17;
			}
		}
		return new object[2] { style, num };
	}

	private void method_59(Style style_0)
	{
		if (pivotTable_0.RowFields.Count <= 1)
		{
			return;
		}
		int num = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int i = num; i < int_8; i++)
		{
			string text = (string)hashtable_0[i - num];
			if (text != null && text == "blank")
			{
				int int_ = 0;
				for (int j = 0; j < int_9; j++)
				{
					Class1686 @class = new Class1686();
					method_82(@class, j, int_, int_9 - 1);
					@class.bool_0 = true;
					@class.bool_1 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[i, j], style_0, @class, 18, hashtable_2[i, j]);
				}
			}
		}
	}

	private void method_60(Style style_0, Style style_1, Style style_2)
	{
		if (pivotTable_0.RowFields.Count <= 1)
		{
			return;
		}
		int num = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int i = num; i < int_8; i++)
		{
			string text = (string)hashtable_0[i - num];
			if (text == null || !text.StartsWith("rowsubtotal"))
			{
				continue;
			}
			int num2 = int.Parse(text.Substring("rowsubtotal".Length));
			object[] array = method_64(num2, new Style[3] { style_0, style_1, style_2 });
			Style style = (Style)array[0];
			int num3 = (int)array[1];
			if (style != null)
			{
				int num4 = method_77(num2 - 1);
				for (int j = num4; j < int_9; j++)
				{
					Class1686 @class = new Class1686();
					method_82(@class, j, num4, int_9 - 1);
					@class.bool_0 = true;
					@class.bool_1 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[i, j], style, @class, num3, hashtable_2[i, j]);
				}
			}
		}
	}

	private void method_61(Style style_0, Style style_1, Style style_2)
	{
		if (pivotTable_0.RowFields.Count <= 1)
		{
			return;
		}
		int num = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int i = num; i < int_8; i++)
		{
			string text = (string)hashtable_0[i - num];
			if (text == null || !text.StartsWith("rowsubtotal"))
			{
				continue;
			}
			int num2 = int.Parse(text.Substring("rowsubtotal".Length));
			object[] array = method_64(num2, new Style[3] { style_0, style_1, style_2 });
			Style style = (Style)array[0];
			int num3 = (int)array[1];
			if (style != null)
			{
				int num4 = method_77(num2 - 1);
				int num5 = pivotTable_0.int_6 - 1 - pivotTable_0.int_2;
				for (int j = num4; j <= num5; j++)
				{
					Class1686 @class = new Class1686();
					method_82(@class, j, num4, num5);
					@class.bool_0 = true;
					@class.bool_1 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[i, j], style, @class, num3, hashtable_2[i, j]);
				}
			}
		}
	}

	private void method_62(Style style_0, TableStyleElementType tableStyleElementType_0, Style style_1, TableStyleElementType tableStyleElementType_1, Style style_2, TableStyleElementType tableStyleElementType_2)
	{
		if (pivotTable_0.RowFields.Count <= 1)
		{
			return;
		}
		int num = pivotTable_0.int_5 - pivotTable_0.int_0;
		for (int i = num; i < int_8; i++)
		{
			string text = (string)hashtable_0[i - num];
			if (text == null || !text.StartsWith("rowsubtotal"))
			{
				continue;
			}
			int num2 = int.Parse(text.Substring("rowsubtotal".Length));
			object[] array = method_63(num2, new Style[3] { style_0, style_1, style_2 }, new int[3]
			{
				(int)tableStyleElementType_0,
				(int)tableStyleElementType_1,
				(int)tableStyleElementType_2
			});
			Style style = (Style)array[0];
			int num3 = (int)array[1];
			if (style != null)
			{
				int num4 = method_77(num2 - 1);
				for (int j = num4; j < int_9; j++)
				{
					Class1686 @class = new Class1686();
					method_82(@class, j, num4, int_9 - 1);
					@class.bool_0 = true;
					@class.bool_1 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[i, j], style, @class, num3, hashtable_2[i, j]);
				}
			}
		}
	}

	private object[] method_63(int int_12, Style[] style_0, int[] int_13)
	{
		Style style = null;
		int num = 0;
		if (int_12 == 1)
		{
			style = style_0[0];
			num = int_13[0];
		}
		else if (int_12 == 2)
		{
			style = style_0[1];
			num = int_13[1];
		}
		else if (int_12 == 3)
		{
			style = style_0[2];
			num = int_13[2];
		}
		else if (int_12 > 0)
		{
			if (int_12 % 2 == 0)
			{
				style = style_0[1];
				num = int_13[1];
			}
			else
			{
				style = style_0[2];
				num = int_13[2];
			}
		}
		return new object[2] { style, num };
	}

	private object[] method_64(int int_12, Style[] style_0)
	{
		Style style = null;
		int num = 0;
		if (int_12 == 1)
		{
			style = style_0[0];
			num = 19;
		}
		else if (int_12 == 2)
		{
			style = style_0[1];
			num = 20;
		}
		else if (int_12 == 3)
		{
			style = style_0[2];
			num = 21;
		}
		else if (int_12 > 0)
		{
			if (int_12 % 2 == 0)
			{
				style = style_0[1];
				num = 20;
			}
			else
			{
				style = style_0[2];
				num = 21;
			}
		}
		return new object[2] { style, num };
	}

	private void method_65(Style style_0, Style style_1, Style style_2)
	{
		if (!pivotTable_0.ShowPivotStyleColumnHeader || pivotTable_0.ColumnFields.Count <= 0)
		{
			return;
		}
		int num = pivotTable_0.int_6 - pivotTable_0.int_2;
		Style style = null;
		int num4;
		int num5;
		int num2;
		for (int i = num; i < int_9; i++)
		{
			num2 = 0;
			string text = (string)hashtable_1[i - num];
			if (text == null || !text.StartsWith("columnsubtotal"))
			{
				continue;
			}
			int num3 = int.Parse(text.Substring("columnsubtotal".Length));
			object[] array = method_66(num3, new Style[3] { style_0, style_1, style_2 });
			if (array != null)
			{
				style = (Style)array[0];
				num2 = (int)array[1];
			}
			if (style != null)
			{
				num4 = num3;
				num5 = pivotTable_0.int_5 - 1 - pivotTable_0.int_0;
				for (int j = num4; j <= num5; j++)
				{
					Class1686 @class = new Class1686();
					method_81(@class, j, num4, num5);
					@class.bool_2 = true;
					@class.bool_3 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[j, i], style, @class, num2, hashtable_2[j, i]);
				}
			}
		}
		num4 = 1;
		num5 = pivotTable_0.int_5 - 1 - pivotTable_0.int_0;
		style = null;
		num2 = 0;
		int num6 = int_9 - 1;
		if (pivotTable_0.RowGrand)
		{
			if (pivotFieldType_0 == PivotFieldType.Column)
			{
				if (pivotTable_0.ColumnFields.Count > 1)
				{
					num6 -= pivotTable_0.DataFields.Count;
				}
			}
			else
			{
				num6--;
			}
		}
		for (int k = num4; k <= num5; k++)
		{
			object[] array2 = method_66(k, new Style[3] { style_0, style_1, style_2 });
			if (array2 != null)
			{
				style = (Style)array2[0];
				num2 = (int)array2[1];
			}
			if (style == null)
			{
				continue;
			}
			int num7 = -1;
			int int_ = num;
			int int_2 = num6;
			bool flag = false;
			for (int l = num; l <= num6; l++)
			{
				if (flag)
				{
					flag = false;
					continue;
				}
				if (num7 != -1)
				{
					int_ = num7;
					int_2 = num6;
					num7 = -1;
				}
				string text2 = (string)hashtable_1[l - num];
				if (text2 != null && text2.StartsWith("columnsubtotal"))
				{
					int num8 = int.Parse(text2.Substring("columnsubtotal".Length));
					if (num8 <= k)
					{
						num7 = l + 1;
						continue;
					}
				}
				if (l < num6)
				{
					text2 = (string)hashtable_1[l + 1 - num];
					if (text2 != null && text2.StartsWith("columnsubtotal"))
					{
						int num9 = int.Parse(text2.Substring("columnsubtotal".Length));
						if (num9 <= k)
						{
							flag = true;
							num7 = l + 2;
							int_2 = l;
						}
					}
				}
				Class1686 class2 = new Class1686();
				method_82(class2, l, int_, int_2);
				class2.bool_0 = true;
				class2.bool_1 = true;
				Class1627.ApplyStyle(pivotTable_0.style_0[k, l], style, class2, num2, hashtable_2[k, l]);
			}
		}
	}

	private object[] method_66(int int_12, Style[] style_0)
	{
		Style style = null;
		int num = 0;
		if (int_12 == 1)
		{
			style = style_0[0];
			num = 22;
		}
		else if (int_12 == 2)
		{
			style = style_0[1];
			num = 23;
		}
		else if (int_12 == 3)
		{
			style = style_0[2];
			num = 24;
		}
		else if (int_12 > 0)
		{
			if (int_12 % 2 == 0)
			{
				style = style_0[1];
				num = 23;
			}
			else
			{
				style = style_0[2];
				num = 24;
			}
		}
		return new object[2] { style, num };
	}

	private void method_67(Style style_0, Style style_1, Style style_2)
	{
		if (!pivotTable_0.ShowPivotStyleRowHeader || pivotTable_0.RowFields.Count <= 1)
		{
			return;
		}
		int num = pivotTable_0.int_5 - pivotTable_0.int_0;
		int num2 = int_8 - 1;
		if (pivotTable_0.ColumnGrand)
		{
			if (pivotFieldType_0 == PivotFieldType.Row)
			{
				if (pivotTable_0.RowFields.Count > 1)
				{
					num2 -= pivotTable_0.DataFields.Count;
				}
			}
			else
			{
				num2--;
			}
		}
		int num3 = 0;
		int num4 = num;
		for (int i = 0; i < pivotTable_0.RowFields.Count - 1; i++)
		{
			PivotField pivotField = pivotTable_0.RowFields[i];
			if (!pivotField.ShowInOutlineForm)
			{
				Style style = null;
				int num5 = 0;
				object[] array = method_79(i, new Style[3] { style_0, style_1, style_2 });
				if (array != null)
				{
					style = (Style)array[0];
					num5 = (int)array[1];
				}
				if (style == null)
				{
					continue;
				}
				int num6 = -1;
				bool flag = false;
				int int_ = num4;
				int int_2 = num2;
				for (int j = num4; j <= num2; j++)
				{
					if (flag)
					{
						flag = false;
						continue;
					}
					if (num6 != -1)
					{
						int_ = num6;
						int_2 = num2;
						num6 = -1;
					}
					string text = (string)hashtable_0[j - num];
					if (text != null)
					{
						if (text.StartsWith("rowsubtotal"))
						{
							int num7 = int.Parse(text.Substring("rowsubtotal".Length));
							if (num7 <= i + 1)
							{
								num6 = j + 1;
								continue;
							}
						}
						else if (text.StartsWith("blank"))
						{
							num6 = j + 1;
							continue;
						}
					}
					if (j < num2)
					{
						text = (string)hashtable_0[j + 1 - num];
						if (text != null)
						{
							if (text.StartsWith("rowsubtotal"))
							{
								int num8 = int.Parse(text.Substring("rowsubtotal".Length));
								if (num8 <= i + 1)
								{
									flag = true;
									num6 = j + 2;
									int_2 = j;
								}
							}
							else if (text.StartsWith("blank"))
							{
								flag = true;
								num6 = j + 2;
								int_2 = j;
							}
							else if (text.StartsWith("rowsubtitle"))
							{
								int[] array2 = method_80(text.Substring("rowsubtitle".Length).Split('+'));
								if (array2 != null)
								{
									for (int k = 0; k < array2.Length; k++)
									{
										if (array2[k] <= i + 1)
										{
											num6 = j + 1;
											int_2 = j;
											break;
										}
									}
								}
							}
						}
					}
					Class1686 @class = new Class1686();
					method_81(@class, j, int_, int_2);
					@class.bool_2 = true;
					@class.bool_3 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[j, num3], style, @class, num5, hashtable_2[j, num3]);
				}
				num3++;
			}
			else
			{
				num4++;
				if (!pivotField.ShowCompact)
				{
					num3++;
				}
			}
		}
		for (int l = num; l <= num2; l++)
		{
			string text2 = (string)hashtable_0[l - num];
			if (text2 == null || !text2.StartsWith("rowsubtitle"))
			{
				continue;
			}
			int[] array3 = method_80(text2.Substring("rowsubtitle".Length).Split('+'));
			if (array3 == null || (array3.Length == 1 && array3[array3.Length - 1] == pivotTable_0.RowFields.Count))
			{
				continue;
			}
			for (int m = 0; m < array3.Length; m++)
			{
				PivotField pivotField2 = pivotTable_0.RowFields[array3[m] - 1];
				if (!pivotField2.ShowInOutlineForm)
				{
					continue;
				}
				Style style2 = null;
				int num9 = 0;
				object[] array4 = method_79(array3[m] - 1, new Style[3] { style_0, style_1, style_2 });
				if (array4 != null)
				{
					style2 = (Style)array4[0];
					num9 = (int)array4[1];
				}
				if (style2 == null)
				{
					continue;
				}
				int num10 = method_77(array3[m] - 1);
				if (m != array3.Length - 1)
				{
					Class1686 class2 = new Class1686();
					class2.bool_0 = true;
					class2.bool_1 = true;
					class2.bool_2 = true;
					class2.bool_3 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[l, num10], style2, class2, num9, hashtable_2[l, num10]);
				}
				else if (array3[m] != pivotTable_0.RowFields.Count)
				{
					int num11 = int_9 - 1;
					if (method_76(array3[m] - 1))
					{
						num11 = pivotTable_0.int_6 - 1 - pivotTable_0.int_2;
					}
					for (int n = num10; n <= num11; n++)
					{
						Class1686 class3 = new Class1686();
						method_82(class3, n, num10, num11);
						class3.bool_0 = true;
						class3.bool_1 = true;
						Class1627.ApplyStyle(pivotTable_0.style_0[l, n], style2, class3, num9, hashtable_2[l, n]);
					}
				}
			}
		}
	}

	private void method_68(Style style_0)
	{
		if (pivotTable_0.RowFields.Count <= 1)
		{
			return;
		}
		int num = pivotTable_0.int_6 - 1 - pivotTable_0.int_2;
		int num2 = int_9 - 1;
		int num3 = pivotTable_0.int_5 - pivotTable_0.int_0;
		bool flag = false;
		int num4 = pivotTable_0.RowFields.Count - 2;
		for (int i = num3; i < int_8; i++)
		{
			flag = false;
			string text = (string)hashtable_0[i - num3];
			if (text != null && (text.StartsWith("rowsubtotal") || text.StartsWith("blank")))
			{
				continue;
			}
			if (i < int_8 - 1)
			{
				text = (string)hashtable_0[i + 1 - num3];
				if (text != null)
				{
					if (text.StartsWith("rowsubtotal"))
					{
						flag = true;
					}
					else if (text.StartsWith("blank"))
					{
						flag = true;
					}
					else if (text.StartsWith("rowsubtitle"))
					{
						int[] array = method_80(text.Substring("rowsubtitle".Length).Split('+'));
						if (array != null)
						{
							for (int j = 0; j < array.Length; j++)
							{
								if (array[j] <= num4 + 1)
								{
									flag = true;
									break;
								}
							}
						}
					}
				}
			}
			if (flag)
			{
				Class1686 @class = new Class1686();
				@class.bool_1 = true;
				for (int k = num; k <= num2; k++)
				{
					Class1627.ApplyStyle(pivotTable_0.style_0[i, k], style_0, @class, int_5, hashtable_2[i, k]);
				}
			}
		}
	}

	private void method_69()
	{
		WorksheetCollection worksheets = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		int num = pivotTable_0.int_5 - pivotTable_0.int_0;
		int num2 = int_8 - 1;
		Style style = null;
		int num3 = 0;
		int num4 = 0;
		bool flag = method_40(pivotTable_0.RowFields);
		for (int i = num; i <= num2; i++)
		{
			string text = (string)hashtable_0[i - num];
			if (text == null)
			{
				continue;
			}
			if (text.StartsWith("rowsubtitle"))
			{
				int[] array = method_80(text.Substring("rowsubtitle".Length).Split('+'));
				for (int j = 0; j < array.Length; j++)
				{
					num3 = method_77(array[j] - 1);
					num4 = method_78(array[j] - 1);
					if (!flag || num4 != 0)
					{
						style = Class1138.smethod_2(worksheets, num4);
						Class1686 class1686_ = new Class1686();
						Class1627.ApplyStyle(pivotTable_0.style_0[i, num3], style, class1686_, 25, hashtable_2[i, num3]);
					}
				}
			}
			else if (text.StartsWith("rowsubtotal"))
			{
				int num5 = int.Parse(text.Substring("rowsubtotal".Length));
				num3 = method_77(num5 - 1);
				num4 = method_78(num5 - 1);
				if (!flag || num4 != 0)
				{
					style = Class1138.smethod_2(worksheets, num4);
					Class1686 class1686_2 = new Class1686();
					Class1627.ApplyStyle(pivotTable_0.style_0[i, num3], style, class1686_2, 25, hashtable_2[i, num3]);
				}
			}
			else if (text == "grandtotalrow")
			{
				num3 = 0;
				if (!flag)
				{
					style = Class1138.smethod_2(worksheets, 0);
					Class1686 class1686_3 = new Class1686();
					Class1627.ApplyStyle(pivotTable_0.style_0[i, num3], style, class1686_3, 29, hashtable_2[i, num3]);
				}
			}
		}
	}

	private void method_70()
	{
		_ = pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		int num = pivotTable_0.int_5 - pivotTable_0.int_0;
		int num2 = int_8 - 1;
		int num3 = 0;
		for (int i = num; i <= num2; i++)
		{
			string text = (string)hashtable_0[i - num];
			if (text == null)
			{
				continue;
			}
			if (text.StartsWith("rowsubtitle"))
			{
				int[] array = method_80(text.Substring("rowsubtitle".Length).Split('+'));
				for (int j = 0; j < array.Length; j++)
				{
					PivotField pivotField = pivotTable_0.RowFields[array[j] - 1];
					if (!pivotField.method_6())
					{
						num3 = method_77(array[j] - 1);
						pivotTable_0.style_0[i, num3].Custom = pivotField.NumberFormat;
						pivotTable_0.style_0[i, num3].method_45(pivotField.Number);
					}
				}
			}
			else if (text.StartsWith("rowsubtotal"))
			{
				int num4 = int.Parse(text.Substring("rowsubtotal".Length));
				PivotField pivotField2 = pivotTable_0.RowFields[num4 - 1];
				if (!pivotField2.method_6())
				{
					num3 = method_77(num4 - 1);
					pivotTable_0.style_0[i, num3].Custom = pivotField2.NumberFormat;
					pivotTable_0.style_0[i, num3].method_45(pivotField2.Number);
				}
			}
			else if (text == "grandtotalrow" && pivotTable_0.RowFields.Count > 0)
			{
				PivotField pivotField3 = pivotTable_0.RowFields[0];
				num3 = 0;
				pivotTable_0.style_0[i, 0].Custom = pivotField3.NumberFormat;
				pivotTable_0.style_0[i, 0].method_45(pivotField3.Number);
			}
		}
		int num5 = pivotTable_0.int_6 - pivotTable_0.int_2;
		int num6 = int_9 - 1;
		int num7 = 0;
		for (int k = num5; k <= num6; k++)
		{
			string text2 = (string)hashtable_1[k - num5];
			if (text2 == null)
			{
				continue;
			}
			if (text2.StartsWith("columnsubtitle"))
			{
				int[] array2 = method_80(text2.Substring("columnsubtitle".Length).Split('+'));
				for (int l = 0; l < array2.Length; l++)
				{
					PivotField pivotField4 = pivotTable_0.ColumnFields[array2[l] - 1];
					if (!pivotField4.method_6())
					{
						num7 = array2[l];
						pivotTable_0.style_0[num7, k].Custom = pivotField4.NumberFormat;
						pivotTable_0.style_0[num7, k].method_45(pivotField4.Number);
					}
				}
			}
			else if (text2.StartsWith("columnsubtotal"))
			{
				int num8 = int.Parse(text2.Substring("columnsubtotal".Length));
				PivotField pivotField5 = pivotTable_0.ColumnFields[num8 - 1];
				if (!pivotField5.method_6())
				{
					num7 = num8;
					pivotTable_0.style_0[num7, k].Custom = pivotField5.NumberFormat;
					pivotTable_0.style_0[num7, k].method_45(pivotField5.Number);
				}
			}
			else if (text2 == "grandtotalcolumn" && pivotTable_0.ColumnFields.Count > 0)
			{
				PivotField pivotField6 = pivotTable_0.ColumnFields[0];
				num7 = 1;
				pivotTable_0.style_0[1, k].Custom = pivotField6.NumberFormat;
				pivotTable_0.style_0[1, k].method_45(pivotField6.Number);
			}
		}
		if (pivotTable_0.DataFields.Count <= 0)
		{
			return;
		}
		int count = pivotTable_0.DataFields.Count;
		for (int m = num5; m <= num6; m++)
		{
			PivotField pivotField7 = pivotTable_0.DataFields[(m - num5) % count];
			for (int n = num; n <= num2; n++)
			{
				pivotTable_0.style_0[n, m].Custom = pivotField7.NumberFormat;
				pivotTable_0.style_0[n, m].method_45(pivotField7.Number);
			}
		}
	}

	private void method_71(Style style_0, Style style_1, Style style_2, Style style_3, Style style_4, Style style_5, Style style_6, Style style_7, Style style_8, Style style_9, Style style_10)
	{
		if (!pivotTable_0.ShowPivotStyleRowHeader || pivotTable_0.RowFields.Count <= 1)
		{
			return;
		}
		int num = pivotTable_0.int_5 - pivotTable_0.int_0;
		int num2 = int_8 - 1;
		if (pivotTable_0.ColumnGrand)
		{
			if (pivotFieldType_0 == PivotFieldType.Row)
			{
				if (pivotTable_0.RowFields.Count > 1)
				{
					num2 -= pivotTable_0.DataFields.Count;
				}
			}
			else
			{
				num2--;
			}
		}
		int num3 = 0;
		int num4 = num;
		for (int i = 0; i < pivotTable_0.RowFields.Count - 1; i++)
		{
			PivotField pivotField = pivotTable_0.RowFields[i];
			if (!pivotField.ShowInOutlineForm)
			{
				Style style = null;
				int num5 = 0;
				object[] array = method_79(i, new Style[3] { style_0, style_3, style_6 });
				if (array != null)
				{
					style = (Style)array[0];
					num5 = (int)array[1];
				}
				if (style == null)
				{
					continue;
				}
				int num6 = -1;
				bool flag = false;
				int int_ = num4;
				int int_2 = num2;
				for (int j = num4; j <= num2; j++)
				{
					if (flag)
					{
						flag = false;
						continue;
					}
					if (num6 != -1)
					{
						int_ = num6;
						int_2 = num2;
						num6 = -1;
					}
					string text = (string)hashtable_0[j - num];
					if (text != null)
					{
						if (text.StartsWith("rowsubtotal"))
						{
							int num7 = int.Parse(text.Substring("rowsubtotal".Length));
							if (num7 <= i + 1)
							{
								num6 = j + 1;
								continue;
							}
						}
						else if (text.StartsWith("blank"))
						{
							num6 = j + 1;
							continue;
						}
					}
					if (j < num2)
					{
						text = (string)hashtable_0[j + 1 - num];
						if (text != null)
						{
							if (text.StartsWith("rowsubtotal"))
							{
								int num8 = int.Parse(text.Substring("rowsubtotal".Length));
								if (num8 <= i + 1)
								{
									flag = true;
									num6 = j + 2;
									int_2 = j;
								}
							}
							else if (text.StartsWith("blank"))
							{
								flag = true;
								num6 = j + 2;
								int_2 = j;
							}
						}
					}
					Class1686 @class = new Class1686();
					method_81(@class, j, int_, int_2);
					@class.bool_2 = true;
					@class.bool_3 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[j, num3], style, @class, num5, hashtable_2[j, num3]);
				}
				num3++;
			}
			else
			{
				num4++;
				if (!pivotField.ShowCompact)
				{
					num3++;
				}
			}
		}
		for (int k = num; k <= num2; k++)
		{
			string text2 = (string)hashtable_0[k - num];
			if (text2 == null || !text2.StartsWith("rowsubtitle"))
			{
				continue;
			}
			int[] array2 = method_80(text2.Substring("rowsubtitle".Length).Split('+'));
			for (int l = 0; l < array2.Length; l++)
			{
				int num9 = method_77(array2[l] - 1);
				if (array2[l] == pivotTable_0.RowFields.Count)
				{
					if (style_9 != null)
					{
						Class1686 class2 = new Class1686();
						class2.bool_0 = true;
						class2.bool_1 = true;
						class2.bool_2 = true;
						class2.bool_3 = true;
						Class1627.ApplyStyle(pivotTable_0.style_0[k, num9], style_9, class2, 27, hashtable_2[k, num9]);
					}
					if (style_10 != null)
					{
						Class1686 class3 = new Class1686();
						class3.bool_0 = true;
						class3.bool_1 = true;
						class3.bool_2 = true;
						class3.bool_3 = true;
						Class1627.ApplyStyle(pivotTable_0.style_0[k, int_9 - 1], style_10, class3, 27, hashtable_2[k, int_9 - 1]);
					}
					continue;
				}
				PivotField pivotField2 = pivotTable_0.RowFields[array2[l] - 1];
				if (!pivotField2.ShowInOutlineForm)
				{
					continue;
				}
				Style style2 = null;
				int num10 = 0;
				if (l != array2.Length - 1)
				{
					object[] array3 = method_79(array2[l] - 1, new Style[3] { style_0, style_3, style_6 });
					if (array3 != null)
					{
						style2 = (Style)array3[0];
						num10 = (int)array3[1];
					}
					if (style2 != null)
					{
						Class1686 class4 = new Class1686();
						class4.bool_0 = true;
						class4.bool_1 = true;
						class4.bool_2 = true;
						class4.bool_3 = true;
						Class1627.ApplyStyle(pivotTable_0.style_0[k, num9], style2, class4, num10, hashtable_2[k, num9]);
					}
					style2 = null;
					continue;
				}
				object[] array4 = method_79(array2[l] - 1, new Style[3] { style_1, style_4, style_7 });
				if (array4 != null)
				{
					style2 = (Style)array4[0];
					num10 = (int)array4[1];
				}
				if (style2 != null)
				{
					int num11 = int_9 - 1;
					if (method_76(array2[l] - 1))
					{
						num11 = pivotTable_0.int_6 - 1 - pivotTable_0.int_2;
					}
					for (int m = num9; m <= num11; m++)
					{
						Class1686 class5 = new Class1686();
						method_82(class5, m, num9, num11);
						class5.bool_0 = true;
						class5.bool_1 = true;
						Class1627.ApplyStyle(pivotTable_0.style_0[k, m], style2, class5, num10, hashtable_2[k, m]);
					}
					style2 = null;
				}
				array4 = method_79(array2[l] - 1, new Style[3] { style_0, style_3, style_6 });
				if (array4 != null)
				{
					style2 = (Style)array4[0];
					num10 = (int)array4[1];
				}
				if (style2 != null)
				{
					Class1686 class6 = new Class1686();
					class6.bool_0 = true;
					class6.bool_1 = true;
					class6.bool_2 = true;
					class6.bool_3 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[k, num9], style2, class6, num10, hashtable_2[k, num9]);
				}
				style2 = null;
				array4 = method_79(array2[l] - 1, new Style[3] { style_2, style_5, style_8 });
				if (array4 != null)
				{
					style2 = (Style)array4[0];
					num10 = (int)array4[1];
				}
				if (style2 != null)
				{
					Class1686 class7 = new Class1686();
					class7.bool_0 = true;
					class7.bool_1 = true;
					class7.bool_2 = true;
					class7.bool_3 = true;
					Class1627.ApplyStyle(pivotTable_0.style_0[k, int_9 - 1], style2, class7, num10, hashtable_2[k, int_9 - 1]);
					style2 = null;
				}
			}
		}
	}

	private void method_72(Style style_0)
	{
		if (!pivotTable_0.RowGrand || (pivotTable_0.ColumnFields.Count == 1 && pivotTable_0.ColumnFields[0].method_6()))
		{
			return;
		}
		int num = 1;
		if (pivotTable_0.ColumnFields.Count == 0)
		{
			num = 0;
		}
		int num2 = int_8 - 1;
		int num3 = int_9 - 1;
		int num4 = num3;
		if (pivotFieldType_0 == PivotFieldType.Column && pivotTable_0.ColumnFields.Count > 1)
		{
			num4 = num4 - pivotTable_0.DataFields.Count + 1;
		}
		for (int i = num; i <= num2; i++)
		{
			for (int j = num4; j <= num3; j++)
			{
				Class1686 class1686_ = new Class1686();
				method_81(class1686_, i, num, num2);
				method_82(class1686_, j, num4, num3);
				Class1627.ApplyStyle(pivotTable_0.style_0[i, j], style_0, class1686_, 28, hashtable_2[i, j]);
			}
		}
	}

	private void method_73(Style style_0)
	{
		if (pivotTable_0.RowGrand && (pivotTable_0.ColumnFields.Count != 1 || !pivotTable_0.ColumnFields[0].method_6()))
		{
			int num = 1;
			if (pivotTable_0.ColumnFields.Count == 0)
			{
				num = 0;
			}
			int num2 = int_9 - 1;
			int num3 = num2;
			if (pivotFieldType_0 == PivotFieldType.Column && pivotTable_0.ColumnFields.Count > 1)
			{
				num3 = num3 - pivotTable_0.DataFields.Count + 1;
			}
			for (int i = num3; i <= num2; i++)
			{
				Class1686 @class = new Class1686();
				method_82(@class, i, num3, num2);
				@class.bool_0 = true;
				@class.bool_1 = true;
				Class1627.ApplyStyle(pivotTable_0.style_0[num, i], style_0, @class, 28, hashtable_2[num, i]);
			}
		}
	}

	private void method_74(Style style_0)
	{
		if (pivotTable_0.ColumnGrand && (pivotTable_0.RowFields.Count != 1 || !pivotTable_0.RowFields[0].method_6()) && (pivotTable_0.RowFields.Count != 0 || pivotTable_0.DataFields.Count <= 1))
		{
			int num = int_8 - 1;
			int num2 = num;
			if (pivotFieldType_0 == PivotFieldType.Row && pivotTable_0.ColumnFields.Count > 1)
			{
				num2 = num2 - pivotTable_0.DataFields.Count + 1;
			}
			for (int i = num2; i <= num; i++)
			{
				Class1686 @class = new Class1686();
				method_81(@class, i, num2, num);
				@class.bool_2 = true;
				@class.bool_3 = true;
				Class1627.ApplyStyle(pivotTable_0.style_0[i, 0], style_0, @class, 29, hashtable_2[i, 0]);
			}
		}
	}

	private void method_75(Style style_0)
	{
		if (!pivotTable_0.ColumnGrand || (pivotTable_0.RowFields.Count == 1 && pivotTable_0.RowFields[0].method_6()) || (pivotTable_0.RowFields.Count == 0 && pivotTable_0.DataFields.Count > 1))
		{
			return;
		}
		int num = 0;
		int num2 = int_9 - 1;
		int num3 = int_8 - 1;
		int num4 = num3;
		if (pivotFieldType_0 == PivotFieldType.Row && pivotTable_0.ColumnFields.Count > 1)
		{
			num4 = num4 - pivotTable_0.DataFields.Count + 1;
		}
		for (int i = num; i <= num2; i++)
		{
			for (int j = num4; j <= num3; j++)
			{
				Class1686 class1686_ = new Class1686();
				method_82(class1686_, i, num, num2);
				method_81(class1686_, j, num4, num3);
				Class1627.ApplyStyle(pivotTable_0.style_0[j, i], style_0, class1686_, 29, hashtable_2[j, i]);
			}
		}
	}

	private bool method_76(int int_12)
	{
		int num = int_12;
		while (true)
		{
			if (num < pivotTable_0.RowFields.Count - 1)
			{
				PivotField pivotField = pivotTable_0.RowFields[num];
				if (pivotField.ShowInOutlineForm)
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private int method_77(int int_12)
	{
		int num = 0;
		if (int_12 >= pivotTable_0.RowFields.Count)
		{
			int_12 = pivotTable_0.RowFields.Count - 1;
		}
		for (int i = 0; i < int_12; i++)
		{
			PivotField pivotField = pivotTable_0.RowFields[i];
			if (!pivotField.ShowInOutlineForm || !pivotField.ShowCompact)
			{
				num++;
			}
		}
		return num;
	}

	private int method_78(int int_12)
	{
		int num = 0;
		if (int_12 >= pivotTable_0.RowFields.Count)
		{
			int_12 = pivotTable_0.RowFields.Count - 1;
		}
		for (int num2 = int_12 - 1; num2 >= 0; num2--)
		{
			PivotField pivotField = pivotTable_0.RowFields[num2];
			if (!pivotField.ShowInOutlineForm || !pivotField.ShowCompact)
			{
				break;
			}
			num++;
		}
		return num;
	}

	private object[] method_79(int int_12, Style[] style_0)
	{
		Style style = null;
		int num = 0;
		switch (int_12)
		{
		case 0:
			style = style_0[0];
			num = 25;
			break;
		case 1:
			style = style_0[1];
			num = 26;
			break;
		case 2:
			style = style_0[2];
			num = 27;
			break;
		default:
		{
			int num2 = int_12 % 2;
			if (num2 == 1)
			{
				style = style_0[1];
				num = 26;
			}
			else
			{
				style = style_0[2];
				num = 27;
			}
			break;
		}
		}
		return new object[2] { style, num };
	}

	private int[] method_80(string[] string_0)
	{
		if (string_0 != null && string_0.Length != 0)
		{
			int[] array = new int[string_0.Length];
			for (int i = 0; i < string_0.Length; i++)
			{
				array[i] = int.Parse(string_0[i]);
			}
			return array;
		}
		return null;
	}

	private void method_81(Class1686 class1686_0, int int_12, int int_13, int int_14)
	{
		class1686_0.bool_0 = false;
		class1686_0.bool_1 = false;
		class1686_0.bool_4 = false;
		class1686_0.bool_5 = false;
		if (int_12 == int_13)
		{
			class1686_0.bool_0 = true;
			if (int_12 == int_14)
			{
				class1686_0.bool_1 = true;
			}
			else
			{
				class1686_0.bool_5 = true;
			}
		}
		else if (int_12 == int_14)
		{
			class1686_0.bool_1 = true;
			if (int_12 == int_13)
			{
				class1686_0.bool_0 = true;
			}
			else
			{
				class1686_0.bool_4 = true;
			}
		}
		else
		{
			class1686_0.bool_5 = true;
			class1686_0.bool_4 = true;
		}
	}

	private void method_82(Class1686 class1686_0, int int_12, int int_13, int int_14)
	{
		class1686_0.bool_2 = false;
		class1686_0.bool_3 = false;
		class1686_0.bool_6 = false;
		class1686_0.bool_7 = false;
		if (int_12 == int_13)
		{
			class1686_0.bool_2 = true;
			if (int_12 == int_14)
			{
				class1686_0.bool_3 = true;
			}
			else
			{
				class1686_0.bool_7 = true;
			}
		}
		else if (int_12 == int_14)
		{
			class1686_0.bool_3 = true;
			if (int_12 == int_13)
			{
				class1686_0.bool_2 = true;
			}
			else
			{
				class1686_0.bool_6 = true;
			}
		}
		else
		{
			class1686_0.bool_6 = true;
			class1686_0.bool_7 = true;
		}
	}

	private void method_83()
	{
		if (bool_7)
		{
			return;
		}
		int num = pivotTable_0.int_0;
		int num2 = pivotTable_0.int_2;
		int num3 = pivotTable_0.int_6;
		int num4 = pivotTable_0.int_5;
		if (bool_6)
		{
			if (pivotTable_0.DataFields.Count == 1)
			{
				cells_0.GetCell(num, num2, bool_2: false).PutValue(pivotTable_0.DataFields[0].DisplayName);
			}
			if (pivotTable_0.ColumnFields.Count != 0)
			{
				if (pivotTable_0.bool_7)
				{
					for (int i = 0; i < pivotTable_0.ColumnFields.Count; i++)
					{
						cells_0.GetCell(num, num3 + i, bool_2: false).PutValue(pivotTable_0.ColumnFields[i].Name);
					}
					if (bool_8)
					{
						method_100(num + 1, num3);
					}
				}
				else if (bool_8)
				{
					method_100(num, num3);
				}
			}
			else if (bool_8 && pivotTable_0.DataFields.Count != 0)
			{
				if (pivotTable_0.DataField == null)
				{
					cells_0.GetCell(num + 1, num3, bool_2: false).PutValue("Total");
				}
				else
				{
					cells_0.GetCell(num, num3, bool_2: false).PutValue("Total");
				}
			}
		}
		else if (bool_8)
		{
			method_100(num, num3);
		}
		if (pivotTable_0.RowFields.Count != 0)
		{
			bool flag = false;
			int num5 = 0;
			num5 = ((pivotTable_0.DataField != null || !pivotTable_0.IsGridDropZones) ? num : (num + 1));
			for (int j = 0; j < pivotTable_0.RowFields.Count; j++)
			{
				if (pivotTable_0.ColumnFields.Count != 0)
				{
					if (flag && j > 0)
					{
						continue;
					}
					if (pivotTable_0.ShowRowHeaderCaption)
					{
						if (pivotTable_0.ColumnFields.Count == 1 && pivotTable_0.ColumnFields[0].int_1 == -2 && pivotTable_0.bool_13)
						{
							cells_0.GetCell(num, num2 + j, bool_2: false).PutValue(pivotTable_0.RowFields[j].Name);
						}
						else
						{
							cells_0.GetCell(num + 1 + pivotTable_0.ColumnFields.Count - 1, num2 + j, bool_2: false).PutValue(pivotTable_0.RowFields[j].Name);
						}
					}
				}
				else
				{
					cells_0.GetCell(num5, num2 + j, bool_2: false).PutValue(pivotTable_0.RowFields[j].Name);
				}
				if (flag)
				{
					flag = pivotTable_0.RowFields[j].ShowCompact;
					j++;
				}
				else
				{
					flag = pivotTable_0.RowFields[j].ShowCompact;
				}
			}
			if (bool_8)
			{
				method_99(num4, num2);
			}
			if (bool_1 & bool_4)
			{
				for (int k = 0; k < arrayList_5.Count; k++)
				{
					Class1165 @class = (Class1165)arrayList_5[k];
					if (@class.enum185_0 != Enum185.const_14 && !@class.method_6() && !@class.method_3())
					{
						method_101(@class, pivotTable_0.RowFields);
						@class.method_2();
					}
				}
				for (int l = 0; l < arrayList_5.Count; l++)
				{
					Class1165 class2 = (Class1165)arrayList_5[l];
					if (!class2.method_3())
					{
						class2.method_2();
					}
				}
				return;
			}
			for (int m = 0; m < arrayList_5.Count; m++)
			{
				Class1165 class3 = (Class1165)arrayList_5[m];
				if (class3.enum185_0 != Enum185.const_14)
				{
					method_105(num4 + m, num3, class3, class3.arrayList_0);
				}
			}
		}
		else if (bool_8 && pivotTable_0.DataFields.Count != 0)
		{
			cells_0.GetCell(num4, num2, bool_2: false).PutValue("Total");
			if (bool_5)
			{
				method_103(num4, num3, null, arrayList_0);
			}
			else
			{
				method_105(num4, num3, null, arrayList_0);
			}
		}
	}

	private void method_84()
	{
		if (!bool_7)
		{
			for (int i = 0; i < pivotTable_0.class1164_0.Count; i++)
			{
				Class1163 class1163_ = pivotTable_0.class1164_0[i];
				method_85(class1163_);
			}
		}
	}

	private void method_85(Class1163 class1163_0)
	{
		Style style = class1163_0.method_1();
		int byte_ = class1163_0.byte_0;
		ArrayList arrayList = method_86(class1163_0.class1171_0);
		for (int i = 0; i < arrayList.Count; i++)
		{
			Cell cell = pivotTable_0.pivotTableCollection_0.worksheet_0.Cells.GetCell(((int[])arrayList[i])[0], ((int[])arrayList[i])[1], bool_2: false);
			switch (byte_)
			{
			case 1:
			{
				Style style2 = new Style(pivotTable_0.pivotTableCollection_0.worksheet_0.method_2());
				style2.Copy(cell.GetStyle());
				if (style != null)
				{
					Class1627.smethod_2(style2, style);
				}
				cell.method_30(style2);
				break;
			}
			case 0:
				cell.method_30(new Style(pivotTable_0.pivotTableCollection_0.worksheet_0.method_2()));
				break;
			}
		}
	}

	private ArrayList method_86(Class1171 class1171_0)
	{
		ArrayList arrayList = new ArrayList();
		if (class1171_0.method_12() == 6)
		{
			if (class1171_0.method_16())
			{
				if (class1171_0.byte_4 == byte.MaxValue)
				{
					arrayList.Add(new int[2] { pivotTable_0.int_0, pivotTable_0.int_3 });
				}
				else
				{
					for (int i = class1171_0.byte_4; i <= class1171_0.byte_5; i++)
					{
						arrayList.Add(new int[2]
						{
							pivotTable_0.int_0,
							pivotTable_0.int_6 + pivotTable_0.ColumnFields.Count + i
						});
					}
				}
			}
			else
			{
				for (int j = pivotTable_0.int_6 + pivotTable_0.ColumnFields.Count; j <= pivotTable_0.int_3; j++)
				{
					arrayList.Add(new int[2] { pivotTable_0.int_0, j });
				}
			}
		}
		else if (class1171_0.method_12() == 5)
		{
			if (class1171_0.method_10() == 1)
			{
				if (pivotTable_0.int_2 + class1171_0.byte_0 < pivotTable_0.int_6)
				{
					arrayList.Add(new int[2]
					{
						pivotTable_0.int_5 - 1,
						pivotTable_0.int_2 + class1171_0.byte_0
					});
				}
			}
			else if (class1171_0.method_10() == 2)
			{
				arrayList.Add(new int[2]
				{
					pivotTable_0.int_0,
					pivotTable_0.int_6 + class1171_0.byte_0
				});
			}
			else if (class1171_0.method_10() == 4)
			{
				arrayList.Add(new int[2]
				{
					pivotTable_0.int_0 - 1 - pivotTable_0.PageFields.Count + class1171_0.byte_0,
					pivotTable_0.int_2
				});
			}
		}
		else if (class1171_0.method_12() == 4)
		{
			if (class1171_0.method_16())
			{
				ArrayList arrayList2 = new ArrayList();
				ArrayList arrayList3 = new ArrayList();
				if (class1171_0.byte_4 == byte.MaxValue)
				{
					arrayList2.Add(pivotTable_0.int_6 - 1);
				}
				else
				{
					for (int k = class1171_0.byte_4; k <= class1171_0.byte_5; k++)
					{
						arrayList2.Add(pivotTable_0.int_2 + k);
					}
				}
				if (class1171_0.byte_2 == byte.MaxValue)
				{
					arrayList3.Add(pivotTable_0.int_5 - 2);
				}
				else
				{
					for (int l = class1171_0.byte_2; l <= class1171_0.byte_3; l++)
					{
						arrayList3.Add(pivotTable_0.int_0 + l);
					}
				}
				for (int m = 0; m < arrayList3.Count; m++)
				{
					for (int n = 0; n < arrayList2.Count; n++)
					{
						arrayList.Add(new int[2]
						{
							(int)arrayList3[m],
							(int)arrayList2[n]
						});
					}
				}
			}
			else
			{
				for (int num = pivotTable_0.int_0; num <= pivotTable_0.int_5 - 2; num++)
				{
					for (int num2 = pivotTable_0.int_2; num2 <= pivotTable_0.int_6 - 1; num2++)
					{
						arrayList.Add(new int[2] { num, num2 });
					}
				}
			}
		}
		else if (class1171_0.method_12() == 3)
		{
			if (pivotTable_0.PageFields.Count > 0)
			{
				for (int num3 = pivotTable_0.int_0 - 1 - pivotTable_0.PageFields.Count; num3 < pivotTable_0.int_0 - 1; num3++)
				{
					for (int num4 = pivotTable_0.int_2; num4 <= pivotTable_0.int_2 + 1; num4++)
					{
						arrayList.Add(new int[2] { num3, num4 });
					}
				}
			}
			for (int num5 = pivotTable_0.int_0; num5 <= pivotTable_0.int_1; num5++)
			{
				for (int num6 = pivotTable_0.int_2; num6 <= pivotTable_0.int_3; num6++)
				{
					arrayList.Add(new int[2] { num5, num6 });
				}
			}
		}
		else if (!class1171_0.method_6() && !class1171_0.method_4())
		{
			if (class1171_0.method_0())
			{
				method_92(class1171_0.arrayList_0, arrayList, class1171_0.bool_0);
			}
			else if (class1171_0.method_2())
			{
				method_89(class1171_0.arrayList_0, arrayList, class1171_0);
			}
			else
			{
				method_89(class1171_0.arrayList_0, arrayList, class1171_0);
				method_92(class1171_0.arrayList_0, arrayList, class1171_0.bool_0);
			}
		}
		else if (class1171_0.method_4() && class1171_0.method_6())
		{
			method_87(class1171_0.arrayList_0, arrayList, class1171_0, bool_11: true, bool_12: true);
		}
		else if (class1171_0.method_4())
		{
			if (class1171_0.method_0())
			{
				method_87(class1171_0.arrayList_0, arrayList, class1171_0, bool_11: true, bool_12: false);
			}
			else if (class1171_0.method_2())
			{
				method_88(class1171_0.arrayList_0, arrayList, class1171_0, bool_11: true);
			}
			else
			{
				for (int num7 = pivotTable_0.int_2; num7 <= pivotTable_0.int_3; num7++)
				{
					arrayList.Add(new int[2] { pivotTable_0.int_1, num7 });
				}
			}
		}
		else if (class1171_0.method_6())
		{
			if (class1171_0.method_0())
			{
				method_87(class1171_0.arrayList_0, arrayList, class1171_0, bool_11: false, bool_12: true);
			}
			else if (class1171_0.method_2())
			{
				method_88(class1171_0.arrayList_0, arrayList, class1171_0, bool_11: false);
			}
			else
			{
				for (int num8 = pivotTable_0.int_0; num8 <= pivotTable_0.int_1; num8++)
				{
					arrayList.Add(new int[2] { num8, pivotTable_0.int_3 });
				}
			}
		}
		return arrayList;
	}

	private void method_87(ArrayList arrayList_9, ArrayList arrayList_10, Class1171 class1171_0, bool bool_11, bool bool_12)
	{
		if (bool_11 && bool_12)
		{
			if (!pivotTable_0.ColumnGrand || !pivotTable_0.RowGrand)
			{
				return;
			}
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			ArrayList arrayList_11 = new ArrayList();
			method_96(arrayList_9, arrayList, arrayList2, arrayList_11);
			ArrayList arrayList3 = new ArrayList();
			if (pivotFieldType_0 == PivotFieldType.Row)
			{
				for (int i = 0; i < arrayList.Count; i++)
				{
					Class1162 @class = (Class1162)arrayList[i];
					for (int j = 0; j < @class.arrayList_0.Count; j++)
					{
						arrayList3.Add((int)@class.arrayList_0[j]);
					}
				}
				for (int k = 0; k < arrayList3.Count; k++)
				{
					arrayList_10.Add(new int[2]
					{
						pivotTable_0.int_1 - pivotTable_0.DataFields.Count + 1 + (int)arrayList3[k],
						pivotTable_0.int_3
					});
				}
			}
			else if (pivotFieldType_0 == PivotFieldType.Column)
			{
				for (int l = 0; l < arrayList2.Count; l++)
				{
					Class1162 class2 = (Class1162)arrayList2[l];
					for (int m = 0; m < class2.arrayList_0.Count; m++)
					{
						arrayList3.Add((int)class2.arrayList_0[m]);
					}
				}
				for (int n = 0; n < arrayList3.Count; n++)
				{
					arrayList_10.Add(new int[2]
					{
						pivotTable_0.int_1,
						pivotTable_0.int_3 - pivotTable_0.DataFields.Count + 1 + (int)arrayList3[n]
					});
				}
			}
			else
			{
				arrayList_10.Add(new int[2] { pivotTable_0.int_1, pivotTable_0.int_3 });
			}
		}
		else if (bool_11)
		{
			if (!pivotTable_0.ColumnGrand)
			{
				return;
			}
			ArrayList arrayList4 = new ArrayList();
			ArrayList arrayList5 = new ArrayList();
			ArrayList arrayList_12 = new ArrayList();
			if (arrayList_9.Count == 0)
			{
				for (int num = pivotTable_0.int_5; num <= pivotTable_0.int_1; num++)
				{
					for (int num2 = pivotTable_0.int_6; num2 <= pivotTable_0.int_3; num2++)
					{
						arrayList_10.Add(new int[2] { num, num2 });
					}
				}
				return;
			}
			method_96(arrayList_9, arrayList4, arrayList5, arrayList_12);
			if (arrayList5.Count == 0)
			{
				return;
			}
			ArrayList arrayList6 = method_93(arrayList5, PivotFieldType.Column, class1171_0.bool_0);
			if (pivotFieldType_0 == PivotFieldType.Row)
			{
				if (arrayList4.Count <= 0)
				{
					return;
				}
				ArrayList arrayList7 = new ArrayList();
				for (int num3 = 0; num3 < arrayList4.Count; num3++)
				{
					Class1162 class3 = (Class1162)arrayList4[num3];
					for (int num4 = 0; num4 < class3.arrayList_0.Count; num4++)
					{
						arrayList7.Add((int)class3.arrayList_0[num4]);
					}
				}
				for (int num5 = 0; num5 < arrayList6.Count; num5++)
				{
					for (int num6 = 0; num6 < arrayList7.Count; num6++)
					{
						arrayList_10.Add(new int[2]
						{
							pivotTable_0.int_1 - pivotTable_0.DataFields.Count + 1 + (int)arrayList7[num5],
							pivotTable_0.int_6 + (int)arrayList6[num5]
						});
					}
				}
			}
			else
			{
				for (int num7 = 0; num7 < arrayList6.Count; num7++)
				{
					arrayList_10.Add(new int[2]
					{
						pivotTable_0.int_1,
						pivotTable_0.int_6 + (int)arrayList6[num7]
					});
				}
			}
		}
		else
		{
			if (!bool_12 || !pivotTable_0.RowGrand)
			{
				return;
			}
			ArrayList arrayList8 = new ArrayList();
			ArrayList arrayList9 = new ArrayList();
			ArrayList arrayList_13 = new ArrayList();
			method_96(arrayList_9, arrayList8, arrayList9, arrayList_13);
			if (arrayList_9.Count == 0)
			{
				for (int num8 = pivotTable_0.int_5; num8 <= pivotTable_0.int_1; num8++)
				{
					for (int num9 = pivotTable_0.int_6; num9 <= pivotTable_0.int_3; num9++)
					{
						arrayList_10.Add(new int[2] { num8, num9 });
					}
				}
			}
			else
			{
				if (arrayList8.Count == 0)
				{
					return;
				}
				ArrayList arrayList10 = method_93(arrayList8, PivotFieldType.Row, class1171_0.bool_0);
				if (pivotFieldType_0 == PivotFieldType.Column)
				{
					if (arrayList9.Count <= 0)
					{
						return;
					}
					ArrayList arrayList11 = new ArrayList();
					for (int num10 = 0; num10 < arrayList9.Count; num10++)
					{
						Class1162 class4 = (Class1162)arrayList9[num10];
						for (int num11 = 0; num11 < class4.arrayList_0.Count; num11++)
						{
							arrayList11.Add((int)class4.arrayList_0[num11]);
						}
					}
					for (int num12 = 0; num12 < arrayList10.Count; num12++)
					{
						for (int num13 = 0; num13 < arrayList11.Count; num13++)
						{
							arrayList_10.Add(new int[2]
							{
								pivotTable_0.int_5 + (int)arrayList10[num12],
								pivotTable_0.int_3 - pivotTable_0.DataFields.Count + 1 + (int)arrayList11[num12]
							});
						}
					}
				}
				else
				{
					for (int num14 = 0; num14 < arrayList10.Count; num14++)
					{
						arrayList_10.Add(new int[2]
						{
							pivotTable_0.int_5 + (int)arrayList10[num14],
							pivotTable_0.int_3
						});
					}
				}
			}
		}
	}

	private void method_88(ArrayList arrayList_9, ArrayList arrayList_10, Class1171 class1171_0, bool bool_11)
	{
		if (bool_11 && pivotTable_0.ColumnGrand)
		{
			bool flag = false;
			ArrayList arrayList = new ArrayList();
			if (pivotFieldType_0 == PivotFieldType.Row)
			{
				flag = true;
				ArrayList arrayList2 = new ArrayList();
				ArrayList arrayList_11 = new ArrayList();
				ArrayList arrayList_12 = new ArrayList();
				method_96(arrayList_9, arrayList2, arrayList_11, arrayList_12);
				for (int i = 0; i < arrayList2.Count; i++)
				{
					Class1162 @class = (Class1162)arrayList2[i];
					for (int j = 0; j < @class.arrayList_0.Count; j++)
					{
						arrayList.Add((int)@class.arrayList_0[j]);
					}
				}
			}
			if (class1171_0.method_16())
			{
				if (class1171_0.byte_4 == byte.MaxValue)
				{
					if (flag)
					{
						for (int k = 0; k < arrayList.Count; k++)
						{
							arrayList_10.Add(new int[2]
							{
								pivotTable_0.int_1 - pivotTable_0.DataFields.Count + 1 + (int)arrayList[k],
								pivotTable_0.int_6 - 1
							});
						}
					}
					else
					{
						arrayList_10.Add(new int[2]
						{
							pivotTable_0.int_1,
							pivotTable_0.int_6 - 1
						});
					}
					return;
				}
				for (int l = pivotTable_0.int_2 + class1171_0.byte_4; l <= pivotTable_0.int_2 + class1171_0.byte_5; l++)
				{
					if (flag)
					{
						for (int m = 0; m < arrayList.Count; m++)
						{
							arrayList_10.Add(new int[2]
							{
								pivotTable_0.int_1 - pivotTable_0.DataFields.Count + 1 + (int)arrayList[m],
								l
							});
						}
					}
					else
					{
						arrayList_10.Add(new int[2] { pivotTable_0.int_1, l });
					}
				}
				return;
			}
			for (int n = 0; n <= pivotTable_0.int_6 - 1 - pivotTable_0.int_2; n++)
			{
				if (flag)
				{
					for (int num = 0; num < arrayList.Count; num++)
					{
						arrayList_10.Add(new int[2]
						{
							pivotTable_0.int_1 - pivotTable_0.DataFields.Count + 1 + (int)arrayList[num],
							pivotTable_0.int_2 + n
						});
					}
				}
				else
				{
					arrayList_10.Add(new int[2]
					{
						pivotTable_0.int_1,
						pivotTable_0.int_2 + n
					});
				}
			}
		}
		else
		{
			if (bool_11 || !pivotTable_0.RowGrand)
			{
				return;
			}
			bool flag2 = false;
			ArrayList arrayList3 = new ArrayList();
			if (pivotFieldType_0 == PivotFieldType.Column)
			{
				flag2 = true;
				ArrayList arrayList_13 = new ArrayList();
				ArrayList arrayList4 = new ArrayList();
				ArrayList arrayList_14 = new ArrayList();
				method_96(arrayList_9, arrayList_13, arrayList4, arrayList_14);
				for (int num2 = 0; num2 < arrayList4.Count; num2++)
				{
					Class1162 class2 = (Class1162)arrayList4[num2];
					for (int num3 = 0; num3 < class2.arrayList_0.Count; num3++)
					{
						arrayList3.Add((int)class2.arrayList_0[num3]);
					}
				}
			}
			int num4 = pivotTable_0.int_0 + 1;
			if (pivotTable_0.RowFields.Count == 0)
			{
				num4 = pivotTable_0.int_0;
			}
			if (class1171_0.method_16())
			{
				if (class1171_0.byte_2 == byte.MaxValue)
				{
					if (flag2)
					{
						for (int num5 = 0; num5 < arrayList3.Count; num5++)
						{
							arrayList_10.Add(new int[2]
							{
								pivotTable_0.int_5 - 1,
								pivotTable_0.int_3 - pivotTable_0.DataFields.Count + 1 + (int)arrayList3[num5]
							});
						}
					}
					else
					{
						arrayList_10.Add(new int[2]
						{
							pivotTable_0.int_5 - 1,
							pivotTable_0.int_3
						});
					}
					return;
				}
				for (int num6 = num4 + class1171_0.byte_2; num6 <= num4 + class1171_0.byte_3; num6++)
				{
					if (flag2)
					{
						for (int num7 = 0; num7 < arrayList3.Count; num7++)
						{
							arrayList_10.Add(new int[2]
							{
								num6,
								pivotTable_0.int_3 - pivotTable_0.DataFields.Count + 1 + (int)arrayList3[num7]
							});
						}
					}
					else
					{
						arrayList_10.Add(new int[2] { num6, pivotTable_0.int_3 });
					}
				}
				return;
			}
			for (int num8 = num4; num8 <= pivotTable_0.int_5 - 1; num8++)
			{
				if (flag2)
				{
					for (int num9 = 0; num9 < arrayList3.Count; num9++)
					{
						arrayList_10.Add(new int[2]
						{
							num8,
							pivotTable_0.int_3 - pivotTable_0.DataFields.Count + 1 + (int)arrayList3[num9]
						});
					}
				}
				else
				{
					arrayList_10.Add(new int[2] { num8, pivotTable_0.int_3 });
				}
			}
		}
	}

	private void method_89(ArrayList arrayList_9, ArrayList arrayList_10, Class1171 class1171_0)
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		method_96(arrayList_9, arrayList, arrayList2, arrayList3);
		if (arrayList.Count == 0 && arrayList2.Count == 0 && arrayList3.Count == 0)
		{
			if (arrayList_9.Count == 0 && class1171_0.method_10() == 8 && class1171_0.byte_0 == 0)
			{
				if (pivotTable_0.RowFields.Count == 0 && pivotTable_0.ColumnFields.Count > 0 && pivotTable_0.DataFields.Count == 1)
				{
					arrayList_10.Add(new int[2] { pivotTable_0.int_5, pivotTable_0.int_2 });
				}
				else if (pivotTable_0.ColumnFields.Count == 0 && pivotTable_0.RowFields.Count > 0 && pivotTable_0.DataFields.Count == 1)
				{
					arrayList_10.Add(new int[2] { pivotTable_0.int_0, pivotTable_0.int_6 });
				}
				else if (pivotTable_0.ColumnFields.Count == 0 && pivotTable_0.RowFields.Count == 0)
				{
					arrayList_10.Add(new int[2] { pivotTable_0.int_0, pivotTable_0.int_2 });
				}
			}
		}
		else if (arrayList3.Count > 0)
		{
			for (int i = 0; i < arrayList3.Count; i++)
			{
				int index = ((Class1162)arrayList3[i]).method_1();
				int position = pivotTable_0.BaseFields[index].Position;
				arrayList_10.Add(new int[2]
				{
					pivotTable_0.int_0 - 1 - pivotTable_0.PageFields.Count + position,
					pivotTable_0.int_2 + 1
				});
			}
		}
		else
		{
			if (arrayList.Count > 0 && arrayList2.Count > 0)
			{
				return;
			}
			if (arrayList.Count > 0)
			{
				ArrayList arrayList4 = method_93(arrayList, PivotFieldType.Row, class1171_0.bool_0);
				if (arrayList4.Count == 0)
				{
					return;
				}
				short num = (short)((Class1162)arrayList[arrayList.Count - 1]).method_1();
				int num2 = 0;
				num2 = ((num != -2) ? pivotTable_0.BaseFields[num].Position : int_1);
				int num3 = method_77(num2);
				ArrayList arrayList5 = new ArrayList();
				if (((Class1162)arrayList[arrayList.Count - 1]).Function != 1 && !pivotTable_0.RowFields[num2].method_9())
				{
					if (class1171_0.method_16())
					{
						if (class1171_0.byte_4 == byte.MaxValue)
						{
							arrayList5.Add(pivotTable_0.int_6 - 1 - pivotTable_0.int_2);
						}
						else
						{
							for (int j = num3 + class1171_0.byte_4; j <= num3 + class1171_0.byte_5; j++)
							{
								arrayList5.Add(j);
							}
						}
					}
					else
					{
						for (int k = num3; k < pivotTable_0.int_6 - pivotTable_0.int_2; k++)
						{
							arrayList5.Add(k);
						}
					}
				}
				else if (num2 != pivotTable_0.RowFields.Count - 1 && pivotTable_0.RowFields[num2].ShowInOutlineForm)
				{
					if (class1171_0.method_16())
					{
						if (class1171_0.byte_2 == byte.MaxValue)
						{
							if (class1171_0.byte_4 == byte.MaxValue)
							{
								ArrayList arrayList6 = new ArrayList();
								for (int l = 0; l < arrayList4.Count; l++)
								{
									arrayList6.Add(method_90((int)arrayList4[l], num2, PivotFieldType.Row));
								}
								arrayList4 = arrayList6;
								arrayList5.Add(num3);
							}
							else
							{
								for (int m = num3 + class1171_0.byte_4; m <= num3 + class1171_0.byte_5; m++)
								{
									arrayList5.Add(m);
								}
							}
						}
						else
						{
							ArrayList arrayList7 = new ArrayList();
							for (int n = 0; n < arrayList4.Count; n++)
							{
								for (int num4 = class1171_0.byte_2; num4 <= class1171_0.byte_3; num4++)
								{
									arrayList7.Add((int)arrayList4[n] + num4);
								}
							}
							arrayList4 = arrayList7;
							arrayList5.Add(num3);
						}
					}
					else
					{
						arrayList5.Add(num3);
					}
				}
				else
				{
					arrayList5.Add(num3);
				}
				for (int num5 = 0; num5 < arrayList4.Count; num5++)
				{
					for (int num6 = 0; num6 < arrayList5.Count; num6++)
					{
						arrayList_10.Add(new int[2]
						{
							pivotTable_0.int_5 + (int)arrayList4[num5],
							pivotTable_0.int_2 + (int)arrayList5[num6]
						});
					}
				}
			}
			if (arrayList2.Count <= 0)
			{
				return;
			}
			ArrayList arrayList8 = method_93(arrayList2, PivotFieldType.Column, class1171_0.bool_0);
			if (arrayList8.Count == 0)
			{
				return;
			}
			short num7 = (short)((Class1162)arrayList2[arrayList2.Count - 1]).method_1();
			int num8 = 0;
			num8 = ((num7 != -2) ? pivotTable_0.BaseFields[num7].Position : int_1);
			int num9 = num8 + 1;
			ArrayList arrayList9 = new ArrayList();
			if (((Class1162)arrayList2[arrayList2.Count - 1]).Function != 1)
			{
				if (class1171_0.method_16())
				{
					if (class1171_0.byte_2 == byte.MaxValue)
					{
						arrayList9.Add(pivotTable_0.int_5 - 1 - pivotTable_0.int_0);
					}
					else
					{
						for (int num10 = num9 + class1171_0.byte_2; num10 <= num9 + class1171_0.byte_3; num10++)
						{
							arrayList9.Add(num10);
						}
					}
				}
				else
				{
					for (int num11 = num9; num11 <= pivotTable_0.int_5 - 1 - pivotTable_0.int_0; num11++)
					{
						arrayList9.Add(num11);
					}
				}
			}
			else if (class1171_0.method_16())
			{
				if (class1171_0.byte_4 == byte.MaxValue)
				{
					ArrayList arrayList10 = new ArrayList();
					for (int num12 = 0; num12 < arrayList8.Count; num12++)
					{
						arrayList10.Add(method_90((int)arrayList8[num12], num8, PivotFieldType.Column));
					}
					arrayList8 = arrayList10;
					arrayList9.Add(num9);
				}
				else
				{
					ArrayList arrayList11 = new ArrayList();
					for (int num13 = 0; num13 < arrayList8.Count; num13++)
					{
						for (int num14 = class1171_0.byte_4; num14 <= class1171_0.byte_5; num14++)
						{
							arrayList11.Add((int)arrayList8[num13] + num14);
						}
					}
					arrayList8 = arrayList11;
					arrayList9.Add(num9);
				}
			}
			else
			{
				arrayList9.Add(num9);
			}
			for (int num15 = 0; num15 < arrayList9.Count; num15++)
			{
				for (int num16 = 0; num16 < arrayList8.Count; num16++)
				{
					arrayList_10.Add(new int[2]
					{
						pivotTable_0.int_0 + (int)arrayList9[num15],
						pivotTable_0.int_6 + (int)arrayList8[num16]
					});
				}
			}
		}
	}

	private int method_90(int int_12, int int_13, PivotFieldType pivotFieldType_1)
	{
		ArrayList arrayList = null;
		arrayList = ((pivotFieldType_1 != PivotFieldType.Row) ? arrayList_8 : arrayList_7);
		int num = int_12 + 1;
		while (true)
		{
			if (num < arrayList.Count)
			{
				Class1165 @class = (Class1165)arrayList[num];
				if (@class.int_0 <= int_13)
				{
					break;
				}
				num++;
				continue;
			}
			return arrayList.Count - 1;
		}
		return num - 1;
	}

	private int method_91(int int_12, int int_13, PivotFieldType pivotFieldType_1)
	{
		ArrayList arrayList = null;
		arrayList = ((pivotFieldType_1 != PivotFieldType.Row) ? arrayList_8 : arrayList_7);
		int num = int_12 - 1;
		while (true)
		{
			if (num >= 0)
			{
				Class1165 @class = (Class1165)arrayList[num];
				if (@class.int_0 <= int_13)
				{
					break;
				}
				num++;
				continue;
			}
			return 0;
		}
		return num;
	}

	private void method_92(ArrayList arrayList_9, ArrayList arrayList_10, bool bool_11)
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList_11 = new ArrayList();
		method_96(arrayList_9, arrayList, arrayList2, arrayList_11);
		ArrayList arrayList3 = null;
		ArrayList arrayList4 = null;
		if (arrayList.Count > 0)
		{
			arrayList3 = method_93(arrayList, PivotFieldType.Row, bool_11);
		}
		if (arrayList2.Count > 0)
		{
			arrayList4 = method_93(arrayList2, PivotFieldType.Column, bool_11);
		}
		if (arrayList3 == null && arrayList4 == null)
		{
			for (int i = pivotTable_0.int_5; i <= pivotTable_0.int_1; i++)
			{
				for (int j = pivotTable_0.int_6; j <= pivotTable_0.int_3; j++)
				{
					arrayList_10.Add(new int[2] { i, j });
				}
			}
		}
		else
		{
			if ((arrayList3 == null || arrayList3.Count == 0) && (arrayList4 == null || arrayList4.Count == 0))
			{
				return;
			}
			if (arrayList3 == null)
			{
				if (pivotTable_0.RowFields.Count == 0)
				{
					arrayList3 = new ArrayList();
					arrayList3.Add(0);
				}
				else
				{
					arrayList3 = method_95(PivotFieldType.Row, 2);
				}
			}
			if (arrayList4 == null)
			{
				if (pivotTable_0.ColumnFields.Count == 0)
				{
					arrayList4 = new ArrayList();
					arrayList4.Add(0);
				}
				else
				{
					arrayList4 = method_95(PivotFieldType.Column, 2);
				}
			}
			for (int k = 0; k < arrayList3.Count; k++)
			{
				for (int l = 0; l < arrayList4.Count; l++)
				{
					arrayList_10.Add(new int[2]
					{
						pivotTable_0.int_5 + (int)arrayList3[k],
						pivotTable_0.int_6 + (int)arrayList4[l]
					});
				}
			}
		}
	}

	private ArrayList method_93(ArrayList arrayList_9, PivotFieldType pivotFieldType_1, bool bool_11)
	{
		byte b = 0;
		Class1162 @class = (Class1162)arrayList_9[arrayList_9.Count - 1];
		bool bool_12 = false;
		int int_ = 0;
		if (((Class1162)arrayList_9[arrayList_9.Count - 1]).Function > 1)
		{
			b = (byte)((!((Class1162)arrayList_9[arrayList_9.Count - 1]).bool_0) ? 1 : 3);
		}
		else if ((short)@class.method_1() == -2 && arrayList_9.Count >= 2 && ((Class1162)arrayList_9[arrayList_9.Count - 2]).Function > 1)
		{
			if (!((Class1162)arrayList_9[arrayList_9.Count - 2]).bool_0)
			{
				b = 1;
				if (@class.arrayList_0.Count > 0)
				{
					bool_12 = true;
					int_ = (int)@class.arrayList_0[0];
					arrayList_9.RemoveAt(arrayList_9.Count - 1);
				}
			}
			else
			{
				b = 3;
			}
		}
		else if (pivotFieldType_1 == PivotFieldType.Row && arrayList_9.Count < pivotTable_0.RowFields.Count)
		{
			int num = (short)((Class1162)arrayList_9[arrayList_9.Count - 1]).method_1();
			int num2 = 0;
			num2 = ((num != -2) ? pivotTable_0.BaseFields[num].Position : int_1);
			if (num >= 0 && num2 < pivotTable_0.RowFields.Count - 1 && pivotTable_0.BaseFields[num].ShowInOutlineForm)
			{
				b = 3;
			}
		}
		ArrayList arrayList = method_95(pivotFieldType_1, b);
		if (arrayList.Count == 0)
		{
			return arrayList;
		}
		for (int i = 0; i < arrayList_9.Count; i++)
		{
			if (i == arrayList_9.Count - 1)
			{
				method_94((Class1162)arrayList_9[i], arrayList, pivotFieldType_1, bool_11: true, b, bool_12, int_);
			}
			else
			{
				method_94((Class1162)arrayList_9[i], arrayList, pivotFieldType_1, bool_11: false, b, bool_12, int_);
			}
		}
		if (b == 3)
		{
			short num3 = (short)((Class1162)arrayList_9[arrayList_9.Count - 1]).method_1();
			if (num3 != -2 && pivotTable_0.BaseFields[num3].ShowInOutlineForm && !pivotTable_0.BaseFields[num3].ShowSubtotalAtTop)
			{
				ArrayList arrayList2 = new ArrayList();
				for (int j = 0; j < arrayList.Count; j++)
				{
					Class1165 class2 = (Class1165)arrayList_7[(int)arrayList[j]];
					if (bool_11)
					{
						if (class2.enum185_0 != 0 && class2.enum185_0 != Enum185.const_13 && class2.enum185_0 != Enum185.const_14)
						{
							arrayList2.Add(arrayList[j]);
						}
					}
					else if (class2.enum185_0 == Enum185.const_0)
					{
						arrayList2.Add(arrayList[j]);
					}
				}
				if (arrayList2.Count > 0)
				{
					arrayList = arrayList2;
				}
			}
		}
		return arrayList;
	}

	private void method_94(Class1162 class1162_0, ArrayList arrayList_9, PivotFieldType pivotFieldType_1, bool bool_11, byte byte_0, bool bool_12, int int_12)
	{
		ArrayList arrayList = new ArrayList();
		if (class1162_0.arrayList_0.Count > 0)
		{
			for (int i = 0; i < arrayList_9.Count; i++)
			{
				bool flag = true;
				Class1165 @class = null;
				@class = ((pivotFieldType_1 != PivotFieldType.Row) ? ((Class1165)arrayList_8[(int)arrayList_9[i]]) : ((Class1165)arrayList_7[(int)arrayList_9[i]]));
				short num = (short)class1162_0.method_1();
				int num2 = 0;
				num2 = ((num == -2 || num == 254) ? int_1 : pivotTable_0.BaseFields[num].Position);
				if (bool_12 && @class.method_5() != int_12)
				{
					flag = true;
				}
				else if (bool_11 && byte_0 == 3 && num2 != @class.int_1 - 1)
				{
					flag = true;
				}
				else if (num2 > @class.int_1 - 1)
				{
					flag = true;
				}
				else
				{
					for (int j = 0; j < class1162_0.arrayList_0.Count; j++)
					{
						if (num != -2 && num != 254)
						{
							if (@class.int_2[num2] == (int)class1162_0.arrayList_0[j])
							{
								flag = false;
								break;
							}
						}
						else if (@class.method_5() == (int)class1162_0.arrayList_0[j])
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					arrayList.Add(arrayList_9[i]);
				}
			}
		}
		if (class1162_0.bool_1)
		{
			for (int k = 0; k < arrayList_9.Count; k++)
			{
				int num3 = (int)arrayList_9[k];
				Class1165 class2 = null;
				class2 = ((pivotFieldType_1 != PivotFieldType.Row) ? ((Class1165)arrayList_8[num3]) : ((Class1165)arrayList_7[num3]));
				if (!class2.method_2())
				{
					arrayList.Add(num3);
				}
			}
		}
		for (int l = 0; l < arrayList.Count; l++)
		{
			arrayList_9.Remove(arrayList[l]);
		}
	}

	private ArrayList method_95(PivotFieldType pivotFieldType_1, byte byte_0)
	{
		ArrayList arrayList = new ArrayList();
		switch (pivotFieldType_1)
		{
		case PivotFieldType.Row:
		{
			for (int j = 0; j < arrayList_7.Count; j++)
			{
				Class1165 class2 = (Class1165)arrayList_7[j];
				switch (byte_0)
				{
				case 1:
					if (class2.enum185_0 == Enum185.const_0 || class2.enum185_0 == Enum185.const_13 || class2.enum185_0 == Enum185.const_14)
					{
						continue;
					}
					break;
				case 0:
					if (class2.enum185_0 != 0)
					{
						continue;
					}
					break;
				case 3:
					if (class2.enum185_0 == Enum185.const_13)
					{
						continue;
					}
					break;
				}
				arrayList.Add(j);
			}
			break;
		}
		case PivotFieldType.Column:
		{
			for (int i = 0; i < arrayList_8.Count; i++)
			{
				Class1165 @class = (Class1165)arrayList_8[i];
				switch (byte_0)
				{
				case 1:
					if (@class.enum185_0 == Enum185.const_0 || @class.enum185_0 == Enum185.const_13 || @class.enum185_0 == Enum185.const_14)
					{
						continue;
					}
					break;
				case 0:
					if (@class.enum185_0 != 0)
					{
						continue;
					}
					break;
				}
				arrayList.Add(i);
			}
			break;
		}
		}
		return arrayList;
	}

	private void method_96(ArrayList arrayList_9, ArrayList arrayList_10, ArrayList arrayList_11, ArrayList arrayList_12)
	{
		for (int i = 0; i < arrayList_9.Count; i++)
		{
			Class1162 @class = (Class1162)arrayList_9[i];
			short num = (short)@class.method_1();
			if (num != -2 && num != 254)
			{
				switch (pivotTable_0.BaseFields[num].pivotFieldType_0)
				{
				case PivotFieldType.Row:
					method_97(pivotTable_0.BaseFields[num].Position, @class, arrayList_10);
					break;
				case PivotFieldType.Column:
					method_97(pivotTable_0.BaseFields[num].Position, @class, arrayList_11);
					break;
				case PivotFieldType.Page:
					method_97(pivotTable_0.BaseFields[num].Position, @class, arrayList_12);
					break;
				}
			}
			else if (pivotFieldType_0 == PivotFieldType.Row)
			{
				method_97(int_1, @class, arrayList_10);
			}
			else if (pivotFieldType_0 == PivotFieldType.Column)
			{
				method_97(int_1, @class, arrayList_11);
			}
		}
	}

	private void method_97(int int_12, Class1162 class1162_0, ArrayList arrayList_9)
	{
		bool flag = false;
		for (int i = 0; i < arrayList_9.Count; i++)
		{
			Class1162 @class = (Class1162)arrayList_9[i];
			int num = 0;
			short num2 = (short)@class.method_1();
			num = ((num2 == -2 || num2 == 254) ? int_1 : pivotTable_0.BaseFields[num2].Position);
			if (int_12 < num)
			{
				arrayList_9.Insert(i, class1162_0);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			arrayList_9.Add(class1162_0);
		}
	}

	private object method_98(object object_0)
	{
		if (object_0 == null)
		{
			return "(Blank)";
		}
		if (object_0 is DateTime)
		{
			return (DateTime)object_0;
		}
		return object_0;
	}

	private void method_99(int int_12, int int_13)
	{
		for (int i = 0; i < arrayList_5.Count; i++)
		{
			Class1165 @class = (Class1165)arrayList_5[i];
			if (@class.enum185_0 == Enum185.const_14)
			{
				continue;
			}
			int num = @class.int_0;
			if (@class.method_4())
			{
				if (@class.method_2())
				{
					PivotItem pivotItem = pivotTable_0.RowFields[num].PivotItems[@class.int_2[num]];
					if (@class.int_0 < int_1)
					{
						int index = @class.method_5();
						cells_0.GetCell(int_12 + i, int_13 + num, bool_2: false).PutValue(string.Concat(method_98(pivotItem.Value), " ", pivotTable_0.DataFields[index].DisplayName));
					}
					else
					{
						cells_0.GetCell(int_12 + i, int_13 + num, bool_2: false).PutValue(string.Concat(method_98(pivotItem.Value), @class.method_1()));
					}
					continue;
				}
				if (@class.method_3())
				{
					cells_0.GetCell(int_12 + i, int_13, bool_2: false).PutValue(pivotTable_0.GrandTotalName);
					continue;
				}
				for (num = @class.int_0; num < @class.int_1; num++)
				{
					if (num == int_1)
					{
						int index2 = @class.method_5();
						cells_0.GetCell(int_12 + i, int_13 + num, bool_2: false).PutValue(pivotTable_0.DataFields[index2].DisplayName);
					}
					else
					{
						int index3 = @class.int_2[num];
						PivotItem pivotItem2 = pivotTable_0.RowFields[num].PivotItems[index3];
						cells_0.GetCell(int_12 + i, int_13 + num, bool_2: false).PutValue(method_98(pivotItem2.Value));
					}
				}
				continue;
			}
			if (@class.method_2())
			{
				PivotItem pivotItem3 = pivotTable_0.RowFields[num].PivotItems[@class.int_2[num]];
				cells_0.GetCell(int_12 + i, int_13 + num, bool_2: false).PutValue(string.Concat(method_98(pivotItem3.Value), @class.method_1()));
				continue;
			}
			if (@class.method_3())
			{
				cells_0.GetCell(int_12 + i, int_13 + num, bool_2: false).PutValue(pivotTable_0.GrandTotalName);
				continue;
			}
			for (num = @class.int_0; num < @class.int_1; num++)
			{
				int index4 = @class.int_2[num];
				PivotItem pivotItem4 = pivotTable_0.RowFields[num].PivotItems[index4];
				object obj = method_98(pivotItem4.Value);
				if (num > 0 && pivotTable_0.RowFields[num - 1].ShowInOutlineForm && pivotTable_0.RowFields[num - 1].ShowCompact)
				{
					Cell cell = cells_0.GetCell(int_12 + i, int_13 + num - 1, bool_2: false);
					cell.PutValue(obj);
					if (obj is DateTime)
					{
						Style style = new Style();
						style.Number = 14;
						cell.SetStyle(style);
					}
				}
				else
				{
					cells_0.GetCell(int_12 + i, int_13 + num, bool_2: false).PutValue(obj);
				}
			}
		}
	}

	private void method_100(int int_12, int int_13)
	{
		if (!bool_6)
		{
			int num = 1;
			if (pivotTable_0.DataFields.Count == 0)
			{
				cells_0.GetCell(int_12, int_13, bool_2: false).PutValue("Total");
				return;
			}
			num = pivotTable_0.DataFields.Count;
			for (int i = 0; i < num; i++)
			{
				cells_0.GetCell(int_12, int_13 + i, bool_2: false).PutValue(pivotTable_0.DataFields[i].DisplayName);
			}
			return;
		}
		for (int j = 0; j < arrayList_6.Count; j++)
		{
			Class1165 @class = (Class1165)arrayList_6[j];
			int num2 = @class.int_0;
			if (@class.method_4())
			{
				if (@class.method_2())
				{
					PivotItem pivotItem = pivotTable_0.ColumnFields[num2].PivotItems[@class.int_2[num2]];
					if (@class.int_0 < int_1)
					{
						int index = @class.method_5();
						cells_0.GetCell(int_12 + num2, int_13 + j, bool_2: false).PutValue(string.Concat(method_98(pivotItem.Value), " ", pivotTable_0.DataFields[index].DisplayName));
					}
					else
					{
						cells_0.GetCell(int_12 + num2, int_13 + j, bool_2: false).PutValue(string.Concat(method_98(pivotItem.Value), @class.method_1()));
					}
					continue;
				}
				if (@class.method_3())
				{
					if (pivotTable_0.DataField == null)
					{
						cells_0.GetCell(int_12, int_13 + j, bool_2: false).PutValue(pivotTable_0.GrandTotalName);
					}
					else
					{
						cells_0.GetCell(int_12, int_13 + j, bool_2: false).PutValue("Total " + pivotTable_0.DataFields[@class.method_5()].DisplayName);
					}
					continue;
				}
				for (num2 = @class.int_0; num2 < @class.int_1; num2++)
				{
					if (num2 == int_1)
					{
						int index2 = @class.method_5();
						cells_0.GetCell(int_12 + num2, int_13 + j, bool_2: false).PutValue(pivotTable_0.DataFields[index2].DisplayName);
					}
					else
					{
						int index3 = @class.int_2[num2];
						PivotItem pivotItem2 = pivotTable_0.ColumnFields[num2].PivotItems[index3];
						cells_0.GetCell(int_12 + num2, int_13 + j, bool_2: false).PutValue(method_98(pivotItem2.Value));
					}
				}
			}
			else if (@class.method_2())
			{
				PivotItem pivotItem3 = pivotTable_0.ColumnFields[num2].PivotItems[@class.int_2[num2]];
				cells_0.GetCell(int_12 + num2, int_13 + j, bool_2: false).PutValue(string.Concat(method_98(pivotItem3.Value), @class.method_1()));
			}
			else if (@class.method_3())
			{
				cells_0.GetCell(int_12 + num2, int_13 + j, bool_2: false).PutValue(pivotTable_0.GrandTotalName);
			}
			else
			{
				for (num2 = @class.int_0; num2 < @class.int_1; num2++)
				{
					int index4 = @class.int_2[num2];
					PivotItem pivotItem4 = pivotTable_0.ColumnFields[num2].PivotItems[index4];
					cells_0.GetCell(int_12 + num2, int_13 + j, bool_2: false).PutValue(method_98(pivotItem4.Value));
				}
			}
		}
	}

	private bool method_101(Class1165 class1165_0, PivotFieldCollection pivotFieldCollection_0)
	{
		PivotItem pivotItem = null;
		int num = class1165_0.int_0;
		while (true)
		{
			if (num < class1165_0.int_1)
			{
				pivotItem = pivotFieldCollection_0[num].PivotItems[class1165_0.int_2[num]];
				if (pivotItem.IsFormula)
				{
					break;
				}
				num++;
				continue;
			}
			if (class1165_0.enum185_0 != 0)
			{
				if (pivotFieldCollection_0.Type == PivotFieldType.Row)
				{
					for (int i = class1165_0.int_0 + class1165_0.int_1; i < bool_2.Length; i++)
					{
						if (bool_2[i])
						{
							return true;
						}
					}
				}
				else
				{
					for (int j = class1165_0.int_0 + class1165_0.int_1; j < bool_3.Length; j++)
					{
						if (bool_3[j])
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		return true;
	}

	private PivotField method_102(Class1165 class1165_0, Class1165 class1165_1)
	{
		if (pivotTable_0.DataFields != null && pivotTable_0.DataFields.Count != 0)
		{
			if (class1165_0 != null && class1165_0.method_4())
			{
				return pivotTable_0.DataFields[class1165_0.method_5()];
			}
			if (class1165_1 != null && class1165_1.method_4())
			{
				return pivotTable_0.DataFields[class1165_1.method_5()];
			}
			return pivotTable_0.DataFields[0];
		}
		return null;
	}

	private void method_103(int int_12, int int_13, Class1165 class1165_0, ArrayList arrayList_9)
	{
		if (class1165_0 != null && method_101(class1165_0, pivotTable_0.RowFields))
		{
			return;
		}
		PivotFieldCollection columnFields = pivotTable_0.ColumnFields;
		if (class1165_0 != null)
		{
			if (class1165_0.enum185_0 == Enum185.const_14 || (class1165_0.enum185_0 == Enum185.const_0 && class1165_0.int_1 < class1165_0.int_2.Length && class1165_0.int_0 != class1165_0.int_2.Length - 1))
			{
				return;
			}
			arrayList_9 = method_123(arrayList_9, class1165_0, pivotFieldType_0 == PivotFieldType.Row, pivotTable_0.RowFields);
		}
		if (arrayList_6 != null && arrayList_6.Count != 0)
		{
			for (int i = 0; i < arrayList_6.Count; i++)
			{
				Class1165 @class = (Class1165)arrayList_6[i];
				if (@class.method_3())
				{
					ArrayList arrayList = new ArrayList();
					string text = null;
					int num = 0;
					if (columnFields.Count > 0 && columnFields[0].IsAutoSubtotals)
					{
						for (int num2 = i - 1; num2 >= 0; num2--)
						{
							Class1165 class2 = (Class1165)arrayList_6[i];
							if (class2.method_2() && class2.int_0 == 0)
							{
								Cell cell = cells_0.CheckCell(int_12, int_13 + num2);
								if (cell != null && !cell.IsBlank && !Class1150.smethod_0(arrayList, cell, ref num))
								{
									text = cell.StringValue;
									break;
								}
							}
						}
					}
					else
					{
						for (int num3 = i - 1; num3 >= 0; num3--)
						{
							Class1165 class3 = (Class1165)arrayList_6[i];
							if (!class3.method_2())
							{
								Cell cell2 = cells_0.CheckCell(int_12, int_13 + num3);
								if (cell2 != null && !cell2.IsBlank && !Class1150.smethod_0(arrayList, cell2, ref num))
								{
									text = cell2.StringValue;
									break;
								}
							}
						}
					}
					if (text != null)
					{
						cells_0.GetCell(int_12, int_13 + i, bool_2: false).PutValue(text);
					}
					else
					{
						cells_0.GetCell(int_12, int_13 + i, bool_2: false).PutValue(Class1151.smethod_0(method_102(class1165_0, @class).Function, num, arrayList, bool_0: false));
					}
				}
				else if (@class.method_2())
				{
					ArrayList arrayList2 = new ArrayList();
					string text2 = null;
					int num4 = 0;
					int num5 = @class.int_0;
					bool flag = true;
					if (num5 != columnFields.Count - 1 && columnFields[num5 + 1].IsAutoSubtotals)
					{
						for (int num6 = i - 1; num6 >= 0; num6--)
						{
							Class1165 class4 = (Class1165)arrayList_6[num6];
							if (class4.method_2())
							{
								flag = true;
								for (int j = 0; j <= num5; j++)
								{
									if (@class.int_2[j] != class4.int_2[j])
									{
										flag = false;
										break;
									}
								}
								if (flag)
								{
									Cell cell3 = cells_0.CheckCell(int_12, int_13 + num6);
									if (cell3 != null && !cell3.IsBlank && !Class1150.smethod_0(arrayList2, cell3, ref num4))
									{
										text2 = cell3.StringValue;
										break;
									}
								}
							}
						}
					}
					else
					{
						for (int num7 = i - 1; num7 >= 0; num7--)
						{
							Class1165 class5 = (Class1165)arrayList_6[num7];
							if (class5.method_2())
							{
								break;
							}
							flag = true;
							for (int k = 0; k <= num5; k++)
							{
								if (@class.int_2[k] != class5.int_2[k])
								{
									flag = false;
									break;
								}
							}
							if (flag)
							{
								Cell cell4 = cells_0.CheckCell(int_12, int_13 + num7);
								if (cell4 != null && !cell4.IsBlank && !Class1150.smethod_0(arrayList2, cell4, ref num4))
								{
									text2 = cell4.StringValue;
									break;
								}
							}
						}
					}
					if (text2 != null)
					{
						cells_0.GetCell(int_12, int_13 + i, bool_2: false).PutValue(text2);
					}
					else
					{
						cells_0.GetCell(int_12, int_13 + i, bool_2: false).PutValue(Class1151.smethod_0(method_102(class1165_0, @class).Function, num4, arrayList2, bool_0: false));
					}
				}
				else if (method_101(@class, pivotTable_0.ColumnFields))
				{
					ArrayList arrayList_10 = method_122(arrayList_9, @class, pivotFieldType_0 == PivotFieldType.Column, pivotTable_0.ColumnFields);
					cells_0.GetCell(int_12, int_13 + i, bool_2: false).PutValue(method_135(arrayList_10, bool_11: true, class1165_0, @class));
				}
				else
				{
					ArrayList arrayList_11 = method_123(arrayList_9, @class, pivotFieldType_0 == PivotFieldType.Column, pivotTable_0.ColumnFields);
					object object_ = method_137(null, null, arrayList_11, bool_11: true, method_102(class1165_0, @class), 0, null);
					object_ = method_104(object_);
					cells_0.GetCell(int_12, int_13 + i, bool_2: false).PutValue(object_);
				}
			}
		}
		else
		{
			object object_2 = method_137(null, null, arrayList_9, bool_11: true, method_102(class1165_0, null), 0, null);
			object_2 = method_104(object_2);
			cells_0.GetCell(int_12, int_13, bool_2: false).PutValue(object_2);
		}
	}

	private object method_104(object object_0)
	{
		if (object_0 != null && object_0.Equals("#DIV/0!") && pivotTable_0.DisplayErrorString)
		{
			object_0 = ((!pivotTable_0.ErrorString.Equals("-")) ? pivotTable_0.ErrorString : ((object)0));
		}
		return object_0;
	}

	private void method_105(int int_12, int int_13, Class1165 class1165_0, ArrayList arrayList_9)
	{
		int_6 = int_12 - pivotTable_0.int_5;
		PivotField pivotField = null;
		ArrayList arrayList = null;
		if (class1165_0 != null)
		{
			if (class1165_0.enum185_0 == Enum185.const_14)
			{
				return;
			}
			if (arrayList_9 == null)
			{
				if (class1165_0.method_2() || class1165_0.method_0() >= pivotTable_0.RowFields.Count || !pivotTable_0.RowFields[class1165_0.method_0()].ShowSubtotalAtTop)
				{
					return;
				}
				arrayList_9 = method_123(arrayList_0, class1165_0, pivotFieldType_0 == PivotFieldType.Row, pivotTable_0.RowFields);
			}
		}
		if (arrayList_6 != null && arrayList_6.Count != 0)
		{
			for (int i = 0; i < arrayList_6.Count; i++)
			{
				Class1165 @class = (Class1165)arrayList_6[i];
				pivotField = method_102(class1165_0, @class);
				if (pivotField != null)
				{
					arrayList = ((arrayList_9 != null) ? method_123(arrayList_9, @class, pivotFieldType_0 == PivotFieldType.Column, pivotTable_0.ColumnFields) : method_123(arrayList_0, @class, pivotFieldType_0 == PivotFieldType.Column, pivotTable_0.ColumnFields));
					object object_ = method_137(null, null, arrayList, bool_11: true, pivotField, i, @class);
					object_ = method_104(object_);
					cells_0.GetCell(int_12, int_13 + i, bool_2: false).PutValue(object_);
				}
			}
		}
		else
		{
			pivotField = method_102(class1165_0, null);
			if (pivotField != null)
			{
				object object_2 = method_137(null, null, arrayList_9, bool_11: true, pivotField, 0, null);
				object_2 = method_104(object_2);
				cells_0.GetCell(int_12, int_13, bool_2: false).PutValue(object_2);
			}
		}
	}

	private void method_106(int[] int_12)
	{
		arrayList_2.Add(int_12.Clone());
		arrayList_3.Add(new Class1165(int_12));
		arrayList_4.Add(new Class1165(int_12, arrayList_4));
	}

	private void method_107(int[] int_12, ArrayList arrayList_9)
	{
		arrayList_2.Add(int_12.Clone());
		arrayList_3.Add(new Class1165(int_12, arrayList_9, bool_0: true));
		arrayList_4.Add(new Class1165(int_12, arrayList_4));
	}

	private void method_108()
	{
		bool bool_ = false;
		if (pivotTable_0.RowFields.Count > 0)
		{
			int[] array = new int[4 + pivotTable_0.RowFields.Count];
			for (int i = 0; i < pivotTable_0.RowFields.Count; i++)
			{
				PivotField pivotField = pivotTable_0.RowFields[i];
				if (pivotField.method_6())
				{
					bool_ = true;
				}
				array[4 + i] = 32767;
			}
			if (pivotFieldType_0 == PivotFieldType.Row)
			{
				array[3] |= 4096;
			}
			pivotTable_0.arrayList_0 = (arrayList_2 = new ArrayList());
			arrayList_5 = (arrayList_3 = new ArrayList());
			arrayList_7 = (arrayList_4 = new ArrayList());
			method_114(class1154_0, pivotTable_0.RowFields, array, 0, bool_);
		}
		else
		{
			pivotTable_0.arrayList_0 = (arrayList_2 = new ArrayList());
			arrayList_7 = new ArrayList();
		}
		if (pivotTable_0.ColumnFields.Count > 0)
		{
			int[] array2 = new int[4 + pivotTable_0.ColumnFields.Count];
			for (int j = 0; j < pivotTable_0.ColumnFields.Count; j++)
			{
				PivotField pivotField2 = pivotTable_0.ColumnFields[j];
				if (pivotField2.method_6())
				{
					bool_ = true;
				}
				array2[4 + j] = 32767;
			}
			if (pivotFieldType_0 == PivotFieldType.Column)
			{
				array2[3] |= 4096;
			}
			pivotTable_0.arrayList_1 = (arrayList_2 = new ArrayList());
			arrayList_6 = (arrayList_3 = new ArrayList());
			arrayList_8 = (arrayList_4 = new ArrayList());
			method_114(class1154_1, pivotTable_0.ColumnFields, array2, 0, bool_);
		}
		else
		{
			pivotTable_0.arrayList_1 = (arrayList_2 = new ArrayList());
			arrayList_8 = new ArrayList();
		}
	}

	private int method_109()
	{
		switch (pivotTable_0.AutoFormatType)
		{
		default:
			return 1;
		case PivotTableAutoFormatType.Report1:
		case PivotTableAutoFormatType.Report2:
		case PivotTableAutoFormatType.Report3:
		case PivotTableAutoFormatType.Report4:
		case PivotTableAutoFormatType.Report5:
		case PivotTableAutoFormatType.Report6:
		case PivotTableAutoFormatType.Report7:
		case PivotTableAutoFormatType.Report8:
		case PivotTableAutoFormatType.Report9:
		case PivotTableAutoFormatType.Report10:
			return 0;
		}
	}

	private void method_110()
	{
		int num = pivotTable_0.int_0;
		int num2 = pivotTable_0.int_2;
		if (bool_7)
		{
			pivotTable_0.int_1 = num + 13;
			pivotTable_0.int_3 = num2 + 6;
			pivotTable_0.int_4 = (pivotTable_0.int_5 = num + 1);
			pivotTable_0.int_6 = num2 + 1;
			return;
		}
		int num3 = num + 1;
		if (method_109() == 0 || !pivotTable_0.ShowRowHeaderCaption || (pivotTable_0.ColumnFields.Count == 1 && pivotTable_0.ColumnFields[0].int_1 == -2 && pivotTable_0.bool_13 && !pivotTable_0.IsGridDropZones))
		{
			num3 = num;
		}
		if (bool_6)
		{
			if (pivotTable_0.DataFields.Count == 0 && !pivotTable_0.DisplayImmediateItems)
			{
				pivotTable_0.int_1 = num + 13;
				pivotTable_0.int_3 = num2 + int_2 + 5;
				pivotTable_0.int_4 = num3;
				pivotTable_0.int_5 = ((num + pivotTable_0.ColumnFields.Count == 0) ? 1 : pivotTable_0.ColumnFields.Count);
				pivotTable_0.int_6 = num2 + int_2;
				return;
			}
			pivotTable_0.int_6 = num2 + int_2;
			if (pivotTable_0.ColumnFields.Count == 0 && (pivotTable_0.IsGridDropZones || pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.FileFormat == FileFormatType.Default) && (pivotTable_0.DataField == null || pivotTable_0.DataField.pivotFieldType_0 != PivotFieldType.Row))
			{
				pivotTable_0.int_4 = num3 + 1;
			}
			else
			{
				pivotTable_0.int_4 = num3;
			}
			if (pivotTable_0.ColumnFields.Count != 0)
			{
				pivotTable_0.int_3 = pivotTable_0.int_6 + pivotTable_0.arrayList_1.Count - 1;
				if (pivotTable_0.arrayList_1.Count == 0)
				{
					pivotTable_0.int_3 = pivotTable_0.int_6 + pivotTable_0.ColumnFields.Count - 1;
				}
				if (pivotTable_0.ShowRowHeaderCaption && (pivotTable_0.DataField == null || (pivotTable_0.DataField != null && pivotTable_0.DataField.pivotFieldType_0 != PivotFieldType.Column) || pivotTable_0.ColumnFields.Count > 1 || (!pivotTable_0.bool_13 && pivotTable_0.ColumnFields.Count == 1 && pivotTable_0.DataField != null && pivotTable_0.DataField.pivotFieldType_0 == PivotFieldType.Column)))
				{
					pivotTable_0.int_5 = num + pivotTable_0.ColumnFields.Count + 1;
				}
				else
				{
					pivotTable_0.int_5 = num + pivotTable_0.ColumnFields.Count;
				}
			}
			else
			{
				if (pivotTable_0.DataFields.Count == 0 && pivotTable_0.IsGridDropZones)
				{
					pivotTable_0.int_3 = pivotTable_0.int_6 + 6;
				}
				else
				{
					pivotTable_0.int_3 = pivotTable_0.int_6;
				}
				if ((!pivotTable_0.IsGridDropZones && (pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.FileFormat == FileFormatType.Xlsx || pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.FileFormat == FileFormatType.Xltx)) || (pivotTable_0.DataField != null && pivotTable_0.DataField.pivotFieldType_0 == PivotFieldType.Row))
				{
					pivotTable_0.int_5 = num3;
				}
				else
				{
					pivotTable_0.int_5 = num3 + 1;
				}
			}
			if (pivotTable_0.RowFields.Count != 0)
			{
				pivotTable_0.int_1 = pivotTable_0.int_5 + pivotTable_0.arrayList_0.Count - 1;
			}
			else if (pivotTable_0.DataFields.Count == 0)
			{
				pivotTable_0.int_1 = pivotTable_0.int_5 + 13;
			}
			else
			{
				pivotTable_0.int_1 = pivotTable_0.int_5;
			}
		}
		else if (pivotTable_0.DataFields.Count == 0 && !pivotTable_0.DisplayImmediateItems)
		{
			pivotTable_0.int_1 = num + 13;
			pivotTable_0.int_4 = (pivotTable_0.int_5 = num3);
			pivotTable_0.int_6 = num2 + int_2;
			pivotTable_0.int_3 = num2 + 5 + int_2;
		}
		else
		{
			pivotTable_0.int_6 = num2 + int_2;
			pivotTable_0.int_4 = num3;
			pivotTable_0.int_3 = pivotTable_0.int_6 + ((pivotTable_0.DataFields.Count != 0) ? (pivotTable_0.DataFields.Count - 1) : 0);
			pivotTable_0.int_5 = num + 1;
			if (pivotTable_0.RowFields.Count != 0)
			{
				pivotTable_0.int_1 = pivotTable_0.int_5 + pivotTable_0.arrayList_0.Count - 1;
			}
			else
			{
				pivotTable_0.int_1 = pivotTable_0.int_5;
			}
		}
	}

	private void method_111()
	{
		int_3 = 0;
		int_4 = 0;
		hashtable_0 = new Hashtable();
		hashtable_1 = new Hashtable();
		method_112(class1154_0, pivotTable_0.RowFields, 0);
		method_113(class1154_1, pivotTable_0.ColumnFields, 0);
	}

	private void method_112(Class1154 class1154_2, PivotFieldCollection pivotFieldCollection_0, int int_12)
	{
		if (class1154_2 == null || class1154_2.arrayList_1 == null || class1154_2.arrayList_1.Count == 0)
		{
			return;
		}
		for (int i = 0; i < class1154_2.arrayList_1.Count; i++)
		{
			Class1154 @class = (Class1154)class1154_2.arrayList_1[i];
			if (int_12 + 1 == pivotFieldCollection_0.Count)
			{
				string text = (string)hashtable_0[int_3];
				if (text != null && text.StartsWith("rowsubtitle"))
				{
					hashtable_0[int_3] = text + "+" + (int_12 + 1);
				}
				else
				{
					hashtable_0[int_3] = "rowsubtitle" + (int_12 + 1);
				}
				int_3++;
			}
			else if (@class.pivotItem_0.method_0())
			{
				string text2 = (string)hashtable_0[int_3];
				if (text2 != null && text2.StartsWith("rowsubtitle"))
				{
					hashtable_0[int_3] = text2 + "+" + (int_12 + 1);
				}
				else
				{
					hashtable_0[int_3] = "rowsubtitle" + (int_12 + 1);
				}
				arrayList_1.Add(int_3);
				int_3++;
				PivotField pivotField = pivotFieldCollection_0[int_12];
				if (pivotField.InsertBlankRow)
				{
					hashtable_0[int_3] = "blank";
					int_3++;
				}
			}
			else
			{
				PivotField pivotField2 = pivotFieldCollection_0[int_12];
				string text3 = (string)hashtable_0[int_3];
				if (text3 != null && text3.StartsWith("rowsubtitle"))
				{
					hashtable_0[int_3] = text3 + "+" + (int_12 + 1);
				}
				else
				{
					hashtable_0[int_3] = "rowsubtitle" + (int_12 + 1);
				}
				if (pivotField2.ShowInOutlineForm)
				{
					int_3++;
				}
				method_112(@class, pivotFieldCollection_0, int_12 + 1);
			}
		}
		if (int_12 == 0)
		{
			if (!pivotTable_0.ColumnGrand)
			{
				return;
			}
			if (pivotFieldType_0 == PivotFieldType.Row)
			{
				if (pivotTable_0.RowFields.Count > 1)
				{
					int count = pivotTable_0.DataFields.Count;
					for (int j = 0; j < count; j++)
					{
						hashtable_0[int_3] = "grandtotalrow";
						int_3++;
					}
				}
			}
			else
			{
				hashtable_0[int_3] = "grandtotalrow";
				int_3++;
			}
		}
		else
		{
			if (int_12 + 1 > pivotFieldCollection_0.Count)
			{
				return;
			}
			PivotField pivotField3 = pivotFieldCollection_0[int_12 - 1];
			if (!pivotField3.method_9())
			{
				if (pivotFieldType_0 == PivotFieldType.Row)
				{
					if (pivotField3.Position - int_1 != -1 && pivotField3.Position != int_1)
					{
						if (pivotField3.Position < int_1)
						{
							int count2 = pivotTable_0.DataFields.Count;
							for (int k = 0; k < count2; k++)
							{
								hashtable_0[int_3] = "rowsubtotal" + int_12;
								int_3++;
							}
						}
						else if ((pivotField3.ShowInOutlineForm && !pivotField3.ShowSubtotalAtTop) || !pivotField3.ShowInOutlineForm)
						{
							hashtable_0[int_3] = "rowsubtotal" + int_12;
							int_3++;
						}
					}
				}
				else if ((pivotField3.ShowInOutlineForm && !pivotField3.ShowSubtotalAtTop) || !pivotField3.ShowInOutlineForm)
				{
					hashtable_0[int_3] = "rowsubtotal" + int_12;
					int_3++;
				}
			}
			if (pivotField3.InsertBlankRow)
			{
				string text4 = (string)hashtable_0[int_3 - 1];
				if (text4 == null || !(text4 == "blank"))
				{
					hashtable_0[int_3] = "blank";
					int_3++;
				}
			}
		}
	}

	private void method_113(Class1154 class1154_2, PivotFieldCollection pivotFieldCollection_0, int int_12)
	{
		if (class1154_2 == null || class1154_2.arrayList_1 == null || class1154_2.arrayList_1.Count == 0)
		{
			return;
		}
		for (int i = 0; i < class1154_2.arrayList_1.Count; i++)
		{
			Class1154 @class = (Class1154)class1154_2.arrayList_1[i];
			if (int_12 + 1 == pivotFieldCollection_0.Count)
			{
				string text = (string)hashtable_1[int_4];
				if (text != null && text.StartsWith("columnsubtitle"))
				{
					hashtable_1[int_4] = text + "+" + (int_12 + 1);
				}
				else
				{
					hashtable_1[int_4] = "columnsubtitle" + (int_12 + 1);
				}
				int_4++;
			}
			else if (@class.pivotItem_0.method_0())
			{
				string text2 = (string)hashtable_1[int_4];
				if (text2 != null && text2.StartsWith("columnsubtitle"))
				{
					hashtable_1[int_4] = text2 + "+" + (int_12 + 1);
				}
				else
				{
					hashtable_1[int_4] = "columnsubtitle" + (int_12 + 1);
				}
				int_4++;
			}
			else
			{
				string text3 = (string)hashtable_1[int_4];
				if (text3 != null && text3.StartsWith("columnsubtitle"))
				{
					hashtable_1[int_4] = text3 + "+" + (int_12 + 1);
				}
				else
				{
					hashtable_1[int_4] = "columnsubtitle" + (int_12 + 1);
				}
				method_113(@class, pivotFieldCollection_0, int_12 + 1);
			}
		}
		if (int_12 == 0)
		{
			if (!pivotTable_0.RowGrand)
			{
				return;
			}
			if (pivotFieldType_0 == PivotFieldType.Column)
			{
				if (pivotTable_0.ColumnFields.Count > 1)
				{
					int count = pivotTable_0.DataFields.Count;
					for (int j = 0; j < count; j++)
					{
						hashtable_1[int_4] = "grandtotalcolumn";
						int_4++;
					}
				}
			}
			else
			{
				hashtable_1[int_4] = "grandtotalcolumn";
				int_4++;
			}
		}
		else
		{
			if (int_12 + 1 > pivotFieldCollection_0.Count)
			{
				return;
			}
			PivotField pivotField = pivotFieldCollection_0[int_12 - 1];
			if (pivotField.method_9())
			{
				return;
			}
			if (pivotFieldType_0 == PivotFieldType.Column)
			{
				if (pivotField.Position - int_1 == -1 || pivotField.Position == int_1)
				{
					return;
				}
				if (pivotField.Position < int_1)
				{
					int count2 = pivotTable_0.DataFields.Count;
					for (int k = 0; k < count2; k++)
					{
						hashtable_1[int_4] = "columnsubtotal" + int_12;
						int_4++;
					}
				}
				else
				{
					hashtable_1[int_4] = "columnsubtotal" + int_12;
					int_4++;
				}
			}
			else
			{
				hashtable_1[int_4] = "columnsubtotal" + int_12;
				int_4++;
			}
		}
	}

	private void method_114(Class1154 class1154_2, PivotFieldCollection pivotFieldCollection_0, int[] int_12, int int_13, bool bool_11)
	{
		PivotField pivotField = pivotFieldCollection_0[int_13];
		int num = int_12[0];
		bool flag;
		if (!(flag = pivotField.method_6()) && pivotField.IsAutoSort && pivotField.AutoSortField > 0 && pivotField.AutoSortField < pivotTable_0.DataFields.Count)
		{
			method_138(class1154_2, pivotFieldCollection_0, int_13);
		}
		for (int i = 0; i < class1154_2.arrayList_1.Count; i++)
		{
			Class1154 @class = (Class1154)class1154_2.arrayList_1[i];
			int_12[4 + int_13] = @class.int_0;
			if (flag)
			{
				int_12[3] |= @class.pivotItem_0.Index << 1;
			}
			if (int_13 + 1 == pivotFieldCollection_0.Count)
			{
				int_12[2] = int_13 + 1;
				method_107(int_12, @class.arrayList_0);
				int_12[0] = int_13;
			}
			else if (@class.pivotItem_0.method_0())
			{
				int_12[2] = int_13 + 1;
				for (int j = int_13 + 1; j < pivotFieldCollection_0.Count; j++)
				{
					int_12[4 + j] = 32767;
				}
				if (pivotFieldType_0 == pivotFieldCollection_0.Type && int_13 < int_1)
				{
					if (pivotField.ShowInOutlineForm)
					{
						method_107(int_12, @class.arrayList_0);
						int_12[2] = int_1 + 1;
						int_12[0] = int_1;
						for (int k = 0; k < pivotTable_0.DataFields.Count; k++)
						{
							int_12[3] |= k << 1;
							int_12[4 + int_1] = k;
							method_107(int_12, @class.arrayList_0);
							int_12[3] &= 65025;
						}
					}
					else
					{
						int_12[4 + int_1] = 0;
						method_107(int_12, @class.arrayList_0);
						int_12[2] = int_1 + 1;
						int_12[0] = int_1;
						for (int l = 1; l < pivotTable_0.DataFields.Count; l++)
						{
							int_12[3] |= l << 1;
							int_12[4 + int_1] = l;
							method_107(int_12, @class.arrayList_0);
							int_12[3] &= 65025;
						}
					}
					int_12[0] = int_13;
				}
				else
				{
					method_107(int_12, @class.arrayList_0);
				}
				int_12[2] = int_13 + 1;
			}
			else if (flag)
			{
				method_114(@class, pivotFieldCollection_0, int_12, int_13 + 1, bool_11);
			}
			else
			{
				bool flag2 = false;
				if (pivotFieldCollection_0.Type == PivotFieldType.Row)
				{
					if (int_13 > 0 && !pivotFieldCollection_0[int_13 - 1].ShowInOutlineForm && pivotFieldCollection_0[int_13].ShowInOutlineForm)
					{
						int_12[0] = int_13;
						int_12[2] = int_13;
						method_107(int_12, @class.arrayList_0);
					}
					else if (pivotField.ShowInOutlineForm)
					{
						int_12[0] = int_13;
						int_12[2] = int_13 + 1;
						for (int m = int_13 + 1; m < pivotFieldCollection_0.Count; m++)
						{
							int_12[4 + m] = 32767;
						}
						if (!pivotField.ShowSubtotalAtTop)
						{
							method_107(int_12, null);
						}
						else
						{
							method_107(int_12, @class.arrayList_0);
						}
						int_12[0]++;
						flag2 = true;
					}
					else if (@class.arrayList_1.Count > 0 && i > 0)
					{
						int_12[0] = int_13;
					}
				}
				method_114(@class, pivotFieldCollection_0, int_12, int_13 + 1, bool_11);
				if (i == 0 && !flag2 && pivotField.ShowInOutlineForm)
				{
					int_12[0]++;
					flag2 = false;
				}
				if (@class.arrayList_1.Count > 0)
				{
					if (pivotFieldCollection_0.Type == PivotFieldType.Column)
					{
						if (!bool_11 || (bool_11 && pivotFieldCollection_0.Count > 2 && !pivotFieldCollection_0[0].method_9()))
						{
							int_12[0] = num;
							int_12[1] = 1;
							int_12[2] = 1;
							int_12[4] = i;
							method_118(int_12, int_13, pivotFieldCollection_0, pivotField, @class.arrayList_0);
						}
						if (bool_11)
						{
							int_12[0] = num;
						}
					}
					else if ((!pivotField.ShowInOutlineForm && !pivotField.method_9() && pivotField.Position + 1 < pivotFieldCollection_0.Count && !pivotFieldCollection_0[pivotField.Position + 1].method_6()) || (pivotField.ShowInOutlineForm && !pivotField.ShowSubtotalAtTop))
					{
						int_12[0] = int_13;
						method_118(int_12, int_13, pivotFieldCollection_0, pivotField, @class.arrayList_0);
					}
				}
			}
			if (flag)
			{
				int_12[3] &= 65025;
			}
		}
		int_12[0] = num;
		if (int_13 != 0)
		{
			return;
		}
		if (method_139(pivotFieldCollection_0))
		{
			method_115(int_12, pivotFieldCollection_0);
		}
		if ((pivotTable_0.ColumnFields.Count != 1 || (pivotTable_0.ColumnFields[0].int_1 != -2 && pivotTable_0.ColumnFields[0].int_1 != 65534) || pivotFieldCollection_0.Type != PivotFieldType.Column) && (pivotTable_0.RowFields.Count != 1 || (pivotTable_0.RowFields[0].int_1 != -2 && pivotTable_0.RowFields[0].int_1 != 65534) || pivotFieldCollection_0.Type != PivotFieldType.Row) && ((pivotTable_0.RowGrand && pivotFieldCollection_0.Type == PivotFieldType.Column) || (pivotTable_0.ColumnGrand && pivotFieldCollection_0.Type == PivotFieldType.Row)))
		{
			if ((pivotTable_0.DataField != null && pivotTable_0.DataField.pivotFieldType_0 == PivotFieldType.Row && pivotFieldCollection_0.pivotFieldType_0 == PivotFieldType.Row) || (pivotTable_0.DataField != null && pivotTable_0.DataField.pivotFieldType_0 == PivotFieldType.Column && pivotFieldCollection_0.pivotFieldType_0 == PivotFieldType.Column))
			{
				int_12[3] |= 1;
			}
			int_12[0] = 0;
			int_12[1] = 13;
			int_12[2] = 1;
			int_12[3] |= 2560;
			int_12[4] = 0;
			for (int n = 1; n < pivotFieldCollection_0.Count; n++)
			{
				int_12[4 + n] = 32767;
			}
			if (pivotFieldType_0 == pivotFieldCollection_0.Type && int_13 < int_1)
			{
				method_116(int_12, int_13);
			}
			else
			{
				method_107(int_12, arrayList_0);
			}
		}
	}

	private void method_115(int[] int_12, PivotFieldCollection pivotFieldCollection_0)
	{
		int num = pivotFieldCollection_0.Count - 1;
		PivotField pivotField = pivotFieldCollection_0[num];
		int_12[0] = num + 1;
		int_12[2] = num;
		int_12[3] |= 1024;
		for (int i = 0; i < pivotFieldCollection_0.Count - 1; i++)
		{
			int_12[4 + i] = 32767;
		}
		for (int j = 0; j < pivotField.PivotItems.Count; j++)
		{
			PivotItem pivotItem = pivotField.PivotItems[j];
			if (!pivotItem.IsHidden)
			{
				int_12[num] = j;
				method_117(int_12, num, pivotFieldCollection_0, pivotField);
			}
		}
		int_12[3] &= 64511;
		int_12[1] = 0;
	}

	private void method_116(int[] int_12, int int_13)
	{
		for (int i = 0; i < pivotTable_0.DataFields.Count; i++)
		{
			_ = pivotTable_0.DataFields[i];
			int_12[3] |= i << 1;
			method_106(int_12);
			int_12[3] &= 65025;
		}
	}

	private void method_117(int[] int_12, int int_13, PivotFieldCollection pivotFieldCollection_0, PivotField pivotField_0)
	{
		if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.None))
		{
			return;
		}
		if (!bool_1 && !pivotField_0.IsAutoSubtotals)
		{
			if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Sum))
			{
				int_12[1] = 2;
				method_116(int_12, int_13);
			}
			if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.CountNums))
			{
				int_12[1] = 3;
				method_116(int_12, int_13);
			}
			if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Count))
			{
				int_12[1] = 4;
				method_116(int_12, int_13);
			}
			if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Average))
			{
				int_12[1] = 5;
				method_116(int_12, int_13);
			}
			if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Max))
			{
				int_12[1] = 6;
				method_116(int_12, int_13);
			}
			if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Min))
			{
				int_12[1] = 7;
				method_116(int_12, int_13);
			}
			if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Product))
			{
				int_12[1] = 8;
				method_116(int_12, int_13);
			}
			if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Stdev))
			{
				int_12[1] = 9;
				method_116(int_12, int_13);
			}
			if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Stdevp))
			{
				int_12[1] = 10;
				method_116(int_12, int_13);
			}
			if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Var))
			{
				int_12[1] = 11;
				method_116(int_12, int_13);
			}
			if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Varp))
			{
				int_12[1] = 12;
				method_116(int_12, int_13);
			}
		}
		else
		{
			int_12[1] = 1;
			method_116(int_12, int_13);
		}
		int_12[1] = 0;
	}

	private void method_118(int[] int_12, int int_13, PivotFieldCollection pivotFieldCollection_0, PivotField pivotField_0, ArrayList arrayList_9)
	{
		int_12[2] = int_13 + 1;
		int_12[3] |= 512;
		if (pivotFieldCollection_0.Type == pivotFieldType_0 && int_13 < int_1)
		{
			method_117(int_12, int_13, pivotFieldCollection_0, pivotField_0);
		}
		else if (!pivotField_0.GetSubtotals(PivotFieldSubtotalType.None))
		{
			if (!bool_1 && !pivotField_0.IsAutoSubtotals)
			{
				if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Sum))
				{
					int_12[1] = 2;
					method_107(int_12, arrayList_9);
				}
				if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.CountNums))
				{
					int_12[1] = 3;
					method_107(int_12, arrayList_9);
				}
				if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Count))
				{
					int_12[1] = 4;
					method_107(int_12, arrayList_9);
				}
				if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Average))
				{
					int_12[1] = 5;
					method_107(int_12, arrayList_9);
				}
				if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Max))
				{
					int_12[1] = 6;
					method_107(int_12, arrayList_9);
				}
				if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Min))
				{
					int_12[1] = 7;
					method_107(int_12, arrayList_9);
				}
				if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Product))
				{
					int_12[1] = 8;
					method_107(int_12, arrayList_9);
				}
				if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Stdev))
				{
					int_12[1] = 9;
					method_107(int_12, arrayList_9);
				}
				if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Stdevp))
				{
					int_12[1] = 10;
					method_107(int_12, arrayList_9);
				}
				if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Var))
				{
					int_12[1] = 11;
					method_107(int_12, arrayList_9);
				}
				if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Varp))
				{
					int_12[1] = 12;
					method_107(int_12, arrayList_9);
				}
			}
			else
			{
				int_12[1] = 1;
				method_107(int_12, arrayList_9);
			}
		}
		int_12[3] &= 65023;
		int_12[1] = 0;
	}

	private int[][] method_119()
	{
		int num = pivotTable_0.int_2;
		Cells cells = pivotTable_0.pivotTableCollection_0.worksheet_0.Cells;
		Cell cell = null;
		Style style = null;
		int num2 = pivotTable_0.int_0 - pivotTable_0.PageFields.Count;
		int num3 = 0;
		int num4 = -1;
		int num5 = -1;
		for (int i = 0; i < pivotTable_0.PageFields.Count; i++)
		{
			PivotField pivotField = pivotTable_0.PageFields[i];
			cell = cells.GetCell(num2 + i, num, bool_2: false);
			cell.PutValue(pivotField.DisplayName);
			if (num4 == -1)
			{
				style = cell.GetStyle();
				style.method_50(bool_0: true);
				style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
				style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
				style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
				style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
				cell.method_30(style);
				num5 = cell.method_36();
				style.method_50(bool_0: true);
				cell.method_30(style);
				num4 = cell.method_36();
			}
			cell.method_37(num4);
			cell = cells.GetCell(num2, num + 1, bool_2: false);
			cell.method_37(num5);
			if (pivotField.CurrentPageItem >= 0 && pivotField.CurrentPageItem <= pivotField.PivotItems.Count)
			{
				object obj = pivotField.PivotItems[pivotField.CurrentPageItem].Value;
				if (obj == null)
				{
					obj = "(blank)";
				}
				cell.PutValue(obj);
				num3++;
			}
			else
			{
				cell.PutValue("(All)");
			}
		}
		if (num3 == 0)
		{
			return null;
		}
		return method_134(num3);
	}

	private int[][] method_120()
	{
		int num = 0;
		for (int i = 0; i < pivotTable_0.PageFields.Count; i++)
		{
			PivotField pivotField = pivotTable_0.PageFields[i];
			if (pivotField.CurrentPageItem >= 0 && pivotField.CurrentPageItem <= pivotField.PivotItems.Count)
			{
				num++;
			}
		}
		if (num == 0)
		{
			return null;
		}
		return method_134(num);
	}

	internal void method_121()
	{
		bool_0 = pivotTable_0.class1141_0.class1144_0.bool_0;
		arrayList_0 = new ArrayList();
		ArrayList arrayList = pivotTable_0.class1141_0.class1144_0.arrayList_0;
		int num = 0;
		Hashtable[] array = new Hashtable[bool_0.Length];
		for (int i = 0; i < pivotTable_0.RowFields.Count; i++)
		{
			PivotField pivotField = pivotTable_0.RowFields[i];
			if (pivotField.method_6())
			{
				continue;
			}
			for (int j = 0; j < pivotField.PivotItems.Count; j++)
			{
				PivotItem pivotItem = pivotField.PivotItems[j];
				if (pivotField.PivotItems[j].IsHidden)
				{
					Hashtable hashtable = array[pivotField.pivotField_0.Index];
					if (hashtable == null)
					{
						hashtable = new Hashtable();
						array[pivotField.pivotField_0.Index] = hashtable;
						num++;
					}
					hashtable.Add(pivotItem.Index, true);
				}
			}
		}
		for (int k = 0; k < pivotTable_0.ColumnFields.Count; k++)
		{
			PivotField pivotField2 = pivotTable_0.ColumnFields[k];
			if (pivotField2.method_6())
			{
				continue;
			}
			for (int l = 0; l < pivotField2.PivotItems.Count; l++)
			{
				PivotItem pivotItem2 = pivotField2.PivotItems[l];
				if (pivotField2.PivotItems[l].IsHidden)
				{
					Hashtable hashtable2 = array[pivotField2.pivotField_0.Index];
					if (hashtable2 == null)
					{
						hashtable2 = new Hashtable();
						array[pivotField2.pivotField_0.Index] = hashtable2;
						num++;
					}
					hashtable2.Add(pivotItem2.Index, true);
				}
			}
		}
		for (int m = 0; m < pivotTable_0.PageFields.Count; m++)
		{
			PivotField pivotField3 = pivotTable_0.PageFields[m];
			for (int n = 0; n < pivotField3.PivotItems.Count; n++)
			{
				PivotItem pivotItem3 = pivotField3.PivotItems[n];
				if (pivotField3.PivotItems[n].IsHidden)
				{
					Hashtable hashtable3 = array[pivotField3.pivotField_0.Index];
					if (hashtable3 == null)
					{
						hashtable3 = new Hashtable();
						array[pivotField3.pivotField_0.Index] = hashtable3;
						num++;
					}
					hashtable3.Add(pivotItem3.Index, true);
				}
			}
		}
		if (pivotTable_0.PivotFilters != null && pivotTable_0.PivotFilters.Count > 0)
		{
			for (int num2 = 0; num2 < pivotTable_0.PivotFilters.Count; num2++)
			{
				PivotFilter pivotFilter = pivotTable_0.PivotFilters[num2];
				if (Class1156.smethod_7(pivotFilter.pivotFilterType_0))
				{
					continue;
				}
				int index = pivotFilter.int_0;
				AutoFilter autoFilter = pivotFilter.AutoFilter;
				PivotField pivotField4 = pivotTable_0.BaseFields[index];
				if (pivotField4.method_6())
				{
					continue;
				}
				for (int num3 = 0; num3 < pivotField4.PivotItems.Count; num3++)
				{
					PivotItem pivotItem4 = pivotField4.PivotItems[num3];
					if (autoFilter.method_4(pivotItem4.Value))
					{
						Hashtable hashtable4 = array[pivotField4.pivotField_0.Index];
						if (hashtable4 == null)
						{
							hashtable4 = new Hashtable();
							array[pivotField4.pivotField_0.Index] = hashtable4;
							num++;
						}
						hashtable4.Add(pivotItem4.Index, true);
					}
				}
			}
		}
		for (int num4 = 0; num4 < arrayList.Count; num4++)
		{
			object[] array2 = (object[])arrayList[num4];
			bool flag = true;
			if (int_0 != null)
			{
				for (int num5 = 0; num5 < int_0.Length; num5++)
				{
					int num6 = int_0[num5][0];
					int num7 = int_0[num5][1];
					if (array2[num6] != null && (int)array2[num6] != num7)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
			}
			if (num != 0)
			{
				for (int num8 = 0; num8 < array.Length; num8++)
				{
					if (array[num8] != null)
					{
						Hashtable hashtable5 = array[num8];
						if (array2[num8] != null && array2[num8] is int && hashtable5[(int)array2[num8]] != null)
						{
							flag = false;
							break;
						}
					}
				}
				if (!flag)
				{
					continue;
				}
			}
			arrayList_0.Add(new Class1153(array2));
		}
	}

	internal ArrayList method_122(ArrayList arrayList_9, Class1165 class1165_0, bool bool_11, PivotFieldCollection pivotFieldCollection_0)
	{
		return null;
	}

	internal ArrayList method_123(ArrayList arrayList_9, Class1165 class1165_0, bool bool_11, PivotFieldCollection pivotFieldCollection_0)
	{
		ArrayList arrayList = new ArrayList();
		if (class1165_0.enum185_0 == Enum185.const_14)
		{
			return arrayList;
		}
		if (class1165_0.method_3())
		{
			return arrayList_9;
		}
		bool flag = true;
		PivotField pivotField = null;
		int num = 0;
		for (int i = 0; i < arrayList_9.Count; i++)
		{
			Class1153 @class = (Class1153)arrayList_9[i];
			flag = true;
			num = ((pivotFieldCollection_0.Type != PivotFieldType.Column || !bool_11) ? class1165_0.int_0 : 0);
			for (int j = num; j < class1165_0.int_1; j++)
			{
				if (bool_11 && j == int_1)
				{
					continue;
				}
				pivotField = pivotFieldCollection_0[j];
				if (class1165_0.int_2[j] >= pivotField.PivotItems.Count || pivotField.Index < 0)
				{
					continue;
				}
				PivotItem pivotItem = pivotField.PivotItems[class1165_0.int_2[j]];
				if (pivotItem.IsFormula)
				{
					continue;
				}
				if (pivotField.class1161_0.sxRng_0 != null && pivotField.pivotFieldType_0 == PivotFieldType.Column)
				{
					int num2 = pivotField.class1161_0.sxRng_0.int_0;
					bool flag2 = false;
					for (int k = 0; k < class1165_0.arrayList_0.Count; k++)
					{
						Class1153 class2 = (Class1153)class1165_0.arrayList_0[k];
						if (@class.object_0[num2] == null || class2.object_0[num2] == null)
						{
							break;
						}
						if ((int)@class.object_0[num2] == (int)class2.object_0[num2])
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						flag = false;
					}
				}
				else
				{
					if (@class.object_0[pivotField.int_1] == null)
					{
						flag = false;
						break;
					}
					if ((int)@class.object_0[pivotField.int_1] != pivotItem.Index)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				arrayList.Add(@class);
			}
		}
		return arrayList;
	}

	internal ArrayList method_124(ArrayList arrayList_9, int int_12, int int_13)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_9.Count; i++)
		{
			Class1153 @class = (Class1153)arrayList_9[i];
			if (int_12 < @class.object_0.Length && @class.object_0[int_12] != null && (int)@class.object_0[int_12] == int_13)
			{
				arrayList.Add(@class);
			}
		}
		return arrayList;
	}

	private ArrayList method_125(int int_12, PivotField pivotField_0, PivotItem pivotItem_0, int int_13)
	{
		ArrayList arrayList = new ArrayList();
		PivotField pivotField = pivotTable_0.BaseFields[int_13];
		if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Quarters)
		{
			for (int i = 0; i < pivotField.class1161_0.arrayList_0.Count; i++)
			{
				object obj = pivotField.class1161_0.arrayList_0[i];
				Class1158 @class = (Class1158)obj;
				if (!(@class.object_0 is DateTime))
				{
					continue;
				}
				DateTime dateTime = (DateTime)@class.object_0;
				switch (int_12)
				{
				case 1:
					if (dateTime.Month >= 1 && dateTime.Month <= 3)
					{
						arrayList.Add(i);
					}
					break;
				case 2:
					if (dateTime.Month >= 4 && dateTime.Month <= 6)
					{
						arrayList.Add(i);
					}
					break;
				case 3:
					if (dateTime.Month >= 7 && dateTime.Month <= 9)
					{
						arrayList.Add(i);
					}
					break;
				case 4:
					if (dateTime.Month >= 10 && dateTime.Month <= 12)
					{
						arrayList.Add(i);
					}
					break;
				}
			}
		}
		else if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Months)
		{
			for (int j = 0; j < pivotField.class1161_0.arrayList_0.Count; j++)
			{
				object obj2 = pivotField.class1161_0.arrayList_0[j];
				Class1158 class2 = (Class1158)obj2;
				if (!(class2.object_0 is DateTime))
				{
					continue;
				}
				DateTime dateTime2 = (DateTime)class2.object_0;
				switch (int_12)
				{
				case 1:
					if (dateTime2.Month == 1)
					{
						arrayList.Add(j);
					}
					break;
				case 2:
					if (dateTime2.Month == 2)
					{
						arrayList.Add(j);
					}
					break;
				case 3:
					if (dateTime2.Month == 3)
					{
						arrayList.Add(j);
					}
					break;
				case 4:
					if (dateTime2.Month == 4)
					{
						arrayList.Add(j);
					}
					break;
				case 5:
					if (dateTime2.Month == 5)
					{
						arrayList.Add(j);
					}
					break;
				case 6:
					if (dateTime2.Month == 6)
					{
						arrayList.Add(j);
					}
					break;
				case 7:
					if (dateTime2.Month == 7)
					{
						arrayList.Add(j);
					}
					break;
				case 8:
					if (dateTime2.Month == 8)
					{
						arrayList.Add(j);
					}
					break;
				case 9:
					if (dateTime2.Month == 9)
					{
						arrayList.Add(j);
					}
					break;
				case 10:
					if (dateTime2.Month == 10)
					{
						arrayList.Add(j);
					}
					break;
				case 11:
					if (dateTime2.Month == 11)
					{
						arrayList.Add(j);
					}
					break;
				case 12:
					if (dateTime2.Month == 12)
					{
						arrayList.Add(j);
					}
					break;
				}
			}
		}
		else if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Years)
		{
			for (int k = 0; k < pivotField.class1161_0.arrayList_0.Count; k++)
			{
				object obj3 = pivotField.class1161_0.arrayList_0[k];
				Class1158 class3 = (Class1158)obj3;
				if (!(class3.object_0 is DateTime))
				{
					continue;
				}
				DateTime dateTime3 = (DateTime)class3.object_0;
				if (int_12 != 0 && int_12 != pivotField_0.class1161_0.sxRng_0.arrayList_0.Count - 1)
				{
					string text = (string)pivotItem_0.Value;
					int num = Class1618.smethod_87(text.Substring(0, 4));
					if (dateTime3.Year == num)
					{
						arrayList.Add(k);
					}
				}
			}
		}
		else if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Days)
		{
			for (int l = 0; l < pivotField.class1161_0.arrayList_0.Count; l++)
			{
				object obj4 = pivotField.class1161_0.arrayList_0[l];
				Class1158 class4 = (Class1158)obj4;
				if (class4.object_0 is DateTime)
				{
					DateTime dateTime4 = (DateTime)class4.object_0;
					if (int_12 != 0 && int_12 != pivotField_0.class1161_0.sxRng_0.arrayList_0.Count - 1 && int_12 == dateTime4.DayOfYear + 1)
					{
						arrayList.Add(l);
					}
				}
			}
		}
		else if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Hours)
		{
			for (int m = 0; m < pivotField.class1161_0.arrayList_0.Count; m++)
			{
				object obj5 = pivotField.class1161_0.arrayList_0[m];
				Class1158 class5 = (Class1158)obj5;
				if (class5.object_0 is DateTime)
				{
					DateTime dateTime5 = (DateTime)class5.object_0;
					if (int_12 != 0 && int_12 != pivotField_0.class1161_0.sxRng_0.arrayList_0.Count - 1 && dateTime5.Hour == int_12 - 1)
					{
						arrayList.Add(m);
					}
				}
			}
		}
		else if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Minutes)
		{
			for (int n = 0; n < pivotField.class1161_0.arrayList_0.Count; n++)
			{
				object obj6 = pivotField.class1161_0.arrayList_0[n];
				Class1158 class6 = (Class1158)obj6;
				if (class6.object_0 is DateTime)
				{
					DateTime dateTime6 = (DateTime)class6.object_0;
					if (int_12 != 0 && int_12 != pivotField_0.class1161_0.sxRng_0.arrayList_0.Count - 1 && dateTime6.Minute == int_12 - 1)
					{
						arrayList.Add(n);
					}
				}
			}
		}
		else if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Seconds)
		{
			for (int num2 = 0; num2 < pivotField.class1161_0.arrayList_0.Count; num2++)
			{
				object obj7 = pivotField.class1161_0.arrayList_0[num2];
				Class1158 class7 = (Class1158)obj7;
				if (class7.object_0 is DateTime)
				{
					DateTime dateTime7 = (DateTime)class7.object_0;
					if (int_12 != 0 && int_12 != pivotField_0.class1161_0.sxRng_0.arrayList_0.Count - 1 && dateTime7.Second == int_12 - 1)
					{
						arrayList.Add(num2);
					}
				}
			}
		}
		return arrayList;
	}

	private ArrayList method_126(int int_12, PivotField pivotField_0, PivotItem pivotItem_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < pivotField_0.class1161_0.arrayList_0.Count; i++)
		{
			object obj = pivotField_0.class1161_0.arrayList_0[i];
			Class1158 @class = (Class1158)obj;
			if (@class.object_0 is DateTime)
			{
				DateTime dateTime = (DateTime)@class.object_0;
				if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Quarters)
				{
					switch (int_12)
					{
					case 1:
						if (dateTime.Month >= 1 && dateTime.Month <= 3)
						{
							arrayList.Add(i);
						}
						break;
					case 2:
						if (dateTime.Month >= 4 && dateTime.Month <= 6)
						{
							arrayList.Add(i);
						}
						break;
					case 3:
						if (dateTime.Month >= 7 && dateTime.Month <= 9)
						{
							arrayList.Add(i);
						}
						break;
					case 4:
						if (dateTime.Month >= 10 && dateTime.Month <= 12)
						{
							arrayList.Add(i);
						}
						break;
					}
				}
				else if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Months)
				{
					switch (int_12)
					{
					case 1:
						if (dateTime.Month == 1)
						{
							arrayList.Add(i);
						}
						break;
					case 2:
						if (dateTime.Month == 2)
						{
							arrayList.Add(i);
						}
						break;
					case 3:
						if (dateTime.Month == 3)
						{
							arrayList.Add(i);
						}
						break;
					case 4:
						if (dateTime.Month == 4)
						{
							arrayList.Add(i);
						}
						break;
					case 5:
						if (dateTime.Month == 5)
						{
							arrayList.Add(i);
						}
						break;
					case 6:
						if (dateTime.Month == 6)
						{
							arrayList.Add(i);
						}
						break;
					case 7:
						if (dateTime.Month == 7)
						{
							arrayList.Add(i);
						}
						break;
					case 8:
						if (dateTime.Month == 8)
						{
							arrayList.Add(i);
						}
						break;
					case 9:
						if (dateTime.Month == 9)
						{
							arrayList.Add(i);
						}
						break;
					case 10:
						if (dateTime.Month == 10)
						{
							arrayList.Add(i);
						}
						break;
					case 11:
						if (dateTime.Month == 11)
						{
							arrayList.Add(i);
						}
						break;
					case 12:
						if (dateTime.Month == 12)
						{
							arrayList.Add(i);
						}
						break;
					}
				}
				else if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Years)
				{
					if (int_12 != 0 && int_12 != pivotField_0.class1161_0.sxRng_0.arrayList_0.Count - 1)
					{
						string text = (string)pivotItem_0.Value;
						int num = Class1618.smethod_87(text.Substring(0, 4));
						if (dateTime.Year == num)
						{
							arrayList.Add(i);
						}
					}
				}
				else if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Days)
				{
					if (int_12 != 0 && int_12 != pivotField_0.class1161_0.sxRng_0.arrayList_0.Count - 1 && int_12 == dateTime.DayOfYear + 1)
					{
						arrayList.Add(i);
					}
				}
				else if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Hours)
				{
					if (int_12 != 0 && int_12 != pivotField_0.class1161_0.sxRng_0.arrayList_0.Count - 1 && dateTime.Hour == int_12 - 1)
					{
						arrayList.Add(i);
					}
				}
				else if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Minutes)
				{
					if (int_12 != 0 && int_12 != pivotField_0.class1161_0.sxRng_0.arrayList_0.Count - 1 && dateTime.Minute == int_12 - 1)
					{
						arrayList.Add(i);
					}
				}
				else if (pivotField_0.class1161_0.sxRng_0.pivotGroupByType_0 == PivotGroupByType.Seconds && int_12 != 0 && int_12 != pivotField_0.class1161_0.sxRng_0.arrayList_0.Count - 1 && dateTime.Second == int_12 - 1)
				{
					arrayList.Add(i);
				}
			}
			else
			{
				if (!(@class.object_0 is int) && !(@class.object_0 is double))
				{
					continue;
				}
				double num2 = 0.0;
				num2 = ((!(@class.object_0 is int)) ? ((double)@class.object_0) : ((double)(int)@class.object_0));
				if (pivotItem_0.Value.ToString().IndexOf('<') != -1)
				{
					double num3 = Class1618.smethod_85(pivotItem_0.Value.ToString().Substring(1));
					if (!(num2 >= num3))
					{
						arrayList.Add(i);
					}
				}
				else if (pivotItem_0.Value.ToString().IndexOf("-") != -1)
				{
					int num4 = pivotItem_0.Value.ToString().IndexOf('-');
					double num5 = Class1618.smethod_85(pivotItem_0.Value.ToString().Substring(0, num4));
					double num6 = Class1618.smethod_85(pivotItem_0.Value.ToString().Substring(num4 + 1));
					if (!(num2 < num5) && !(num2 > num6))
					{
						arrayList.Add(i);
					}
				}
				else
				{
					double num7 = Class1618.smethod_85(pivotItem_0.Value.ToString().Substring(1));
					if (!(num2 <= num7))
					{
						arrayList.Add(i);
					}
				}
			}
		}
		return arrayList;
	}

	private void method_127(Class1154 class1154_2, PivotFieldCollection pivotFieldCollection_0, int int_12, bool bool_11)
	{
		PivotField pivotField = pivotFieldCollection_0[int_12];
		PivotItemCollection pivotItems = pivotField.PivotItems;
		bool flag = pivotField.method_6();
		int[] array = null;
		if (pivotField.IsAutoSort)
		{
			method_129();
			if (pivotField.AutoSortField == -1)
			{
				if (pivotFieldCollection_0.Type == PivotFieldType.Row)
				{
					if (int_11 != null)
					{
						array = int_11[int_12];
					}
				}
				else if (int_10 != null)
				{
					array = int_10[int_12];
				}
			}
		}
		for (int i = 0; i < pivotItems.Count; i++)
		{
			PivotItem pivotItem = null;
			pivotItem = ((array == null) ? pivotItems[i] : pivotItems[array[i]]);
			if (!flag && !pivotItem.IsFormula)
			{
				if (pivotItem.IsFormula)
				{
					Class1154 @class = new Class1154();
					class1154_2.arrayList_1.Add(@class);
					@class.pivotItem_0 = pivotItem;
					if (array != null)
					{
						@class.int_0 = array[i];
					}
					else
					{
						@class.int_0 = i;
					}
					@class.arrayList_0 = arrayList_0;
					continue;
				}
				if (pivotField.class1161_0 != null && pivotField.class1161_0.sxRng_0 != null)
				{
					ArrayList arrayList = new ArrayList();
					int num = pivotField.class1161_0.sxRng_0.int_0;
					if (pivotField.class1161_0.arrayList_0 != null && pivotField.class1161_0.arrayList_0.Count != 0)
					{
						if (pivotField.class1161_0.arrayList_0 != null)
						{
							arrayList = method_126(i, pivotField, pivotItem);
						}
					}
					else
					{
						arrayList = method_125(i, pivotField, pivotItem, num);
					}
					ArrayList arrayList2 = new ArrayList();
					ArrayList arrayList3 = new ArrayList();
					for (int j = 0; j < arrayList.Count; j++)
					{
						int int_13 = (int)arrayList[j];
						int num2 = num;
						if (num2 >= 0)
						{
							arrayList2 = method_124(class1154_2.arrayList_0, num2, int_13);
							if (arrayList2 != null && arrayList2.Count != 0)
							{
								arrayList3.AddRange(arrayList2);
							}
						}
					}
					if (arrayList3.Count != 0)
					{
						Class1154 class2 = new Class1154();
						class1154_2.arrayList_1.Add(class2);
						class2.pivotItem_0 = pivotItem;
						if (array != null)
						{
							class2.int_0 = array[i];
						}
						else
						{
							class2.int_0 = i;
						}
						class2.arrayList_0 = arrayList3;
					}
					continue;
				}
				int index = pivotItem.Index;
				int index2 = pivotField.pivotField_0.Index;
				if (index2 < 0)
				{
					continue;
				}
				ArrayList arrayList4 = method_124(class1154_2.arrayList_0, index2, index);
				if (arrayList4 != null && arrayList4.Count != 0)
				{
					Class1154 class3 = new Class1154();
					class1154_2.arrayList_1.Add(class3);
					class3.pivotItem_0 = pivotItem;
					if (array != null)
					{
						class3.int_0 = array[i];
					}
					else
					{
						class3.int_0 = i;
					}
					class3.arrayList_0 = arrayList4;
				}
			}
			else
			{
				Class1154 class4 = new Class1154();
				class1154_2.arrayList_1.Add(class4);
				class4.pivotItem_0 = pivotItem;
				if (array != null)
				{
					class4.int_0 = array[i];
				}
				else
				{
					class4.int_0 = i;
				}
				class4.arrayList_0 = class1154_2.arrayList_0;
			}
		}
		if (pivotField.IsAutoShow)
		{
			int autoShowField = pivotField.AutoShowField;
			PivotField pivotField_ = pivotTable_0.DataFields[autoShowField];
			method_132(pivotField_, class1154_2, pivotField.IsAscendShow, pivotField.AutoShowCount);
		}
		if (pivotTable_0.PivotFilters != null && pivotTable_0.PivotFilters.Count > 0)
		{
			for (int k = 0; k < pivotTable_0.PivotFilters.Count; k++)
			{
				PivotFilter pivotFilter = pivotTable_0.PivotFilters[k];
				int num3 = pivotFilter.int_0;
				int measureFldIndex = pivotFilter.MeasureFldIndex;
				if (pivotTable_0.DataFields.Count == 0)
				{
					continue;
				}
				PivotField pivotField_2 = pivotTable_0.DataFields[measureFldIndex];
				AutoFilter autoFilter = pivotFilter.AutoFilter;
				if (num3 != pivotField.Index)
				{
					continue;
				}
				if (pivotFilter.pivotFilterType_0 != PivotFilterType.Count && pivotFilter.pivotFilterType_0 != PivotFilterType.Percent)
				{
					if (Class1156.smethod_7(pivotFilter.pivotFilterType_0))
					{
						method_133(pivotField_2, class1154_2, autoFilter);
					}
					continue;
				}
				FilterColumnCollection filterColumnCollection = autoFilter.method_5();
				for (int l = 0; l < filterColumnCollection.Count; l++)
				{
					FilterColumn byIndex = filterColumnCollection.GetByIndex(l);
					if (byIndex.FilterType != FilterType.Top10)
					{
						continue;
					}
					Top10Filter top10Filter = (Top10Filter)byIndex.Filter;
					bool isTop = top10Filter.IsTop;
					bool isPercent = top10Filter.IsPercent;
					int num4 = top10Filter.Items;
					if (isPercent)
					{
						num4 = num4 * arrayList_0.Count / 100;
						if (num4 == 0)
						{
							num4 = 1;
						}
					}
					method_132(pivotField_2, class1154_2, isTop, num4);
					break;
				}
			}
		}
		for (int m = 0; m < class1154_2.arrayList_1.Count; m++)
		{
			Class1154 class5 = (Class1154)class1154_2.arrayList_1[m];
			if (!class5.pivotItem_0.method_0() && class5.arrayList_0 != null && int_12 + 1 != pivotFieldCollection_0.Count)
			{
				method_127(class5, pivotFieldCollection_0, int_12 + 1, bool_11);
			}
		}
		if (bool_11)
		{
			for (int n = 0; n < class1154_2.arrayList_1.Count; n++)
			{
				class1154_2.arrayList_0 = null;
			}
		}
	}

	private void method_128()
	{
		Cell cell = null;
		pivotTable_0.int_12 = pivotTable_0.PageFields.Count;
		if (pivotTable_0.int_12 > 0)
		{
			int num = pivotTable_0.int_0 - pivotTable_0.int_12 - 1;
			for (int i = 0; i < pivotTable_0.int_12; i++)
			{
				PivotField pivotField = pivotTable_0.PageFields[i];
				if (pivotField.CurrentPageItem == 32765)
				{
					continue;
				}
				if (pivotField.IsMultipleItemSelectionAllowed && (!pivotField.IsMultipleItemSelectionAllowed || pivotField.PivotItems.Count - pivotField.PivotItems.method_0() != 1))
				{
					if (pivotField.IsMultipleItemSelectionAllowed)
					{
						cell = cells_0.CheckCell(num + i, pivotTable_0.int_2 + 1);
						cell.PutValue("(Multiple Items)");
					}
				}
				else
				{
					cell = cells_0.CheckCell(num + i, pivotTable_0.int_2 + 1);
					cell.PutValue(pivotField.PivotItems[pivotField.CurrentPageItem].Value);
				}
			}
		}
		for (int j = pivotTable_0.int_0; j <= pivotTable_0.int_1; j++)
		{
			for (int k = pivotTable_0.int_2; k <= pivotTable_0.int_3; k++)
			{
				cell = cells_0.CheckCell(j, k);
				if (cell != null)
				{
					cell.method_37(-1);
					cell.method_6();
				}
			}
		}
	}

	private void method_129()
	{
		for (int i = 0; i < pivotTable_0.ColumnFields.Count; i++)
		{
			PivotField pivotField = pivotTable_0.ColumnFields[i];
			if (pivotField.IsAutoSort && pivotField.AutoSortField == -1)
			{
				if (int_10 == null)
				{
					int_10 = new int[bool_0.Length][];
				}
				int_10[i] = method_131(pivotField);
			}
		}
		for (int j = 0; j < pivotTable_0.RowFields.Count; j++)
		{
			PivotField pivotField2 = pivotTable_0.RowFields[j];
			if (pivotField2.IsAutoSort && pivotField2.AutoSortField == -1)
			{
				if (int_11 == null)
				{
					int_11 = new int[bool_0.Length][];
				}
				int_11[j] = method_131(pivotField2);
			}
		}
	}

	private void method_130()
	{
		if (pivotTable_0.ColumnFields.Count != 0)
		{
			class1154_1 = new Class1154();
			class1154_1.arrayList_0 = arrayList_0;
			method_127(class1154_1, pivotTable_0.ColumnFields, 0, pivotTable_0.RowFields.Count != 0);
			class1154_1.arrayList_0 = null;
		}
		if (pivotTable_0.RowFields.Count != 0)
		{
			class1154_0 = new Class1154();
			class1154_0.arrayList_0 = arrayList_0;
			method_127(class1154_0, pivotTable_0.RowFields, 0, bool_11: false);
			class1154_0.arrayList_0 = null;
		}
	}

	private int[] method_131(PivotField pivotField_0)
	{
		if (pivotField_0.Index != -2 && pivotField_0.Index != 65534)
		{
			bool isAscendSort = pivotField_0.IsAscendSort;
			int[] array = new int[pivotField_0.PivotItems.Count];
			new ArrayList();
			SortedList sortedList = new SortedList(new Class989(isAscendSort));
			int num = -1;
			PivotItemCollection pivotItems = pivotField_0.PivotItems;
			for (int i = 0; i < pivotItems.Count; i++)
			{
				if (pivotItems[i].Value != null)
				{
					sortedList.Add(pivotItems[i].Value, i);
				}
				else if (pivotItems[i].pivotField_0 == null)
				{
					num = i;
				}
			}
			int num2 = 0;
			if (!isAscendSort && num >= 0)
			{
				array[num2++] = num;
			}
			IEnumerator enumerator = sortedList.Values.GetEnumerator();
			while (enumerator.MoveNext())
			{
				array[num2++] = (int)enumerator.Current;
			}
			if (isAscendSort && num >= 0)
			{
				array[num2++] = num;
			}
			return array;
		}
		return null;
	}

	private void method_132(PivotField pivotField_0, Class1154 class1154_2, bool bool_11, int int_12)
	{
		Class1147 @class = new Class1147(bool_11, int_12);
		for (int i = 0; i < class1154_2.arrayList_1.Count; i++)
		{
			Class1154 class2 = (Class1154)class1154_2.arrayList_1[i];
			object object_ = method_137(class2.pivotItem_0, null, class2.arrayList_0, bool_11: true, pivotField_0, i, null);
			object_ = method_104(object_);
			@class.Add(object_, class2.int_0);
		}
		Hashtable hashtable = @class.method_0();
		for (int j = 0; j < class1154_2.arrayList_1.Count; j++)
		{
			Class1154 class3 = (Class1154)class1154_2.arrayList_1[j];
			if (hashtable[class3.int_0] == null)
			{
				int num = 0;
				while (class3.arrayList_0 != null && num < class3.arrayList_0.Count)
				{
					Class1153 class4 = (Class1153)class3.arrayList_0[num];
					class4.bool_0 = true;
					num++;
				}
				class1154_2.arrayList_1.RemoveAt(j--);
			}
		}
	}

	private void method_133(PivotField pivotField_0, Class1154 class1154_2, AutoFilter autoFilter_0)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < class1154_2.arrayList_1.Count; i++)
		{
			Class1154 @class = (Class1154)class1154_2.arrayList_1[i];
			object object_ = method_137(@class.pivotItem_0, null, @class.arrayList_0, bool_11: true, pivotField_0, i, null);
			object_ = method_104(object_);
			if (object_ != null && !autoFilter_0.method_4(object_))
			{
				hashtable.Add(@class.int_0, object_);
			}
		}
		for (int j = 0; j < class1154_2.arrayList_1.Count; j++)
		{
			Class1154 class2 = (Class1154)class1154_2.arrayList_1[j];
			if (!hashtable.ContainsKey(class2.int_0))
			{
				int num = 0;
				while (class2.arrayList_0 != null && num < class2.arrayList_0.Count)
				{
					Class1153 class3 = (Class1153)class2.arrayList_0[num];
					class3.bool_0 = true;
					num++;
				}
				class1154_2.arrayList_1.RemoveAt(j--);
			}
		}
	}

	private int[][] method_134(int int_12)
	{
		if (int_12 < 0)
		{
			int_12 = 0;
			for (int i = 0; i < pivotTable_0.PageFields.Count; i++)
			{
				PivotField pivotField = pivotTable_0.PageFields[i];
				if (pivotField.CurrentPageItem >= 0 && pivotField.CurrentPageItem < pivotField.PivotItems.Count)
				{
					int_12++;
				}
			}
		}
		if (int_12 == 0)
		{
			return null;
		}
		int[][] array = new int[int_12][];
		int_12 = 0;
		for (int j = 0; j < pivotTable_0.PageFields.Count; j++)
		{
			PivotField pivotField2 = pivotTable_0.PageFields[j];
			if (pivotField2.CurrentPageItem >= 0 && pivotField2.CurrentPageItem <= pivotField2.PivotItems.Count)
			{
				PivotItem pivotItem = pivotField2.PivotItems[pivotField2.CurrentPageItem];
				array[int_12] = new int[2];
				array[int_12][0] = pivotField2.pivotField_0.Index;
				array[int_12][1] = pivotItem.Index;
				int_12++;
			}
		}
		return array;
	}

	internal object method_135(ArrayList arrayList_9, bool bool_11, Class1165 class1165_0, Class1165 class1165_1)
	{
		return null;
	}

	internal object method_136(int int_12)
	{
		if (pivotTable_0.class1141_0.class1161_0 != null && int_12 < pivotTable_0.class1141_0.class1161_0.arrayList_1.Count)
		{
			Class1166 @class = (Class1166)pivotTable_0.class1141_0.class1161_0.arrayList_1[int_12];
			if (@class.ushort_1 >= pivotTable_0.class1141_0.arrayList_0.Count)
			{
				return null;
			}
			Class1161 class2 = (Class1161)pivotTable_0.class1141_0.arrayList_0[@class.ushort_1];
			if (arrayList_5 != null && arrayList_6 != null)
			{
				Class1165 class3 = (Class1165)arrayList_5[int_6];
				Class1165 class1165_ = (Class1165)arrayList_6[class2.int_1];
				ArrayList arrayList = new ArrayList();
				arrayList = ((pivotTable_0.BaseFields[@class.ushort_1].pivotFieldType_0 != PivotFieldType.Row) ? method_123(class3.arrayList_0, class1165_, pivotFieldType_0 == PivotFieldType.Column, pivotTable_0.ColumnFields) : method_123(class3.arrayList_0, class3, pivotFieldType_0 == PivotFieldType.Row, pivotTable_0.RowFields));
				int count = 0;
				bool hasItem = false;
				PivotField pivotField = pivotTable_0.BaseFields[class2.Index];
				ArrayList arrayList2 = Class1150.smethod_1(arrayList, ignore: false, pivotField, bool_0, pivotField.Function, pivotTable_0.class1141_0, 0, null, out count, out hasItem);
				return Class1151.smethod_0(pivotField.Function, count, arrayList2, hasItem);
			}
			return null;
		}
		return null;
	}

	internal object CalculateFormula(byte[] byte_0)
	{
		if (byte_0 == null)
		{
			return null;
		}
		Class1661 @class = cells_0.method_19().Formula.method_11(null, byte_0, 0);
		if (@class != null)
		{
			Class1658 class2 = new Class1658(cells_0.method_19().Workbook);
			return class2.method_2(@class, null);
		}
		return null;
	}

	internal object method_137(PivotItem pivotItem_0, PivotItem pivotItem_1, ArrayList arrayList_9, bool bool_11, PivotField pivotField_0, int int_12, Class1165 class1165_0)
	{
		if (pivotField_0.IsCalculatedField && arrayList_9.Count != 0)
		{
			bool_9 = true;
			cells_0.method_19().method_3(this);
			object result = CalculateFormula(pivotField_0.pivotField_0.class1161_0.byte_0);
			cells_0.method_19().method_3(null);
			return result;
		}
		int count = 0;
		bool hasItem = false;
		ArrayList arrayList = Class1150.smethod_1(arrayList_9, bool_11, pivotField_0, bool_0, pivotField_0.Function, pivotTable_0.class1141_0, int_12, class1165_0, out count, out hasItem);
		return Class1151.smethod_0(pivotField_0.Function, count, arrayList, hasItem);
	}

	private void method_138(Class1154 class1154_2, PivotFieldCollection pivotFieldCollection_0, int int_12)
	{
		PivotField pivotField = pivotFieldCollection_0[int_12];
		int autoShowField = pivotField.AutoShowField;
		if (autoShowField < pivotTable_0.DataFields.Count && autoShowField >= 0)
		{
			PivotField pivotField_ = pivotTable_0.DataFields[autoShowField];
			Class1145 @class = new Class1145(bool_2: true, pivotField.IsAscendSort);
			for (int i = 0; i < class1154_2.arrayList_1.Count; i++)
			{
				Class1154 class2 = (Class1154)class1154_2.arrayList_1[i];
				object object_ = method_137(class2.pivotItem_0, null, class2.arrayList_0, bool_11: true, pivotField_, i, null);
				object_ = method_104(object_);
				@class.Add(object_, i);
			}
			int[] array = @class.method_0();
			ArrayList arrayList = new ArrayList();
			for (int j = 0; j < array.Length; j++)
			{
				arrayList.Add(class1154_2.arrayList_1[array[j]]);
			}
			class1154_2.arrayList_1 = arrayList;
		}
	}

	private bool method_139(PivotFieldCollection pivotFieldCollection_0)
	{
		if (pivotFieldCollection_0.Count > 1)
		{
			PivotField pivotField = pivotFieldCollection_0[pivotFieldCollection_0.Count - 1];
			if (pivotTable_0.DataFields.Count > 1 && pivotField == pivotTable_0.DataField)
			{
				return false;
			}
			if (pivotField.GetSubtotals(PivotFieldSubtotalType.Automatic))
			{
				return false;
			}
			if (pivotField.GetSubtotals(PivotFieldSubtotalType.None))
			{
				return false;
			}
			return true;
		}
		return false;
	}
}
