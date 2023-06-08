using System;
using System.Collections;
using ns2;
using ns51;

namespace ns12;

internal class Class1248
{
	internal static void smethod_0(Class1653 class1653_0)
	{
		byte[] array = class1653_0.method_5();
		if (array != null && array.Length >= 4)
		{
			if (array.Length == 4)
			{
				class1653_0.method_6(new byte[2]);
				return;
			}
			byte[] array2 = new byte[array.Length - 2];
			Array.Copy(array, 0, array2, 0, 2);
			Array.Copy(array, 4, array2, 2, array.Length - 4);
			class1653_0.method_6(array2);
		}
	}

	public static byte[] smethod_1(byte[] byte_0, int int_0)
	{
		int num = byte_0.Length;
		int num2 = num;
		int num3 = num2;
		bool flag = false;
		Class1249 @class = null;
		int num4 = 0;
		if (int_0 == -1)
		{
			int_0 = 4;
			num = BitConverter.ToInt32(byte_0, 0);
			num2 = 4 + num;
			if (num2 < byte_0.Length)
			{
				num4 = BitConverter.ToInt32(byte_0, num2);
				num3 = num2 + 4;
			}
			flag = true;
			@class = new Class1249(num + 4);
		}
		else
		{
			@class = new Class1249(byte_0.Length);
		}
		if (num3 >= byte_0.Length)
		{
			num4 = 0;
		}
		Class1249 class2 = null;
		if (num4 != 0)
		{
			class2 = new Class1249(num4);
			smethod_5(byte_0, num3, num4, class2);
		}
		ArrayList arrayList = new ArrayList();
		int_0 = smethod_4(byte_0, int_0, num2, @class, arrayList);
		if (arrayList.Count != 0)
		{
			for (int i = 0; i < arrayList.Count; i++)
			{
				int[] array = (int[])arrayList[i];
				@class.method_0(array[2], BitConverter.GetBytes(array[1] - array[0] - array[3]), 0, 2);
			}
		}
		int length = @class.Length;
		if (length > 65535)
		{
			return new byte[4] { 2, 0, 28, 42 };
		}
		if (flag)
		{
			length += ((num4 != 0) ? class2.Length : 0);
			byte[] array2 = new byte[length + 2];
			Array.Copy(BitConverter.GetBytes((ushort)@class.Length), 0, array2, 0, 2);
			@class.Read(array2, 2);
			if (num4 != 0)
			{
				int int_ = @class.Length + 2;
				class2.Read(array2, int_);
			}
			return array2;
		}
		byte[] array3 = new byte[length];
		@class.Read(array3, 0);
		return array3;
	}

	private static bool smethod_2(int int_0, int int_1, int int_2, int int_3)
	{
		if (int_0 == 0 && int_2 == 1048575)
		{
			if (int_1 <= 255)
			{
				return int_3 > 255;
			}
			return true;
		}
		if (int_1 == 0 && int_3 == 16383)
		{
			if (int_0 <= 65535)
			{
				return int_2 > 65535;
			}
			return true;
		}
		if (int_0 <= 65535 && int_2 <= 65535 && int_1 <= 255 && int_3 <= 255)
		{
			return true;
		}
		return false;
	}

	private static void smethod_3(ArrayList arrayList_0, int int_0, int int_1, Class1249 class1249_0)
	{
		if (arrayList_0.Count == 0)
		{
			return;
		}
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			int[] array = (int[])arrayList_0[i];
			if (int_0 < array[0])
			{
				continue;
			}
			if (int_0 >= array[1])
			{
				if (array[3] != 0)
				{
					class1249_0.method_0(array[2], BitConverter.GetBytes(array[1] - array[0] - array[3]), 0, 2);
				}
				arrayList_0.RemoveAt(i--);
			}
			else
			{
				array[3] += int_1;
			}
		}
	}

	private static int smethod_4(byte[] byte_0, int int_0, int int_1, Class1249 class1249_0, ArrayList arrayList_0)
	{
		int[] array = new int[4];
		while (int_0 < int_1)
		{
			switch (byte_0[int_0])
			{
			case 1:
			case 2:
			{
				int num = BitConverter.ToInt32(byte_0, int_0 + 1);
				int num3 = Class1268.smethod_1(byte_0, int_0 + 5);
				if (num <= 65535 && num3 <= 255)
				{
					class1249_0.Write(byte_0, int_0, 3);
					class1249_0.Write(byte_0, int_0 + 5, 2);
				}
				else
				{
					class1249_0.Write(42);
					class1249_0.Seek(4);
				}
				int_0 += 7;
				break;
			}
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
				int num12 = BitConverter.ToUInt16(byte_0, int_0 + 1);
				class1249_0.Write(byte_0[int_0]);
				class1249_0.Write(byte_0[int_0 + 1]);
				class1249_0.Write(1);
				class1249_0.Write(byte_0, int_0 + 3, num12 * 2);
				int_0 += (ushort)(num12 * 2 + 3);
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
				int num7 = 4;
				int num8 = 0;
				switch (byte_0[int_0 + 1])
				{
				case 2:
				case 8:
					class1249_0.Write(byte_0, int_0, num7);
					num8 = BitConverter.ToUInt16(byte_0, int_0 + 2);
					int_0 += 4;
					arrayList_0.Add(new int[4]
					{
						int_0,
						int_0 + num8,
						class1249_0.Length - 2,
						0
					});
					break;
				default:
					class1249_0.Write(byte_0, int_0, num7);
					int_0 += num7;
					break;
				case 4:
				{
					ushort num9 = BitConverter.ToUInt16(byte_0, int_0 + 4);
					num7 = num9 + 4;
					class1249_0.Write(byte_0, int_0, num7);
					int num10 = BitConverter.ToUInt16(byte_0, int_0 + 2);
					for (int i = 0; i < num10; i++)
					{
						int num11 = int_0 + 6 + i * 2;
						array = new int[4]
						{
							num11 + 2,
							0,
							0,
							0
						};
						num8 = BitConverter.ToUInt16(byte_0, num11);
						array[1] = num11 + 2 + num8;
						array[2] = class1249_0.Length - (num10 - i) * 2;
						arrayList_0.Add(array);
					}
					int_0 += num7;
					break;
				}
				}
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
				class1249_0.Write(byte_0, int_0, 8);
				int_0 += 15;
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
			case 36:
			case 68:
			case 100:
			{
				smethod_3(arrayList_0, int_0, 2, class1249_0);
				int num = BitConverter.ToInt32(byte_0, int_0 + 1);
				int num3 = Class1268.smethod_1(byte_0, int_0 + 5);
				if (num <= 65535 && num3 <= 255)
				{
					class1249_0.Write(byte_0, int_0, 3);
					class1249_0.Write(byte_0, int_0 + 5, 2);
				}
				else
				{
					class1249_0.Write((byte)(byte_0[int_0] + 6));
					class1249_0.Seek(4);
				}
				int_0 += 7;
				break;
			}
			case 37:
			case 69:
			case 101:
			{
				smethod_3(arrayList_0, int_0, 4, class1249_0);
				int num = BitConverter.ToInt32(byte_0, int_0 + 1);
				int num2 = BitConverter.ToInt32(byte_0, int_0 + 5);
				int num3 = Class1268.smethod_1(byte_0, int_0 + 9);
				int num4 = Class1268.smethod_1(byte_0, int_0 + 11);
				if (num == 0 && num2 == 1048575)
				{
					if (num3 == 0 && num4 == 16383)
					{
						class1249_0.Write(byte_0, int_0, 3);
						class1249_0.Write(byte_0, int_0 + 5, 2);
						class1249_0.Write(byte_0, int_0 + 9, 3);
						class1249_0.Write((byte)(byte_0[int_0 + 12] & 0xC0u));
					}
					else if (num3 <= 255 && num4 <= 255)
					{
						class1249_0.Write(byte_0, int_0, 3);
						class1249_0.Write(byte_0, int_0 + 5, 2);
						class1249_0.Write(byte_0, int_0 + 9, 4);
					}
					else
					{
						class1249_0.Write((byte)(byte_0[int_0] + 6));
						class1249_0.Seek(8);
					}
				}
				else if (num3 == 0 && num4 == 16383)
				{
					if (num <= 65535 && num <= 65535)
					{
						class1249_0.Write(byte_0, int_0, 3);
						class1249_0.Write(byte_0, int_0 + 5, 2);
						class1249_0.Write(byte_0, int_0 + 9, 3);
						class1249_0.Write((byte)(byte_0[int_0 + 12] & 0xC0u));
					}
					else
					{
						class1249_0.Write((byte)(byte_0[int_0] + 6));
						class1249_0.Seek(8);
					}
				}
				else if (!smethod_2(num, num3, num2, num4))
				{
					class1249_0.Write((byte)(byte_0[int_0] + 6));
					class1249_0.Seek(8);
				}
				else
				{
					class1249_0.Write(byte_0, int_0, 3);
					class1249_0.Write(byte_0, int_0 + 5, 2);
					class1249_0.Write(byte_0, int_0 + 9, 4);
				}
				int_0 += 13;
				break;
			}
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
				int num5 = BitConverter.ToUInt16(byte_0, int_0 + 5);
				int length = class1249_0.Length;
				class1249_0.Seek(2);
				int_0 += 7;
				int_0 = smethod_4(byte_0, int_0, int_0 + num5, class1249_0, arrayList_0);
				class1249_0.method_0(length, BitConverter.GetBytes((ushort)(class1249_0.Length - length - 2)), 0, 2);
				break;
			}
			case 41:
			case 73:
			case 105:
			{
				class1249_0.Write(byte_0[int_0]);
				int num6 = BitConverter.ToUInt16(byte_0, int_0 + 1);
				int length2 = class1249_0.Length;
				class1249_0.Seek(2);
				int_0 += 3;
				int_0 = smethod_4(byte_0, int_0, int_0 + num6, class1249_0, arrayList_0);
				class1249_0.method_0(length2, BitConverter.GetBytes((ushort)(class1249_0.Length - length2 - 2)), 0, 2);
				break;
			}
			case 42:
			case 74:
			case 106:
				smethod_3(arrayList_0, int_0, 2, class1249_0);
				class1249_0.Write(byte_0, int_0, 3);
				class1249_0.Write(byte_0, int_0 + 5, 2);
				int_0 += 7;
				break;
			case 43:
			case 75:
			case 107:
				smethod_3(arrayList_0, int_0, 4, class1249_0);
				class1249_0.Write(byte_0, int_0, 3);
				class1249_0.Write(byte_0, int_0 + 5, 2);
				class1249_0.Write(byte_0, int_0 + 9, 4);
				int_0 += 13;
				break;
			case 44:
			case 76:
			case 108:
				smethod_3(arrayList_0, int_0, 2, class1249_0);
				class1249_0.Write(byte_0, int_0, 3);
				class1249_0.Write(byte_0[int_0 + 5]);
				class1249_0.Write((byte)(byte_0[int_0 + 6] & 0xC0u));
				int_0 += 7;
				break;
			case 45:
			case 77:
			case 109:
				smethod_3(arrayList_0, int_0, 4, class1249_0);
				class1249_0.Write(byte_0, int_0, 3);
				class1249_0.Write(byte_0, int_0 + 5, 2);
				class1249_0.Write(byte_0[int_0 + 9]);
				class1249_0.Write((byte)(byte_0[int_0 + 10] & 0xC0u));
				class1249_0.Write(byte_0[int_0 + 11]);
				class1249_0.Write((byte)(byte_0[int_0 + 12] & 0xC0u));
				int_0 += 13;
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
			{
				smethod_3(arrayList_0, int_0, 2, class1249_0);
				int num = BitConverter.ToInt32(byte_0, int_0 + 3);
				int num3 = Class1268.smethod_1(byte_0, int_0 + 7);
				if (num <= 65535 && num3 <= 255)
				{
					class1249_0.Write(byte_0, int_0, 5);
					class1249_0.Write(byte_0, int_0 + 7, 2);
				}
				else
				{
					class1249_0.Write((byte)(byte_0[int_0] + 2));
					class1249_0.Write(byte_0, int_0 + 1, 2);
					class1249_0.Seek(6);
				}
				int_0 += 9;
				break;
			}
			case 59:
			case 91:
			case 123:
			{
				smethod_3(arrayList_0, int_0, 4, class1249_0);
				int num = BitConverter.ToInt32(byte_0, int_0 + 3);
				int num2 = BitConverter.ToInt32(byte_0, int_0 + 7);
				int num3 = Class1268.smethod_1(byte_0, int_0 + 11);
				int num4 = Class1268.smethod_1(byte_0, int_0 + 13);
				if (num == 0 && num2 == 1048575)
				{
					if (num3 == 0 && num4 == 16383)
					{
						class1249_0.Write(byte_0, int_0, 5);
						class1249_0.Write(byte_0, int_0 + 7, 2);
						class1249_0.Write(byte_0, int_0 + 11, 3);
						class1249_0.Write((byte)(byte_0[int_0 + 14] & 0xC0u));
					}
					else if (num3 <= 255 && num4 <= 255)
					{
						class1249_0.Write(byte_0, int_0, 5);
						class1249_0.Write(byte_0, int_0 + 7, 2);
						class1249_0.Write(byte_0, int_0 + 11, 4);
					}
					else
					{
						class1249_0.Write((byte)(byte_0[int_0] + 2));
						class1249_0.Write(byte_0, int_0 + 1, 2);
						class1249_0.Seek(8);
					}
				}
				else if (num3 == 0 && num4 == 16383)
				{
					if (num <= 65535 && num <= 65535)
					{
						class1249_0.Write(byte_0, int_0, 5);
						class1249_0.Write(byte_0, int_0 + 7, 2);
						class1249_0.Write(byte_0, int_0 + 11, 3);
						class1249_0.Write((byte)(byte_0[int_0 + 14] & 0xC0u));
					}
					else
					{
						class1249_0.Write((byte)(byte_0[int_0] + 2));
						class1249_0.Write(byte_0, int_0 + 1, 2);
						class1249_0.Seek(8);
					}
				}
				else if (!smethod_2(num, num3, num2, num4))
				{
					class1249_0.Write((byte)(byte_0[int_0] + 2));
					class1249_0.Write(byte_0, int_0 + 1, 2);
					class1249_0.Seek(8);
				}
				else
				{
					class1249_0.Write(byte_0, int_0, 5);
					class1249_0.Write(byte_0, int_0 + 7, 2);
					class1249_0.Write(byte_0, int_0 + 11, 4);
				}
				int_0 += 15;
				break;
			}
			case 60:
			case 92:
			case 124:
				smethod_3(arrayList_0, int_0, 2, class1249_0);
				class1249_0.Write(byte_0, int_0, 5);
				class1249_0.Write(byte_0, int_0 + 7, 2);
				int_0 += 9;
				break;
			case 61:
			case 93:
			case 125:
				smethod_3(arrayList_0, int_0, 4, class1249_0);
				class1249_0.Write(byte_0, int_0, 5);
				class1249_0.Write(byte_0, int_0 + 7, 2);
				class1249_0.Write(byte_0, int_0 + 11, 4);
				int_0 += 15;
				break;
			}
		}
		return int_0;
	}

	private static void smethod_5(byte[] byte_0, int int_0, int int_1, Class1249 class1249_0)
	{
		int num = int_0 + int_1;
		while (int_0 < num)
		{
			int num2 = BitConverter.ToInt32(byte_0, int_0);
			int num3 = BitConverter.ToInt32(byte_0, int_0 + 4);
			int_0 += 8;
			class1249_0.Write((byte)(num2 - 1));
			class1249_0.Write(BitConverter.GetBytes((ushort)(num3 - 1)), 0, 2);
			for (int i = 0; i < num3; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					switch (byte_0[int_0])
					{
					case 0:
						class1249_0.Write(1);
						class1249_0.Write(byte_0, int_0 + 1, 8);
						int_0 += 9;
						break;
					case 1:
					{
						int num4 = BitConverter.ToUInt16(byte_0, int_0 + 1);
						class1249_0.Write(2);
						if (num4 == 0)
						{
							class1249_0.Seek(2);
						}
						else
						{
							class1249_0.Write(byte_0, int_0 + 1, 2);
							class1249_0.Write(1);
							class1249_0.Write(byte_0, int_0 + 3, num4 * 2);
						}
						int_0 += 3 + num4 * 2;
						break;
					}
					case 2:
						class1249_0.Write(4);
						class1249_0.Write(byte_0[int_0 + 1]);
						class1249_0.Seek(7);
						int_0 += 2;
						break;
					case 4:
						class1249_0.Write(16);
						class1249_0.Write(byte_0[int_0 + 1]);
						class1249_0.Seek(7);
						int_0 += 5;
						break;
					}
				}
			}
		}
	}
}
