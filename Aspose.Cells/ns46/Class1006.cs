using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Aspose.Cells.DigitalSignatures;
using ns16;

namespace ns46;

internal class Class1006
{
	private DigitalSignatureCollection digitalSignatureCollection_0;

	private SHA1CryptoServiceProvider sha1CryptoServiceProvider_0 = new SHA1CryptoServiceProvider();

	private Class1001 class1001_0;

	private DigitalSignature digitalSignature_0;

	private Regex regex_0 = new Regex("sig(\\d+)(\\x2Exml)$");

	public Class1006(DigitalSignatureCollection digitalSignatureCollection_1)
	{
		if (digitalSignatureCollection_1 == null)
		{
			throw new Exception("Signatures can not be null");
		}
		digitalSignatureCollection_0 = digitalSignatureCollection_1;
		class1001_0 = new Class1001("DigestMethod");
		class1001_0.arrayList_1.Add(new Class998("Algorithm", "http://www.w3.org/2000/09/xmldsig#sha1"));
	}

	public void method_0(Stream stream_0)
	{
		method_14(stream_0);
	}

	private Class1003 method_1(DigitalSignature digitalSignature_1)
	{
		Class1003 @class = new Class1003("KeyInfo", "");
		string string_ = digitalSignature_1.Certificate.PublicKey.Key.ToXmlString(includePrivateParameters: false);
		Class1003 class999_ = new Class1003("KeyValue", string_);
		@class.Add(class999_);
		string text = Convert.ToBase64String(digitalSignature_1.Certificate.RawData);
		Class1003 class999_2 = new Class1003("X509Data", "<X509Certificate>" + text + "</X509Certificate>");
		@class.Add(class999_2);
		return @class;
	}

	private Class1003 method_2(Class746 class746_0, string string_0, string string_1)
	{
		if (string_0 != null && string_0.Length > 0)
		{
			Class744 @class = class746_0.method_38(string_0);
			if (@class.Size <= 0)
			{
				return null;
			}
			Stream inputStream = class746_0.method_39(@class);
			byte[] inArray = sha1CryptoServiceProvider_0.ComputeHash(inputStream);
			Class1003 class2 = new Class1003("Reference", "");
			class2.arrayList_1.Add(new Class998("URI", string_1));
			class2.Add(class1001_0);
			Class1003 class999_ = new Class1003("DigestValue", Convert.ToBase64String(inArray));
			class2.Add(class999_);
			return class2;
		}
		return null;
	}

	private Class1003 method_3()
	{
		string text = digitalSignature_0.SignTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
		string string_ = "<SignatureProperty Id=\"idSignatureTime\" Target=\"#idPackageSignature\"><mdssi:SignatureTime><mdssi:Format>YYYY-MM-DDThh:mm:ssTZD</mdssi:Format><mdssi:Value>" + text + "</mdssi:Value></mdssi:SignatureTime></SignatureProperty>";
		return new Class1003("SignatureProperties", string_);
	}

	private Class1003 method_4(Class746 class746_0, Class744 class744_0)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(class746_0.method_39(class744_0));
		Class1003 @class = new Class1003("Reference", "");
		@class.arrayList_1.Add(new Class998("URI", '/' + class744_0.Name + "?ContentType=application/vnd.openxmlformats-package.relationships+xml"));
		Class1003 class2 = new Class1003("Transforms", "");
		@class.Add(class2);
		Class1003 class3 = new Class1003("Transform", "");
		class3.arrayList_1.Add(new Class998("Algorithm", "http://schemas.openxmlformats.org/package/2006/RelationshipTransform"));
		class2.Add(class3);
		Class1001 class4 = new Class1001("Transform");
		class4.arrayList_1.Add(new Class998("Algorithm", "http://www.w3.org/TR/2001/REC-xml-c14n-20010315"));
		class2.Add(class4);
		XmlElement xmlElement = (XmlElement)xmlDocument.ChildNodes[1];
		foreach (XmlNode childNode in xmlElement.ChildNodes)
		{
			string text = Class1005.smethod_0(childNode, "TargetMode");
			if (text == null || !text.StartsWith("External"))
			{
				string text2 = Class1005.smethod_0(childNode, "Target");
				if (text2 != null && text2.Length > 0 && !text2.StartsWith("docProps/"))
				{
					Class1001 class5 = new Class1001("mdssi:RelationshipReference");
					class5.arrayList_1.Add(new Class998("SourceId", Class1005.smethod_0(childNode, "Id")));
					class3.Add(class5);
				}
			}
		}
		string string_ = "";
		lock (Class1005.hashtable_0)
		{
			Class1005.smethod_1();
			string string_2 = "";
			@class.vmethod_1(ref string_2);
			Class1005.smethod_5(string_2, ref string_, class746_0);
		}
		Class1001 class6 = new Class1001("DigestMethod");
		class6.arrayList_1.Add(new Class998("Algorithm", "http://www.w3.org/2000/09/xmldsig#sha1"));
		@class.Add(class6);
		byte[] inArray = sha1CryptoServiceProvider_0.ComputeHash(Encoding.UTF8.GetBytes(string_));
		Class1003 class999_ = new Class1003("DigestValue", Convert.ToBase64String(inArray));
		@class.Add(class999_);
		return @class;
	}

	private void method_5(Class1003 class1003_0)
	{
		SortedList sortedList = new SortedList();
		foreach (Class1003 item in class1003_0.arrayList_0)
		{
			Class998 class2 = (Class998)item.arrayList_1[0];
			sortedList.Add(class2.string_1, item);
		}
		class1003_0.arrayList_0.Clear();
		foreach (object key in sortedList.Keys)
		{
			class1003_0.Add((Class1003)sortedList[key]);
		}
	}

	private Class1003 method_6(Class746 class746_0)
	{
		Class1003 @class = new Class1003("Object", "");
		@class.arrayList_1.Add(new Class998("Id", "idPackageObject"));
		@class.arrayList_1.Add(new Class998("xmlns:mdssi", "http://schemas.openxmlformats.org/package/2006/digital-signature"));
		Class1003 class2 = new Class1003("Manifest", "");
		Class1003 class999_ = method_3();
		@class.Add(class2);
		@class.Add(class999_);
		foreach (Class744 item in class746_0)
		{
			if (item.Name.Contains("_rels/") && item.method_19())
			{
				class2.Add(method_4(class746_0, item));
			}
		}
		Class744 class744_ = class746_0.method_38("[Content_Types].xml");
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(class746_0.method_39(class744_));
		XmlNode xmlNode = xmlDocument.ChildNodes[1];
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = new Hashtable();
		foreach (XmlElement childNode in xmlNode.ChildNodes)
		{
			if (childNode.Name == "Override")
			{
				string text = Class1005.smethod_0(childNode, "PartName");
				string text2 = Class1005.smethod_0(childNode, "ContentType");
				if (!text.StartsWith("/"))
				{
					text = "/" + text;
				}
				hashtable[text.TrimStart('/')] = text + "?ContentType=" + text2;
			}
			else if (childNode.Name == "Default")
			{
				string text3 = Class1005.smethod_0(childNode, "Extension");
				string text4 = Class1005.smethod_0(childNode, "ContentType");
				hashtable2["." + text3] = "?ContentType=" + text4;
			}
		}
		try
		{
			foreach (Class744 item2 in class746_0)
			{
				if (!item2.Name.EndsWith(".rels") && !(item2.Name == "[Content_Types].xml") && item2.Name.StartsWith("xl/"))
				{
					if (hashtable[item2.Name] != null)
					{
						class2.Add(method_2(class746_0, item2.Name, (string)hashtable[item2.Name]));
					}
					else if (hashtable2[Path.GetExtension(item2.Name)] != null)
					{
						class2.Add(method_2(class746_0, item2.Name, "/" + item2.Name + (string)hashtable2[Path.GetExtension(item2.Name)]));
					}
				}
			}
		}
		catch
		{
		}
		method_5(class2);
		return @class;
	}

	private Class1003 method_7(DigitalSignature digitalSignature_1)
	{
		string string_ = "<SignatureProperties><SignatureProperty Id=\"idOfficeV1Details\" Target=\"#idPackageSignature\"><SignatureInfoV1 xmlns=\"http://schemas.microsoft.com/office/2006/digsig\"><SetupID></SetupID><SignatureText></SignatureText><SignatureImage></SignatureImage><SignatureComments>" + digitalSignature_1.Comments + "</SignatureComments><WindowsVersion>5.1</WindowsVersion><OfficeVersion>12.0</OfficeVersion><ApplicationVersion>12.0</ApplicationVersion><Monitors>1</Monitors><HorizontalResolution>1280</HorizontalResolution><VerticalResolution>800</VerticalResolution><ColorDepth>32</ColorDepth><SignatureProviderId>{00000000-0000-0000-0000-000000000000}</SignatureProviderId><SignatureProviderUrl></SignatureProviderUrl><SignatureProviderDetails>9</SignatureProviderDetails><ManifestHashAlgorithm>http://www.w3.org/2000/09/xmldsig#sha1</ManifestHashAlgorithm><SignatureType>1</SignatureType></SignatureInfoV1></SignatureProperty></SignatureProperties>";
		Class1003 @class = new Class1003("Object", string_);
		@class.arrayList_1.Add(new Class998("Id", "idOfficeObject"));
		return @class;
	}

	private Class1000 method_8(Class746 class746_0, DigitalSignature digitalSignature_1, int int_0)
	{
		digitalSignature_0 = digitalSignature_1;
		Class1000 @class = new Class1000();
		Class1003 class2 = new Class1003("Signature", "");
		class2.arrayList_1.Add(new Class998("Id", "idPackageSignature"));
		class2.arrayList_1.Add(new Class998("xmlns", "http://www.w3.org/2000/09/xmldsig#"));
		Class1003 class3 = method_6(class746_0);
		Class1003 class4 = method_7(digitalSignature_1);
		Class1003 class5 = method_11(class3, class4);
		class2.Add(class5);
		class2.Add(method_10(digitalSignature_1, class5));
		class2.Add(method_1(digitalSignature_1));
		class2.Add(class3);
		class2.Add(class4);
		@class.Add(class2);
		return @class;
	}

	private string method_9(byte[] byte_0)
	{
		string text = Convert.ToBase64String(byte_0);
		string text2 = "";
		while (true)
		{
			string text3 = text.Substring(0, Math.Min(72, text.Length));
			text2 = text2 + "\r\n    " + text3;
			if (text3.Length < 72)
			{
				break;
			}
			text = text.Substring(72);
		}
		return text2;
	}

	private Class1003 method_10(DigitalSignature digitalSignature_1, Class1003 class1003_0)
	{
		string string_ = "";
		string string_2 = "";
		class1003_0.vmethod_1(ref string_2);
		lock (Class1005.hashtable_0)
		{
			Class1005.smethod_1();
			Class1005.smethod_4(string_2, ref string_);
		}
		RSACryptoServiceProvider key = (RSACryptoServiceProvider)digitalSignature_1.Certificate.PrivateKey;
		RSAPKCS1SignatureFormatter rSAPKCS1SignatureFormatter = new RSAPKCS1SignatureFormatter(key);
		rSAPKCS1SignatureFormatter.SetHashAlgorithm("SHA1");
		byte[] rgbHash = sha1CryptoServiceProvider_0.ComputeHash(Encoding.UTF8.GetBytes(string_));
		byte[] byte_ = rSAPKCS1SignatureFormatter.CreateSignature(rgbHash);
		return new Class1003("SignatureValue", method_9(byte_));
	}

	private Class1003 method_11(Class1003 class1003_0, Class1003 class1003_1)
	{
		string string_ = "";
		string string_2 = "";
		class1003_0.vmethod_1(ref string_2);
		lock (Class1005.hashtable_0)
		{
			Class1005.smethod_1();
			Class1005.smethod_4(string_2, ref string_);
		}
		byte[] inArray = sha1CryptoServiceProvider_0.ComputeHash(Encoding.ASCII.GetBytes(string_));
		string_2 = "";
		string_ = "";
		class1003_1.vmethod_1(ref string_2);
		lock (Class1005.hashtable_0)
		{
			Class1005.smethod_1();
			Class1005.smethod_4(string_2, ref string_);
		}
		byte[] inArray2 = sha1CryptoServiceProvider_0.ComputeHash(Encoding.ASCII.GetBytes(string_));
		string string_3 = "<CanonicalizationMethod Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315\"/><SignatureMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#rsa-sha1\"/><Reference URI=\"#idPackageObject\" Type=\"http://www.w3.org/2000/09/xmldsig#Object\"><DigestMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#sha1\"/><DigestValue>" + Convert.ToBase64String(inArray) + "</DigestValue></Reference><Reference URI=\"#idOfficeObject\" Type=\"http://www.w3.org/2000/09/xmldsig#Object\"><DigestMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#sha1\"/><DigestValue>" + Convert.ToBase64String(inArray2) + "</DigestValue></Reference>";
		return new Class1003("SignedInfo", string_3);
	}

	private Class1002 method_12(Class746 class746_0)
	{
		Class1002 @class = new Class1002("_xmlsignatures/");
		int num = 0;
		foreach (DigitalSignature item in digitalSignatureCollection_0)
		{
			num++;
			Class1004 class2 = new Class1004("_xmlsignatures/sig" + num + ".xml");
			class2.Add(method_8(class746_0, item, num));
			@class.Add(class2);
		}
		return @class;
	}

	private Class1002 method_13(Class1002 class1002_0)
	{
		Class1003 @class = new Class1003("Relationships", "");
		@class.arrayList_1.Add(new Class998("xmlns", "http://schemas.openxmlformats.org/package/2006/relationships"));
		foreach (Class1004 item in class1002_0.arrayList_0)
		{
			Match match = regex_0.Match(item.string_0);
			if (match.Groups.Count == 3)
			{
				string value = match.Groups[0].Value;
				string string_ = "rId" + match.Groups[1].Value;
				Class1001 class3 = new Class1001("Relationship");
				class3.arrayList_1.Add(new Class998("Id", string_));
				class3.arrayList_1.Add(new Class998("Type", "http://schemas.openxmlformats.org/package/2006/relationships/digital-signature/signature"));
				class3.arrayList_1.Add(new Class998("Target", value));
				@class.Add(class3);
			}
		}
		class1002_0.Add(new Class1004("_xmlsignatures/origin.sigs"));
		Class1002 class4 = new Class1002("_xmlsignatures/_rels/");
		class1002_0.Add(class4);
		Class1004 class5 = new Class1004("_xmlsignatures/_rels/origin.sigs.rels");
		class4.Add(class5);
		Class1000 class6 = new Class1000("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\" ?>");
		class5.Add(class6);
		class6.Add(@class);
		return class1002_0;
	}

	private void method_14(Stream stream_0)
	{
		Class746 @class = Class746.Read(stream_0);
		MemoryStream memoryStream = new MemoryStream();
		Stream6 stream = new Stream6(memoryStream);
		stream.method_6(Enum42.const_4);
		stream.method_10(Enum32.const_0);
		Class1002 class2 = method_12(@class);
		method_13(class2);
		Class1008 class1008_ = new Class1008(stream);
		class2.vmethod_0(class1008_);
		method_15(class2, @class, stream);
		method_17(class2, @class, stream);
		stream.Flush();
		stream.method_22();
		memoryStream.Position = 0L;
		Class746 class3 = Class746.Read(memoryStream);
		foreach (Class744 item in class3)
		{
			if (@class.method_40(item.Name, bool_18: false) >= 0)
			{
				@class.method_1();
				@class.method_45(item.Name);
				@class.method_2();
			}
			@class.method_1();
			if (!item.method_18())
			{
				Class1007 class1007_ = new Class1007(item, class3);
				@class.Add(class1007_, item.Name);
			}
			@class.method_2();
		}
		MemoryStream memoryStream2 = new MemoryStream();
		@class.Save(memoryStream2);
		stream_0.Position = 0L;
		stream_0.SetLength(0L);
		memoryStream2.WriteTo(stream_0);
	}

	private void method_15(Class1002 class1002_0, Class746 class746_0, Stream6 stream6_0)
	{
		Class1004 @class = new Class1004("_rels/.rels");
		@class.method_0(class746_0, "_rels/.rels");
		Class1001 class2 = new Class1001("Relationship");
		class2.arrayList_1.Add(new Class998("Id", "rId"));
		class2.arrayList_1.Add(new Class998("Type", "http://schemas.openxmlformats.org/package/2006/relationships/digital-signature/origin"));
		class2.arrayList_1.Add(new Class998("Target", "_xmlsignatures/origin.sigs"));
		@class.method_4("/Relationships/", class2);
		Class1008 class1008_ = new Class1008(stream6_0);
		@class.vmethod_0(class1008_);
	}

	private void method_16(Class1004 class1004_0)
	{
		ArrayList arrayList = new ArrayList();
		Class1000 @class = (Class1000)class1004_0.arrayList_0[0];
		Class1003 class2 = (Class1003)@class.arrayList_0[0];
		foreach (Class1001 item in class2.arrayList_0)
		{
			foreach (Class998 item2 in item.arrayList_1)
			{
				if (item2.string_1.StartsWith("application/vnd.openxmlformats-package.digital-signature-"))
				{
					arrayList.Add(item);
					break;
				}
			}
		}
		foreach (Class1001 item3 in arrayList)
		{
			class2.arrayList_0.Remove(item3);
		}
	}

	private void method_17(Class1002 class1002_0, Class746 class746_0, Stream6 stream6_0)
	{
		Class1004 @class = new Class1004("[Content_Types].xml");
		@class.method_0(class746_0, "[Content_Types].xml");
		method_16(@class);
		Class1001 class2 = new Class1001("Default");
		class2.arrayList_1.Add(new Class998("Extension", "sigs"));
		class2.arrayList_1.Add(new Class998("ContentType", "application/vnd.openxmlformats-package.digital-signature-origin"));
		@class.method_2("/Types/", class2);
		foreach (Class999 item in class1002_0.arrayList_0)
		{
			if (item is Class1004)
			{
				Class1004 class4 = (Class1004)item;
				if (class4.string_0.StartsWith("_xmlsignatures/sig"))
				{
					Class1001 class5 = new Class1001("Override");
					class5.arrayList_1.Add(new Class998("PartName", "/" + class4.string_0));
					class5.arrayList_1.Add(new Class998("ContentType", "application/vnd.openxmlformats-package.digital-signature-xmlsignature+xml"));
					@class.method_2("/Types/", class5);
				}
			}
		}
		Class1008 class1008_ = new Class1008(stream6_0);
		@class.vmethod_0(class1008_);
	}
}
