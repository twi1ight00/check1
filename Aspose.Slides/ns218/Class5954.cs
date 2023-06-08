using System.Collections;
using System.Text;

namespace ns218;

internal static class Class5954
{
	public const int int_0 = 2;

	public const int int_1 = 437;

	public const int int_2 = 850;

	public const int int_3 = 1200;

	public const int int_4 = 1201;

	public const int int_5 = 1252;

	public const int int_6 = 10000;

	public const int int_7 = 12000;

	public const int int_8 = 12001;

	public const int int_9 = 65000;

	public const int int_10 = 65001;

	private static readonly Hashtable hashtable_0;

	private static readonly byte[] byte_0;

	private static readonly byte[] byte_1;

	private static readonly byte[] byte_2;

	private static readonly byte[] byte_3;

	private static readonly byte[] byte_4;

	private static readonly byte[] byte_5;

	private static readonly byte[][] byte_6;

	private static readonly Encoding[] encoding_0;

	public static byte[] Utf7Bom => byte_0;

	public static int smethod_0(int charSet, int defaultCodePage)
	{
		object obj = hashtable_0[charSet];
		if (obj == null)
		{
			return defaultCodePage;
		}
		return (int)obj;
	}

	public static Encoding smethod_1(byte[] data, int bytesRead, out int bomSize)
	{
		Encoding encoding = null;
		bomSize = 0;
		for (int i = 0; i < byte_6.Length; i++)
		{
			if (encoding != null)
			{
				break;
			}
			byte[] array = byte_6[i];
			int num = array.Length;
			if (num > bytesRead)
			{
				continue;
			}
			bool flag = true;
			for (int j = 0; j < num; j++)
			{
				if (array[j] != data[j])
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				encoding = encoding_0[i];
				bomSize = num;
			}
		}
		return encoding;
	}

	static Class5954()
	{
		byte_0 = new byte[5] { 43, 47, 118, 56, 45 };
		byte_1 = new byte[3] { 239, 187, 191 };
		byte_2 = new byte[2] { 255, 254 };
		byte_3 = new byte[2] { 254, 255 };
		byte_4 = new byte[4] { 255, 254, 0, 0 };
		byte_5 = new byte[4] { 0, 0, 254, 255 };
		byte_6 = new byte[6][] { byte_1, byte_0, byte_4, byte_5, byte_2, byte_3 };
		encoding_0 = new Encoding[6]
		{
			Encoding.UTF8,
			Encoding.UTF7,
			Encoding.UTF32,
			Encoding.GetEncoding(12001),
			Encoding.Unicode,
			Encoding.BigEndianUnicode
		};
		hashtable_0 = new Hashtable();
		hashtable_0.Add(0, 1252);
		hashtable_0.Add(1, 1252);
		hashtable_0.Add(77, 10000);
		hashtable_0.Add(78, 10001);
		hashtable_0.Add(79, 10003);
		hashtable_0.Add(80, 10008);
		hashtable_0.Add(81, 10002);
		hashtable_0.Add(83, 10005);
		hashtable_0.Add(84, 10004);
		hashtable_0.Add(85, 10006);
		hashtable_0.Add(86, 10081);
		hashtable_0.Add(87, 10021);
		hashtable_0.Add(88, 10029);
		hashtable_0.Add(89, 10007);
		hashtable_0.Add(128, 932);
		hashtable_0.Add(129, 949);
		hashtable_0.Add(130, 1361);
		hashtable_0.Add(134, 936);
		hashtable_0.Add(136, 950);
		hashtable_0.Add(161, 1253);
		hashtable_0.Add(162, 1254);
		hashtable_0.Add(163, 1258);
		hashtable_0.Add(177, 1255);
		hashtable_0.Add(178, 1256);
		hashtable_0.Add(186, 1257);
		hashtable_0.Add(204, 1251);
		hashtable_0.Add(222, 874);
		hashtable_0.Add(238, 1250);
		hashtable_0.Add(254, 437);
		hashtable_0.Add(255, 850);
	}
}
