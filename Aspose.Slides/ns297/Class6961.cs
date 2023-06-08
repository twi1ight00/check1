using System;
using System.IO;
using System.Text;
using System.Xml;
using ns288;
using ns301;
using ns302;

namespace ns297;

internal class Class6961
{
	private const string string_0 = "//style";

	private const string string_1 = "//head/link[translate(@rel, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')='stylesheet' and @href]";

	private const string string_2 = "{0}\n";

	public const string string_3 = "http://www.w3.org/1999/xhtml";

	private readonly string string_4;

	private Class6905 class6905_0;

	private XmlNamespaceManager xmlNamespaceManager_0;

	private string string_5;

	public XmlNamespaceManager NamespaceManager
	{
		get
		{
			if (xmlNamespaceManager_0 == null)
			{
				xmlNamespaceManager_0 = new XmlNamespaceManager(new NameTable());
				xmlNamespaceManager_0.AddNamespace(string.Empty, "http://www.w3.org/1999/xhtml");
			}
			return xmlNamespaceManager_0;
		}
	}

	public Class6961(string rawHtml, string inputEncoding)
	{
		string_4 = rawHtml;
		string_5 = inputEncoding;
		class6905_0 = new Class6905();
	}

	public Class6908 method_0()
	{
		try
		{
			class6905_0.method_1(string_4);
		}
		catch (Exception innerException)
		{
			throw new Exception71("Exception occured while loading given html", string_4, innerException);
		}
		if (class6905_0.DocumentNode == null)
		{
			throw new Exception71("Bad format of input data. Root node could not be found.", string_4);
		}
		return class6905_0.DocumentNode;
	}

	public Class6908 method_1(Stream stream)
	{
		Class6892.smethod_0(stream, "stream");
		Encoding encoding = null;
		if (!string.IsNullOrEmpty(string_5))
		{
			try
			{
				encoding = Encoding.GetEncoding(string_5);
			}
			catch (ArgumentException)
			{
			}
		}
		StreamReader reader = ((encoding == null) ? new StreamReader(stream) : new StreamReader(stream, encoding));
		try
		{
			class6905_0 = new Class6905();
			class6905_0.bool_2 = encoding == null;
			class6905_0.method_2(reader);
		}
		catch (Exception68 exception)
		{
			class6905_0 = new Class6905();
			stream.Seek(0L, SeekOrigin.Begin);
			reader = new StreamReader(stream, exception.Encoding);
			class6905_0.method_2(reader);
		}
		catch (Exception innerException)
		{
			throw new Exception71("Exception occured while loading given html", string_4, innerException);
		}
		if (class6905_0.DocumentNode == null)
		{
			throw new Exception71("Bad format of input data. Root node could not be found.", string_4);
		}
		return class6905_0.DocumentNode;
	}
}
