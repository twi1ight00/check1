using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x7ada41eb09239afd : x6ed66b5cf8da2955
{
	private string x466efe2449ba68a6 = string.Empty;

	internal string xe5d13ccbc3df998a
	{
		get
		{
			return x466efe2449ba68a6;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x466efe2449ba68a6 = value;
		}
	}

	internal x7ada41eb09239afd()
	{
	}

	internal x7ada41eb09239afd(string progId)
	{
		xe5d13ccbc3df998a = progId;
	}

	internal static string xda09af88ab899a50(string x1fd8f5e5bbfdb602)
	{
		x7ada41eb09239afd x7ada41eb09239afd2 = new x7ada41eb09239afd(x1fd8f5e5bbfdb602);
		return x7ada41eb09239afd2.ToString();
	}

	internal static x7ada41eb09239afd x1f490eac106aee12(string x0e59413709b18038)
	{
		x7ada41eb09239afd x7ada41eb09239afd2 = new x7ada41eb09239afd();
		x985dd08fd338eeea x985dd08fd338eeea2 = new x985dd08fd338eeea(x0e59413709b18038, x7ada41eb09239afd2);
		x7ada41eb09239afd2.xe5d13ccbc3df998a = x985dd08fd338eeea2.x642e37025c67edab(0, x9fc40ce4428c62cc: true, xbd96676852fc71de: true);
		return x7ada41eb09239afd2;
	}

	public override string ToString()
	{
		return $" CONTROL {xe5d13ccbc3df998a} \\s ";
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		string text;
		if ((text = x724fbd227bfb6eda) != null && text == "\\s")
		{
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		}
		return x9f6b815e19fa8f62.xf6c17f648b65c793;
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}
}
