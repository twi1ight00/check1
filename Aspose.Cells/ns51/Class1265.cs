using System;
using System.Text;
using Aspose.Cells;
using ns2;

namespace ns51;

internal class Class1265
{
	internal Class1265()
	{
	}

	internal string ToString(Class1653 class1653_0, bool bool_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('=');
		byte[] array = class1653_0.method_5();
		string[] array2 = class1653_0.method_0().method_4();
		int num = 4;
		if (bool_0)
		{
			num = 2;
		}
		if (array != null && array.Length > num)
		{
			switch (array[num])
			{
			default:
				return "#REF!";
			case 58:
			{
				int num8 = BitConverter.ToUInt16(array, num + 1);
				int num9 = BitConverter.ToUInt16(array, num + 3);
				stringBuilder.Append(array2[num8]);
				if (num8 != num9)
				{
					stringBuilder.Append(':');
					stringBuilder.Append(array2[num9]);
				}
				stringBuilder.Append('!');
				int num10 = BitConverter.ToUInt16(array, num + 5);
				int column = array[num + 7];
				byte b4 = array[num + 8];
				if ((b4 & 0x40) == 0)
				{
					stringBuilder.Append('$');
				}
				stringBuilder.Append(CellsHelper.ColumnIndexToName(column));
				if ((b4 & 0x80) == 0)
				{
					stringBuilder.Append('$');
				}
				stringBuilder.Append(num10 + 1);
				return stringBuilder.ToString();
			}
			case 59:
			{
				int num2 = BitConverter.ToUInt16(array, num + 1);
				int num3 = BitConverter.ToUInt16(array, num + 3);
				if (num2 != 65535 && num2 != 65534)
				{
					stringBuilder.Append(array2[num2]);
					if (num2 != num3)
					{
						stringBuilder.Append(':');
						stringBuilder.Append(array2[num3]);
					}
					stringBuilder.Append('!');
					int num4 = BitConverter.ToUInt16(array, num + 5);
					int num5 = BitConverter.ToUInt16(array, num + 7);
					int num6 = array[num + 9];
					int num7 = array[num + 11];
					if (num4 == 0 && num5 == 65535)
					{
						byte b = array[num + 10];
						if ((b & 0x40) == 0)
						{
							stringBuilder.Append('$');
						}
						stringBuilder.Append(CellsHelper.ColumnIndexToName(num6));
						stringBuilder.Append(':');
						b = array[num + 12];
						if ((b & 0x40) == 0)
						{
							stringBuilder.Append('$');
						}
						stringBuilder.Append(CellsHelper.ColumnIndexToName(num7));
					}
					else if (num6 == 0 && num7 == 255)
					{
						byte b2 = array[num + 10];
						if ((b2 & 0x80) == 0)
						{
							stringBuilder.Append('$');
						}
						stringBuilder.Append(num4 + 1);
						stringBuilder.Append(':');
						b2 = array[num + 12];
						if ((b2 & 0x80) == 0)
						{
							stringBuilder.Append('$');
						}
						stringBuilder.Append(num5 + 1);
					}
					else
					{
						byte b3 = array[num + 10];
						if ((b3 & 0x40) == 0)
						{
							stringBuilder.Append('$');
						}
						stringBuilder.Append(CellsHelper.ColumnIndexToName(num6));
						if ((b3 & 0x80) == 0)
						{
							stringBuilder.Append('$');
						}
						stringBuilder.Append(num4 + 1);
						stringBuilder.Append(':');
						b3 = array[num + 12];
						if ((b3 & 0x40) == 0)
						{
							stringBuilder.Append('$');
						}
						stringBuilder.Append(CellsHelper.ColumnIndexToName(num7));
						if ((b3 & 0x80) == 0)
						{
							stringBuilder.Append('$');
						}
						stringBuilder.Append(num5 + 1);
					}
					return stringBuilder.ToString();
				}
				return "#REF!";
			}
			case 60:
			case 61:
				return "#REF!";
			}
		}
		return null;
	}
}
