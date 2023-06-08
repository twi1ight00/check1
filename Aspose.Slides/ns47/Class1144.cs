using System.Collections.Generic;
using System.IO;
using System.Text;
using ns4;

namespace ns47;

internal class Class1144 : Interface37
{
	private readonly List<Class1125> list_0 = new List<Class1125>();

	public List<Class1125> Links => list_0;

	public byte[] Write()
	{
		int num = 0;
		byte[] array;
		if (list_0.Count > 0)
		{
			num += 12;
			for (int i = 0; i < list_0.Count; i++)
			{
				num += 32;
				num += 16;
				int num2 = list_0[i].Url.Length + 1;
				num += 4;
				num += num2 * 2;
				if (((uint)num2 & (true ? 1u : 0u)) != 0)
				{
					num += 2;
				}
			}
			int num3 = 0;
			array = new byte[num];
			Class1162.smethod_13(array, 0, 65);
			Class1162.smethod_13(array, 2, 0);
			num3 = 4;
			Class1162.smethod_16(array, 4, num - 8);
			num3 = 8;
			Class1162.smethod_16(array, 8, list_0.Count * 6);
			num3 = 12;
			for (int j = 0; j < list_0.Count; j++)
			{
				Class1162.smethod_16(array, num3, 3);
				num3 += 4;
				Class1162.smethod_16(array, num3, 7);
				num3 += 4;
				Class1162.smethod_16(array, num3, 3);
				num3 += 4;
				Class1162.smethod_16(array, num3, 6);
				num3 += 4;
				Class1162.smethod_16(array, num3, 3);
				num3 += 4;
				Class1162.smethod_16(array, num3, 0);
				num3 += 4;
				Class1162.smethod_16(array, num3, 3);
				num3 += 4;
				Class1162.smethod_16(array, num3, 7);
				num3 += 4;
				if (list_0[j].Type == Enum172.const_0)
				{
					Class1162.smethod_16(array, num3, 31);
					num3 += 4;
					Class1162.smethod_16(array, num3, 1);
					num3 += 4;
					Class1162.smethod_16(array, num3, 0);
					num3 += 4;
					Class1162.smethod_16(array, num3, 31);
					num3 += 4;
					int num4 = list_0[j].Url.Length + 1;
					Class1162.smethod_16(array, num3, num4);
					num3 += 4;
					UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
					unicodeEncoding.GetBytes(list_0[j].Url, 0, num4 - 1, array, num3);
					num3 += num4 * 2;
					if (((uint)num4 & (true ? 1u : 0u)) != 0)
					{
						num3 += 2;
					}
					continue;
				}
				Class1162.smethod_16(array, num3, 31);
				num3 += 4;
				string text = list_0[j].Url;
				string text2 = "";
				if (text.IndexOf('#') >= 0)
				{
					int num5 = text.IndexOf('#');
					text2 = text.Substring(num5 + 1);
					text = text.Substring(0, num5);
				}
				int num6 = text.Length + 1;
				Class1162.smethod_16(array, num3, num6);
				num3 += 4;
				UnicodeEncoding unicodeEncoding2 = new UnicodeEncoding();
				unicodeEncoding2.GetBytes(text, 0, num6 - 1, array, num3);
				num3 += num6 * 2;
				if (((uint)num6 & (true ? 1u : 0u)) != 0)
				{
					num3 += 2;
				}
				Class1162.smethod_16(array, num3, 31);
				num3 += 4;
				if (text2.Length > 0)
				{
					int num7 = text2.Length + 1;
					Class1162.smethod_16(array, num3, num7);
					num3 += 4;
					unicodeEncoding2.GetBytes(text2, 0, num7 - 1, array, num3);
					num3 += num7 * 2;
					if (((uint)num7 & (true ? 1u : 0u)) != 0)
					{
						num3 += 2;
					}
				}
				else
				{
					Class1162.smethod_16(array, num3, 1);
					num3 += 4;
					Class1162.smethod_16(array, num3, 0);
					num3 += 4;
				}
			}
		}
		else
		{
			MemoryStream memoryStream = new MemoryStream();
			Class1162.smethod_25(memoryStream, 65);
			Class1162.smethod_25(memoryStream, 4);
			Class1162.smethod_25(memoryStream, 0);
			array = memoryStream.ToArray();
		}
		return array;
	}

	public Class1144()
	{
	}

	internal Class1144(Class1147 srcprop)
	{
		byte[] array = srcprop.Write();
		int num = 4;
		num = 8;
		int num2 = Class1162.smethod_6(array, 8);
		num = 12;
		while (num2 > 0)
		{
			num += 36;
			int num3 = Class1162.smethod_6(array, num);
			num += 4;
			Enum172 type;
			string text;
			if (num3 == 1)
			{
				type = Enum172.const_0;
				num += 8;
				num3 = Class1162.smethod_6(array, num);
				num += 4;
				UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
				text = unicodeEncoding.GetString(array, num, (num3 - 1) * 2);
				num += num3 * 2;
				if (((uint)num3 & (true ? 1u : 0u)) != 0)
				{
					num += 2;
				}
			}
			else
			{
				type = Enum172.const_1;
				UnicodeEncoding unicodeEncoding2 = new UnicodeEncoding();
				text = unicodeEncoding2.GetString(array, num, (num3 - 1) * 2);
				num += num3 * 2;
				if (((uint)num3 & (true ? 1u : 0u)) != 0)
				{
					num += 2;
				}
				num += 4;
				int num4 = Class1162.smethod_6(array, num);
				num += 4;
				if (num4 > 1)
				{
					string @string = unicodeEncoding2.GetString(array, num, (num4 - 1) * 2);
					num += num4 * 2;
					if (((uint)num4 & (true ? 1u : 0u)) != 0)
					{
						num += 2;
					}
					text = text + "#" + @string;
				}
				else
				{
					num += 4;
				}
			}
			list_0.Add(new Class1125(type, text));
			num2 -= 6;
		}
	}
}
