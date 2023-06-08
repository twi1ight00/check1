using System.Collections.Specialized;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x5af3f327d745698a;

internal class x3c332ff69b5b440d
{
	private readonly bool x0dfad4a2ac4c4b47;

	private readonly string xe2bba4c03e1779af;

	private readonly string x2744f4d61b605321;

	private readonly int xeddc4e207b3dc14d;

	internal bool x22ab5dfa6f12e902 => x0dfad4a2ac4c4b47;

	internal string x63f271b9608e0c03 => xe2bba4c03e1779af;

	internal string x7d8d2ed69d304345 => x2744f4d61b605321;

	internal int x44126f8c9ad27a03 => xeddc4e207b3dc14d;

	internal x3c332ff69b5b440d(byte[] metafileBytes)
	{
		x0dfad4a2ac4c4b47 = false;
		if (metafileBytes == null)
		{
			return;
		}
		StringCollection stringCollection = xdd1b8f14cc8ba86d.xdf30c5cd56940123(metafileBytes);
		switch (xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(metafileBytes))
		{
		default:
			return;
		case xfe2ff3c162b47c70.xb5fe04c34562f438:
			if (stringCollection.Count == 5)
			{
				stringCollection[1] += stringCollection[2];
				stringCollection.RemoveAt(2);
			}
			break;
		case xfe2ff3c162b47c70.xd69df86e2a88ddb2:
		{
			char c = stringCollection[3][0];
			c = (char)(c + 48);
			stringCollection[3] = new string(new char[1] { c });
			stringCollection.RemoveAt(4);
			break;
		}
		}
		if (!(stringCollection[0] != "IconOnly"))
		{
			if (stringCollection.Count > 1)
			{
				xe2bba4c03e1779af = stringCollection[1];
			}
			if (stringCollection.Count > 2)
			{
				x2744f4d61b605321 = stringCollection[2];
			}
			if (stringCollection.Count > 3)
			{
				xeddc4e207b3dc14d = xca004f56614e2431.xa93402510be8434e(stringCollection[3]);
			}
			x0dfad4a2ac4c4b47 = true;
		}
	}
}
