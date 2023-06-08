using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security;
using System.Text;
using System.Xml;
using ns33;
using ns52;

namespace ns4;

internal class Class1179
{
	private struct Struct117
	{
		internal string string_0;

		internal string string_1;

		internal Struct117(string oldName, string newName)
		{
			string_0 = oldName;
			string_1 = newName;
		}
	}

	private const string string_0 = "Aspose.";

	internal static readonly int int_0 = 5;

	internal static readonly string string_1 = "... text has been truncated due to evaluation version limitation.";

	private string[] string_2;

	private Enum178 enum178_0;

	private string string_3;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private Enum179 enum179_0;

	private static Class1179 class1179_0;

	private static List<string> list_0;

	private static Struct117[] struct117_0 = new Struct117[5]
	{
		new Struct117("Aspose.Word", "Aspose.Words"),
		new Struct117("Aspose.Excel", "Aspose.Cells"),
		new Struct117("Aspose.Excel.Web", "Aspose.Grid"),
		new Struct117("Aspose.PowerPoint", "Aspose.Slides"),
		new Struct117("Aspose.Project", "Aspose.Tasks")
	};

	internal string[] Products => string_2;

	internal Enum178 EditionType => enum178_0;

	internal string SerialNumber => string_3;

	internal DateTime SubscriptionExpiry => dateTime_0;

	internal DateTime LicenseExpiry => dateTime_1;

	public void method_0(string licenseName, Assembly clientAssembly)
	{
		string text = "Professional";
		string text2 = "Professional";
		if (!licenseName.Equals(""))
		{
			using Stream stream = smethod_6(licenseName, clientAssembly);
			method_1(stream);
		}
		else
		{
			class1179_0 = this;
		}
		text = text2;
		text2 = text;
	}

	public void method_1(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(stream);
		method_2(xmlDocument);
		if (list_0 == null)
		{
			smethod_10();
		}
		int num = 0;
		while (true)
		{
			if (num < list_0.Count)
			{
				string text = list_0[num];
				if (!text.Equals(string_3))
				{
					num++;
					continue;
				}
				throw new InvalidOperationException("This license is disabled, please contact Aspose to obtain a new license.");
			}
			if (Class1141.SignatureInvalidFlag > 0)
			{
				return;
			}
			bool flag = false;
			string[] array = string_2;
			foreach (string text2 in array)
			{
				if (!text2.Equals("Aspose.Slides for .NET"))
				{
					if (!text2.Equals("Aspose.Total Product Family") && !text2.Equals("Aspose.Slides Product Family"))
					{
						if (!text2.Equals("Aspose.Total") && !text2.Equals("Aspose.Total for .NET"))
						{
							if (text2.Equals("Aspose.Slides for .NET for .NET"))
							{
								flag = true;
								break;
							}
							continue;
						}
						flag = true;
						break;
					}
					flag = true;
					break;
				}
				flag = true;
				break;
			}
			if (!flag)
			{
				throw new InvalidOperationException("The license is not valid for this product.");
			}
			DateTime dateTime = DateTime.ParseExact("2015.01.30", "yyyy.MM.dd", CultureInfo.InvariantCulture);
			if (dateTime > dateTime_0)
			{
				throw new InvalidOperationException(string.Format("The subscription included in this license allows free upgrades until {0}, but this version of the product was released on {1}. Please renew the subscription or use a previous version of the product.", dateTime_0.ToString("dd MMM yyyy"), dateTime.ToString("dd MMM yyyy")));
			}
			if (!(DateTime.Now > dateTime_1))
			{
				break;
			}
			throw new InvalidOperationException("The license has expired.");
		}
		enum179_0 = Enum179.const_1;
		class1179_0 = this;
	}

	public static void smethod_0()
	{
		string text = "Professional";
		string text2 = "Professional";
		text = text2;
		text2 = text;
		class1179_0 = null;
	}

	public static Enum179 smethod_1()
	{
		string text = "Professional";
		string text2 = "Professional";
		text = text2;
		text2 = text;
		if (class1179_0 != null && class1179_0.enum179_0 != 0 && Class1141.smethod_0() != 4096 && !(class1179_0.LicenseExpiry < DateTime.Now))
		{
			return Enum179.const_1;
		}
		return Enum179.const_0;
	}

	internal static void smethod_2(Enum178 wantEditionType, string message)
	{
		if (smethod_1() != 0)
		{
			string arg = wantEditionType switch
			{
				Enum178.const_0 => "Professional", 
				Enum178.const_1 => "Enterprise", 
				_ => throw new InvalidOperationException("Invalid edition type."), 
			};
			string arg2 = class1179_0.EditionType switch
			{
				Enum178.const_0 => "Professional", 
				Enum178.const_1 => "Enterprise", 
				_ => throw new InvalidOperationException("Invalid edition type."), 
			};
			if (wantEditionType > class1179_0.EditionType)
			{
				throw new InvalidOperationException($"{message} Unfortunately, this feature is only available in {arg} Edition, but your license is for {arg2} Edition. Please contact Aspose to upgrade your license.");
			}
		}
	}

	public static string smethod_3(string originalText)
	{
		if (smethod_1() != 0)
		{
			return originalText;
		}
		if (originalText != null && int_0 < originalText.Length)
		{
			return originalText.Substring(0, int_0) + string_1;
		}
		return originalText;
	}

	internal void method_2(XmlDocument doc)
	{
		XmlElement documentElement = doc.DocumentElement;
		XmlElement xmlElement = smethod_13(documentElement, "Data");
		XmlElement signatureElem = smethod_13(documentElement, "Signature");
		smethod_5(xmlElement, signatureElem);
		XmlElement xmlElement2 = smethod_13(xmlElement, "Products");
		XmlNodeList elementsByTagName = xmlElement2.GetElementsByTagName("Product");
		string_2 = new string[elementsByTagName.Count];
		for (int i = 0; i < elementsByTagName.Count; i++)
		{
			string_2[i] = smethod_4(elementsByTagName[i].InnerText);
		}
		string text = smethod_11(xmlElement, "EditionType");
		if (text.Equals("Professional"))
		{
			enum178_0 = Enum178.const_0;
		}
		else
		{
			if (!text.Equals("Enterprise"))
			{
				throw new InvalidOperationException("Invalid edition type.");
			}
			enum178_0 = Enum178.const_1;
		}
		string_3 = smethod_11(xmlElement, "SerialNumber");
		dateTime_0 = smethod_12(xmlElement, "SubscriptionExpiry");
		dateTime_1 = smethod_12(xmlElement, "LicenseExpiry");
	}

	private static string smethod_4(string productName)
	{
		int num = 0;
		while (true)
		{
			if (num < struct117_0.Length)
			{
				if (productName.Equals(struct117_0[num].string_0))
				{
					break;
				}
				num++;
				continue;
			}
			return productName;
		}
		return struct117_0[num].string_1;
	}

	internal void method_3(string fileName)
	{
		string text = "Professional";
		string text2 = "Professional";
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(fileName);
		method_2(xmlDocument);
		text = text2;
		text2 = text;
	}

	private static void smethod_5(XmlNode dataElem, XmlNode signatureElem)
	{
		string text = "Professional";
		string text2 = "Professional";
		string s = ((dataElem != null) ? dataElem.OuterXml : "");
		byte[] bytes = Encoding.Unicode.GetBytes(s);
		string s2 = ((signatureElem != null) ? signatureElem.InnerText : "");
		byte[] signature = Convert.FromBase64String(s2);
		string s3 = "u+h2qn9ohhbv4023RqfxfWkc5ehyf8Mmgww0BPYvKOVNWsxmIo82x9Z8diZjJUQOfZt793cKc/efC35MYhyoQ34U6SiyGRGU9J0BJwvAqekd8T7Be6fAfGnnYJDomhi5lfbWjTx8up5C1Csz6vCeB5IOqtfvrM5/h5Upsj2UdIc=";
		string s4 = "AQAB";
		byte[] modulus = Convert.FromBase64String(s3);
		byte[] exponent = Convert.FromBase64String(s4);
		Class1135 @class = new Class1135(modulus, exponent);
		@class.method_0(bytes, signature);
		text = text2;
		text2 = text;
	}

	private static Stream smethod_6(string licenseName, Assembly callingAssembly)
	{
		string text = null;
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			text = licenseName;
			if (File.Exists(text))
			{
				return File.OpenRead(text);
			}
			stringBuilder.Append($"License \"{text}\" doesn't exist or access is restricted.");
			stringBuilder.Append(Environment.NewLine);
		}
		catch (SecurityException ex)
		{
			Class1165.smethod_28(ex);
			stringBuilder.Append($"License \"{text}\" isn't accessible.");
			stringBuilder.Append(Environment.NewLine);
		}
		try
		{
			text = smethod_7(licenseName, Assembly.GetExecutingAssembly());
			if (File.Exists(text))
			{
				return File.OpenRead(text);
			}
			stringBuilder.Append($"License \"{text}\" doesn't exist in the executing assembly's directory.");
			stringBuilder.Append(Environment.NewLine);
		}
		catch (SecurityException ex2)
		{
			Class1165.smethod_28(ex2);
			stringBuilder.Append($"License \"{text}\" isn't accessible in the executing assembly's directory.");
			stringBuilder.Append(Environment.NewLine);
		}
		try
		{
			text = smethod_7(licenseName, callingAssembly);
			if (File.Exists(text))
			{
				return File.OpenRead(text);
			}
			stringBuilder.Append($"License \"{text}\" doesn't exist in the calling assembly's directory.");
			stringBuilder.Append(Environment.NewLine);
		}
		catch (SecurityException ex3)
		{
			Class1165.smethod_28(ex3);
			stringBuilder.Append($"License \"{text}\" isn't accessible in the calling assembly's directory.");
			stringBuilder.Append(Environment.NewLine);
		}
		try
		{
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			if (entryAssembly != null)
			{
				text = smethod_7(licenseName, entryAssembly);
				if (File.Exists(text))
				{
					return File.OpenRead(text);
				}
				stringBuilder.Append($"License \"{licenseName}\" doesn't exist in the entry assembly's directory.");
				stringBuilder.Append(Environment.NewLine);
			}
		}
		catch (SecurityException ex4)
		{
			Class1165.smethod_28(ex4);
			stringBuilder.Append($"License \"{licenseName}\" isn't accessible in the entry assembly's directory.");
			stringBuilder.Append(Environment.NewLine);
		}
		string text2 = null;
		try
		{
			text2 = Path.GetFileName(licenseName);
			Stream stream = smethod_9(callingAssembly, text2);
			if (stream != null)
			{
				return stream;
			}
			stringBuilder.Append($"License \"{text2}\" doesn't exist in calling assembly's resources. Assembly name: {callingAssembly.FullName}");
			stringBuilder.Append(Environment.NewLine);
		}
		catch (SecurityException ex5)
		{
			Class1165.smethod_28(ex5);
			stringBuilder.Append($"License \"{text2}\" isn't accessible as calling assembly resource.");
			stringBuilder.Append(Environment.NewLine);
		}
		stringBuilder.Append($"Cannot find license \"{licenseName}\".");
		throw new FileNotFoundException(stringBuilder.ToString());
	}

	internal static string smethod_7(string fileName, Assembly assembly)
	{
		return Path.Combine(smethod_8(assembly), Path.GetFileName(fileName));
	}

	private static string smethod_8(Assembly assembly)
	{
		Uri uri = new Uri(assembly.CodeBase);
		return Path.GetDirectoryName(uri.LocalPath);
	}

	private static Stream smethod_9(Assembly assembly, string partialName)
	{
		string[] manifestResourceNames = assembly.GetManifestResourceNames();
		string[] array = manifestResourceNames;
		int num = 0;
		string text;
		while (true)
		{
			if (num < array.Length)
			{
				text = array[num];
				if (text.IndexOf(partialName) != -1)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return assembly.GetManifestResourceStream(text);
	}

	private static void smethod_10()
	{
		Stream stream = smethod_9(Assembly.GetExecutingAssembly(), "Aspose.License.BlackList");
		if (stream == null)
		{
			throw new InvalidOperationException("Cannot find black listed licenses resource. Please report this error to Aspose.");
		}
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(stream);
			XmlElement documentElement = xmlDocument.DocumentElement;
			XmlElement xmlElement = smethod_13(documentElement, "Data");
			XmlNode signatureElem = smethod_13(documentElement, "Signature");
			smethod_5(xmlElement, signatureElem);
			list_0 = new List<string>();
			XmlNodeList elementsByTagName = xmlElement.GetElementsByTagName("SN");
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				list_0.Add(elementsByTagName[i].InnerText);
			}
		}
		finally
		{
			stream.Close();
		}
	}

	private static string smethod_11(XmlElement parentElem, string childElemName)
	{
		XmlElement xmlElement = smethod_13(parentElem, childElemName);
		if (xmlElement == null)
		{
			return "";
		}
		return xmlElement.InnerText;
	}

	private static DateTime smethod_12(XmlElement parentElem, string childElemName)
	{
		string text = smethod_11(parentElem, childElemName);
		if (!text.Equals(""))
		{
			return DateTime.ParseExact(text, "yyyyMMdd", CultureInfo.InvariantCulture);
		}
		return DateTime.MaxValue;
	}

	private static XmlElement smethod_13(XmlElement parentElem, string childElemName)
	{
		XmlNodeList elementsByTagName = parentElem.GetElementsByTagName(childElemName);
		if (elementsByTagName.Count <= 0)
		{
			return null;
		}
		return (XmlElement)elementsByTagName[0];
	}
}
