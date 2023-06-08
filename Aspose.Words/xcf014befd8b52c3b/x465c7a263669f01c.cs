using System.Collections;
using x643046e3f004c49f;

namespace xcf014befd8b52c3b;

internal class x465c7a263669f01c
{
	private readonly ArrayList x0a5d45e5b91b3fd4 = new ArrayList();

	private string x85672ef2a158d360;

	private string x503f7b27668b4fc6;

	private bool x0dfad4a2ac4c4b47;

	internal string xb405a444ca77e2d4
	{
		get
		{
			return x85672ef2a158d360;
		}
		set
		{
			x85672ef2a158d360 = value;
		}
	}

	internal string x759aa16c2016a289 => xc1c50fc311d52fdf.x7661afba8cc0ba23(x85672ef2a158d360).Split('?')[0];

	internal string xdf22e372ee592a9e
	{
		get
		{
			return x503f7b27668b4fc6;
		}
		set
		{
			x503f7b27668b4fc6 = value;
		}
	}

	internal ArrayList x31d70360be76ba60 => x0a5d45e5b91b3fd4;

	internal bool x0552da4f5c09bde5 => !x85672ef2a158d360.StartsWith("#");

	internal bool x22ab5dfa6f12e902
	{
		get
		{
			return x0dfad4a2ac4c4b47;
		}
		set
		{
			x0dfad4a2ac4c4b47 = value;
		}
	}

	internal x465c7a263669f01c(string uri, ArrayList transformCollection, string digestValue)
	{
		x85672ef2a158d360 = uri;
		x0a5d45e5b91b3fd4 = transformCollection;
		x503f7b27668b4fc6 = digestValue;
	}
}
