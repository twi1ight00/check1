using System;
using System.Xml.Linq;

namespace SolrNet.Utils;

public static class X
{
	public static string ValueOrNull(this XAttribute attr)
	{
		return attr?.Value;
	}

	public static Func<XElement, bool> AttrEq(string name, string value)
	{
		return (XElement e) => e.Attribute(name).ValueOrNull() == value;
	}
}
