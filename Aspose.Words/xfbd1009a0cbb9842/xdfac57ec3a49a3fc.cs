using System.Text;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class xdfac57ec3a49a3fc : x6ed66b5cf8da2955
{
	private string x8db51f27cf6e4cf1 = string.Empty;

	private string xc4b2a12ce9be39d4 = string.Empty;

	private string x56afea46213ac9fc = string.Empty;

	private string xbe39036341e55b02 = string.Empty;

	internal string x1d5cfa3bffdfb042
	{
		get
		{
			return x8db51f27cf6e4cf1;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x8db51f27cf6e4cf1 = value;
		}
	}

	internal string x2141cbc5929f5173
	{
		get
		{
			return xc4b2a12ce9be39d4;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xc4b2a12ce9be39d4 = value;
		}
	}

	internal string x3c9d02bc0fddd226
	{
		get
		{
			return x56afea46213ac9fc;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x56afea46213ac9fc = value;
		}
	}

	internal string x42f4c234c9358072
	{
		get
		{
			return xbe39036341e55b02;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xbe39036341e55b02 = value;
		}
	}

	internal string x58c712b0d1d1c39b => x0d4d45882065c63e.x60ea34a7657b9f8a(x1d5cfa3bffdfb042, x2141cbc5929f5173);

	internal xdfac57ec3a49a3fc()
	{
	}

	internal xdfac57ec3a49a3fc(string address, string subAddress, string screenTip, string target)
	{
		x1d5cfa3bffdfb042 = address;
		x2141cbc5929f5173 = subAddress;
		x3c9d02bc0fddd226 = screenTip;
		x42f4c234c9358072 = target;
	}

	internal static xdfac57ec3a49a3fc x1f490eac106aee12(string x0e59413709b18038)
	{
		xdfac57ec3a49a3fc xdfac57ec3a49a3fc2 = new xdfac57ec3a49a3fc();
		x985dd08fd338eeea x985dd08fd338eeea2 = new x985dd08fd338eeea(x0e59413709b18038, xdfac57ec3a49a3fc2);
		xdfac57ec3a49a3fc2.x1d5cfa3bffdfb042 = x985dd08fd338eeea2.x642e37025c67edab(0, x9fc40ce4428c62cc: true, xbd96676852fc71de: true);
		xdfac57ec3a49a3fc2.x2141cbc5929f5173 = x985dd08fd338eeea2.x6eba61762c5e83d7("\\l", xbd96676852fc71de: true);
		if (x985dd08fd338eeea2.xcc2d426b867d703d("\\n"))
		{
			xdfac57ec3a49a3fc2.x42f4c234c9358072 = "_blank";
		}
		xdfac57ec3a49a3fc2.x3c9d02bc0fddd226 = x985dd08fd338eeea2.x6eba61762c5e83d7("\\o", xbd96676852fc71de: true);
		xdfac57ec3a49a3fc2.x42f4c234c9358072 = x985dd08fd338eeea2.x6eba61762c5e83d7("\\t", xbd96676852fc71de: true);
		return xdfac57ec3a49a3fc2;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(" HYPERLINK ");
		if (x0d299f323d241756.x5959bccb67bbf051(x1d5cfa3bffdfb042))
		{
			stringBuilder.AppendFormat("{0} ", xb7dbd7bb3ed97d5b.x0b0647af7a5ab290(x1d5cfa3bffdfb042));
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x2141cbc5929f5173))
		{
			stringBuilder.AppendFormat("\\l {0} ", xb7dbd7bb3ed97d5b.xe8f643df16d085d9(x2141cbc5929f5173));
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x3c9d02bc0fddd226))
		{
			stringBuilder.AppendFormat("\\o {0} ", xb7dbd7bb3ed97d5b.xe8f643df16d085d9(x3c9d02bc0fddd226));
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x42f4c234c9358072))
		{
			stringBuilder.AppendFormat("\\t {0} ", xb7dbd7bb3ed97d5b.xe8f643df16d085d9(x42f4c234c9358072));
		}
		return stringBuilder.ToString();
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\m":
		case "\\n":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		case "\\l":
		case "\\o":
		case "\\t":
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
