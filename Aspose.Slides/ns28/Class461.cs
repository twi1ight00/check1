using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace ns28;

internal abstract class Class461 : XmlDocument
{
	internal Class476 class476_0;

	internal Class480 class480_0;

	protected abstract Class482 ElementsFactory { get; }

	internal virtual void vmethod_0()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode is Class369 @class)
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
				if (xmlNode is Class369 @class)
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

	public Class369 method_0(string localName, string namespaceURI)
	{
		XmlNodeList elementsByTagName = GetElementsByTagName(localName, namespaceURI);
		if (elementsByTagName.Count < 1)
		{
			return null;
		}
		return elementsByTagName[0] as Class369;
	}

	public Class369[] method_1(string[] localNames, string namespaceURI)
	{
		List<Class369> list = new List<Class369>();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (!(xmlNode is Class369 @class) || !(@class.NamespaceURI == namespaceURI))
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

	public Class461(Class476 package)
	{
		class476_0 = package;
	}

	public override XmlElement CreateElement(string prefix, string localName, string namespaceURI)
	{
		XmlElement xmlElement = ElementsFactory.CreateElement(prefix, localName, namespaceURI, this);
		if (xmlElement != null)
		{
			return xmlElement;
		}
		return new Class369(prefix, localName, namespaceURI, this);
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
}
