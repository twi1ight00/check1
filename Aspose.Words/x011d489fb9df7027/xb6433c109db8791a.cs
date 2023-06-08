using System.Drawing;
using System.Xml;
using Aspose.Words;
using Aspose.Words.Drawing;
using x5794c252ba25e723;
using x996431aaaaf00543;

namespace x011d489fb9df7027;

internal class xb6433c109db8791a : x1709225c4bd1ed83
{
	private readonly DrawingML x61f18ca85b7c2226;

	private readonly x8e500baeffc6e539 xbf762ca9cde15360;

	public xb6433c109db8791a(DrawingML drawingML)
	{
		x61f18ca85b7c2226 = drawingML;
		xbf762ca9cde15360 = new x8e500baeffc6e539((Document)drawingML.Document, new xc349e998e159a27c(x61f18ca85b7c2226));
	}

	public string x052a6c2e603b1662(string xc06e652f250a3786)
	{
		return (string)x950e0224ef8e59be(xc06e652f250a3786);
	}

	public byte[] x3e0c39f372c8f2f9(string xc06e652f250a3786)
	{
		return (byte[])x950e0224ef8e59be(xc06e652f250a3786);
	}

	public XmlDocument x7e9143f4af321ab1(string xc06e652f250a3786)
	{
		return (XmlDocument)x950e0224ef8e59be(xc06e652f250a3786);
	}

	public byte[] xe7ea3b1eeee820e4(string xc06e652f250a3786)
	{
		string xafe2f3653ee64ebc = x052a6c2e603b1662(xc06e652f250a3786);
		return xbf762ca9cde15360.x096dc407252fbea0(xafe2f3653ee64ebc);
	}

	public xe39d06eee35dd23d xdc2247c8d4648ae8(string xa79a9f649c74f4a4, float xa03db8a5ee939042, FontStyle x44ecfea61c937b8e)
	{
		return x61f18ca85b7c2226.Document.FontInfos.x26ee10d60756aeab.x491f5a7224612753(xa79a9f649c74f4a4, xa03db8a5ee939042, x44ecfea61c937b8e);
	}

	private object x950e0224ef8e59be(string xc06e652f250a3786)
	{
		return x950e0224ef8e59be(xc06e652f250a3786, x61f18ca85b7c2226.x169b8a3bc8f77f64);
	}

	private static object x950e0224ef8e59be(string xc06e652f250a3786, x40136e0b18d3d4d5 x4db5bf504666828e)
	{
		foreach (x5645a78cb658cd2d item in x4db5bf504666828e)
		{
			if (xc06e652f250a3786 == item.xdb0ebfc0d169741e.Value)
			{
				return item.xd2f68ee6f47e9dfb;
			}
			if (item.x169b8a3bc8f77f64 != null)
			{
				object obj = x950e0224ef8e59be(xc06e652f250a3786, item.x169b8a3bc8f77f64);
				if (obj != null)
				{
					return obj;
				}
			}
		}
		return null;
	}
}
