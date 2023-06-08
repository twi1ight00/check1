using System;
using System.IO;
using System.Text;

namespace ns46;

internal sealed class Class1118
{
	public static Stream smethod_0(Stream stream)
	{
		StreamReader streamReader = new StreamReader(stream);
		Encoding currentEncoding = streamReader.CurrentEncoding;
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(memoryStream, currentEncoding);
		int num;
		while ((num = streamReader.Read()) >= 0)
		{
			streamWriter.Write((char)num);
			if (num != 60)
			{
				continue;
			}
			num = streamReader.Read();
			streamWriter.Write((char)num);
			if (num != 33)
			{
				continue;
			}
			num = streamReader.Read();
			if (num < 0)
			{
				break;
			}
			switch (num)
			{
			case 91:
			{
				int num3 = streamReader.Read();
				if (num3 >= 0)
				{
					if (num3 == 67)
					{
						streamWriter.Write((char)num);
						streamWriter.Write((char)num3);
						bool flag = true;
						while ((num = streamReader.Read()) >= 0)
						{
							streamWriter.Write((char)num);
							if (num == 93)
							{
								if (flag)
								{
									break;
								}
								flag = true;
							}
							else
							{
								flag = false;
							}
						}
						continue;
					}
					StringBuilder stringBuilder2 = new StringBuilder();
					stringBuilder2.Append((char)num);
					stringBuilder2.Append((char)num3);
					char c2 = ' ';
					while (c2 != ']' && (num = streamReader.Read()) >= 0)
					{
						stringBuilder2.Append((char)num);
						c2 = (char)num;
					}
					while ((num = streamReader.Peek()) >= 0 && (num <= 32 || num == 45))
					{
						streamReader.Read();
						stringBuilder2.Append((char)num);
					}
					streamWriter.Write("-- ");
					streamWriter.Write(Convert.ToBase64String(Encoding.UTF8.GetBytes(stringBuilder2.ToString())));
					streamWriter.Write(" --");
					continue;
				}
				streamWriter.Write((char)num);
				break;
			}
			case 45:
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append((char)num);
				if ((num = streamReader.Read()) < 0)
				{
					break;
				}
				stringBuilder.Append((char)num);
				while ((num = streamReader.Read()) >= 0)
				{
					stringBuilder.Append((char)num);
					if (num > 32)
					{
						break;
					}
				}
				if (num == 91)
				{
					char c = ' ';
					while (c != ']' && c != '-' && (num = streamReader.Read()) >= 0)
					{
						stringBuilder.Append((char)num);
						c = (char)num;
					}
					while ((num = streamReader.Peek()) >= 0 && (num <= 32 || num == 45))
					{
						streamReader.Read();
						stringBuilder.Append((char)num);
					}
					streamWriter.Write("-- ");
					streamWriter.Write(Convert.ToBase64String(Encoding.UTF8.GetBytes(stringBuilder.ToString())));
					streamWriter.Write(" --");
				}
				else
				{
					int num2 = 0;
					while ((num = streamReader.Read()) >= 0 && (num != 62 || num2 < 2))
					{
						stringBuilder.Append((char)num);
						num2 = ((num == 45) ? (num2 + 1) : 0);
					}
					streamWriter.Write("-- ");
					streamWriter.Write(Convert.ToBase64String(Encoding.UTF8.GetBytes(stringBuilder.ToString())));
					streamWriter.Write(" --");
					if (num >= 0)
					{
						streamWriter.Write((char)num);
					}
				}
				continue;
			}
			default:
				continue;
			}
			break;
		}
		streamWriter.Flush();
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return memoryStream;
	}

	internal static void smethod_1(Stream input, Stream output)
	{
		StreamReader streamReader = new StreamReader(input);
		Encoding currentEncoding = streamReader.CurrentEncoding;
		StreamWriter streamWriter = new StreamWriter(output, currentEncoding);
		int num;
		while ((num = streamReader.Read()) >= 0)
		{
			streamWriter.Write((char)num);
			if (num != 33)
			{
				continue;
			}
			num = streamReader.Read();
			if (num < 0)
			{
				break;
			}
			switch (num)
			{
			case 91:
				break;
			case 45:
			{
				StringBuilder stringBuilder = new StringBuilder();
				streamReader.Read();
				while ((num = streamReader.Read()) >= 0 && num <= 32)
				{
				}
				stringBuilder.Append((char)num);
				while ((num = streamReader.Read()) >= 32 && num != 45)
				{
					stringBuilder.Append((char)num);
				}
				streamWriter.Write(Encoding.UTF8.GetString(Convert.FromBase64String(stringBuilder.ToString())));
				while ((num = streamReader.Peek()) > 0 && num != 62)
				{
					streamReader.Read();
				}
				continue;
			}
			default:
				continue;
			}
			int num2 = streamReader.Read();
			if (num2 >= 0)
			{
				if (num2 != 67)
				{
					continue;
				}
				streamWriter.Write((char)num);
				streamWriter.Write((char)num2);
				bool flag = true;
				while ((num = streamReader.Read()) >= 0)
				{
					streamWriter.Write((char)num);
					if (num == 93)
					{
						if (flag)
						{
							break;
						}
						flag = true;
					}
					else
					{
						flag = false;
					}
				}
				continue;
			}
			streamWriter.Write((char)num);
			break;
		}
		streamWriter.Flush();
	}

	public static Class1124 smethod_2(Stream stream, bool insertSpacePreserve)
	{
		return smethod_3(stream, insertSpacePreserve, fixRepeatingAttributes: true);
	}

	internal static Class1124 smethod_3(Stream stream, bool insertSpacePreserve, bool fixRepeatingAttributes)
	{
		Class1122 @class = new Class1122(stream);
		Class1124 class2 = new Class1124();
		Class1117 class3 = new Class1117();
		Class1114 class4 = new Class1114();
		while (true)
		{
			int num = @class.Read();
			if (num < 0)
			{
				break;
			}
			if (num != 60)
			{
				continue;
			}
			int num2 = @class.Position - 1;
			int num3 = 0;
			StringBuilder stringBuilder = new StringBuilder();
			char c = (char)@class.Read();
			char c2 = ' ';
			int num4 = 0;
			Class1115 class5;
			switch (c)
			{
			case '?':
				while (c != '>' || c2 != '?')
				{
					c2 = c;
					num4 = @class.Read();
					if (num4 >= 0)
					{
						c = (char)num4;
						continue;
					}
					throw new Exception("EOF in processing directive.");
				}
				continue;
			case '/':
			{
				class5 = class3.Peek();
				if (class5.string_1 != null)
				{
					for (int i = 0; i < class5.string_1.Length; i++)
					{
						if (@class.Read() != class5.string_1[i])
						{
							throw new Exception($"Non matching element close tag: expected </{class5.string_1}:{class5.string_2}>");
						}
					}
					if (@class.Read() != 58)
					{
						throw new Exception($"Non matching element close tag: expected </{class5.string_1}:{class5.string_2}>");
					}
				}
				for (int j = 0; j < class5.string_2.Length; j++)
				{
					if (@class.Read() != class5.string_2[j])
					{
						throw new Exception($"Non matching element close tag: expected </{class5.string_2}>");
					}
				}
				for (c = (char)@class.Read(); c <= ' '; c = (char)@class.Read())
				{
				}
				if (c == '>')
				{
					num3 = @class.Position;
					if (class5.string_1 != null && class3.method_2(class5.string_1) == "http://schemas.openxmlformats.org/markup-compatibility/2006" && (class5.string_2 == "Choice" || class5.string_2 == "Fallback") && class5.int_3 == 0)
					{
						class2.method_1(class5.int_4, num3 - class5.int_4);
					}
					if (class5.bool_0)
					{
						if (!class3.method_5(class5.string_1, class5.string_2))
						{
							class2.method_1(class5.int_4, num3 - class5.int_4);
						}
						else
						{
							class2.method_1(class5.int_4, class5.int_5 - class5.int_4);
							class2.method_1(num2, num3 - num2);
						}
					}
					class3.method_1();
					continue;
				}
				throw new Exception($"Non matching element close tag: expected </{class5.string_2}>");
			}
			case '!':
				c = (char)@class.Read();
				switch (c)
				{
				case '[':
					do
					{
						num4 = @class.Read();
					}
					while (num4 != 91 && num4 > 0);
					while (c != ']' && c2 != ']')
					{
						c2 = c;
						num4 = @class.Read();
						if (num4 >= 0)
						{
							c = (char)num4;
							continue;
						}
						throw new Exception("EOF in comment.");
					}
					break;
				case '!':
					if (@class.Read() == 45 && @class.Read() == 45)
					{
						while (c != '-' && c2 != '-')
						{
							c2 = c;
							num4 = @class.Read();
							if (num4 >= 0)
							{
								c = (char)num4;
								continue;
							}
							throw new Exception("EOF in comment.");
						}
						if (@class.Read() != 62)
						{
							throw new Exception("Error in comment.");
						}
						break;
					}
					throw new Exception("Error in comment.");
				}
				continue;
			}
			stringBuilder = new StringBuilder();
			string text = null;
			while (c > ' ' && c != '/' && c != '>' && c != ':')
			{
				stringBuilder.Append(c);
				num4 = @class.Read();
				if (num4 >= 0)
				{
					c = (char)num4;
					continue;
				}
				throw new Exception("Error in element name.");
			}
			string text2 = stringBuilder.ToString();
			bool flag = false;
			if (c == ':')
			{
				stringBuilder = new StringBuilder();
				c = (char)@class.Read();
				text = text2;
				while (c > ' ' && c != '/' && c != '>')
				{
					stringBuilder.Append(c);
					num4 = @class.Read();
					if (num4 >= 0)
					{
						c = (char)num4;
						continue;
					}
					throw new Exception("Error in element name.");
				}
				text2 = stringBuilder.ToString();
			}
			if (insertSpacePreserve && class3.Count == 0)
			{
				class2.method_2(Class1120.char_1, @class.Position - 1);
			}
			while (c <= ' ')
			{
				c = (char)@class.Read();
			}
			class5 = new Class1115(text, text2);
			class4.Clear();
			while (c != '/' && c != '>')
			{
				stringBuilder = new StringBuilder();
				string text3 = null;
				int startPosition = @class.Position - 1;
				while (c > ' ' && c != '=' && c != ':')
				{
					stringBuilder.Append(c);
					num4 = @class.Read();
					if (num4 >= 0)
					{
						c = (char)num4;
						continue;
					}
					throw new Exception("Error in attribute name.");
				}
				string text4 = stringBuilder.ToString();
				if (c == ':')
				{
					stringBuilder = new StringBuilder();
					c = (char)@class.Read();
					text3 = text4;
					while (c > ' ' && c != '=')
					{
						stringBuilder.Append(c);
						num4 = @class.Read();
						if (num4 >= 0)
						{
							c = (char)num4;
							continue;
						}
						throw new Exception("Error in attribute name.");
					}
					text4 = stringBuilder.ToString();
				}
				while (c <= ' ')
				{
					c = (char)@class.Read();
				}
				if (c == '=')
				{
					for (c = (char)@class.Read(); c <= ' '; c = (char)@class.Read())
					{
					}
					if (c == '\'' || c == '"')
					{
						int position = @class.Position;
						stringBuilder = new StringBuilder();
						num4 = @class.Read();
						while (num4 >= 0 && num4 != c)
						{
							stringBuilder.Append((char)num4);
							num4 = @class.Read();
						}
						if (num4 == c)
						{
							int num5 = @class.Position - 1;
							string text5 = stringBuilder.ToString();
							for (c = (char)@class.Read(); c <= ' '; c = (char)@class.Read())
							{
							}
							int endPosition = @class.Position - 1;
							if (text3 == "xmlns")
							{
								if (text5 == "http://schemas.microsoft.com/office/powerpoint/2007/7/12/main")
								{
									class2.method_1(position, num5 - position);
									class2.method_2(Class1120.char_0, position);
								}
								class5.method_0(text4, text5);
							}
							else
							{
								class4.method_0(text3, text4, text5, startPosition, endPosition, class2, fixRepeatingAttributes);
							}
							continue;
						}
						throw new Exception("Unexpected EOF in attribute value.");
					}
					throw new Exception("Error in attribute syntax.");
				}
				throw new Exception("Error in attribute syntax.");
			}
			if (c == '/')
			{
				if (@class.Read() != 62)
				{
					throw new Exception("Error in element.");
				}
				flag = true;
			}
			num3 = @class.Position;
			class5.int_4 = num2;
			class5.int_5 = num3;
			class3.method_0(class5);
			if (class5.string_1 != null && class3.method_2(class5.string_1) == "http://schemas.openxmlformats.org/markup-compatibility/2006")
			{
				switch (class5.string_2)
				{
				case "Fallback":
				{
					Class1115 class8 = class3.Peek(1);
					if (!(class8.string_2 != "AlternateContent"))
					{
						if (class8.int_3 != 0)
						{
							class5.int_3 = 0;
							break;
						}
						class5.int_3 = 1;
						class8.int_3 = 1;
						break;
					}
					throw new Exception("Fallback element found not within AlternativeContent");
				}
				case "Choice":
				{
					Class1115 class6 = class3.Peek(1);
					if (!(class6.string_2 != "AlternateContent"))
					{
						if (class6.int_3 != 0)
						{
							class5.int_3 = 0;
							break;
						}
						for (int k = 0; k < class4.Count; k++)
						{
							Class1113 class7 = class4[k];
							if (class7.string_0 != null || !(class7.string_1 == "Requires"))
							{
								continue;
							}
							class5.int_3 = 1;
							int l = 0;
							while (l < class7.string_2.Length)
							{
								for (; l < class7.string_2.Length && class7.string_2[l] <= ' '; l++)
								{
								}
								int num6 = l;
								for (; l < class7.string_2.Length && class7.string_2[l] > ' '; l++)
								{
								}
								if (l > num6 && !class3.method_6(class7.string_2.Substring(num6, l - num6)))
								{
									class5.int_3 = 0;
									break;
								}
							}
							if (class5.int_3 != 0)
							{
								class6.int_3 = 1;
							}
						}
						break;
					}
					throw new Exception("Choice element found not within AlternativeContent");
				}
				}
			}
			if (text != null && class3.method_3(text))
			{
				class5.bool_0 = true;
				class2.method_1(class5.int_4, class5.int_5 - class5.int_4);
			}
			for (int m = 0; m < class4.Count; m++)
			{
				Class1113 class9 = class4[m];
				if (class9.string_0 == null)
				{
					continue;
				}
				if (class3.method_3(class9.string_0))
				{
					class2.method_1(class9.int_0, class9.int_1 - class9.int_0);
				}
				if (string.Compare(class3.method_2(class9.string_0), "http://schemas.openxmlformats.org/markup-compatibility/2006", ignoreCase: true) != 0)
				{
					continue;
				}
				if (class9.string_1 == "Ignorable")
				{
					int n = 0;
					while (n < class9.string_2.Length)
					{
						for (; n < class9.string_2.Length && class9.string_2[n] <= ' '; n++)
						{
						}
						int num7 = n;
						for (; n < class9.string_2.Length && class9.string_2[n] > ' '; n++)
						{
						}
						if (n > num7)
						{
							class5.method_2(class3.method_2(class9.string_2.Substring(num7, n - num7)));
						}
					}
					continue;
				}
				if (!(class9.string_1 == "ProcessContent"))
				{
					continue;
				}
				int num8 = 0;
				while (num8 < class9.string_2.Length)
				{
					for (; num8 < class9.string_2.Length && class9.string_2[num8] <= ' '; num8++)
					{
					}
					int num9 = num8;
					for (; num8 < class9.string_2.Length && class9.string_2[num8] > ' ' && class9.string_2[num8] != ':'; num8++)
					{
					}
					int num10 = num8++;
					for (; num8 < class9.string_2.Length && class9.string_2[num8] > ' '; num8++)
					{
					}
					if (num8 > num10 + 1 && num10 > num9)
					{
						string text6 = class9.string_2.Substring(num10 + 1, num8 - num10 - 1);
						class5.method_1(class3.method_2(class9.string_2.Substring(num9, num10 - num9)), (text6 == "*") ? null : text6);
					}
				}
			}
			if (flag)
			{
				class3.method_1();
			}
		}
		return class2;
	}

	private static bool smethod_4(char c)
	{
		return c <= ' ';
	}
}
