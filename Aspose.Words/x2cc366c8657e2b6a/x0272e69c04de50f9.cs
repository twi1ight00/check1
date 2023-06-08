using System.Collections;
using System.IO;
using Aspose.Words;
using x0a300997a0b66409;
using x1495530f35d79681;

namespace x2cc366c8657e2b6a;

internal class x0272e69c04de50f9 : x3c85359e1389ad43
{
	private static readonly Hashtable x454d7c73a18a4116;

	internal override bool x57b319ed721a743d => (string)x454d7c73a18a4116[base.xd8a1c7c41bfbcde0] == base.x91d35d7dc070c876;

	static x0272e69c04de50f9()
	{
		x454d7c73a18a4116 = new Hashtable();
		x454d7c73a18a4116.Add("aml", "http://schemas.microsoft.com/aml/2001/core");
		x454d7c73a18a4116.Add("wx", "http://schemas.microsoft.com/office/word/2003/auxHint");
		x454d7c73a18a4116.Add("dt", "uuid:C2F41010-65B3-11d1-A29F-00AA00C14882");
		x454d7c73a18a4116.Add("sl", "http://schemas.microsoft.com/schemaLibrary/2003/core");
		x454d7c73a18a4116.Add("w", "http://schemas.microsoft.com/office/word/2003/wordml");
		x454d7c73a18a4116.Add("wsp", "http://schemas.microsoft.com/office/word/2003/wordml/sp2");
		x454d7c73a18a4116.Add("o", "urn:schemas-microsoft-com:office:office");
		x454d7c73a18a4116.Add("v", "urn:schemas-microsoft-com:vml");
		x454d7c73a18a4116.Add("w10", "urn:schemas-microsoft-com:office:word");
	}

	internal x0272e69c04de50f9(Stream stream)
		: base(stream)
	{
	}

	internal x0272e69c04de50f9(Stream stream, IWarningCallback warningCallback, WarningSource warningSource)
		: base(stream, warningCallback, warningSource)
	{
	}

	protected override LineStyle ReadLineStyle()
	{
		return x0beb84bbfae8adcf.x48cc497618505668(base.xd2f68ee6f47e9dfb);
	}
}
