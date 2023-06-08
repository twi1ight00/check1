using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using ns42;

namespace ns2;

internal class Class972
{
	private struct Struct73
	{
		internal readonly string string_0;

		internal readonly string string_1;

		internal Struct73(string string_2, string string_3)
		{
			string_0 = string_2;
			string_1 = string_3;
		}
	}

	private string[] string_0;

	private Enum133 enum133_0;

	private string string_1;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private Enum134 enum134_0;

	private static Class972 class972_0;

	private static Hashtable hashtable_0;

	private static readonly Struct73[] struct73_0 = new Struct73[1]
	{
		new Struct73("Aspose.Excel", "Aspose.Cells")
	};

	internal void method_0(string string_2, Assembly assembly_0)
	{
		string text = "Professional";
		string text2 = "Professional";
		if (!string_2.Equals(""))
		{
			using Stream stream_ = smethod_3(string_2, assembly_0);
			method_1(stream_);
		}
		else
		{
			class972_0 = this;
		}
		text = text2;
		text2 = text;
	}

	internal void method_1(Stream stream_0)
	{
		if (stream_0 == null)
		{
			throw new ArgumentNullException("stream");
		}
		Class971.smethod_2(0);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(stream_0);
		method_2(xmlDocument);
		Hashtable hashtable = hashtable_0;
		if (hashtable == null)
		{
			hashtable = (hashtable_0 = smethod_9());
		}
		if (hashtable.ContainsKey(string_1))
		{
			throw new InvalidOperationException("This license is disabled, please contact Aspose to obtain a new license.");
		}
		if (Class971.smethod_1() > 0)
		{
			return;
		}
		bool flag = false;
		string[] array = string_0;
		foreach (string text in array)
		{
			if (text.Equals("Aspose.Total") || text.Equals("Aspose.Total for .NET") || text.Equals("Aspose.Cells for .NET") || text.Equals("Aspose.Cells Product Family") || text.Equals("Aspose.Total Product Family") || text.Equals("Aspose.Cells"))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			throw new InvalidOperationException("The license is not valid for this product.");
		}
		DateTime dateTime = DateTime.ParseExact("2013.02.26", "yyyy.MM.dd", CultureInfo.InvariantCulture);
		if (dateTime > dateTime_0)
		{
			throw new InvalidOperationException(string.Format("The subscription included in this license allows free upgrades until {0}, but this version of the product was released on {1}. Please renew the subscription or use a previous version of the product.", dateTime_0.ToString("dd MMM yyyy", CultureInfo.InvariantCulture), dateTime.ToString("dd MMM yyyy", CultureInfo.InvariantCulture)));
		}
		if (DateTime.Now > dateTime_1)
		{
			throw new InvalidOperationException("The license has expired.");
		}
		enum134_0 = Enum134.const_1;
		class972_0 = this;
	}

	internal static Enum134 smethod_0()
	{
		string text = "Professional";
		string text2 = "Professional";
		text = text2;
		text2 = text;
		if (class972_0 != null && class972_0.enum134_0 != 0 && Class971.smethod_0() != 4096)
		{
			return Enum134.const_1;
		}
		return Enum134.const_0;
	}

	internal void method_2(XmlDocument xmlDocument_0)
	{
		XmlElement documentElement = xmlDocument_0.DocumentElement;
		XmlElement xmlElement = smethod_8(documentElement, "Data");
		XmlElement xmlNode_ = smethod_8(documentElement, "Signature");
		smethod_2(xmlElement, xmlNode_);
		XmlElement xmlElement2 = smethod_8(xmlElement, "Products");
		XmlNodeList elementsByTagName = xmlElement2.GetElementsByTagName("Product");
		string_0 = new string[elementsByTagName.Count];
		for (int i = 0; i < elementsByTagName.Count; i++)
		{
			string_0[i] = smethod_1(elementsByTagName[i].InnerText);
		}
		string stringValue = GetStringValue(xmlElement, "EditionType");
		if (stringValue.Equals("Professional"))
		{
			enum133_0 = Enum133.const_0;
		}
		else
		{
			if (!stringValue.Equals("Enterprise"))
			{
				throw new InvalidOperationException("Invalid edition type.");
			}
			enum133_0 = Enum133.const_1;
		}
		string_1 = GetStringValue(xmlElement, "SerialNumber");
		dateTime_0 = smethod_7(xmlElement, "SubscriptionExpiry");
		dateTime_1 = smethod_7(xmlElement, "LicenseExpiry");
	}

	private static string smethod_1(string string_2)
	{
		int num = 0;
		while (true)
		{
			if (num < struct73_0.Length)
			{
				if (string_2.Equals(struct73_0[num].string_0))
				{
					break;
				}
				num++;
				continue;
			}
			return string_2;
		}
		return struct73_0[num].string_1;
	}

	private static void smethod_2(XmlNode xmlNode_0, XmlNode xmlNode_1)
	{
		string text = "Professional";
		string text2 = "Professional";
		string s = ((xmlNode_0 != null) ? xmlNode_0.OuterXml : "");
		byte[] bytes = Encoding.Unicode.GetBytes(s);
		string s2 = ((xmlNode_1 != null) ? xmlNode_1.InnerText : "");
		byte[] byte_ = Convert.FromBase64String(s2);
		string s3 = "u+h2qn9ohhbv4023RqfxfWkc5ehyf8Mmgww0BPYvKOVNWsxmIo82x9Z8diZjJUQOfZt793cKc/efC35MYhyoQ34U6SiyGRGU9J0BJwvAqekd8T7Be6fAfGnnYJDomhi5lfbWjTx8up5C1Csz6vCeB5IOqtfvrM5/h5Upsj2UdIc=";
		string s4 = "AQAB";
		byte[] byte_2 = Convert.FromBase64String(s3);
		byte[] byte_3 = Convert.FromBase64String(s4);
		Class967 @class = new Class967(byte_2, byte_3);
		@class.method_0(bytes, byte_);
		text = text2;
		text2 = text;
	}

	private static Stream smethod_3(string string_2, Assembly assembly_0)
	{
		string path = string_2;
		if (File.Exists(path))
		{
			return File.OpenRead(path);
		}
		try
		{
			path = smethod_4(string_2, Assembly.GetExecutingAssembly());
			if (File.Exists(path))
			{
				return File.OpenRead(path);
			}
			path = smethod_4(string_2, assembly_0);
			if (File.Exists(path))
			{
				return File.OpenRead(path);
			}
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			if (entryAssembly != null)
			{
				path = smethod_4(string_2, entryAssembly);
				if (File.Exists(path))
				{
					return File.OpenRead(path);
				}
			}
			Stream stream = smethod_6(assembly_0, string_2);
			if (stream != null)
			{
				return stream;
			}
		}
		catch
		{
		}
		throw new FileNotFoundException($"Cannot find license '{string_2}'.");
	}

	internal static string smethod_4(string string_2, Assembly assembly_0)
	{
		return Path.Combine(smethod_5(assembly_0), string_2);
	}

	private static string smethod_5(Assembly assembly_0)
	{
		Uri uri = new Uri(assembly_0.CodeBase);
		return Path.GetDirectoryName(uri.LocalPath);
	}

	private static Stream smethod_6(Assembly assembly_0, string string_2)
	{
		string[] manifestResourceNames = assembly_0.GetManifestResourceNames();
		string[] array = manifestResourceNames;
		int num = 0;
		string text;
		while (true)
		{
			if (num < array.Length)
			{
				text = array[num];
				if (text.IndexOf(string_2) != -1)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return assembly_0.GetManifestResourceStream(text);
	}

	private static string GetStringValue(XmlElement xmlElement_0, string string_2)
	{
		XmlElement xmlElement = smethod_8(xmlElement_0, string_2);
		if (xmlElement == null)
		{
			return "";
		}
		return xmlElement.InnerText;
	}

	private static DateTime smethod_7(XmlElement xmlElement_0, string string_2)
	{
		string stringValue = GetStringValue(xmlElement_0, string_2);
		if (!stringValue.Equals(""))
		{
			return DateTime.ParseExact(stringValue, "yyyyMMdd", CultureInfo.InvariantCulture);
		}
		return DateTime.MaxValue;
	}

	private static XmlElement smethod_8(XmlElement xmlElement_0, string string_2)
	{
		XmlNodeList elementsByTagName = xmlElement_0.GetElementsByTagName(string_2);
		if (elementsByTagName.Count <= 0)
		{
			return null;
		}
		return (XmlElement)elementsByTagName[0];
	}

	private static Hashtable smethod_9()
	{
		Stream stream = smethod_6(Assembly.GetExecutingAssembly(), "Aspose.License.BlackList");
		if (stream == null)
		{
			throw new InvalidOperationException("Cannot find black listed licenses resource. Please report this error to Aspose.");
		}
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(stream);
			XmlElement documentElement = xmlDocument.DocumentElement;
			XmlElement xmlElement = smethod_8(documentElement, "Data");
			XmlNode xmlNode_ = smethod_8(documentElement, "Signature");
			smethod_2(xmlElement, xmlNode_);
			Hashtable hashtable = new Hashtable();
			XmlNodeList elementsByTagName = xmlElement.GetElementsByTagName("SN");
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				hashtable[elementsByTagName[i].InnerText] = null;
			}
			return hashtable;
		}
		finally
		{
			stream.Close();
		}
	}
}
