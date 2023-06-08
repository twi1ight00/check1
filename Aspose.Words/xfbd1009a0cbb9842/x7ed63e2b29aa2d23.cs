using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal class x7ed63e2b29aa2d23 : Field, x6ed66b5cf8da2955
{
	private string x113ec0a83b1ef460;

	internal string x0e99a2a20bc3c647 => x113ec0a83b1ef460;

	internal override void x20aee281977480cf(FieldStart x10aaa7cdfa38f254, FieldSeparator x3de314ab70bbd9bf, FieldEnd xca09b6c2b5b18485)
	{
		base.x20aee281977480cf(x10aaa7cdfa38f254, x3de314ab70bbd9bf, xca09b6c2b5b18485);
		x1f490eac106aee12();
	}

	internal void x1f490eac106aee12()
	{
		x985dd08fd338eeea x985dd08fd338eeea2 = new x985dd08fd338eeea(this);
		x113ec0a83b1ef460 = x985dd08fd338eeea2.x642e37025c67edab(0);
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\f":
		case "\\h":
		case "\\p":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
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
