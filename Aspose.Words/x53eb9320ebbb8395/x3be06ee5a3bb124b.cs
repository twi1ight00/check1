using System;
using System.Collections;
using System.IO;
using System.Xml;
using Aspose.Words.Markup;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x53eb9320ebbb8395;

internal class x3be06ee5a3bb124b
{
	private readonly string x518f65aea4c18f4d;

	private readonly string x0bd93ae72c72de01;

	private readonly string x3b3f617f9cfddeab;

	private Hashtable x5efffdf462132495
	{
		get
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(x9035cee51805f20b))
			{
				return null;
			}
			xc1dcd6189d01216e xc1dcd6189d01216e = new xc1dcd6189d01216e("<?xml version='1.0' encoding='utf-8' standalone='yes'?><map " + x9035cee51805f20b + "/>", null);
			Hashtable hashtable = new Hashtable();
			xc1dcd6189d01216e.x99f8cdb2827fa686();
			while (xc1dcd6189d01216e.x1ac1960adc8c4c39(xf8a30dc03e702055: false))
			{
				hashtable.Add(xc1dcd6189d01216e.xa66385d80d4d296f, xc1dcd6189d01216e.xd2f68ee6f47e9dfb);
			}
			return hashtable;
		}
	}

	internal string x9035cee51805f20b => x518f65aea4c18f4d;

	internal string x8d815cb9b264fc20 => x0bd93ae72c72de01;

	internal string x949db66894158be8 => x3b3f617f9cfddeab;

	internal x3be06ee5a3bb124b(string prefixMapping, string xPath, string storeItemId)
	{
		x518f65aea4c18f4d = prefixMapping;
		x0bd93ae72c72de01 = xPath;
		x3b3f617f9cfddeab = storeItemId;
	}

	internal x3be06ee5a3bb124b(string xPath, string storeItemId)
		: this("", xPath, storeItemId)
	{
	}

	internal x3be06ee5a3bb124b x8b61531c8ea35b85()
	{
		return (x3be06ee5a3bb124b)MemberwiseClone();
	}

	internal XmlNode x68190b5ec24229fb(CustomXmlPartCollection x361132de876f4a8c)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x949db66894158be8))
		{
			return null;
		}
		XmlNode xmlNode = null;
		if (x361132de876f4a8c.GetById(x949db66894158be8) == null)
		{
			foreach (CustomXmlPart item in x361132de876f4a8c)
			{
				xmlNode = x68190b5ec24229fb(item);
				if (xmlNode != null)
				{
					break;
				}
			}
		}
		else
		{
			xmlNode = x68190b5ec24229fb(x361132de876f4a8c.GetById(x949db66894158be8));
		}
		return xmlNode;
	}

	private XmlNode x68190b5ec24229fb(CustomXmlPart x8e12b4cb5e54b506)
	{
		XmlNode result = null;
		try
		{
			XmlDocument xmlDocument = xd165c26d81eb4a1e.xbbd823d2b4dbb41a(new MemoryStream(x8e12b4cb5e54b506.Data), x835fd5ade25a938d: false);
			result = xd165c26d81eb4a1e.x97bb330a631993a5(xmlDocument.DocumentElement, x8d815cb9b264fc20, x5efffdf462132495);
		}
		catch (Exception xc3c70767499bc99a)
		{
			x0d299f323d241756.x27d8ee3f0a83f46a(xc3c70767499bc99a);
		}
		return result;
	}

	internal bool x22ab5dfa6f12e902()
	{
		return x0d299f323d241756.x5959bccb67bbf051(x8d815cb9b264fc20);
	}
}
