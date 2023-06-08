using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class xb7fab88ef0a63baf : x6ed66b5cf8da2955
{
	private string xecea29caa71c189c = string.Empty;

	private bool x2954df6071c3af37;

	internal string x9f8e4dc805c6986e
	{
		get
		{
			return xecea29caa71c189c;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xecea29caa71c189c = value;
		}
	}

	internal bool x66b8b219d7a8c7b2
	{
		get
		{
			return x2954df6071c3af37;
		}
		set
		{
			x2954df6071c3af37 = value;
		}
	}

	internal static xb7fab88ef0a63baf x1f490eac106aee12(string x0e59413709b18038)
	{
		xb7fab88ef0a63baf xb7fab88ef0a63baf2 = new xb7fab88ef0a63baf();
		x985dd08fd338eeea x985dd08fd338eeea2 = new x985dd08fd338eeea(x0e59413709b18038, xb7fab88ef0a63baf2);
		xb7fab88ef0a63baf2.x9f8e4dc805c6986e = x985dd08fd338eeea2.x642e37025c67edab(0, x9fc40ce4428c62cc: true, xbd96676852fc71de: true);
		xb7fab88ef0a63baf2.x66b8b219d7a8c7b2 = x985dd08fd338eeea2.xcc2d426b867d703d("\\d");
		return xb7fab88ef0a63baf2;
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		return x724fbd227bfb6eda switch
		{
			"\\c" => x9f6b815e19fa8f62.x47e3e032f7bd5d28, 
			"\\d" => x9f6b815e19fa8f62.x8416ed4b8ffb3e34, 
			_ => x9f6b815e19fa8f62.xf6c17f648b65c793, 
		};
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}
}
