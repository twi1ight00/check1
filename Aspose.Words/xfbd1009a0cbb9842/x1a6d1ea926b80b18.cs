using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using x6c95d9cf46ff5f25;
using xe86f37adaccef1c3;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal class x1a6d1ea926b80b18 : Field, x6ed66b5cf8da2955, x64b01a877c5fd558
{
	private static readonly IDictionary xa6e82ce59d36e77d;

	internal bool xad31029fe055c0d7 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\d");

	internal string x1d1c717ddf6c8993 => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\c");

	internal string x208b504d129b06de => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\e");

	internal string x684b7efc38a273dc => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\f");

	internal string x609daf39d0822544 => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\l");

	string x64b01a877c5fd558.x5c6443ded0369839 => x684b7efc38a273dc;

	IDictionary x64b01a877c5fd558.xe731d6cec9a63042 => xa6e82ce59d36e77d;

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		xa11a4c48b53f49a6 xa11a4c48b53f49a = (xa11a4c48b53f49a6)base.x6edce55dcd2d335b.xc1acbb49fa87a8a3();
		if (xa11a4c48b53f49a != null)
		{
			xde99a4913041ec62 xde99a4913041ec63 = new xde99a4913041ec62(this, xa11a4c48b53f49a);
			return new xca592a476766b11a(this, xde99a4913041ec63.x04968c2c1f991c0e(), new x15d8a03b1db63b1e(applyToContainingField: false, removeParentParagraph: false));
		}
		return new xca592a476766b11a(this, "«AddressBlock»");
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\d":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		case "\\c":
		case "\\e":
		case "\\f":
		case "\\l":
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

	private Document x6fc9cf1a21adbc81()
	{
		return x357c90b33d6bb8e6();
	}

	Document x64b01a877c5fd558.x0e887c4fa8f397a5()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6fc9cf1a21adbc81
		return this.x6fc9cf1a21adbc81();
	}

	private string xa8e833ece84dedc4(x190443e12b0b496b x0f7b23d1c393aed9, x714b8c1b8d1b556b x37f3a555926e71c4)
	{
		string text = x0f7b23d1c393aed9.x193434603289be03(x37f3a555926e71c4.x759aa16c2016a289);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			return $"{x37f3a555926e71c4.xc0cc6aa8c5758ee8}{text}{x37f3a555926e71c4.x97586616c5ed2194}";
		}
		return string.Empty;
	}

	string x64b01a877c5fd558.x193434603289be03(x190443e12b0b496b x0f7b23d1c393aed9, x714b8c1b8d1b556b x37f3a555926e71c4)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa8e833ece84dedc4
		return this.xa8e833ece84dedc4(x0f7b23d1c393aed9, x37f3a555926e71c4);
	}

	static x1a6d1ea926b80b18()
	{
		xa6e82ce59d36e77d = xd51c34d05311eee3.xdb04a310bbb29cff();
		xa6e82ce59d36e77d.Add("TITLE0", "Courtesy Title");
		xa6e82ce59d36e77d.Add("NICK0", "Nickname");
		xa6e82ce59d36e77d.Add("FIRST0", "First Name");
		xa6e82ce59d36e77d.Add("MIDDLE0", "Middle Name");
		xa6e82ce59d36e77d.Add("LAST0", "Last Name");
		xa6e82ce59d36e77d.Add("SUFFIX0", "Suffix");
		xa6e82ce59d36e77d.Add("TITLE1", "Spouse Courtesy Title");
		xa6e82ce59d36e77d.Add("NICK1", "Spouse Nickname");
		xa6e82ce59d36e77d.Add("FIRST1", "Spouse First Name");
		xa6e82ce59d36e77d.Add("MIDDLE1", "Spouse Middle Name");
		xa6e82ce59d36e77d.Add("LAST1", "Spouse Last Name");
		xa6e82ce59d36e77d.Add("SUFFIX1", "Spouse Suffix");
		xa6e82ce59d36e77d.Add("COMPANY", "Company");
		xa6e82ce59d36e77d.Add("STREET1", "Address 1");
		xa6e82ce59d36e77d.Add("STREET2", "Address 2");
		xa6e82ce59d36e77d.Add("CITY", "City");
		xa6e82ce59d36e77d.Add("STATE", "State");
		xa6e82ce59d36e77d.Add("POSTAL", "Postal Code");
		xa6e82ce59d36e77d.Add("COUNTRY", "Country or Region");
	}
}
