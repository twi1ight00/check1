using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using ns43;

namespace ns42;

internal abstract class Class822 : XmlDocument
{
	private class Class829
	{
		public string string_0;

		public string string_1;

		public string string_2;

		public int int_0;

		public int int_1;

		public Class829(string namespacePrefix, string localName, string value, int startPosition, int endPosition)
		{
			string_0 = namespacePrefix;
			string_1 = localName;
			string_2 = value;
			int_0 = startPosition;
			int_1 = endPosition;
		}
	}

	private class Class830
	{
		private Class829[] class829_0 = new Class829[8];

		private int int_0;

		public Class829 this[int index]
		{
			get
			{
				if (index < 0 || index >= int_0)
				{
					throw new IndexOutOfRangeException("");
				}
				return class829_0[index];
			}
		}

		public int Count => int_0;

		public int method_0(string namespacePrefix, string localName, string value, int startPosition, int endPosition, Class1092.Class1094 builder, bool fixRepeatingAttributes)
		{
			if (fixRepeatingAttributes)
			{
				for (int i = 0; i < int_0; i++)
				{
					Class829 @class = class829_0[i];
					if (namespacePrefix == @class.string_0 && localName == @class.string_1)
					{
						builder.method_1(startPosition, endPosition - startPosition);
						return -1;
					}
				}
			}
			if (int_0 + 1 > class829_0.Length)
			{
				Class829[] array = new Class829[class829_0.Length + class829_0.Length / 2 + 8];
				for (int j = 0; j < class829_0.Length; j++)
				{
					array[j] = class829_0[j];
				}
				class829_0 = array;
			}
			class829_0[int_0] = new Class829(namespacePrefix, localName, value, startPosition, endPosition);
			return int_0++;
		}

		public void Clear()
		{
			int_0 = 0;
		}
	}

	private class Class831
	{
		private class Class832
		{
			public readonly string string_0;

			public readonly string string_1;

			public Class832(string first, string second)
			{
				string_0 = first;
				string_1 = second;
			}
		}

		private Class832[] class832_0 = new Class832[8];

		private Class832[] class832_1 = new Class832[8];

		private string[] string_0 = new string[8];

		private int int_0;

		private int int_1;

		private int int_2;

		public bool bool_0;

		public int int_3;

		public string string_1;

		public string string_2;

		public int int_4;

		public int int_5;

		public int NamespacesCount => int_0;

		public int PreserveContentCount => int_1;

		public int IgnorableCount => int_2;

		public Class831(string namespacePrefix, string localName)
		{
			string_1 = namespacePrefix;
			string_2 = localName;
		}

		public Class831(string namespacePrefix, string localName, int startPosition, int endPosition)
		{
			string_1 = namespacePrefix;
			string_2 = localName;
			int_4 = startPosition;
			int_5 = endPosition;
		}

		public void method_0(string prefix, string namespaceUri)
		{
			if (int_0 >= class832_0.Length)
			{
				Class832[] array = new Class832[class832_0.Length + class832_0.Length / 2 + 8];
				for (int i = 0; i < class832_0.Length; i++)
				{
					array[i] = class832_0[i];
				}
				class832_0 = array;
			}
			class832_0[int_0++] = new Class832(prefix, namespaceUri);
		}

		public void method_1(string namespaceUri, string localName)
		{
			if (int_1 >= class832_1.Length)
			{
				Class832[] array = new Class832[class832_1.Length + class832_1.Length / 2 + 8];
				for (int i = 0; i < class832_1.Length; i++)
				{
					array[i] = class832_1[i];
				}
				class832_1 = array;
			}
			if (localName == "*")
			{
				localName = null;
			}
			class832_1[int_1++] = new Class832(namespaceUri, localName);
		}

		public void method_2(string namespaceUri)
		{
			if (int_2 >= string_0.Length)
			{
				string[] array = new string[string_0.Length + string_0.Length / 2 + 8];
				for (int i = 0; i < class832_0.Length; i++)
				{
					array[i] = string_0[i];
				}
				string_0 = array;
			}
			string_0[int_2++] = namespaceUri;
		}

		public string method_3(string prefix)
		{
			int num = 0;
			while (true)
			{
				if (num < int_0)
				{
					if (class832_0[num].string_0 == prefix)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return class832_0[num].string_1;
		}

		public bool method_4(string namespaceUri)
		{
			int num = 0;
			while (true)
			{
				if (num < int_2)
				{
					if (string.Compare(namespaceUri, string_0[num], ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		public bool method_5(string namespaceUri, string localName)
		{
			int num = 0;
			while (true)
			{
				if (num < int_1)
				{
					if (string.Compare(namespaceUri, class832_1[num].string_0, ignoreCase: true) == 0 && (class832_1[num].string_1 == null || class832_1[num].string_1 == localName))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
	}

	private class Class833
	{
		private Class831[] class831_0 = new Class831[64];

		private int int_0;

		public int Count => int_0;

		public void method_0(Class831 element)
		{
			if (int_0 >= class831_0.Length)
			{
				Class831[] array = new Class831[class831_0.Length + class831_0.Length / 2 + 8];
				for (int i = 0; i < class831_0.Length; i++)
				{
					array[i] = class831_0[i];
				}
				class831_0 = array;
			}
			class831_0[int_0++] = element;
		}

		public void method_1()
		{
			int_0--;
		}

		public Class831 Peek()
		{
			return class831_0[int_0 - 1];
		}

		public Class831 Peek(int index)
		{
			return class831_0[int_0 - 1 - index];
		}

		public void Clear()
		{
			int_0 = 0;
		}

		public string method_2(string prefix)
		{
			int num = int_0 - 1;
			string text;
			while (true)
			{
				if (num >= 0)
				{
					text = class831_0[num].method_3(prefix);
					if (text != null)
					{
						break;
					}
					num--;
					continue;
				}
				return null;
			}
			return text;
		}

		public bool method_3(string prefix)
		{
			string text = method_2(prefix);
			int num = 0;
			while (true)
			{
				if (num < string_11.Length)
				{
					if (string.Compare(text, string_11[num], ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				if (string.Compare(text, "http://schemas.openxmlformats.org/markup-compatibility/2006", ignoreCase: true) == 0)
				{
					return true;
				}
				for (int num2 = int_0 - 1; num2 >= 0; num2--)
				{
					for (int i = 0; i < class831_0[num2].IgnorableCount; i++)
					{
						if (class831_0[num2].method_4(text))
						{
							return true;
						}
					}
				}
				return false;
			}
			return false;
		}

		public bool method_4(string prefix)
		{
			string text = method_2(prefix);
			if (string.Compare(text, "http://schemas.openxmlformats.org/markup-compatibility/2006", ignoreCase: true) == 0)
			{
				return true;
			}
			for (int num = int_0 - 1; num >= 0; num--)
			{
				for (int i = 0; i < class831_0[num].IgnorableCount; i++)
				{
					if (class831_0[num].method_4(text))
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool method_5(string prefix, string localName)
		{
			string text = method_2(prefix);
			for (int num = int_0 - 1; num >= 0; num--)
			{
				for (int i = 0; i < class831_0[num].IgnorableCount; i++)
				{
					if (class831_0[num].method_5(text, localName))
					{
						return true;
					}
				}
			}
			if (text == "http://schemas.openxmlformats.org/markup-compatibility/2006")
			{
				if (!(localName == "AlternateContent") && !(localName == "Choice"))
				{
					return localName == "Fallback";
				}
				return true;
			}
			return false;
		}

		public bool method_6(string prefix)
		{
			string strA = method_2(prefix);
			int num = 0;
			while (true)
			{
				if (num < string_11.Length)
				{
					if (string.Compare(strA, string_11[num], ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
	}

	internal const string string_0 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";

	internal const string string_1 = "http://schemas.openxmlformats.org/presentationml/2006/main";

	internal const string string_2 = "http://schemas.openxmlformats.org/drawingml/2006/main";

	internal const string string_3 = "http://schemas.microsoft.com/office/2006/activeX";

	internal const string string_4 = "http://schemas.openxmlformats.org/markup-compatibility/2006";

	internal const string string_5 = "http://schemas.microsoft.com/office/powerpoint/2010/main";

	internal const string string_6 = "urn:schemas-microsoft-com:vml";

	internal const string string_7 = "http://www.w3.org/XML/1998/namespace";

	private const string string_8 = "http://schemas.microsoft.com/office/powerpoint/2007/7/12/main";

	private const string string_9 = "http://schemas.microsoft.com/office/powerpoint/2010/main";

	internal Class834 class834_0;

	internal Class1086 class1086_0;

	internal Class1090 class1090_0;

	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	internal static readonly Dictionary<string, string> dictionary_0;

	internal static readonly Dictionary<string, string> dictionary_1;

	private static readonly string[] string_10;

	internal XmlSchemaCollection xmlSchemaCollection_0;

	internal static readonly string[] string_11;

	internal static readonly char[] char_0;

	private static char[] char_1;

	internal Class1090 Relationships
	{
		get
		{
			return class1090_0;
		}
		set
		{
			class1090_0 = value;
		}
	}

	protected abstract Class1096 ElementsFactory { get; }

	public new Class810 DocumentElement => (Class810)base.DocumentElement;

	static Class822()
	{
		dictionary_0 = new Dictionary<string, string>();
		dictionary_1 = new Dictionary<string, string>();
		string_10 = new string[14]
		{
			"http://schemas.openxmlformats.org/officeDocument/2006/relationships", "r", "http://schemas.openxmlformats.org/presentationml/2006/main", "p", "http://schemas.microsoft.com/office/2006/activeX", "ox", "http://schemas.openxmlformats.org/drawingml/2006/main", "a", "http://schemas.microsoft.com/office/powerpoint/2010/main", "p14",
			"urn:schemas-microsoft-com:vml", "v", "http://schemas.openxmlformats.org/markup-compatibility/2006", "mc"
		};
		string_11 = new string[4] { "http://schemas.openxmlformats.org/officeDocument/2006/relationships", "http://schemas.openxmlformats.org/presentationml/2006/main", "http://schemas.openxmlformats.org/drawingml/2006/main", "http://schemas.microsoft.com/office/2006/activeX" };
		char_0 = string.Format(" xmlns:xml=\"{0}\" xml:space=\"preserve\"", "http://www.w3.org/XML/1998/namespace").ToCharArray();
		char_1 = "http://schemas.microsoft.com/office/powerpoint/2010/main".ToCharArray();
		for (int i = 0; i < string_10.Length; i += 2)
		{
			dictionary_0[string_10[i]] = string_10[i + 1];
			dictionary_1[string_10[i + 1]] = string_10[i];
		}
	}

	public Class822(Class834 package)
	{
		class834_0 = package;
	}

	internal void method_0()
	{
	}

	internal virtual void vmethod_0()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode is Class810 @class)
				{
					@class.vmethod_0();
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	internal virtual void vmethod_1()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode is Class810 @class)
				{
					@class.vmethod_1();
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	internal virtual void vmethod_2()
	{
		if (class834_0 != null && class1090_0 != null && class1086_0 != null)
		{
			string name = Class834.smethod_4(class1086_0.string_0);
			Class1086 @class = class834_0.method_5(name);
			if (@class == null)
			{
				@class = new Class1086(name);
				@class.string_1 = "application/vnd.openxmlformats-package.relationships+xml";
				class834_0.method_7(@class);
			}
			@class.class1090_0 = class1090_0;
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode is Class810 class2)
				{
					class2.vmethod_2();
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	public Class810 method_1(string localName, string namespaceURI)
	{
		XmlNodeList elementsByTagName = GetElementsByTagName(localName, namespaceURI);
		if (elementsByTagName.Count < 1)
		{
			return null;
		}
		return elementsByTagName[0] as Class810;
	}

	public Class810[] method_2(string[] localNames, string namespaceURI)
	{
		List<Class810> list = new List<Class810>();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (!(xmlNode is Class810 @class) || !(@class.NamespaceURI == namespaceURI))
				{
					continue;
				}
				foreach (string text in localNames)
				{
					if (text == @class.LocalName)
					{
						list.Add(@class);
						break;
					}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return list.ToArray();
	}

	public Class810 method_3(string[] localNames, string namespaceURI)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (!(xmlNode is Class810 @class) || !(@class.NamespaceURI == namespaceURI))
				{
					continue;
				}
				foreach (string text in localNames)
				{
					if (text == @class.LocalName)
					{
						return @class;
					}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	public Class810 method_4(string localName, string namespaceURI)
	{
		Class810 @class = method_1(localName, namespaceURI);
		if (@class == null)
		{
			@class = (Class810)OwnerDocument.CreateElement(GetPrefixOfNamespace(namespaceURI), localName, namespaceURI);
		}
		return @class;
	}

	public override XmlElement CreateElement(string prefix, string localName, string namespaceURI)
	{
		XmlElement xmlElement = ElementsFactory.CreateElement(prefix, localName, namespaceURI, this);
		if (xmlElement == null)
		{
			throw new Exception();
		}
		return xmlElement;
	}

	internal static Stream smethod_0(Stream stream)
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

	private static bool smethod_2(char c)
	{
		return c <= ' ';
	}

	internal static Class1092.Class1094 smethod_3(Stream stream, bool insertSpacePreserve)
	{
		return smethod_4(stream, insertSpacePreserve, fixRepeatingAttributes: true);
	}

	internal static Class1092.Class1094 smethod_4(Stream stream, bool insertSpacePreserve, bool fixRepeatingAttributes)
	{
		Class1092 @class = new Class1092(stream);
		Class1092.Class1094 class2 = new Class1092.Class1094();
		Class833 class3 = new Class833();
		Class830 class4 = new Class830();
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
			Class831 class5;
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
				class2.method_2(char_0, @class.Position - 1);
			}
			while (c <= ' ')
			{
				c = (char)@class.Read();
			}
			class5 = new Class831(text, text2);
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
									class2.method_2(char_1, position);
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
					Class831 class8 = class3.Peek(1);
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
					Class831 class6 = class3.Peek(1);
					if (!(class6.string_2 != "AlternateContent"))
					{
						if (class6.int_3 != 0)
						{
							class5.int_3 = 0;
							break;
						}
						for (int k = 0; k < class4.Count; k++)
						{
							Class829 class7 = class4[k];
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
				Class829 class9 = class4[m];
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
}
