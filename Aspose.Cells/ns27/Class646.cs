using System;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns2;

namespace ns27;

internal class Class646 : Class538
{
	private CellArea cellArea_0;

	private byte[] byte_1;

	private byte[] byte_2;

	internal Class646(CellArea cellArea_1, string string_0, string string_1, Hyperlink hyperlink_0)
	{
		method_2(440);
		method_7(cellArea_1, string_0, string_1, hyperlink_0);
	}

	private void method_4(Hyperlink hyperlink_0)
	{
		string text = null;
		int num = hyperlink_0.Address.IndexOf('#');
		string text2 = hyperlink_0.Address;
		string textToDisplay = hyperlink_0.TextToDisplay;
		bool flag = textToDisplay != null && textToDisplay != "";
		if (num != -1)
		{
			text = text2.Substring(num + 1);
			text2 = text2.Substring(0, num);
		}
		byte[] bytes = Encoding.Unicode.GetBytes(text2);
		int num2 = 0;
		byte[] array = bytes;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != 0)
			{
				num2++;
			}
		}
		bool flag2 = num2 != bytes.Length / 2;
		byte[] array2 = new byte[num2];
		num2 = 0;
		foreach (byte b in bytes)
		{
			if (b != 0)
			{
				array2[num2] = b;
				num2++;
			}
		}
		method_2(440);
		method_0(32);
		if (flag)
		{
			method_0((short)(base.Length + (short)(6 + textToDisplay.Length * 2)));
		}
		method_0((short)(base.Length + 18));
		method_0((short)(base.Length + (short)(array2.Length + 1 + 4)));
		method_0((short)(base.Length + 28));
		if (flag2)
		{
			method_0((short)(base.Length + (short)(6 + text2.Length * 2 + 2)));
		}
		if (text != null)
		{
			method_0((short)(base.Length + (short)(4 + text.Length * 2 + 2)));
		}
		byte_0 = new byte[base.Length];
		cellArea_0 = hyperlink_0.Area;
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_0.StartRow), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_0.EndRow), 0, byte_0, 2, 2);
		byte_0[4] = (byte)cellArea_0.StartColumn;
		byte_0[6] = (byte)cellArea_0.EndColumn;
		byte_1 = new byte[20]
		{
			208, 201, 234, 121, 249, 186, 206, 17, 140, 130,
			0, 170, 0, 75, 169, 11, 2, 0, 0, 0
		};
		Array.Copy(byte_1, 0, byte_0, 8, 20);
		byte_1 = null;
		byte_0[28] = 3;
		if (text != null)
		{
			byte_0[28] |= 8;
		}
		int num3 = 32;
		if (flag)
		{
			byte_0[28] |= 20;
			Array.Copy(BitConverter.GetBytes(textToDisplay.Length + 1), 0, byte_0, num3, 4);
			num3 += 4;
			Array.Copy(Encoding.Unicode.GetBytes(textToDisplay), 0, byte_0, num3, textToDisplay.Length * 2);
			num3 += textToDisplay.Length * 2 + 2;
		}
		byte_1 = new byte[16]
		{
			3, 3, 0, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		};
		Array.Copy(byte_1, 0, byte_0, num3, 16);
		byte_1 = null;
		num3 += 18;
		Array.Copy(BitConverter.GetBytes(array2.Length + 1), 0, byte_0, num3, 4);
		num3 += 4;
		Array.Copy(array2, 0, byte_0, num3, array2.Length);
		num3 += array2.Length + 1;
		byte_1 = new byte[24];
		byte_1[0] = byte.MaxValue;
		byte_1[1] = byte.MaxValue;
		byte_1[2] = 173;
		byte_1[3] = 222;
		Array.Copy(byte_1, 0, byte_0, num3, 24);
		num3 += 24;
		if (flag2)
		{
			num2 = bytes.Length + 6;
			Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, num3, 4);
			num3 += 4;
			Array.Copy(BitConverter.GetBytes(bytes.Length), 0, byte_0, num3, 4);
			num3 += 4;
			byte_0[num3] = 3;
			num3 += 2;
			Array.Copy(bytes, 0, byte_0, num3, bytes.Length);
			num3 += bytes.Length;
		}
		else
		{
			num3 += 4;
		}
		if (text != null)
		{
			Array.Copy(BitConverter.GetBytes(text.Length + 1), 0, byte_0, num3, 4);
			num3 += 4;
			Array.Copy(Encoding.Unicode.GetBytes(text), 0, byte_0, num3, text.Length * 2);
		}
	}

	private void method_5(CellArea cellArea_1, string string_0, string string_1)
	{
		string text = null;
		int num = string_1.LastIndexOf('#');
		if (num != -1)
		{
			text = string_1.Substring(num + 1);
			string_1 = string_1.Substring(0, num);
		}
		method_0((short)(44 + 2 * (string_0.Length + string_1.Length)));
		if (text != null)
		{
			method_0((short)(base.Length + (short)(4 + text.Length * 2 + 2)));
		}
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_1.StartRow), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_1.EndRow), 0, byte_0, 2, 2);
		byte_0[4] = (byte)cellArea_1.StartColumn;
		byte_0[6] = (byte)cellArea_1.EndColumn;
		byte_1 = new byte[20]
		{
			208, 201, 234, 121, 249, 186, 206, 17, 140, 130,
			0, 170, 0, 75, 169, 11, 2, 0, 0, 0
		};
		Array.Copy(byte_1, 0, byte_0, 8, 20);
		byte_0[28] = 23;
		byte_0[29] = 1;
		if (text != null)
		{
			byte_0[28] |= 8;
		}
		Array.Copy(BitConverter.GetBytes(string_0.Length + 1), 0, byte_0, 32, 4);
		Array.Copy(Encoding.Unicode.GetBytes(string_0), 0, byte_0, 36, 2 * string_0.Length);
		int num2 = 38 + 2 * string_0.Length;
		Array.Copy(BitConverter.GetBytes(string_1.Length + 1), 0, byte_0, num2, 4);
		num2 += 4;
		Array.Copy(Encoding.Unicode.GetBytes(string_1), 0, byte_0, num2, 2 * string_1.Length);
		num2 += 2 + 2 * string_1.Length;
		if (text != null)
		{
			Array.Copy(BitConverter.GetBytes(text.Length + 1), 0, byte_0, num2, 4);
			num2 += 4;
			Array.Copy(Encoding.Unicode.GetBytes(text), 0, byte_0, num2, text.Length * 2);
		}
	}

	private void method_6(CellArea cellArea_1, string string_0, string string_1)
	{
		int num = 0;
		int num2 = string_1.LastIndexOf("..\\");
		string text;
		if (num2 != -1)
		{
			num = num2 / 3 + 1;
			text = string_1.Substring(num2 + 3);
		}
		else
		{
			text = string_1;
		}
		string[] array = text.Split('#');
		text = array[0];
		string text2 = null;
		if (array.Length > 1)
		{
			text2 = array[1];
		}
		byte[] bytes = Encoding.ASCII.GetBytes(text);
		byte[] bytes2 = Encoding.Unicode.GetBytes(text);
		bool flag = true;
		for (int i = 0; i < bytes2.Length; i += 2)
		{
			if (bytes2[i + 1] == 0)
			{
				if (bytes2[i] != bytes[i / 2])
				{
					flag = false;
					break;
				}
				continue;
			}
			flag = false;
			break;
		}
		method_0((short)(89 + 2 * string_0.Length + bytes.Length));
		if (!flag)
		{
			method_0((short)(base.Length + (short)(6 + bytes2.Length)));
		}
		if (text2 != null)
		{
			method_0((short)(base.Length + (short)(4 + text2.Length * 2 + 2)));
		}
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_1.StartRow), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_1.EndRow), 0, byte_0, 2, 2);
		byte_0[4] = (byte)cellArea_1.StartColumn;
		byte_0[6] = (byte)cellArea_1.EndColumn;
		byte_1 = new byte[20]
		{
			208, 201, 234, 121, 249, 186, 206, 17, 140, 130,
			0, 170, 0, 75, 169, 11, 2, 0, 0, 0
		};
		Array.Copy(byte_1, 0, byte_0, 8, 20);
		byte_0[28] = 21;
		if (text2 != null)
		{
			byte_0[28] |= 8;
		}
		Array.Copy(BitConverter.GetBytes(string_0.Length + 1), 0, byte_0, 32, 4);
		Array.Copy(Encoding.Unicode.GetBytes(string_0), 0, byte_0, 36, 2 * string_0.Length);
		int num3 = 38 + 2 * string_0.Length;
		byte_0[num3] = 3;
		num3++;
		byte_0[num3] = 3;
		num3 += 7;
		byte_0[num3] = 192;
		num3 += 7;
		byte_0[num3] = 70;
		num3++;
		Array.Copy(BitConverter.GetBytes((short)num), 0, byte_0, num3, 2);
		num3 += 2;
		Array.Copy(BitConverter.GetBytes(bytes.Length + 1), 0, byte_0, num3, 4);
		num3 += 4;
		Array.Copy(bytes, 0, byte_0, num3, bytes.Length);
		num3 += bytes.Length + 1;
		byte_0[num3] = byte.MaxValue;
		num3++;
		byte_0[num3] = byte.MaxValue;
		num3++;
		byte_0[num3] = 173;
		num3++;
		byte_0[num3] = 222;
		num3++;
		num3 += 20;
		if (flag)
		{
			num3 += 4;
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(6 + bytes2.Length), 0, byte_0, num3, 4);
			num3 += 4;
			Array.Copy(BitConverter.GetBytes(bytes2.Length), 0, byte_0, num3, 4);
			num3 += 4;
			byte_0[num3++] = 3;
			byte_0[num3++] = 0;
			Array.Copy(bytes2, 0, byte_0, num3, bytes2.Length);
			num3 += bytes2.Length;
		}
		if (text2 != null)
		{
			Array.Copy(BitConverter.GetBytes(text2.Length + 1), 0, byte_0, num3, 4);
			Array.Copy(Encoding.Unicode.GetBytes(text2), 0, byte_0, num3 + 4, text2.Length * 2);
		}
	}

	private void method_7(CellArea cellArea_1, string string_0, string string_1, Hyperlink hyperlink_0)
	{
		if (string_0 == null || string_0 == "")
		{
			string_0 = string_1;
		}
		if (string_1.StartsWith("\\\\"))
		{
			method_5(cellArea_1, string_0, string_1);
			return;
		}
		if (string_1.Length > 1 && string_1[1] == ':')
		{
			method_4(hyperlink_0);
			return;
		}
		if (string_1.IndexOf(".") != -1)
		{
			bool flag = true;
			string text = string_1.ToLower();
			if (!text.StartsWith("http:") && !text.StartsWith("www.") && !text.StartsWith("https:") && !text.StartsWith("mailto:"))
			{
				if (string_1.IndexOf("!") != -1)
				{
					int num = string_1.LastIndexOf('#');
					if (num == -1)
					{
						string[] array = string_1.Split('!');
						if (array[1] != null && array[1] != "" && Class1677.smethod_23(array[1]))
						{
							flag = false;
						}
					}
				}
			}
			else
			{
				flag = false;
			}
			if (flag)
			{
				method_6(cellArea_1, string_0, string_1);
				return;
			}
		}
		bool flag2 = false;
		string text2 = string_1.ToLower();
		Match match = Regex.Match(text2, "^\\w+:", RegexOptions.IgnoreCase);
		if (!match.Success && !text2.StartsWith("www."))
		{
			flag2 = true;
		}
		if (flag2)
		{
			method_0((short)(44 + 2 * (string_0.Length + string_1.Length)));
		}
		else
		{
			method_0((short)(60 + 2 * (string_0.Length + string_1.Length)));
		}
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_1.StartRow), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_1.EndRow), 0, byte_0, 2, 2);
		byte_0[4] = (byte)cellArea_1.StartColumn;
		byte_0[6] = (byte)cellArea_1.EndColumn;
		byte_1 = new byte[20]
		{
			208, 201, 234, 121, 249, 186, 206, 17, 140, 130,
			0, 170, 0, 75, 169, 11, 2, 0, 0, 0
		};
		Array.Copy(byte_1, 0, byte_0, 8, 20);
		if (flag2)
		{
			byte_0[28] = 28;
		}
		else
		{
			byte_0[28] = 23;
		}
		Array.Copy(BitConverter.GetBytes(string_0.Length + 1), 0, byte_0, 32, 4);
		Array.Copy(Encoding.Unicode.GetBytes(string_0), 0, byte_0, 36, 2 * string_0.Length);
		int num2 = 38 + 2 * string_0.Length;
		byte_2 = new byte[16]
		{
			224, 201, 234, 121, 249, 186, 206, 17, 140, 130,
			0, 170, 0, 75, 169, 11
		};
		if (!flag2)
		{
			Array.Copy(byte_2, 0, byte_0, num2, 16);
			num2 += 16;
		}
		if (flag2)
		{
			Array.Copy(BitConverter.GetBytes(string_1.Length + 1), 0, byte_0, num2, 4);
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(2 * string_1.Length + 2), 0, byte_0, num2, 4);
		}
		num2 += 4;
		Array.Copy(Encoding.Unicode.GetBytes(string_1), 0, byte_0, num2, 2 * string_1.Length);
		num2 += 2 * string_1.Length + 2;
	}

	internal Class646()
	{
		method_2(440);
	}
}
