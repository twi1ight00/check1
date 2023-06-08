using System.Xml;

namespace x011d489fb9df7027;

internal class x5645a78cb658cd2d
{
	internal XmlAttribute xdb0ebfc0d169741e;

	internal bool x9a6a8577ab0646a4;

	internal x40136e0b18d3d4d5 x169b8a3bc8f77f64;

	internal object xd2f68ee6f47e9dfb;

	internal bool xdedd2a9303f28980
	{
		get
		{
			if (!(xdb0ebfc0d169741e.LocalName == "embed"))
			{
				return xdb0ebfc0d169741e.LocalName == "blip";
			}
			return true;
		}
	}

	internal bool x98a0056949b5f2bc => xdb0ebfc0d169741e.LocalName == "link";

	internal x5645a78cb658cd2d(XmlAttribute attr, object value)
		: this(attr, value, null)
	{
	}

	internal x5645a78cb658cd2d(XmlAttribute attr, object value, bool external)
		: this(attr, value, null)
	{
		x9a6a8577ab0646a4 = external;
	}

	internal x5645a78cb658cd2d(XmlAttribute attr, object value, x40136e0b18d3d4d5 relatedDataCollection)
	{
		xdb0ebfc0d169741e = attr;
		xd2f68ee6f47e9dfb = value;
		x169b8a3bc8f77f64 = relatedDataCollection;
	}
}
