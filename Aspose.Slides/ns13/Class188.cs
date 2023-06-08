using System;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Slides;
using ns270;
using ns3;
using ns4;

namespace ns13;

internal class Class188
{
	internal static void Encrypt(Stream packageStream, string password, Stream outputStream, Class60 customProps)
	{
		Class6630 @class = new Class6630();
		Class186 class2 = new Class186(password, 128);
		@class.Add("EncryptionInfo", class2.method_4());
		@class.Add("EncryptedPackage", class2.method_5(packageStream));
		if (customProps != null)
		{
			@class.Add("\u0005SummaryInformation", new MemoryStream(customProps.Si.Write()));
			@class.Add("\u0005DocumentSummaryInformation", new MemoryStream(customProps.DSi.Write()));
		}
		Class6711 class3 = new Class6711(@class);
		class3.Save(outputStream);
	}

	internal static MemoryStream smethod_0(Stream packageStream, string password)
	{
		MemoryStream encryptionInfo;
		MemoryStream encryptedPackage;
		try
		{
			Class6711 @class = new Class6711(packageStream);
			if (!@class.Root.Contains("EncryptedPackage") || !@class.Root.Contains("EncryptionInfo"))
			{
				throw new PptxUnsupportedFormatException("Unknown file format.");
			}
			encryptionInfo = @class.Root.method_1("EncryptionInfo");
			encryptedPackage = @class.Root.method_1("EncryptedPackage");
		}
		catch (InvalidOperationException)
		{
			throw new OOXMLCorruptFileException("This file is not correctly encrypted or malformed");
		}
		return smethod_1(encryptedPackage, encryptionInfo, password);
	}

	private static MemoryStream smethod_1(MemoryStream encryptedPackage, MemoryStream encryptionInfo, string password)
	{
		byte[] array = new byte[(int)encryptionInfo.Length];
		encryptionInfo.Read(array, 0, array.Length);
		if (array[0] == 4 && array[2] == 4)
		{
			XmlNode xmlNode = smethod_2(array);
			XmlElement xmlElement = xmlNode["keyData"];
			if (xmlElement != null)
			{
				string value = xmlElement.Attributes["hashAlgorithm"].Value;
				if (value == "SHA512")
				{
					Class10 @class = new Class10(value, xmlNode, Encoding.Unicode.GetBytes(password));
					if (@class.method_0())
					{
						return @class.method_1(encryptedPackage);
					}
					throw new InvalidPasswordException("Invalid password.");
				}
			}
			Class187 class2 = new Class187(xmlNode, Encoding.Unicode.GetBytes(password));
			if (class2.method_2())
			{
				return class2.method_3(encryptedPackage);
			}
			throw new InvalidPasswordException("Invalid password.");
		}
		Class186 class3 = null;
		if (string.IsNullOrEmpty(password))
		{
			password = "VelvetSweatshop";
		}
		class3 = new Class186(array, password);
		if (!class3.method_1())
		{
			throw new InvalidPasswordException("Invalid password.");
		}
		return class3.method_3(encryptedPackage);
	}

	private static XmlNode smethod_2(byte[] recordData)
	{
		XmlDocument xmlDocument = new XmlDocument();
		MemoryStream memoryStream = new MemoryStream(recordData);
		memoryStream.Position = 8L;
		xmlDocument.Load(memoryStream);
		return xmlDocument.DocumentElement;
	}
}
