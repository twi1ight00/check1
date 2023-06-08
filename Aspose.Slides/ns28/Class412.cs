using System.Xml;

namespace ns28;

internal class Class412 : Class369
{
	internal static readonly string[] string_0 = new string[15]
	{
		"generator", "title", "description", "subject", "keyword", "initial-creator", "creator", "printed-by", "creation-date", "date",
		"print-date", "editing-cycles", "editing-duration", "language", "object-count"
	};

	public Class412(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
		switch (localName)
		{
		case "title":
			((Class463)doc).class412_1 = this;
			break;
		case "generator":
			((Class463)doc).class412_0 = this;
			break;
		case "description":
			((Class463)doc).class412_2 = this;
			break;
		case "subject":
			((Class463)doc).class412_3 = this;
			break;
		case "keyword":
			((Class463)doc).class412_4 = this;
			break;
		case "initial-creator":
			((Class463)doc).class412_5 = this;
			break;
		case "creator":
			((Class463)doc).class412_6 = this;
			break;
		case "printed-by":
			((Class463)doc).class412_7 = this;
			break;
		case "creation-date":
			((Class463)doc).class412_8 = this;
			break;
		case "print-date":
			((Class463)doc).class412_10 = this;
			break;
		case "editing-cycles":
			((Class463)doc).class412_11 = this;
			break;
		case "editing-duration":
			((Class463)doc).class412_12 = this;
			break;
		case "language":
			((Class463)doc).class412_13 = this;
			break;
		case "object-count":
			((Class463)doc).class412_14 = this;
			break;
		case "date":
			((Class463)doc).class412_9 = this;
			break;
		}
	}
}
