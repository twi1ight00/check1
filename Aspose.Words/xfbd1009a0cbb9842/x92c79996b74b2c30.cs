using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal class x92c79996b74b2c30 : x6ed66b5cf8da2955
{
	private int xe89e927f84ed6094;

	private string x8756913c23d46cb8 = string.Empty;

	private double x591696bcdf019c27;

	internal int xfea0b9f75f567474 => xe89e927f84ed6094;

	internal char xfb1fc02db7c42694 => (char)xe89e927f84ed6094;

	internal string x707c2bded9e130c2 => x8756913c23d46cb8;

	internal double x70c328f6f2e77d76 => x591696bcdf019c27;

	internal static x92c79996b74b2c30 x1f490eac106aee12(string x0e59413709b18038)
	{
		x92c79996b74b2c30 x92c79996b74b2c31 = new x92c79996b74b2c30();
		x985dd08fd338eeea x985dd08fd338eeea2 = new x985dd08fd338eeea(x0e59413709b18038, x92c79996b74b2c31);
		int num = xca004f56614e2431.x912616ee70b2d94d(x985dd08fd338eeea2.x642e37025c67edab(0, x9fc40ce4428c62cc: true, xbd96676852fc71de: true));
		if (num != int.MinValue)
		{
			x92c79996b74b2c31.xe89e927f84ed6094 = num;
		}
		x92c79996b74b2c31.x8756913c23d46cb8 = x985dd08fd338eeea2.x6eba61762c5e83d7("\\f", xbd96676852fc71de: true);
		double d = xca004f56614e2431.xf5ece46c5d72e3b9(x985dd08fd338eeea2.x6eba61762c5e83d7("\\s", xbd96676852fc71de: true));
		if (!double.IsNaN(d))
		{
			x92c79996b74b2c31.x591696bcdf019c27 = d;
		}
		return x92c79996b74b2c31;
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\a":
		case "\\h":
		case "\\j":
		case "\\u":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		case "\\f":
		case "\\s":
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
