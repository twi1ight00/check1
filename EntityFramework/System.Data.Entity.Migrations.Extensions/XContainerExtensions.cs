using System.Xml.Linq;

namespace System.Data.Entity.Migrations.Extensions;

internal static class XContainerExtensions
{
	public static XElement GetOrAddElement(this XContainer container, XName name)
	{
		XElement xElement = container.Element(name);
		if (xElement == null)
		{
			xElement = new XElement(name);
			container.Add(xElement);
		}
		return xElement;
	}
}
