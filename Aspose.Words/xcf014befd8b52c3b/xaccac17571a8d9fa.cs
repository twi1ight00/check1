using System.IO;
using System.Security.Cryptography.Xml;
using System.Xml;
using Aspose;
using x38d3ef1c1d247e82;
using x6c95d9cf46ff5f25;

namespace xcf014befd8b52c3b;

[JavaManual("Port it manually because of DOM XML")]
internal class xaccac17571a8d9fa
{
	private const string x9ec7600cbf843742 = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315";

	private const string x88f08911271084dc = "http://schemas.openxmlformats.org/package/2006/RelationshipTransform";

	private readonly x36e82cb2c24c9b3f xdc434e4949faeedd;

	private readonly x6519502b0e34e920 xa98a8eb115bc804c = x6519502b0e34e920.x820665812c4c07a7();

	internal xaccac17571a8d9fa(xc1dcd6189d01216e reader)
	{
		switch (reader.xd68abcd61e368af9("Algorithm", null))
		{
		case "http://www.w3.org/TR/2001/REC-xml-c14n-20010315":
			xdc434e4949faeedd = x36e82cb2c24c9b3f.x39bb818785512fcd;
			break;
		case "http://schemas.openxmlformats.org/package/2006/RelationshipTransform":
			xdc434e4949faeedd = x36e82cb2c24c9b3f.x8dd2d7a22f5d358a;
			while (reader.x152cbadbfa8061b1("Transform"))
			{
				if (reader.xa66385d80d4d296f == "RelationshipReference")
				{
					xa98a8eb115bc804c.xd6b6ed77479ef68c(reader.xd68abcd61e368af9("SourceId", null));
				}
			}
			break;
		default:
			xdc434e4949faeedd = x36e82cb2c24c9b3f.x09a030c0af5860c9;
			break;
		}
	}

	internal MemoryStream x550781f8db1cf5f2(Stream x536ee0b561cc97c2)
	{
		MemoryStream memoryStream = null;
		x536ee0b561cc97c2.Position = 0L;
		switch (xdc434e4949faeedd)
		{
		case x36e82cb2c24c9b3f.x39bb818785512fcd:
		{
			XmlDsigC14NTransform xmlDsigC14NTransform = new XmlDsigC14NTransform();
			xmlDsigC14NTransform.LoadInput(x536ee0b561cc97c2);
			memoryStream = (MemoryStream)xmlDsigC14NTransform.GetOutput(typeof(MemoryStream));
			break;
		}
		case x36e82cb2c24c9b3f.x8dd2d7a22f5d358a:
		{
			XmlDocument xmlDocument = xac5476da6b2561be(x536ee0b561cc97c2);
			x536ee0b561cc97c2.Position = 0L;
			XmlDocument xmlDocument2 = xac5476da6b2561be(x536ee0b561cc97c2);
			XmlNode xmlNode = xmlDocument2.GetElementsByTagName("Relationships")[0];
			xmlNode.RemoveAll();
			foreach (string item in xa98a8eb115bc804c)
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode($"//*[@Id='{item}']");
				XmlAttribute xmlAttribute = xmlNode2.OwnerDocument.CreateAttribute("TargetMode");
				xmlAttribute.Value = "Internal";
				xmlNode2.Attributes.Append(xmlAttribute);
				XmlNode newChild = xmlDocument2.ImportNode(xmlNode2, deep: true);
				xmlNode.AppendChild(newChild);
			}
			memoryStream = new MemoryStream();
			xmlDocument2.Save(memoryStream);
			break;
		}
		}
		return memoryStream;
	}

	private XmlDocument xac5476da6b2561be(Stream x536ee0b561cc97c2)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.PreserveWhitespace = true;
		xmlDocument.Load(x536ee0b561cc97c2);
		return xmlDocument;
	}
}
