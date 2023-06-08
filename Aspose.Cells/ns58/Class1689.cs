using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns1;
using ns12;

namespace ns58;

internal class Class1689
{
	internal static string ToString(WorksheetCollection worksheetCollection_0, Cell cell_0, byte[] byte_0, int int_0, int int_1, int int_2)
	{
		int int_3 = BitConverter.ToUInt16(byte_0, int_0 + 2);
		ushort num = BitConverter.ToUInt16(byte_0, int_0 + 4);
		int int_4 = BitConverter.ToInt32(byte_0, int_0 + 6);
		int num2 = worksheetCollection_0.method_32().method_12(int_3);
		int num3 = worksheetCollection_0.method_32().method_13(int_3);
		if (num2 != worksheetCollection_0.method_36())
		{
			int_0 += 14;
			return "#REF!";
		}
		if (num3 >= 0 && num3 <= worksheetCollection_0.Count)
		{
			ListObject listObject = worksheetCollection_0[num3].ListObjects.method_3(int_4);
			if (listObject != null && (byte_0[int_0 + 5] & 0x30) == 0)
			{
				int num4 = BitConverter.ToUInt16(byte_0, int_0 + 10);
				int num5 = BitConverter.ToUInt16(byte_0, int_0 + 12);
				if (num4 >= listObject.ListColumns.Count)
				{
					int_0 += 14;
					return "#REF!";
				}
				if (num5 >= listObject.ListColumns.Count)
				{
					num5 = num4;
				}
				int num6 = num & 3;
				int_0 += 14;
				StringBuilder stringBuilder = new StringBuilder();
				switch ((num >> 2) & 0x1F)
				{
				case 16:
					stringBuilder.Append(listObject.DisplayName);
					stringBuilder.Append('[');
					stringBuilder.Append('[');
					stringBuilder.Append("#This Row");
					stringBuilder.Append("],[");
					stringBuilder.Append(Class1660.smethod_0(listObject.ListColumns[num4].Name));
					stringBuilder.Append("]");
					if (num5 != num4)
					{
						stringBuilder.Append(":[");
						stringBuilder.Append(Class1660.smethod_0(listObject.ListColumns[num5].Name));
						stringBuilder.Append("]");
					}
					stringBuilder.Append("]");
					return stringBuilder.ToString();
				default:
					if (num6 == 0)
					{
						stringBuilder.Append(listObject.DisplayName);
						stringBuilder.Append("[]");
						return stringBuilder.ToString();
					}
					if (cell_0 == null || cell_0.method_4().method_3().Index != num3 || int_1 < listObject.StartRow || int_1 > listObject.EndRow || int_2 < listObject.StartColumn || int_2 > listObject.EndColumn)
					{
						stringBuilder.Append(listObject.DisplayName);
					}
					stringBuilder.Append('[');
					if (num4 == num5)
					{
						stringBuilder.Append(Class1660.smethod_0(listObject.ListColumns[num4].Name));
					}
					else
					{
						stringBuilder.Append('[');
						stringBuilder.Append(Class1660.smethod_0(listObject.ListColumns[num4].Name));
						stringBuilder.Append("]:[");
						stringBuilder.Append(Class1660.smethod_0(listObject.ListColumns[num5].Name));
						stringBuilder.Append(']');
					}
					stringBuilder.Append(']');
					return stringBuilder.ToString();
				case 8:
					stringBuilder.Append(listObject.DisplayName);
					stringBuilder.Append('[');
					stringBuilder.Append('[');
					stringBuilder.Append("#Totals");
					stringBuilder.Append("],[");
					stringBuilder.Append(Class1660.smethod_0(listObject.ListColumns[num4].Name));
					stringBuilder.Append("]");
					if (num5 != num4)
					{
						stringBuilder.Append(":[");
						stringBuilder.Append(Class1660.smethod_0(listObject.ListColumns[num5].Name));
						stringBuilder.Append("]");
					}
					stringBuilder.Append("]");
					return stringBuilder.ToString();
				}
			}
			int_0 += 14;
			return "#REF!";
		}
		int_0 += 14;
		return "#REF!";
	}

	internal static int[] GetRange(WorksheetCollection worksheetCollection_0, byte[] byte_0, int int_0, int int_1, int int_2)
	{
		int num = BitConverter.ToUInt16(byte_0, int_0 + 2);
		int num2 = BitConverter.ToUInt16(byte_0, int_0 + 4);
		int int_3 = BitConverter.ToInt32(byte_0, int_0 + 6);
		int num3 = worksheetCollection_0.method_32().method_12(num);
		int num4 = worksheetCollection_0.method_32().method_13(num);
		if (num3 != worksheetCollection_0.method_36())
		{
			return null;
		}
		if (num4 >= 0 && num4 <= worksheetCollection_0.Count)
		{
			ListObject listObject = worksheetCollection_0[num4].ListObjects.method_3(int_3);
			if (listObject != null && (byte_0[int_0 + 5] & 0x30) == 0)
			{
				int num5 = BitConverter.ToUInt16(byte_0, int_0 + 10);
				int num6 = BitConverter.ToUInt16(byte_0, int_0 + 12);
				if (num5 >= listObject.ListColumns.Count)
				{
					return null;
				}
				num5 = listObject.StartColumn + num5;
				num6 = listObject.StartColumn + num6;
				int num7 = listObject.StartRow;
				int num8 = listObject.EndRow;
				int num9 = num2 & 3;
				switch ((num2 >> 2) & 0x1F)
				{
				case 16:
					num7 = (num8 = int_1);
					break;
				default:
					if (listObject.ShowHeaderRow)
					{
						num7++;
					}
					if (listObject.ShowTotals)
					{
						num8--;
					}
					if (num9 == 0)
					{
						num5 = listObject.StartColumn;
						num6 = listObject.EndColumn;
					}
					break;
				case 8:
					if (!listObject.method_19())
					{
						return null;
					}
					num7 = (num8 = listObject.EndRow);
					break;
				}
				return new int[5] { num, num7, num5, num8, num6 };
			}
			return null;
		}
		return null;
	}

	internal static byte[] smethod_0(WorksheetCollection sheets, int sheetIndex, int row, int column, string node, Enum227 refMode, out bool InvalidTable)
	{
		byte[] array = new byte[14]
		{
			24, 25, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		};
		int num = node.LastIndexOf('!');
		int num2 = 0;
		bool flag = false;
		if (num != -1)
		{
			flag = true;
			string string_ = node.Substring(0, num);
			node = node.Substring(num + 1).Trim();
			string_ = Class1660.smethod_2(string_);
			int[] array2 = Class1660.smethod_3(sheets, string_);
			num2 = array2[0];
			int num3 = array2[2];
			sheetIndex = num3;
		}
		else
		{
			num2 = sheets.method_32().method_8(sheets.method_36(), sheetIndex);
		}
		Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array, 2, 2);
		string text = null;
		if (node[0] != '[')
		{
			num = node.IndexOf('[');
			text = node.Substring(0, num);
			node = node.Substring(num).Trim();
			node = node.Replace("''", "'");
		}
		ListObjectCollection listObjectCollection = null;
		ListObject listObject = null;
		int value = -1;
		if (text == null)
		{
			listObjectCollection = sheets[sheetIndex].ListObjects;
			for (int i = 0; i < listObjectCollection.Count; i++)
			{
				ListObject listObject2 = listObjectCollection[i];
				if (listObject2.StartRow <= row && listObject2.StartColumn <= column && listObject2.EndRow >= row && listObject2.EndColumn >= column)
				{
					listObject = listObject2;
					value = listObject.method_0();
					break;
				}
			}
		}
		else
		{
			for (int j = 0; j < sheets.Count; j++)
			{
				listObjectCollection = sheets[j].ListObjects;
				bool flag2 = false;
				for (int k = 0; k < listObjectCollection.Count; k++)
				{
					ListObject listObject3 = listObjectCollection[k];
					if (string.Compare(listObject3.DisplayName, text, ignoreCase: true) == 0)
					{
						listObject = listObject3;
						value = listObject.method_0();
						if (!flag && sheetIndex != j)
						{
							num2 = sheets.method_32().method_8(sheets.method_36(), j);
							Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array, 2, 2);
						}
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					break;
				}
			}
		}
		ushort num4 = 0;
		num4 = ((refMode != Enum227.const_2) ? ((ushort)(num4 | 0x400u)) : ((ushort)(num4 | 0x800u)));
		InvalidTable = false;
		if (listObject == null)
		{
			array[5] = 48;
			array[6] = byte.MaxValue;
			array[7] = byte.MaxValue;
			array[8] = byte.MaxValue;
			array[9] = byte.MaxValue;
			InvalidTable = true;
			return array;
		}
		Array.Copy(BitConverter.GetBytes((uint)value), 0, array, 6, 4);
		if (node.IndexOf("],") != -1)
		{
			num = node.IndexOf("],");
			string text2 = node.Substring(3, num - 3).ToUpper();
			string text3 = node.Substring(num + 2, node.Length - (num + 3)).ToUpper();
			int num5 = -1;
			int num6 = -1;
			num4 = (ushort)(num4 | 1u);
			int num7 = 0;
			string key;
			if ((key = text2) != null)
			{
				if (Class1742.dictionary_219 == null)
				{
					Class1742.dictionary_219 = new Dictionary<string, int>(9)
					{
						{ "DATA", 0 },
						{ "ALL", 1 },
						{ "HEADERS", 2 },
						{ "DATA2", 3 },
						{ "DATAHEADERS", 4 },
						{ "TOTALS", 5 },
						{ "DATATOTALS", 6 },
						{ "CURRENT", 7 },
						{ "THIS ROW", 8 }
					};
				}
				if (Class1742.dictionary_219.TryGetValue(key, out var value2))
				{
					switch (value2)
					{
					case 0:
						num7 = 0;
						break;
					case 1:
						num7 = 1;
						break;
					case 2:
						num7 = 2;
						break;
					case 3:
						num7 = 4;
						break;
					case 4:
						num7 = 6;
						break;
					case 5:
						num7 = 8;
						break;
					case 6:
						num7 = 12;
						break;
					case 7:
					case 8:
						num7 = 16;
						break;
					}
				}
			}
			num = text3.IndexOf("]:[");
			if (num != -1)
			{
				string text4 = text3.Substring(1, num - 1);
				string text5 = text3.Substring(num + 3, text3.Length - (num + 4));
				for (int l = 0; l < listObject.ListColumns.Count; l++)
				{
					ListColumn listColumn = listObject.ListColumns[l];
					if (listColumn.Name.ToUpper() == text4)
					{
						num5 = l;
					}
					else if (listColumn.Name.ToUpper() == text5)
					{
						num6 = l;
					}
				}
			}
			else
			{
				text3 = text3.Substring(1, text3.Length - 2);
				text3 = text3.Replace("''", "'");
				for (int m = 0; m < listObject.ListColumns.Count; m++)
				{
					ListColumn listColumn2 = listObject.ListColumns[m];
					if (listColumn2.Name.ToUpper() == text3)
					{
						num5 = (num6 = m);
						break;
					}
				}
			}
			if (num5 != -1 && num6 != -1)
			{
				num4 = (ushort)(num4 | (ushort)(num7 << 2));
				Array.Copy(BitConverter.GetBytes(num4), 0, array, 4, 2);
				Array.Copy(BitConverter.GetBytes((ushort)num5), 0, array, 10, 2);
				Array.Copy(BitConverter.GetBytes((ushort)num6), 0, array, 12, 2);
				return array;
			}
		}
		else
		{
			node = node.Substring(1, node.Length - 2).Trim().ToUpper();
			int num8 = -1;
			int num9 = -1;
			if (node != null && !(node == ""))
			{
				num = node.IndexOf(":");
				if (num != -1)
				{
					num4 = (ushort)(num4 | 2u);
					string[] array3 = node.Split(':');
					for (int n = 0; n < array3.Length; n++)
					{
						if (array3[n][0] == '[')
						{
							array3[n] = array3[n].Substring(1, array3[n].Length - 2);
						}
					}
					for (int num10 = 0; num10 < listObject.ListColumns.Count; num10++)
					{
						ListColumn listColumn3 = listObject.ListColumns[num10];
						if (listColumn3.Name.ToUpper() == array3[0])
						{
							num8 = num10;
							break;
						}
					}
					for (int num11 = 0; num11 < listObject.ListColumns.Count; num11++)
					{
						ListColumn listColumn4 = listObject.ListColumns[num11];
						if (listColumn4.Name.ToUpper() == array3[1])
						{
							num9 = num11;
							break;
						}
					}
				}
				else
				{
					num4 = (ushort)(num4 | 1u);
					for (int num12 = 0; num12 < listObject.ListColumns.Count; num12++)
					{
						ListColumn listColumn5 = listObject.ListColumns[num12];
						if (listColumn5.Name.ToUpper() == node)
						{
							num8 = (num9 = num12);
							break;
						}
					}
				}
			}
			else
			{
				num8 = (num9 = 0);
			}
			if (num8 != -1 && num9 != -1)
			{
				Array.Copy(BitConverter.GetBytes(num4), 0, array, 4, 2);
				Array.Copy(BitConverter.GetBytes((ushort)num8), 0, array, 10, 2);
				Array.Copy(BitConverter.GetBytes((ushort)num9), 0, array, 12, 2);
				return array;
			}
		}
		array[5] = 48;
		array[6] = byte.MaxValue;
		array[7] = byte.MaxValue;
		array[8] = byte.MaxValue;
		array[9] = byte.MaxValue;
		return array;
	}
}
