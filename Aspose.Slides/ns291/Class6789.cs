using System;
using System.IO;
using System.Text;
using System.Xml;
using ns277;

namespace ns291;

internal class Class6789 : XmlUrlResolver
{
	private const string string_0 = "http://www.w3.org/TR/xhtml1/DTD/xhtml-lat1.ent";

	private const string string_1 = "http://www.w3.org/TR/xhtml1/DTD/xhtml-special.ent";

	private const string string_2 = "http://www.w3.org/TR/xhtml1/DTD/xhtml-symbol.ent";

	public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
	{
		if (absoluteUri.ToString().Equals("http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd", StringComparison.OrdinalIgnoreCase))
		{
			return new MemoryStream(Encoding.UTF8.GetBytes(Class6765.xhtml1_transitional));
		}
		if (absoluteUri.ToString().Equals("http://www.w3.org/TR/xhtml1/DTD/xhtml-lat1.ent", StringComparison.OrdinalIgnoreCase))
		{
			return new MemoryStream(Class6765.xhtml_lat1);
		}
		if (absoluteUri.ToString().Equals("http://www.w3.org/TR/xhtml1/DTD/xhtml-special.ent", StringComparison.OrdinalIgnoreCase))
		{
			return new MemoryStream(Class6765.xhtml_special);
		}
		if (absoluteUri.ToString().Equals("http://www.w3.org/TR/xhtml1/DTD/xhtml-symbol.ent", StringComparison.OrdinalIgnoreCase))
		{
			return new MemoryStream(Class6765.xhtml_symbol);
		}
		return base.GetEntity(absoluteUri, role, ofObjectToReturn);
	}
}
