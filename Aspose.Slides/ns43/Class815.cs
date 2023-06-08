using System.Xml;
using ns42;

namespace ns43;

internal class Class815 : Class810
{
	internal static readonly string string_1 = "row";

	internal int RowIndex
	{
		get
		{
			if (method_57("r", "") != null)
			{
				return method_11("r", "", 0);
			}
			return 0;
		}
		set
		{
			method_13("r", "", value);
		}
	}

	internal bool IsHidden
	{
		get
		{
			return method_20("hidden", "", defaultValue: false);
		}
		set
		{
			method_21("hidden", "", value);
		}
	}

	public Class815(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
