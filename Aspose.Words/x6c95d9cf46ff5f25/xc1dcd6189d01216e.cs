using System;
using System.Collections;
using System.IO;
using System.Xml;
using Aspose;
using xf9a9481c3f63a419;

namespace x6c95d9cf46ff5f25;

internal class xc1dcd6189d01216e
{
	private readonly XmlTextReader x7450cc1e48712286;

	public string xd8a1c7c41bfbcde0 => x7450cc1e48712286.Prefix;

	public string xa66385d80d4d296f => x7450cc1e48712286.LocalName;

	private bool x03f0124d771d307a => x7450cc1e48712286.IsEmptyElement;

	public string xd2f68ee6f47e9dfb => x7450cc1e48712286.Value;

	public int xbba6773b8ce56a01 => xca004f56614e2431.x59884ab46dd0d856(xd2f68ee6f47e9dfb);

	public double x0cf73f14becdef59 => xca004f56614e2431.xec25d08a2af152f0(xd2f68ee6f47e9dfb);

	internal virtual bool xc3be6b142c6aca84 => xeae765c206270ba2(xd2f68ee6f47e9dfb);

	public int x38637a30d8932f79 => (int)(xca004f56614e2431.x71505bb121b63b5e(x7450cc1e48712286.Value) & 0xFFFFFFFFu);

	public string x91d35d7dc070c876 => x7450cc1e48712286.NamespaceURI;

	public xc1dcd6189d01216e(Stream stream)
	{
		stream.Position = 0L;
		x7450cc1e48712286 = xd165c26d81eb4a1e.x8bf3565aac7e7331(stream);
		x7450cc1e48712286.MoveToContent();
	}

	public xc1dcd6189d01216e(string xml, Hashtable namespaces)
	{
		x7450cc1e48712286 = xd165c26d81eb4a1e.x8bf3565aac7e7331(xml, namespaces);
		x7450cc1e48712286.MoveToContent();
	}

	public bool x152cbadbfa8061b1(string x65bb1537d51f4cd7)
	{
		return x416ea3123144a39f(x65bb1537d51f4cd7, x764dfdef5d60f7e6.x4d0b9d4447ba7566);
	}

	public bool x416ea3123144a39f(string x65bb1537d51f4cd7, x764dfdef5d60f7e6 x8e899bb83cf2e97d)
	{
		x7450cc1e48712286.MoveToElement();
		if (x03f0124d771d307a && xa66385d80d4d296f == x65bb1537d51f4cd7)
		{
			return false;
		}
		while (x7450cc1e48712286.Read())
		{
			switch (x7450cc1e48712286.NodeType)
			{
			case XmlNodeType.Element:
				return true;
			case XmlNodeType.EndElement:
				if (x5f5740eafb9c0cef(x65bb1537d51f4cd7))
				{
					return false;
				}
				break;
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
				if ((x8e899bb83cf2e97d & x764dfdef5d60f7e6.xf9ad6fb78355fe13) != 0)
				{
					return true;
				}
				break;
			case XmlNodeType.SignificantWhitespace:
				if ((x8e899bb83cf2e97d & x764dfdef5d60f7e6.xe15fb22d825aa76b) != 0)
				{
					return true;
				}
				break;
			case XmlNodeType.Whitespace:
				if ((x8e899bb83cf2e97d & x764dfdef5d60f7e6.x61490797a179fc62) != 0)
				{
					return true;
				}
				break;
			}
		}
		return false;
	}

	[JavaThrows(true)]
	public virtual void IgnoreElement()
	{
		x7450cc1e48712286.MoveToElement();
		if (x03f0124d771d307a)
		{
			return;
		}
		string x4c12babe29167a = xa66385d80d4d296f;
		while (!x5f5740eafb9c0cef(x4c12babe29167a))
		{
			x7450cc1e48712286.Read();
			if (x7450cc1e48712286.NodeType == XmlNodeType.Element)
			{
				x7450cc1e48712286.Skip();
			}
		}
	}

	public bool x5f5740eafb9c0cef(string x4c12babe29167a55)
	{
		if (x7450cc1e48712286.NodeType == XmlNodeType.EndElement)
		{
			return xa66385d80d4d296f == x4c12babe29167a55;
		}
		return false;
	}

	public string xd68abcd61e368af9(string xe8dc17d722705970, string xc6e85c82d0d89508)
	{
		string result = xc6e85c82d0d89508;
		while (x7450cc1e48712286.MoveToNextAttribute())
		{
			if (xa66385d80d4d296f == xe8dc17d722705970)
			{
				result = x7450cc1e48712286.Value;
				break;
			}
		}
		x7450cc1e48712286.MoveToElement();
		return result;
	}

	public int xe8602379c60acf13(string xe8dc17d722705970, int xc6e85c82d0d89508)
	{
		string text = xd68abcd61e368af9(xe8dc17d722705970, null);
		if (text == null)
		{
			return xc6e85c82d0d89508;
		}
		return xca004f56614e2431.x59884ab46dd0d856(text);
	}

	public double x075a63114fe24ce9(string xe8dc17d722705970, double xc6e85c82d0d89508)
	{
		string text = xd68abcd61e368af9(xe8dc17d722705970, null);
		if (text == null)
		{
			return xc6e85c82d0d89508;
		}
		return xca004f56614e2431.xec25d08a2af152f0(text);
	}

	public bool x9c1302ecb6c4f3a2(string xe8dc17d722705970, bool xc6e85c82d0d89508)
	{
		string text = xd68abcd61e368af9(xe8dc17d722705970, null);
		if (text == null)
		{
			return xc6e85c82d0d89508;
		}
		return xeae765c206270ba2(text);
	}

	private bool xeae765c206270ba2(string xe4115acdf4fbfccc)
	{
		if (!(xe4115acdf4fbfccc == "1") && !(xe4115acdf4fbfccc == "true"))
		{
			return xe4115acdf4fbfccc == "t";
		}
		return true;
	}

	public Guid x291bb964d3760288(string xe8dc17d722705970, Guid xc6e85c82d0d89508)
	{
		string text = xd68abcd61e368af9(xe8dc17d722705970, null);
		if (text == null)
		{
			return xc6e85c82d0d89508;
		}
		return new Guid(text);
	}

	public bool x99f8cdb2827fa686()
	{
		return x7450cc1e48712286.MoveToElement();
	}

	public bool x1ac1960adc8c4c39()
	{
		return x1ac1960adc8c4c39(xf8a30dc03e702055: true);
	}

	public bool x1ac1960adc8c4c39(bool xf8a30dc03e702055)
	{
		while (x7450cc1e48712286.MoveToNextAttribute())
		{
			if (x7450cc1e48712286.Prefix != "xmlns" || !xf8a30dc03e702055)
			{
				return true;
			}
		}
		return false;
	}

	public string x2a1ea9d24e62bf84()
	{
		return x7450cc1e48712286.ReadString();
	}

	public int xab461f3453328cf7()
	{
		return xca004f56614e2431.x59884ab46dd0d856(x2a1ea9d24e62bf84());
	}

	public bool x0291058ae9d2ec36()
	{
		return xca004f56614e2431.xa0946eaa4f07cba1(x2a1ea9d24e62bf84());
	}

	public string x7a5890ace27d0288()
	{
		string result = x7450cc1e48712286.ReadOuterXml();
		while (x7450cc1e48712286.NodeType == XmlNodeType.Whitespace || x7450cc1e48712286.NodeType == XmlNodeType.Text)
		{
			x7450cc1e48712286.Read();
		}
		return result;
	}

	public string xadae1fe271161ea1(string x05bcae9c376a7a50)
	{
		return x7450cc1e48712286.LookupNamespace(x05bcae9c376a7a50);
	}
}
