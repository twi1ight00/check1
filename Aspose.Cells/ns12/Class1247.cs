using System;
using System.Text;
using ns2;

namespace ns12;

internal class Class1247
{
	internal static void smethod_0(Class1653 class1653_0)
	{
		byte[] array = class1653_0.method_5();
		if (array != null && array.Length >= 2)
		{
			if (array.Length == 2)
			{
				class1653_0.method_6(new byte[4]);
				return;
			}
			byte[] array2 = new byte[array.Length + 2];
			Array.Copy(array, 0, array2, 0, 2);
			Array.Copy(array, 2, array2, 4, array.Length - 2);
			class1653_0.method_6(array2);
		}
	}

	public static byte[] smethod_1(byte[] byte_0, int int_0, int int_1, int int_2, bool bool_0)
	{
		int num = byte_0.Length;
		int num2 = num;
		int num3 = num2;
		bool flag = false;
		Class1249 @class = null;
		Class1249 class2 = null;
		if (int_0 == -1)
		{
			int_0 = 2;
			num = BitConverter.ToUInt16(byte_0, 0);
			num3 = (num2 = num + 2);
			@class = new Class1249(num * 2);
			if (num3 != byte_0.Length)
			{
				class2 = new Class1249(byte_0.Length - num3);
			}
			flag = true;
		}
		else
		{
			@class = new Class1249(num * 2);
		}
		smethod_2(byte_0, int_0, num3, num2, @class, class2, int_1, int_2, bool_0);
		if (flag)
		{
			int num4 = 4 + @class.Length + 4 + (class2?.Length ?? 0);
			byte[] array = new byte[num4];
			Array.Copy(BitConverter.GetBytes(@class.Length), 0, array, 0, 4);
			@class.Read(array, 4);
			int num5 = 4 + @class.Length;
			if (class2 != null)
			{
				Array.Copy(BitConverter.GetBytes(class2.Length), 0, array, num5, 4);
				class2.Read(array, num5 + 4);
			}
			return array;
		}
		byte[] array2 = new byte[@class.Length];
		@class.Read(array2, 0);
		return array2;
	}

	private static int[] smethod_2(byte[] byte_0, int int_0, int int_1, int int_2, Class1249 class1249_0, Class1249 class1249_1, int int_3, int int_4, bool bool_0)
	{
		while (int_0 < int_2)
		{
			switch (byte_0[int_0])
			{
			case 1:
			case 2:
				class1249_0.Write(byte_0, int_0, 3);
				class1249_0.Seek(2);
				class1249_0.Write(byte_0, int_0 + 3, 2);
				int_0 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				class1249_0.Write(byte_0[int_0]);
				int_0++;
				break;
			case 23:
			{
				byte b = byte_0[int_0 + 1];
				if (b == 0)
				{
					class1249_0.Write(byte_0, int_0, 2);
					class1249_0.Write(0);
					int_0 += 3;
				}
				else if (byte_0[int_0 + 2] == 0)
				{
					class1249_0.Write(byte_0, int_0, 3);
					byte[] array = new byte[b * 2];
					for (int i = 0; i < b; i++)
					{
						array[i * 2] = byte_0[int_0 + 3 + i];
					}
					class1249_0.Write(array, 0, array.Length);
					int_0 += (ushort)(b + 3);
				}
				else
				{
					class1249_0.Write(byte_0, int_0, 2);
					class1249_0.Write(0);
					class1249_0.Write(byte_0, int_0 + 3, b * 2);
					int_0 += b * 2 + 3;
				}
				break;
			}
			case 24:
				if (byte_0[int_0 + 1] == 25)
				{
					class1249_0.Write(byte_0, int_0, 14);
					int_0 += 14;
				}
				else if (byte_0[int_0 + 1] == 29)
				{
					class1249_0.Write(byte_0, int_0, 6);
					int_0 += 6;
				}
				else
				{
					class1249_0.Write(byte_0[int_0]);
					int_0++;
				}
				break;
			case 25:
			{
				int num = 0;
				switch (byte_0[int_0 + 1])
				{
				case 8:
					num = 4;
					break;
				case 1:
					num = 4;
					class1249_0.Write(byte_0, int_0, 4);
					break;
				case 2:
					num = 4;
					break;
				case 4:
				{
					ushort num2 = BitConverter.ToUInt16(byte_0, int_0 + 4);
					num = num2 + 4;
					break;
				}
				default:
					num = 4;
					break;
				case 64:
					num = 4;
					break;
				case 32:
					num = 4;
					break;
				case 16:
					num = 4;
					class1249_0.Write(byte_0, int_0, 4);
					break;
				}
				int_0 += num;
				break;
			}
			case 28:
			case 29:
				class1249_0.Write(byte_0, int_0, 2);
				int_0 += 2;
				break;
			case 31:
				class1249_0.Write(byte_0, int_0, 9);
				int_0 += 9;
				break;
			case 32:
			case 64:
			case 96:
				class1249_0.Write(byte_0[int_0]);
				class1249_0.Seek(14);
				int_1 = smethod_5(byte_0, int_1, class1249_1);
				int_0 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				class1249_0.Write(byte_0, int_0, 3);
				int_0 += 3;
				break;
			case 34:
			case 66:
			case 98:
				class1249_0.Write(byte_0, int_0, 4);
				int_0 += 4;
				break;
			case 35:
			case 67:
			case 99:
				class1249_0.Write(byte_0, int_0, 5);
				int_0 += 5;
				break;
			case 37:
			case 69:
			case 101:
				class1249_0.Write(byte_0, int_0, 3);
				class1249_0.Seek(2);
				class1249_0.Write(byte_0, int_0 + 3, 2);
				if (byte_0[int_0 + 1] == 0 && byte_0[int_0 + 2] == 0 && byte_0[int_0 + 3] == byte.MaxValue && byte_0[int_0 + 4] == byte.MaxValue)
				{
					class1249_0.Write(15);
					class1249_0.Seek(1);
				}
				else
				{
					class1249_0.Seek(2);
				}
				if (byte_0[int_0 + 5] == 0 && byte_0[int_0 + 7] == byte.MaxValue)
				{
					class1249_0.Write(byte_0, int_0 + 5, 3);
					class1249_0.Write((byte)(byte_0[int_0 + 8] | 0x3Fu));
				}
				else
				{
					class1249_0.Write(byte_0, int_0 + 5, 4);
				}
				int_0 += 9;
				break;
			case 38:
			case 39:
			case 40:
			case 70:
			case 71:
			case 72:
			case 102:
			case 103:
			case 104:
			{
				class1249_0.Write(byte_0, int_0, 5);
				int num4 = BitConverter.ToUInt16(byte_0, int_0 + 5);
				int length2 = class1249_0.Length;
				class1249_0.Seek(2);
				int_0 += 7;
				int[] array3 = smethod_2(byte_0, int_0, int_1, int_0 + num4, class1249_0, class1249_1, int_3, int_4, bool_0);
				int_0 = array3[0];
				int_1 = array3[1];
				class1249_0.method_0(length2, BitConverter.GetBytes((ushort)(class1249_0.Length - length2 - 2)), 0, 2);
				break;
			}
			case 41:
			case 73:
			case 105:
			{
				class1249_0.Write(byte_0[int_0]);
				int num3 = BitConverter.ToUInt16(byte_0, int_0 + 1);
				int length = class1249_0.Length;
				class1249_0.Seek(2);
				int_0 += 3;
				int[] array2 = smethod_2(byte_0, int_0, int_1, int_0 + num3, class1249_0, class1249_1, int_3, int_4, bool_0);
				int_0 = array2[0];
				int_1 = array2[1];
				class1249_0.method_0(length, BitConverter.GetBytes((ushort)(class1249_0.Length - length - 2)), 0, 2);
				break;
			}
			case 36:
			case 42:
			case 68:
			case 74:
			case 100:
			case 106:
				class1249_0.Write(byte_0, int_0, 3);
				class1249_0.Seek(2);
				class1249_0.Write(byte_0, int_0 + 3, 2);
				int_0 += 5;
				break;
			case 43:
			case 75:
			case 107:
				class1249_0.Write(byte_0, int_0, 3);
				class1249_0.Seek(2);
				class1249_0.Write(byte_0, int_0 + 3, 2);
				class1249_0.Seek(2);
				class1249_0.Write(byte_0, int_0 + 5, 4);
				int_0 += 9;
				break;
			case 44:
			case 76:
			case 108:
				class1249_0.Write(byte_0[int_0]);
				int_0++;
				smethod_3(byte_0, int_0, class1249_0, int_3, int_4);
				int_0 += 4;
				break;
			case 45:
			case 77:
			case 109:
				smethod_4(byte_0, int_0, class1249_0, int_3, int_4);
				int_0 += 9;
				break;
			default:
				class1249_0.Write(byte_0[int_0++]);
				break;
			case 57:
			case 89:
			case 121:
				class1249_0.Write(byte_0, int_0, 7);
				int_0 += 7;
				break;
			case 58:
			case 90:
			case 122:
				if (bool_0)
				{
					class1249_0.Write(byte_0, int_0, 3);
					int_0 += 3;
					smethod_3(byte_0, int_0, class1249_0, int_3, int_4);
					int_0 += 4;
				}
				else
				{
					class1249_0.Write(byte_0, int_0, 5);
					class1249_0.Seek(2);
					class1249_0.Write(byte_0, int_0 + 5, 2);
					int_0 += 7;
				}
				break;
			case 59:
			case 91:
			case 123:
				class1249_0.Write(byte_0, int_0, 5);
				class1249_0.Seek(2);
				class1249_0.Write(byte_0, int_0 + 5, 2);
				if (byte_0[int_0 + 3] == 0 && byte_0[int_0 + 4] == 0 && byte_0[int_0 + 5] == byte.MaxValue && byte_0[int_0 + 6] == byte.MaxValue)
				{
					class1249_0.Write(15);
					class1249_0.Seek(1);
				}
				else
				{
					class1249_0.Seek(2);
				}
				if (byte_0[int_0 + 7] == 0 && byte_0[int_0 + 9] == byte.MaxValue)
				{
					class1249_0.Write(byte_0, int_0 + 7, 3);
					class1249_0.Write((byte)(byte_0[int_0 + 10] | 0x3Fu));
				}
				else
				{
					class1249_0.Write(byte_0, int_0 + 7, 4);
				}
				int_0 += 11;
				break;
			case 60:
			case 92:
			case 124:
				class1249_0.Write(byte_0, int_0, 5);
				class1249_0.Seek(2);
				class1249_0.Write(byte_0, int_0 + 5, 2);
				int_0 += 7;
				break;
			case 61:
			case 93:
			case 125:
				class1249_0.Write(byte_0, int_0, 5);
				class1249_0.Seek(2);
				class1249_0.Write(byte_0, int_0 + 5, 2);
				class1249_0.Seek(2);
				class1249_0.Write(byte_0, int_0 + 7, 4);
				int_0 += 11;
				break;
			}
		}
		return new int[2] { int_0, int_1 };
	}

	private static void smethod_3(byte[] byte_0, int int_0, Class1249 class1249_0, int int_1, int int_2)
	{
		bool flag = (byte_0[int_0 + 3] & 0x80) == 0;
		bool flag2 = (byte_0[int_0 + 3] & 0x40) == 0;
		int num = BitConverter.ToUInt16(byte_0, int_0);
		if (!flag && num + int_1 > 65535)
		{
			class1249_0.Write(byte_0, int_0, 2);
			class1249_0.Write(15);
			class1249_0.Seek(1);
		}
		else
		{
			class1249_0.Write(byte_0, int_0, 2);
			class1249_0.Seek(2);
		}
		int_0 += 2;
		if (!flag2 && byte_0[int_0] + int_2 > 255)
		{
			class1249_0.Write(byte_0[int_0]);
			class1249_0.Write((byte)(byte_0[int_0 + 1] | 0x3Fu));
		}
		else
		{
			class1249_0.Write(byte_0, int_0, 2);
		}
	}

	private static void smethod_4(byte[] byte_0, int int_0, Class1249 class1249_0, int int_1, int int_2)
	{
		class1249_0.Write(byte_0[int_0]);
		int_0++;
		bool flag = (byte_0[int_0 + 5] & 0x80) == 0;
		bool flag2 = (byte_0[int_0 + 5] & 0x40) == 0;
		bool flag3 = (byte_0[int_0 + 7] & 0x80) == 0;
		bool flag4 = (byte_0[int_0 + 7] & 0x40) == 0;
		int num = BitConverter.ToUInt16(byte_0, int_0);
		if (!flag && int_1 + num > 65535)
		{
			class1249_0.Write(byte_0, int_0, 2);
			class1249_0.Write(15);
			class1249_0.Seek(1);
		}
		else
		{
			class1249_0.Write(byte_0, int_0, 2);
			class1249_0.Seek(2);
		}
		int_0 += 2;
		num = BitConverter.ToUInt16(byte_0, int_0);
		if (!flag3 && int_1 + num > 65535)
		{
			class1249_0.Write(byte_0, int_0, 2);
			class1249_0.Write(15);
			class1249_0.Seek(1);
		}
		else
		{
			class1249_0.Write(byte_0, int_0, 2);
			class1249_0.Seek(2);
		}
		int_0 += 2;
		if (!flag2 && byte_0[int_0] + int_2 > 255)
		{
			class1249_0.Write(byte_0[int_0]);
			class1249_0.Write((byte)(byte_0[int_0 + 1] | 0x3Fu));
		}
		else
		{
			class1249_0.Write(byte_0, int_0, 2);
		}
		int_0 += 2;
		if (!flag4 && byte_0[int_0] + int_2 > 255)
		{
			class1249_0.Write(byte_0[int_0]);
			class1249_0.Write((byte)(byte_0[int_0 + 1] | 0x3Fu));
		}
		else
		{
			class1249_0.Write(byte_0, int_0, 2);
		}
		int_0 += 2;
	}

	private static int smethod_5(byte[] byte_0, int int_0, Class1249 class1249_0)
	{
		int num = byte_0[int_0] + 1;
		int num2 = BitConverter.ToUInt16(byte_0, int_0 + 1) + 1;
		int_0 += 3;
		class1249_0.Write(BitConverter.GetBytes(num), 0, 4);
		class1249_0.Write(BitConverter.GetBytes(num2), 0, 4);
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				switch (byte_0[int_0])
				{
				case 16:
					class1249_0.Write(4);
					class1249_0.Write(byte_0[int_0 + 1]);
					class1249_0.Seek(3);
					int_0 += 9;
					break;
				case 0:
					class1249_0.Write(1);
					class1249_0.Seek(2);
					int_0 += 9;
					break;
				case 1:
					int_0++;
					class1249_0.Write(0);
					class1249_0.Write(byte_0, int_0, 8);
					int_0 += 8;
					break;
				case 2:
				{
					int_0++;
					int num3 = BitConverter.ToUInt16(byte_0, int_0);
					if (num3 != 0)
					{
						class1249_0.Write(1);
						string text = null;
						if (byte_0[int_0 + 2] == 0)
						{
							text = Encoding.ASCII.GetString(byte_0, int_0 + 3, num3);
							int_0 += 3 + num3;
						}
						else
						{
							text = Encoding.Unicode.GetString(byte_0, int_0 + 3, num3 * 2);
							int_0 += 3 + num3 * 2;
						}
						class1249_0.Write(BitConverter.GetBytes(num3), 0, 2);
						class1249_0.Write(Encoding.Unicode.GetBytes(text), 0, num3 * 2);
					}
					else
					{
						class1249_0.Write(1);
						class1249_0.Seek(2);
						int_0 += 3;
					}
					break;
				}
				case 4:
					class1249_0.Write(2);
					class1249_0.Write(byte_0[int_0 + 1]);
					int_0 += 9;
					break;
				}
			}
		}
		return int_0;
	}
}
