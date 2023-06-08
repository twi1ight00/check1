using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace ns8;

internal class Class430
{
	public static Stream smethod_0(Stream stream_0, Encoding encoding_0)
	{
		Stream stream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(stream, encoding_0);
		StreamReader streamReader = new StreamReader(stream_0, encoding_0);
		int num = 1;
		int num2 = streamReader.Read();
		char c = (char)num2;
		while (streamReader.Peek() != -1)
		{
			int num3 = streamReader.Read();
			char c2 = (char)num3;
			if ((c < '!' || c > '~' || c == '=') && c != '\r' && c != '\n' && c != ' ')
			{
				string text = Convert.ToString(c, 16);
				if (c < '\u0010')
				{
					streamWriter.Write("=0" + text);
					num += 2;
				}
				else if (c > '\u007f')
				{
					streamWriter.Write(c);
					num++;
				}
				else
				{
					streamWriter.Write("=" + text);
					num += text.Length;
				}
			}
			else if (num3 > -1)
			{
				c2 = (char)num3;
				if (c == '\t' && (c2 == '\n' || c2 == '\r'))
				{
					streamWriter.Write("=09");
					num += 2;
				}
				else if (c == ' ' && (c2 == '\n' || c2 == '\r'))
				{
					streamWriter.Write("=09");
					num += 2;
				}
				else
				{
					streamWriter.Write(c);
				}
			}
			else
			{
				streamWriter.Write(c);
			}
			if (c != '\r' && c != '\n')
			{
				num++;
			}
			if (c == '\r' && c2 == '\n')
			{
				num = 1;
			}
			if (num >= 75)
			{
				streamWriter.Write("=\r\n");
				num = 1;
			}
			num2 = num3;
			c = c2;
		}
		streamWriter.Flush();
		stream.Position = 0L;
		return stream;
	}

	public static Stream smethod_1(Stream stream_0, Encoding encoding_0)
	{
		Stream stream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(stream, encoding_0);
		for (StreamReader streamReader = new StreamReader(stream_0, encoding_0); streamReader.Peek() != -1; streamWriter.Flush())
		{
			char c = (char)streamReader.Read();
			switch (c)
			{
			case '=':
			{
				char c2 = (char)streamReader.Read();
				char c3 = (char)streamReader.Read();
				if (c2 != '\r' || c3 != '\n')
				{
					int num3 = int.Parse(c2.ToString() + c3, NumberStyles.HexNumber);
					streamWriter.Write((char)num3);
				}
				continue;
			}
			case '\r':
			{
				if ((ushort)streamReader.Read() != 10)
				{
					break;
				}
				int num = streamReader.Read();
				switch (num)
				{
				case 32:
				{
					int num2 = streamReader.Read();
					if (num2 != -1 && num2 == 32)
					{
						streamWriter.Write(' ');
						break;
					}
					streamWriter.Write('\r');
					streamWriter.Write('\n');
					streamWriter.Write((char)num2);
					break;
				}
				default:
					streamWriter.Write('\r');
					streamWriter.Write('\n');
					streamWriter.Write((char)num);
					break;
				case -1:
					streamWriter.Write('\r');
					streamWriter.Write('\n');
					break;
				}
				continue;
			}
			}
			streamWriter.Write(c);
		}
		stream.Position = 0L;
		return stream;
	}
}
