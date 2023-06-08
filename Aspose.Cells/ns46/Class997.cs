using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using Aspose.Cells.DigitalSignatures;
using ns16;

namespace ns46;

internal class Class997
{
	private DigitalSignatureCollection digitalSignatureCollection_0 = new DigitalSignatureCollection();

	[SpecialName]
	public DigitalSignatureCollection method_0()
	{
		return digitalSignatureCollection_0;
	}

	public Class997(Class746 class746_0)
	{
		method_7(class746_0);
	}

	internal XmlNode method_1(XmlNode xmlNode_0, string string_0)
	{
		if (xmlNode_0.ChildNodes != null && xmlNode_0.ChildNodes.Count > 0)
		{
			foreach (XmlNode childNode in xmlNode_0.ChildNodes)
			{
				if (childNode.Name == string_0)
				{
					return childNode;
				}
			}
		}
		return null;
	}

	private void method_2(XmlNode signatureProperties, out string comments)
	{
		foreach (XmlNode childNode in signatureProperties.ChildNodes)
		{
			_ = signatureProperties.FirstChild;
			foreach (XmlNode childNode2 in childNode.FirstChild.ChildNodes)
			{
				if (childNode2.Name == "SignatureComments")
				{
					comments = childNode2.InnerText;
					return;
				}
			}
		}
		comments = "";
	}

	private void method_3(XmlNode signatureProperties, out DateTime datetime)
	{
		datetime = DateTime.MinValue;
		string s = "";
		foreach (XmlNode childNode in signatureProperties.ChildNodes)
		{
			if (!(Class1005.smethod_0(childNode, "Id") == "idSignatureTime"))
			{
				continue;
			}
			XmlNode firstChild = childNode.FirstChild;
			foreach (XmlNode childNode2 in firstChild.ChildNodes)
			{
				if (childNode2.Name == "mdssi:Format")
				{
					_ = childNode2.InnerText;
				}
				if (childNode2.Name == "mdssi:Value")
				{
					s = childNode2.InnerText;
				}
			}
			try
			{
				datetime = DateTime.Parse(s).ToUniversalTime();
			}
			catch (Exception)
			{
			}
		}
	}

	private bool method_4(string signatureXml, Class746 zipFile, out string comment, out DateTime signTime)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(signatureXml);
		Signature signature = new Signature();
		XmlElement documentElement = xmlDocument.DocumentElement;
		signature.LoadXml(documentElement);
		string string_ = "";
		lock (Class1005.hashtable_0)
		{
			Class1005.smethod_1();
			Class1005.smethod_2(signature.SignedInfo.GetXml(), ref string_);
		}
		SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
		comment = null;
		signTime = DateTime.MinValue;
		foreach (Reference reference3 in signature.SignedInfo.References)
		{
			foreach (DataObject @object in signature.ObjectList)
			{
				if (!(reference3.Uri.Substring(1) == @object.Id))
				{
					continue;
				}
				string_ = "";
				lock (Class1005.hashtable_0)
				{
					Class1005.smethod_1();
					Class1005.smethod_2(@object.GetXml(), ref string_);
				}
				SHA1CryptoServiceProvider sHA1CryptoServiceProvider2 = new SHA1CryptoServiceProvider();
				byte[] array = sHA1CryptoServiceProvider2.ComputeHash(Encoding.ASCII.GetBytes(string_));
				array = sHA1CryptoServiceProvider2.ComputeHash(Encoding.ASCII.GetBytes(string_));
				byte[] digestValue = reference3.DigestValue;
				if (method_5(array, digestValue))
				{
					Reference reference2 = null;
					foreach (XmlNode datum in @object.Data)
					{
						if (datum.Name == "SignatureProperties")
						{
							if (Class1005.smethod_0(datum.FirstChild, "Id").StartsWith("idOfficeV1Details"))
							{
								method_2(datum, out comment);
							}
							if (Class1005.smethod_0(datum.FirstChild, "Id").StartsWith("idSignatureTime"))
							{
								method_3(datum, out signTime);
							}
						}
						else
						{
							if (!(datum.Name == "Manifest") || !datum.HasChildNodes)
							{
								continue;
							}
							foreach (XmlNode childNode in datum.ChildNodes)
							{
								if (!(childNode.Name == "Reference") || Class1005.smethod_0(childNode, "URI").EndsWith(".relationships+xml"))
								{
									continue;
								}
								try
								{
									reference2 = new Reference();
									reference2.LoadXml((XmlElement)childNode);
									byte[] buffer = method_8(zipFile, reference2.Uri);
									if (!method_5(sHA1CryptoServiceProvider.ComputeHash(buffer), reference2.DigestValue))
									{
										return false;
									}
								}
								catch
								{
								}
							}
						}
					}
					continue;
				}
				return false;
			}
		}
		return true;
	}

	private bool method_5(byte[] byte_0, byte[] byte_1)
	{
		if (byte_0.Length != byte_1.Length)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < byte_0.Length)
			{
				if (byte_0[num] != byte_1[num])
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private bool method_6(string signatureXml, out X509Certificate2 cert)
	{
		RSACryptoServiceProvider rSACryptoServiceProvider = null;
		Signature signature = new Signature();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(signatureXml);
		XmlElement documentElement = xmlDocument.DocumentElement;
		signature.LoadXml(documentElement);
		signature.KeyInfo.GetXml();
		KeyInfo keyInfo = signature.KeyInfo;
		cert = null;
		foreach (KeyInfoClause item in keyInfo)
		{
			XmlElement xml = item.GetXml();
			if (xml.Name.ToLower().StartsWith("x509"))
			{
				KeyInfoX509Data keyInfoX509Data = new KeyInfoX509Data();
				keyInfoX509Data.LoadXml(xml);
				cert = (X509Certificate2)keyInfoX509Data.Certificates[0];
				rSACryptoServiceProvider = (RSACryptoServiceProvider)cert.PublicKey.Key;
			}
		}
		if (rSACryptoServiceProvider == null)
		{
			return false;
		}
		string s = Class1005.smethod_3(signature.SignedInfo);
		byte[] bytes = Encoding.ASCII.GetBytes(s);
		return rSACryptoServiceProvider.VerifyData(bytes, "SHA1", signature.SignatureValue);
	}

	private bool method_7(Class746 class746_0)
	{
		Class744 class744_ = class746_0.method_38("[Content_Types].xml");
		Stream stream = class746_0.method_39(class744_);
		StreamReader streamReader = new StreamReader(stream);
		string xml = streamReader.ReadToEnd();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		XmlNode xmlNode = method_1(xmlDocument, "Types");
		if (xmlNode != null)
		{
			foreach (XmlNode childNode in xmlNode.ChildNodes)
			{
				if (Class1005.smethod_0(childNode, "ContentType").EndsWith("digital-signature-xmlsignature+xml"))
				{
					X509Certificate2 cert = null;
					bool bool_ = true;
					string signatureXml = method_9(class746_0, Class1005.smethod_0(childNode, "PartName"));
					if (!method_6(signatureXml, out cert))
					{
						bool_ = false;
					}
					if (!method_4(signatureXml, class746_0, out var comment, out var signTime))
					{
						bool_ = false;
					}
					DigitalSignature value = new DigitalSignature(cert, comment, signTime, bool_);
					digitalSignatureCollection_0.arrayList_0.Add(value);
				}
			}
		}
		return true;
	}

	private byte[] method_8(Class746 class746_0, string string_0)
	{
		int num = ((string_0[0] == '/') ? 1 : 0);
		int num2 = string_0.IndexOf('?');
		num2 = ((num2 == -1) ? (string_0.Length - num) : (num2 - num));
		Class744 @class = class746_0.method_38(string_0.Substring(num, num2));
		Stream stream = class746_0.method_39(@class);
		byte[] array = new byte[@class.Size];
		stream.Read(array, 0, array.Length);
		return array;
	}

	private string method_9(Class746 class746_0, string string_0)
	{
		int num = ((string_0[0] == '/') ? 1 : 0);
		int num2 = string_0.IndexOf('?');
		num2 = ((num2 == -1) ? (string_0.Length - num) : (num2 - num));
		Class744 class744_ = class746_0.method_38(string_0.Substring(num, num2));
		StreamReader streamReader = new StreamReader(class746_0.method_39(class744_));
		return streamReader.ReadToEnd();
	}
}
