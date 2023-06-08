using System;
using System.Collections;
using System.Text;
using Aspose.Cells;
using ns2;

namespace ns59;

internal class Class1729
{
	internal Class1729()
	{
	}

	internal static void smethod_0(ArrayList arrayList_0, WorksheetCollection worksheetCollection_0)
	{
		try
		{
			byte[] array = null;
			byte[] array2 = (byte[])arrayList_0[0];
			int num = BitConverter.ToInt32(array2, 4);
			int num2 = 0;
			int num3 = 8;
			Class1301 class1301_ = worksheetCollection_0.class1301_0;
			for (int i = 0; i < num; i++)
			{
				if (num3 >= array2.Length)
				{
					num2++;
					num3 = 0;
					array2 = (byte[])arrayList_0[num2];
				}
				int num4 = BitConverter.ToUInt16(array2, num3);
				int num5 = array2[num3 + 2] & 0xD;
				num3 += 3;
				bool flag = (num5 & 1) == 0;
				int num6 = 0;
				int num7 = 0;
				if (((uint)num5 & 8u) != 0)
				{
					num7 = BitConverter.ToUInt16(array2, num3) * 4;
					num3 += 2;
				}
				if (((uint)num5 & 4u) != 0)
				{
					num6 = BitConverter.ToInt32(array2, num3);
					num3 += 4;
				}
				if (num4 == 0)
				{
					Class1719 class1719_ = new Class1719("", 0);
					class1301_.method_6(class1719_, i);
					num3 += num6 + num7;
					continue;
				}
				byte[] array3 = new byte[num4 * 2];
				int num8 = 0;
				while (num4 > 0)
				{
					int num9 = array2.Length - num3;
					if (flag)
					{
						if (num9 >= num4)
						{
							for (int j = 0; j < num4; j++)
							{
								array3[num8 + 2 * j] = array2[j + num3];
							}
							num3 += num4;
							num4 = 0;
							continue;
						}
						for (int k = 0; k < num9; k++)
						{
							array3[num8 + 2 * k] = array2[k + num3];
						}
						num4 -= num9;
						num8 += num9 * 2;
						num2++;
						array2 = (byte[])arrayList_0[num2];
						flag = (array2[0] & 1) == 0;
						num3 = 1;
					}
					else
					{
						int num10 = num4 + num4;
						if (num9 >= num10)
						{
							Array.Copy(array2, num3, array3, num8, num10);
							num3 += num10;
							num4 = 0;
							continue;
						}
						Array.Copy(array2, num3, array3, num8, num9);
						num4 -= num9 / 2;
						num8 += num9;
						num2++;
						array2 = (byte[])arrayList_0[num2];
						flag = (array2[0] & 1) == 0;
						num3 = 1;
					}
				}
				string @string = Encoding.Unicode.GetString(array3);
				if (num7 > 0)
				{
					array = new byte[num7];
					num8 = 0;
					while (num7 > 0)
					{
						int num11 = array2.Length - num3;
						if (num11 >= num7)
						{
							Array.Copy(array2, num3, array, num8, num7);
							num3 += num7;
							num7 = 0;
							continue;
						}
						Array.Copy(array2, num3, array, num8, num11);
						num7 -= num11;
						num8 += num11;
						num2++;
						array2 = (byte[])arrayList_0[num2];
						num3 = 0;
					}
					class1301_.method_7(@string, i, array);
				}
				else
				{
					Class1719 class1719_ = new Class1719(@string, 0);
					class1301_.method_6(class1719_, i);
				}
				if (num6 <= 0)
				{
					continue;
				}
				while (num6 > 0)
				{
					int num12 = array2.Length - num3;
					if (num12 >= num6)
					{
						num3 += num6;
						num6 = 0;
						continue;
					}
					num6 -= num12;
					num2++;
					array2 = (byte[])arrayList_0[num2];
					num3 = 0;
				}
			}
		}
		catch
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid string in the file.");
		}
	}
}
