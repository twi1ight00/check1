using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal class xf4d6002ce6b6b245 : Field, x6ed66b5cf8da2955
{
	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\b":
		case "\\i":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		case "\\f":
		case "\\r":
		case "\\t":
		case "\\y":
			return x9f6b815e19fa8f62.x47e3e032f7bd5d28;
		default:
			return x9f6b815e19fa8f62.xf6c17f648b65c793;
		}
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}
}
