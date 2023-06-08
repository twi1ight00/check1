using System;
using System.Text;

namespace ns27;

internal class Class639 : Class538
{
	private string string_0;

	private int int_0 = -1;

	internal bool bool_0;

	internal string Custom
	{
		get
		{
			if (string_0 != null && string_0 != "")
			{
				return string_0.Replace("\\/", "/");
			}
			if (byte_0 != null && byte_0.Length > 0)
			{
				if (byte_0[4] == 0)
				{
					byte[] array = new byte[2 * byte_0.Length - 10];
					for (int i = 0; i < byte_0.Length - 5; i++)
					{
						array[2 * i] = byte_0[i + 5];
					}
					string_0 = Encoding.Unicode.GetString(array);
				}
				else
				{
					string_0 = Encoding.Unicode.GetString(byte_0, 5, byte_0.Length - 5);
				}
				return string_0;
			}
			return "";
		}
	}

	internal int Index
	{
		get
		{
			if (int_0 < 0)
			{
				if (byte_0 != null && byte_0.Length > 0)
				{
					int_0 = BitConverter.ToUInt16(byte_0, 0);
					return int_0;
				}
				return 0;
			}
			return int_0;
		}
	}

	internal Class639()
	{
		method_2(1054);
	}

	internal void method_4(string string_1, ushort ushort_0)
	{
		string_0 = method_5(string_1);
		int_0 = ushort_0;
		method_0((short)(string_0.Length * 2 + 5));
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(ushort_0), byte_0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)string_0.Length), 0, byte_0, 2, 2);
		byte_0[4] = 1;
		Array.Copy(Encoding.Unicode.GetBytes(string_0), 0, byte_0, 5, base.Length - 5);
	}

	private string method_5(string string_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < string_1.Length; i++)
		{
			switch (string_1[i])
			{
			default:
				stringBuilder.Append(string_1[i]);
				break;
			case '\\':
				stringBuilder.Append(string_1[i]);
				i++;
				stringBuilder.Append(string_1[i]);
				break;
			case '/':
				if (i == 0)
				{
					stringBuilder.Append('\\');
				}
				else if (i == string_1.Length - 1)
				{
					stringBuilder.Append('\\');
				}
				else if (i + 1 < string_1.Length)
				{
					char c = string_1[i + 1];
					if (c != 'P' && c != 'p')
					{
						switch (string_1[i - 1])
						{
						default:
							stringBuilder.Append('\\');
							break;
						case '?':
						case 'D':
						case 'M':
						case 'Y':
						case '\\':
						case 'd':
						case 'm':
						case 'y':
							break;
						}
					}
				}
				stringBuilder.Append(string_1[i]);
				break;
			case '"':
				stringBuilder.Append(string_1[i]);
				for (i++; i < string_1.Length; i++)
				{
					stringBuilder.Append(string_1[i]);
					if (string_1[i] == '"')
					{
						break;
					}
				}
				break;
			}
		}
		return stringBuilder.ToString();
	}

	internal void Copy(Class639 class639_0)
	{
		Copy((Class538)class639_0);
		string_0 = class639_0.string_0;
		int_0 = class639_0.int_0;
	}
}
