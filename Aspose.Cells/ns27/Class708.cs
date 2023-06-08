using System;
using System.Collections.Generic;
using System.Text;
using ns1;

namespace ns27;

internal class Class708 : Class538
{
	internal Class708()
	{
		method_2(659);
		method_0(4);
	}

	internal void SetStyle(ushort ushort_0, byte byte_1)
	{
		byte_0 = new byte[4] { 16, 128, 5, 255 };
		ushort_0 = (ushort)(ushort_0 | 0x8000u);
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 0, 2);
		byte_0[2] = byte_1;
	}

	internal void SetStyle(ushort ushort_0, string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_228 == null)
			{
				Class1742.dictionary_228 = new Dictionary<string, int>(8)
				{
					{ "Normal", 0 },
					{ "Comma", 1 },
					{ "Currency", 2 },
					{ "Percent", 3 },
					{ "Comma [0]", 4 },
					{ "Currency [0]", 5 },
					{ "Hyperlink", 6 },
					{ "Followed Hyperlink", 7 }
				};
			}
			if (Class1742.dictionary_228.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					break;
				case 1:
					goto IL_00ea;
				case 2:
					goto IL_0110;
				case 3:
					goto IL_0136;
				case 4:
					goto IL_015c;
				case 5:
					goto IL_0182;
				case 6:
					goto IL_01a8;
				case 7:
					goto IL_01ce;
				default:
					goto IL_01f1;
				}
				byte_0 = new byte[4] { 0, 128, 0, 255 };
				ushort_0 = (ushort)(ushort_0 | 0x8000u);
				goto IL_024e;
			}
		}
		goto IL_01f1;
		IL_0110:
		byte_0 = new byte[4] { 17, 128, 4, 255 };
		ushort_0 = (ushort)(ushort_0 | 0x8000u);
		goto IL_024e;
		IL_024e:
		Array.Copy(BitConverter.GetBytes(ushort_0), byte_0, 2);
		return;
		IL_00ea:
		byte_0 = new byte[4] { 19, 128, 3, 255 };
		ushort_0 = (ushort)(ushort_0 | 0x8000u);
		goto IL_024e;
		IL_01f1:
		byte[] bytes = Encoding.Unicode.GetBytes(string_0);
		method_0((short)(bytes.Length + 5));
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes((ushort)string_0.Length), 0, byte_0, 2, 2);
		byte_0[4] = 1;
		Array.Copy(bytes, 0, byte_0, 5, bytes.Length);
		goto IL_024e;
		IL_01ce:
		byte_0 = new byte[4] { 22, 128, 9, 255 };
		ushort_0 = (ushort)(ushort_0 | 0x8000u);
		goto IL_024e;
		IL_01a8:
		byte_0 = new byte[4] { 21, 128, 8, 255 };
		ushort_0 = (ushort)(ushort_0 | 0x8000u);
		goto IL_024e;
		IL_0182:
		byte_0 = new byte[4] { 18, 128, 7, 255 };
		ushort_0 = (ushort)(ushort_0 | 0x8000u);
		goto IL_024e;
		IL_015c:
		byte_0 = new byte[4] { 20, 128, 6, 255 };
		ushort_0 = (ushort)(ushort_0 | 0x8000u);
		goto IL_024e;
		IL_0136:
		byte_0 = new byte[4] { 16, 128, 5, 255 };
		ushort_0 = (ushort)(ushort_0 | 0x8000u);
		goto IL_024e;
	}
}
