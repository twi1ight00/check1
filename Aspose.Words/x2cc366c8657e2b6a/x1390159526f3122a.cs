using Aspose.Words.Markup;
using x1495530f35d79681;

namespace x2cc366c8657e2b6a;

internal class x1390159526f3122a
{
	private x1390159526f3122a()
	{
	}

	internal static CustomXmlMarkup x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, MarkupLevel x66bbd7ed8c65740d)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		CustomXmlMarkup customXmlMarkup = new CustomXmlMarkup(xe134235b3526fa75.x2c8c6741422a1298, x66bbd7ed8c65740d);
		customXmlMarkup.Element = x3bcd232d01c.xa66385d80d4d296f;
		customXmlMarkup.Uri = x3bcd232d01c.x91d35d7dc070c876;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			if (x3bcd232d01c.xa66385d80d4d296f == "placeholder" && x3bcd232d01c.x91d35d7dc070c876 == "http://schemas.microsoft.com/office/word/2003/wordml")
			{
				customXmlMarkup.Placeholder = x3bcd232d01c.xd2f68ee6f47e9dfb;
				continue;
			}
			CustomXmlProperty x46710263f0fedd = new CustomXmlProperty(x3bcd232d01c.xa66385d80d4d296f, x3bcd232d01c.x91d35d7dc070c876, x3bcd232d01c.xd2f68ee6f47e9dfb);
			customXmlMarkup.Properties.x1cd8943d02c5342f(x46710263f0fedd);
		}
		return customXmlMarkup;
	}
}
