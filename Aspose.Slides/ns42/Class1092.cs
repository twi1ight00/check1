using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;

namespace ns42;

internal class Class1092 : TextReader
{
	internal class Class1094
	{
		private class Class1095
		{
			internal int int_0;

			internal Class1093 class1093_0;

			public Class1095(int position, Class1093 segment)
			{
				int_0 = position;
				class1093_0 = segment;
			}
		}

		private List<Class1095> list_0;

		public bool IsIdentity
		{
			get
			{
				if (list_0.Count != 1)
				{
					return false;
				}
				Class1093 class1093_ = list_0[0].class1093_0;
				if (class1093_.int_0 == 0 && class1093_.int_1 == int.MaxValue)
				{
					return class1093_.char_0 == null;
				}
				return false;
			}
		}

		public Class1094()
		{
			list_0 = new List<Class1095>(16);
			list_0.Add(new Class1095(0, new Class1093(0, int.MaxValue, null)));
		}

		private int method_0(int position)
		{
			int num = 0;
			int num2 = list_0.Count;
			while (num2 - num > 1)
			{
				int num3 = num + num2 >> 1;
				Class1095 @class = list_0[num3];
				if (position < @class.int_0)
				{
					num2 = num3;
				}
				else
				{
					num = num3;
				}
			}
			return num;
		}

		public void method_1(int startPosition, int length)
		{
			int num = method_0(startPosition);
			int num2 = startPosition + length;
			int num3 = method_0(startPosition + length);
			Class1095 @class = list_0[num];
			if (startPosition < @class.int_0)
			{
				length -= @class.int_0 - startPosition;
				startPosition = @class.int_0;
				if (length < 0)
				{
					return;
				}
			}
			if (startPosition > @class.int_0)
			{
				if (@class.class1093_0.int_1 > startPosition)
				{
					@class.class1093_0.int_1 = startPosition;
				}
				num++;
			}
			if (num3 > num)
			{
				list_0.RemoveRange(num, num3 - num);
			}
			if (num == list_0.Count)
			{
				list_0.Add(new Class1095(num2, new Class1093(num2, int.MaxValue, null)));
				return;
			}
			Class1095 class2 = list_0[num];
			int num4 = num2 - class2.int_0;
			if (num4 > 0)
			{
				class2.int_0 = num2;
				class2.class1093_0.int_0 += num4;
			}
		}

		public void method_2(char[] data, int position)
		{
			method_3(data, 0, data.Length, position);
		}

		public void method_3(char[] data, int dataStartIndex, int dataLength, int position)
		{
			int num = method_0(position);
			Class1095 @class = list_0[num];
			if (@class.int_0 < position)
			{
				if (position < @class.int_0 + @class.class1093_0.Length)
				{
					Class1093 class1093_ = @class.class1093_0;
					Class1095 item = new Class1095(position, new Class1093(class1093_.int_0 + position - @class.int_0, class1093_.int_1, class1093_.char_0));
					class1093_.int_1 = class1093_.int_0 + position - @class.int_0;
					list_0.Insert(num + 1, item);
				}
				num++;
			}
			list_0.Insert(num, new Class1095(position, new Class1093(dataStartIndex, dataLength, data)));
		}

		internal Class1093[] method_4()
		{
			Class1093[] array = new Class1093[list_0.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = list_0[i].class1093_0;
			}
			return array;
		}
	}

	internal class Class1093
	{
		public int int_0;

		public int int_1;

		public readonly char[] char_0;

		public int Length => int_1 - int_0;

		internal Class1093(int startIndex, int endIndex, char[] data)
		{
			int_0 = startIndex;
			int_1 = endIndex;
			char_0 = data;
		}
	}

	private const int int_0 = 1024;

	private TextReader textReader_0;

	private Class1093[] class1093_0;

	private int int_1;

	private char[] char_0;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private char[] char_1 = new char[1024];

	internal int Position => int_1;

	public Class1092(Stream stream)
	{
		Initialize(new StreamReader(stream, detectEncodingFromByteOrderMarks: true), new Class1093[1]
		{
			new Class1093(0, int.MaxValue, null)
		});
	}

	public Class1092(Stream stream, Class1094 builder)
	{
		Initialize(new StreamReader(stream, detectEncodingFromByteOrderMarks: true), builder.method_4());
	}

	private void Initialize(TextReader reader, Class1093[] segments)
	{
		textReader_0 = reader;
		class1093_0 = segments;
		int_2 = int_3;
		int_6 = 0;
		Class1093 @class = class1093_0[0];
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
				int_4 = class1093_0.Length;
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
					Class1093 @class = class1093_0[int_4];
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
			Class1093 @class = class1093_0[int_4];
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
					int_4 = class1093_0.Length;
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
		if (int_4 >= class1093_0.Length)
		{
			return false;
		}
		Class1093 @class = class1093_0[int_4];
		if (int_5 < @class.int_1)
		{
			return true;
		}
		int_4++;
		if (int_4 < class1093_0.Length)
		{
			@class = class1093_0[int_4];
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
						int_4 = class1093_0.Length;
						return false;
					}
					int_6 = @class.int_0;
					int_3 = 0;
					int_2 = 0;
				}
				else if (@class.int_0 < int_6)
				{
					throw new PptxException("Inner error: wrong segment.");
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
