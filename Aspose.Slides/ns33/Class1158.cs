using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns33;

internal class Class1158
{
	public static readonly int int_0 = 0;

	public static readonly int int_1 = 1;

	public static readonly int int_2 = 2;

	public static readonly int int_3 = 3;

	public static readonly int int_4 = -1;

	public static readonly int int_5 = 0;

	public static readonly int int_6 = 1;

	public static readonly int int_7 = 2;

	public static readonly int int_8 = 3;

	private static readonly string[] string_0 = new string[4] { "JPEG", "GIF", "PNG", "BMP" };

	private static readonly string[] string_1 = new string[4] { "image/jpeg", "image/gif", "image/png", "image/bmp" };

	private int int_9;

	private int int_10;

	private int int_11;

	private int int_12 = int_4;

	private bool bool_0;

	private int int_13;

	private bool bool_1 = true;

	private List<string> list_0;

	private bool bool_2;

	private int int_14;

	private int int_15;

	private int int_16;

	private Stream stream_0;

	public Stream Stream
	{
		get
		{
			return stream_0;
		}
		set
		{
			stream_0 = value;
		}
	}

	public int Width => int_9;

	public int Height => int_10;

	public int BitsPerPixel => int_11;

	public bool Progressive => bool_0;

	public int Format => int_13;

	public int ColorType => int_12;

	public bool CollectComments
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public List<string> Comments => list_0;

	public bool DetermineNumberOfImages
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public int NumberOfImages => int_14;

	public int PhysicalHeightDpi => int_15;

	public int PhysicalWidthDpi => int_16;

	public string FormatName
	{
		get
		{
			if (int_13 >= 0 && int_13 < string_0.Length)
			{
				return string_0[int_13];
			}
			return "?";
		}
	}

	public string MimeType
	{
		get
		{
			if (int_13 >= 0 && int_13 < string_1.Length)
			{
				if (int_13 == int_0 && bool_0)
				{
					return "image/pjpeg";
				}
				return string_1[int_13];
			}
			return null;
		}
	}

	public Class1158()
	{
	}

	public Class1158(Stream stream)
	{
		stream_0 = stream;
	}

	public bool method_0()
	{
		if (stream_0 == null)
		{
			return false;
		}
		int_13 = -1;
		int_9 = -1;
		int_10 = -1;
		int_11 = -1;
		int_14 = 1;
		int_15 = -1;
		int_16 = -1;
		list_0 = null;
		stream_0.Position = 0L;
		try
		{
			int num = stream_0.ReadByte() & 0xFF;
			int num2 = stream_0.ReadByte() & 0xFF;
			if (num == 71 && num2 == 73)
			{
				return method_2();
			}
			if (num == 137 && num2 == 80)
			{
				return method_4();
			}
			if (num == 255 && num2 == 216)
			{
				return method_3();
			}
			if (num == 66 && num2 == 77)
			{
				return method_1();
			}
			return false;
		}
		catch (IOException ex)
		{
			Class1165.smethod_28(ex);
			return false;
		}
	}

	private bool method_1()
	{
		byte[] array = new byte[44];
		if (stream_0.Read(array, 0, 44) != 44)
		{
			return false;
		}
		int_9 = method_7(array, 16);
		int_10 = method_7(array, 20);
		if (int_9 >= 1 && int_10 >= 1)
		{
			int_11 = method_9(array, 26);
			if (int_11 != 1 && int_11 != 4 && int_11 != 8 && int_11 != 16 && int_11 != 24 && int_11 != 32)
			{
				return false;
			}
			int num = (int)((double)method_7(array, 36) * 0.0254);
			if (num > 0)
			{
				int_16 = num;
			}
			int num2 = (int)((double)method_7(array, 40) * 0.0254);
			if (num2 > 0)
			{
				int_15 = num2;
			}
			int_13 = int_3;
			return true;
		}
		return false;
	}

	private bool method_2()
	{
		byte[] a = new byte[4] { 70, 56, 55, 97 };
		byte[] a2 = new byte[4] { 70, 56, 57, 97 };
		byte[] array = new byte[11];
		if (stream_0.Read(array, 0, 11) != 11)
		{
			return false;
		}
		if (!method_5(array, 0, a2, 0, 4) && !method_5(array, 0, a, 0, 4))
		{
			return false;
		}
		int_13 = int_1;
		int_9 = method_9(array, 4);
		int_10 = method_9(array, 6);
		int num = array[8] & 0xFF;
		int_11 = ((num >> 4) & 7) + 1;
		bool_0 = (num & 2) != 0;
		if (!bool_2)
		{
			return true;
		}
		if (((uint)num & 0x80u) != 0)
		{
			int num2 = (1 << (num & 7) + 1) * 3;
			stream_0.Position += num2;
		}
		int_14 = 0;
		int num3;
		do
		{
			num3 = stream_0.ReadByte();
			switch (num3)
			{
			case 33:
			{
				int num6 = stream_0.ReadByte();
				if (bool_1 && num6 == 254)
				{
					StringBuilder stringBuilder = new StringBuilder();
					int num7;
					do
					{
						num7 = stream_0.ReadByte();
						if (num7 != -1)
						{
							if (num7 <= 0)
							{
								continue;
							}
							for (int i = 0; i < num7; i++)
							{
								int num8 = stream_0.ReadByte();
								if (num8 != -1)
								{
									stringBuilder.Append((char)num8);
									continue;
								}
								return false;
							}
							continue;
						}
						return false;
					}
					while (num7 > 0);
					break;
				}
				int num9;
				do
				{
					num9 = stream_0.ReadByte();
					if (num9 <= 0)
					{
						if (num9 == -1)
						{
							return false;
						}
					}
					else
					{
						stream_0.Position += num9;
					}
				}
				while (num9 > 0);
				break;
			}
			case 59:
				break;
			case 44:
				if (stream_0.Read(array, 0, 9) == 9)
				{
					num = array[8] & 0xFF;
					int num4 = (num & 7) + 1;
					if (num4 > int_11)
					{
						int_11 = num4;
					}
					if (((uint)num & 0x80u) != 0)
					{
						stream_0.Position += (1 << num4) * 3;
					}
					stream_0.Position++;
					int num5;
					do
					{
						num5 = stream_0.ReadByte();
						if (num5 <= 0)
						{
							if (num5 == -1)
							{
								return false;
							}
						}
						else
						{
							stream_0.Position += num5;
						}
					}
					while (num5 > 0);
					int_14++;
					break;
				}
				return false;
			default:
				return false;
			}
		}
		while (num3 != 59);
		return true;
	}

	private bool method_3()
	{
		byte[] array = new byte[12];
		int num;
		while (true)
		{
			if (stream_0.Read(array, 0, 4) == 4)
			{
				num = method_8(array, 0);
				int num2 = method_8(array, 2);
				if ((num & 0xFF00) == 65280)
				{
					if (num == 65504)
					{
						if (num2 < 14 && num2 != 8)
						{
							return false;
						}
						if (stream_0.Read(array, 0, 12) != 12)
						{
							return false;
						}
						byte[] a = new byte[5] { 74, 70, 73, 70, 0 };
						if (method_5(a, 0, array, 0, 5))
						{
							if (array[7] == 1)
							{
								int_16 = method_8(array, 8);
								int_15 = method_8(array, 10);
							}
							else if (array[7] == 2)
							{
								int num3 = method_8(array, 8);
								int num4 = method_8(array, 10);
								int_16 = (int)((float)num3 * 2.54f);
								int_15 = (int)((float)num4 * 2.54f);
							}
						}
						stream_0.Position += num2 - 14;
					}
					else if (bool_1 && num2 > 2 && num == 65534)
					{
						num2 -= 2;
						byte[] array2 = new byte[num2];
						if (stream_0.Read(array2, 0, num2) != num2)
						{
							return false;
						}
						Encoding encoding = Encoding.GetEncoding("iso-8859-1");
						string @string = encoding.GetString(array2);
						@string = @string.Trim();
						AddComment(@string);
					}
					else
					{
						if (num >= 65472 && num <= 65487 && num != 65476 && num != 65480)
						{
							break;
						}
						stream_0.Position += num2 - 2;
					}
					continue;
				}
				return false;
			}
			return false;
		}
		if (stream_0.Read(array, 0, 6) != 6)
		{
			return false;
		}
		int_13 = int_0;
		int_11 = (array[0] & 0xFF) * (array[5] & 0xFF);
		bool_0 = num == 65474 || num == 65478 || num == 65482 || num == 65486;
		int_9 = method_8(array, 3);
		int_10 = method_8(array, 1);
		return true;
	}

	private bool method_4()
	{
		byte[] a = new byte[6] { 78, 71, 13, 10, 26, 10 };
		byte[] array = new byte[27];
		if (stream_0.Read(array, 0, 27) != 27)
		{
			return false;
		}
		if (!method_5(array, 0, a, 0, 6))
		{
			return false;
		}
		int_13 = int_2;
		int_9 = method_6(array, 14);
		int_10 = method_6(array, 18);
		int_11 = array[22] & 0xFF;
		int num = array[23] & 0xFF;
		if (num == 2 || num == 6)
		{
			int_11 *= 3;
		}
		bool_0 = (array[26] & 0xFF) != 0;
		return true;
	}

	private void AddComment(string s)
	{
		if (list_0 == null)
		{
			list_0 = new List<string>();
		}
		list_0.Add(s);
	}

	private bool method_5(byte[] a1, int offs1, byte[] a2, int offs2, int num)
	{
		do
		{
			if (num-- <= 0)
			{
				return true;
			}
		}
		while (a1[offs1++] == a2[offs2++]);
		return false;
	}

	private int method_6(byte[] a, int offs)
	{
		return ((a[offs] & 0xFF) << 24) | ((a[offs + 1] & 0xFF) << 16) | ((a[offs + 2] & 0xFF) << 8) | (a[offs + 3] & 0xFF);
	}

	private int method_7(byte[] a, int offs)
	{
		return ((a[offs + 3] & 0xFF) << 24) | ((a[offs + 2] & 0xFF) << 16) | ((a[offs + 1] & 0xFF) << 8) | (a[offs] & 0xFF);
	}

	private int method_8(byte[] a, int offs)
	{
		return ((a[offs] & 0xFF) << 8) | (a[offs + 1] & 0xFF);
	}

	private int method_9(byte[] a, int offs)
	{
		return (a[offs] & 0xFF) | ((a[offs + 1] & 0xFF) << 8);
	}
}
