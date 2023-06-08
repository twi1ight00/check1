using System;
using System.IO;

namespace ns46;

internal class Class1122 : TextReader
{
	private const int int_0 = 1024;

	private TextReader textReader_0;

	private Class1121[] class1121_0;

	private int int_1;

	private char[] char_0;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private char[] char_1 = new char[1024];

	internal int Position => int_1;

	public Class1122(Stream stream)
	{
		Initialize(new StreamReader(stream, detectEncodingFromByteOrderMarks: true), new Class1121[1]
		{
			new Class1121(0, int.MaxValue, null)
		});
	}

	public Class1122(Stream stream, Class1124 builder)
	{
		Initialize(new StreamReader(stream, detectEncodingFromByteOrderMarks: true), builder.method_4());
	}

	private void Initialize(TextReader reader, Class1121[] segments)
	{
		textReader_0 = reader;
		class1121_0 = segments;
		int_2 = int_3;
		int_6 = 0;
		Class1121 @class = class1121_0[0];
		if (@class.char_0 != null || @class.int_0 <= int_6)
		{
			return;
		}
		int num = @class.int_0 - int_6;
		while (num > 0)
		{
			int num2 = textReader_0.Read(char_1, 0, Math.Min(1024, num));
			if (num2 == 0)
			{
				int_4 = class1121_0.Length;
			}
			num -= num2;
		}
		int_6 = (int_5 = @class.int_0);
	}

	public override void Close()
	{
		textReader_0.Close();
		base.Close();
	}

	public override int Peek()
	{
		if (int_2 >= int_3 && !method_0())
		{
			return -1;
		}
		return char_0[int_2];
	}

	public override int Read()
	{
		if (int_2 >= int_3 && !method_0())
		{
			return -1;
		}
		int_1++;
		return char_0[int_2++];
	}

	public override int Read(char[] buffer, int index, int count)
	{
		if (int_2 >= int_3 && !method_0())
		{
			return 0;
		}
		int num = 0;
		int num2 = Math.Min(count, int_3 - int_2);
		int num3 = int_2 + num2;
		while (int_2 < num3)
		{
			buffer[index] = char_0[int_2];
			index++;
			int_2++;
		}
		count -= num2;
		int_1 += num2;
		num += num2;
		while (true)
		{
			if (count > 0)
			{
				if (method_1())
				{
					Class1121 @class = class1121_0[int_4];
					num2 = Math.Min(@class.int_1 - int_5, count);
					if (@class.char_0 == null)
					{
						int num4 = textReader_0.Read(buffer, index, num2);
						int_6 += num4;
						int_1 += num4;
						int_5 += num4;
						num += num4;
						count -= num4;
						index += num4;
						if (num4 < num2)
						{
							break;
						}
					}
					else
					{
						for (int i = 0; i < num2; i++)
						{
							buffer[index + i] = @class.char_0[int_5 + i];
						}
						int_1 += num2;
						int_5 += num2;
						num += num2;
						count -= num2;
						index += num2;
					}
					continue;
				}
				return num;
			}
			return num;
		}
		return num;
	}

	private bool method_0()
	{
		if (int_2 == int_3)
		{
			if (!method_1())
			{
				return false;
			}
			Class1121 @class = class1121_0[int_4];
			if (@class.char_0 != null)
			{
				char_0 = @class.char_0;
				int_2 = @class.int_0 + int_5;
				int_3 = @class.int_1;
				int_5 = @class.int_1;
			}
			else
			{
				char_0 = char_1;
				int_2 = 0;
				int num = textReader_0.Read(char_1, 0, Math.Min(1024, @class.int_1 - int_5));
				if (num == 0)
				{
					int_4 = class1121_0.Length;
					int_3 = int_2;
					return false;
				}
				int_3 = int_2 + num;
				int_5 += num;
				int_6 += num;
			}
		}
		return true;
	}

	private bool method_1()
	{
		if (int_4 >= class1121_0.Length)
		{
			return false;
		}
		Class1121 @class = class1121_0[int_4];
		if (int_5 < @class.int_1)
		{
			return true;
		}
		int_4++;
		if (int_4 < class1121_0.Length)
		{
			@class = class1121_0[int_4];
			int_5 = @class.int_0;
			if (@class.char_0 == null)
			{
				if (@class.int_0 > int_6)
				{
					int num = @class.int_0 - int_6;
					while (num > 0)
					{
						int num2 = textReader_0.Read(char_1, 0, Math.Min(1024, num));
						if (num2 != 0)
						{
							num -= num2;
							continue;
						}
						int_4 = class1121_0.Length;
						return false;
					}
					int_6 = @class.int_0;
					int_3 = 0;
					int_2 = 0;
				}
				else if (@class.int_0 < int_6)
				{
					throw new Exception("Inner error: wrong segment.");
				}
			}
			int_5 = @class.int_0;
			int_3 = 0;
			int_2 = 0;
			return true;
		}
		return false;
	}
}
