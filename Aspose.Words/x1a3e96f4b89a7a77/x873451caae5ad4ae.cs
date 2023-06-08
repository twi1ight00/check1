using System;
using System.IO;
using System.Text;
using Aspose;
using Aspose.Words;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x7c7a1dceb600404e;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace x1a3e96f4b89a7a77;

internal class x873451caae5ad4ae : x3c74b3c4f21844f9
{
	private readonly bool x09405ec9a449f284;

	private int x68936f0cacd103a9;

	internal virtual bool xa35b0cf71c822836 => false;

	internal bool xac094da7bd5cf4c8 => x68936f0cacd103a9 > 0;

	public x873451caae5ad4ae(Stream stream, Encoding encoding, bool isPrettyFormat, bool useOnOff)
		: base(stream, encoding, isPrettyFormat)
	{
		x09405ec9a449f284 = useOnOff;
	}

	internal void x547195bcc386fe66(string x121383aa64985888, object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == null)
		{
			return;
		}
		if (xbcea506a33cf9111 is bool xbcea506a33cf9112)
		{
			x547195bcc386fe66(x121383aa64985888, xbcea506a33cf9112);
			return;
		}
		if (xbcea506a33cf9111 is string)
		{
			string xbcea506a33cf9113 = (string)xbcea506a33cf9111;
			x547195bcc386fe66(x121383aa64985888, xbcea506a33cf9113);
			return;
		}
		if (xbcea506a33cf9111 is int xbcea506a33cf9114)
		{
			x547195bcc386fe66(x121383aa64985888, xbcea506a33cf9114);
			return;
		}
		if (xbcea506a33cf9111 is x26d9ecb4bdf0456d)
		{
			x26d9ecb4bdf0456d xbcea506a33cf9115 = (x26d9ecb4bdf0456d)xbcea506a33cf9111;
			x547195bcc386fe66(x121383aa64985888, xbcea506a33cf9115);
			return;
		}
		throw new InvalidOperationException("Unknown object type in the WriteVal method.");
	}

	internal void x547195bcc386fe66(string x121383aa64985888, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			x2307058321cdb62f(x121383aa64985888);
			xff520a0047c27122(xaf38cbe298c3d296(x121383aa64985888) + "val", xbcea506a33cf9111);
			x2dfde153f4ef96d0();
		}
	}

	internal void xa639a651da945648(string x121383aa64985888, string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null)
		{
			x2307058321cdb62f(x121383aa64985888);
			xff520a0047c27122(xaf38cbe298c3d296(x121383aa64985888) + "val", xbcea506a33cf9111);
			x2dfde153f4ef96d0();
		}
	}

	internal void x7ca1f53fecbf2ab4(string x121383aa64985888, string xbcea506a33cf9111)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kgojkjfkhjmkfidlkiklkibmliimjhpmfhgnocnnpheohhlofccpjhjpbhaafghangoalffbdbmbbfdcnakcifbdmfidafpdnegeopmekeefkelffpbghdjgmdahmdhhndohpdfidoligddjobkjgcbkmcikjbpknnflommlnaemnblmjbcncminiaaoabhojlnoppepgampalcappjapoabiphbjpobkofcapmcaoddmnkdfjbedniecnpepmgfinnfineghmlgjmchlmjhbmaihhhiimoiamfjogmjpldkalkkkkblcgilclplpjgmbknmljenaklnbjcolfjo", 252747305)));
		}
		x547195bcc386fe66(x121383aa64985888, xbcea506a33cf9111);
	}

	internal void x547195bcc386fe66(string x121383aa64985888, x26d9ecb4bdf0456d xbcea506a33cf9111)
	{
		x547195bcc386fe66(x121383aa64985888, xc1b08afa36bf580c.xfb8d75f850ffd0e7(xbcea506a33cf9111));
	}

	internal void x547195bcc386fe66(string x121383aa64985888, int xbcea506a33cf9111)
	{
		x547195bcc386fe66(x121383aa64985888, xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf9111));
	}

	internal void x547195bcc386fe66(string x121383aa64985888, byte[] xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null && xbcea506a33cf9111.Length > 0)
		{
			x547195bcc386fe66(x121383aa64985888, xc1b08afa36bf580c.x5f36f04871c53347(xbcea506a33cf9111));
		}
	}

	internal void x67aa7400b293b13a(string x121383aa64985888, int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 > 0)
		{
			x547195bcc386fe66(x121383aa64985888, xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf9111));
		}
	}

	internal virtual void x547195bcc386fe66(string x121383aa64985888, bool xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111)
		{
			xf68f9c3818e1f4b1(x121383aa64985888);
		}
		else
		{
			x547195bcc386fe66(x121383aa64985888, "off");
		}
	}

	internal void x9601fe92a1b73d3f(string x121383aa64985888, bool xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111)
		{
			xf68f9c3818e1f4b1(x121383aa64985888);
		}
	}

	internal void x24f8794502b580ff(string x121383aa64985888, int xbcea506a33cf9111, int xc6e85c82d0d89508)
	{
		if (xbcea506a33cf9111 != xc6e85c82d0d89508)
		{
			x547195bcc386fe66(x121383aa64985888, xbcea506a33cf9111);
		}
	}

	internal void xc049ea80ee267201(string x121383aa64985888, params object[] x172a1403be5e4c63)
	{
		if (x4122f10182ac673a(x121383aa64985888, x172a1403be5e4c63))
		{
			x2dfde153f4ef96d0();
		}
	}

	internal bool x4122f10182ac673a(string x121383aa64985888, params object[] x172a1403be5e4c63)
	{
		int num = x172a1403be5e4c63.Length / 2;
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			object obj = x172a1403be5e4c63[i * 2 + 1];
			if (obj != null && (!(obj is string) || !((string)obj == "")))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return false;
		}
		x2307058321cdb62f(x121383aa64985888);
		for (int j = 0; j < num; j++)
		{
			string x9e89cc6e6284edf = (string)x172a1403be5e4c63[j * 2];
			object xbcea506a33cf = x172a1403be5e4c63[j * 2 + 1];
			x943f6be3acf634db(x9e89cc6e6284edf, xbcea506a33cf);
		}
		return true;
	}

	internal void x31389f0c752f577e(string x9e89cc6e6284edf4, object xbcea506a33cf9111, object xc6e85c82d0d89508)
	{
		if (xbcea506a33cf9111 != null && !xbcea506a33cf9111.Equals(xc6e85c82d0d89508))
		{
			xfb5ff561cb1d5db2(x9e89cc6e6284edf4, xbcea506a33cf9111);
		}
	}

	internal void xfb5ff561cb1d5db2(string x9e89cc6e6284edf4, object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 is bool)
		{
			x943f6be3acf634db(x9e89cc6e6284edf4, ((bool)xbcea506a33cf9111) ? "t" : "f");
		}
		else if (xbcea506a33cf9111 is x26d9ecb4bdf0456d)
		{
			x943f6be3acf634db(x9e89cc6e6284edf4, xd76179d16486fd56.xbe7cce711e45fa32((x26d9ecb4bdf0456d)xbcea506a33cf9111));
		}
		else
		{
			x943f6be3acf634db(x9e89cc6e6284edf4, xbcea506a33cf9111);
		}
	}

	internal void x31389f0c752f577e(string x9e89cc6e6284edf4, bool xbcea506a33cf9111, bool xc6e85c82d0d89508)
	{
		if (xbcea506a33cf9111 != xc6e85c82d0d89508)
		{
			xff520a0047c27122(x9e89cc6e6284edf4, xbcea506a33cf9111 ? "t" : "f");
		}
	}

	internal void x943f6be3acf634db(string x9e89cc6e6284edf4, object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == null)
		{
			return;
		}
		if (xbcea506a33cf9111 is string)
		{
			string xbcea506a33cf9112 = (string)xbcea506a33cf9111;
			x943f6be3acf634db(x9e89cc6e6284edf4, xbcea506a33cf9112);
			return;
		}
		if (xbcea506a33cf9111 is int xbcea506a33cf9113)
		{
			x943f6be3acf634db(x9e89cc6e6284edf4, xbcea506a33cf9113);
			return;
		}
		if (xbcea506a33cf9111 is double xbcea506a33cf9114)
		{
			x943f6be3acf634db(x9e89cc6e6284edf4, xbcea506a33cf9114);
			return;
		}
		if (xbcea506a33cf9111 is bool xbcea506a33cf9115)
		{
			x943f6be3acf634db(x9e89cc6e6284edf4, xbcea506a33cf9115);
			return;
		}
		if (xbcea506a33cf9111 is x26d9ecb4bdf0456d)
		{
			x26d9ecb4bdf0456d x6c50a99faab7d = (x26d9ecb4bdf0456d)xbcea506a33cf9111;
			x943f6be3acf634db(x9e89cc6e6284edf4, xc1b08afa36bf580c.xfb8d75f850ffd0e7(x6c50a99faab7d));
			return;
		}
		if (xbcea506a33cf9111 is DateTime xbcea506a33cf9116)
		{
			x943f6be3acf634db(x9e89cc6e6284edf4, xca004f56614e2431.x6efbf9d15154c80d(xbcea506a33cf9116));
			return;
		}
		throw new InvalidOperationException("Unknown object type in WriteAttribute method.");
	}

	internal void x943f6be3acf634db(string x9e89cc6e6284edf4, object xbcea506a33cf9111, object xc6e85c82d0d89508)
	{
		if (xbcea506a33cf9111 == null)
		{
			xbcea506a33cf9111 = xc6e85c82d0d89508;
		}
		x943f6be3acf634db(x9e89cc6e6284edf4, xbcea506a33cf9111);
	}

	internal void x943f6be3acf634db(string x9e89cc6e6284edf4, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			xff520a0047c27122(x9e89cc6e6284edf4, xbcea506a33cf9111);
		}
	}

	internal void x25e28424582ee3ac(string x9e89cc6e6284edf4, string xbcea506a33cf9111, string xc6e85c82d0d89508)
	{
		if (xbcea506a33cf9111 != xc6e85c82d0d89508)
		{
			x943f6be3acf634db(x9e89cc6e6284edf4, xbcea506a33cf9111);
		}
	}

	internal void x943f6be3acf634db(string x9e89cc6e6284edf4, x26d9ecb4bdf0456d xbcea506a33cf9111)
	{
		xff520a0047c27122(x9e89cc6e6284edf4, xc1b08afa36bf580c.xfb8d75f850ffd0e7(xbcea506a33cf9111));
	}

	internal void x943f6be3acf634db(string x9e89cc6e6284edf4, int xbcea506a33cf9111)
	{
		xff520a0047c27122(x9e89cc6e6284edf4, xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf9111));
	}

	internal void x943f6be3acf634db(string x9e89cc6e6284edf4, byte[] xbcea506a33cf9111)
	{
		xff520a0047c27122(x9e89cc6e6284edf4, xc1b08afa36bf580c.x5f36f04871c53347(xbcea506a33cf9111));
	}

	internal void x943f6be3acf634db(string x9e89cc6e6284edf4, double xbcea506a33cf9111)
	{
		xff520a0047c27122(x9e89cc6e6284edf4, xca004f56614e2431.xdbca7a004e2d3753(xbcea506a33cf9111));
	}

	internal virtual void x943f6be3acf634db(string x9e89cc6e6284edf4, bool xbcea506a33cf9111)
	{
		if (x09405ec9a449f284)
		{
			xff520a0047c27122(x9e89cc6e6284edf4, xbcea506a33cf9111 ? "on" : "off");
		}
		else
		{
			xff520a0047c27122(x9e89cc6e6284edf4, xbcea506a33cf9111 ? "true" : "false");
		}
	}

	internal virtual void x0ea3ef8dd3ae2f3f(string x9e89cc6e6284edf4, bool xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111)
		{
			xff520a0047c27122(x9e89cc6e6284edf4, x09405ec9a449f284 ? "on" : "true");
		}
	}

	protected static object xee995edcf4ac3ea8(bool xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111)
		{
			return xbcea506a33cf9111;
		}
		return null;
	}

	private static string xaf38cbe298c3d296(string xc15bd84e01929885)
	{
		int num = xc15bd84e01929885.IndexOf(':');
		if (num > 0)
		{
			return xc15bd84e01929885.Substring(0, num + 1);
		}
		return "";
	}

	internal void xa653462abd146df5(string x121383aa64985888, params object[] x73d4d69be68103fe)
	{
		int num = x73d4d69be68103fe.Length / 2;
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			Border border = (Border)x73d4d69be68103fe[i * 2 + 1];
			if (border != null && !border.xa157de8185757b11)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			x2307058321cdb62f(x121383aa64985888);
			for (int j = 0; j < num; j++)
			{
				x7bb3fbb369864bd2((string)x73d4d69be68103fe[j * 2], (Border)x73d4d69be68103fe[j * 2 + 1]);
			}
			x2dfde153f4ef96d0();
		}
	}

	internal void x7bb3fbb369864bd2(string x121383aa64985888, Border x14cf9593b86ecbaa)
	{
		if (x14cf9593b86ecbaa != null && !x14cf9593b86ecbaa.xa157de8185757b11)
		{
			if (x14cf9593b86ecbaa.LineStyle == LineStyle.None)
			{
				xc049ea80ee267201(x121383aa64985888, "w:val", "nil");
			}
			else
			{
				WriteBorderCore(x121383aa64985888, x14cf9593b86ecbaa);
			}
		}
	}

	[JavaThrows(true)]
	protected virtual void WriteBorderCore(string elementName, Border border)
	{
	}

	[JavaThrows(true)]
	internal virtual void xbcea76c28b5e9461(Shading x12b7f8e5698b30a6)
	{
	}

	internal void xcdbc678d36159c69(string x121383aa64985888, string x961016a387451f05)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(x961016a387451f05))
		{
			xcdbc678d36159c69(x121383aa64985888, x961016a387451f05, "dxa");
		}
	}

	protected void xcdbc678d36159c69(string x121383aa64985888, string xbcea506a33cf9111, string x43163d22e8cd5a71)
	{
		xc049ea80ee267201(x121383aa64985888, "w:w", xbcea506a33cf9111, "w:type", x43163d22e8cd5a71);
	}

	internal void x99a8871fc05f6874(string x121383aa64985888, string x60e3d97b97bb8c4b, string xc790aa4ad151a9a1, string xbec4ce2ebab55739, string x9d14ae04d4852341)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(x60e3d97b97bb8c4b) || x0d299f323d241756.x5959bccb67bbf051(xc790aa4ad151a9a1) || x0d299f323d241756.x5959bccb67bbf051(xbec4ce2ebab55739) || x0d299f323d241756.x5959bccb67bbf051(x9d14ae04d4852341))
		{
			x2307058321cdb62f(x121383aa64985888);
			xcdbc678d36159c69("w:top", x60e3d97b97bb8c4b);
			xcdbc678d36159c69("w:left", xc790aa4ad151a9a1);
			xcdbc678d36159c69("w:bottom", xbec4ce2ebab55739);
			xcdbc678d36159c69("w:right", x9d14ae04d4852341);
			x2dfde153f4ef96d0();
		}
	}

	internal void xad600da2051d6341(string x9e89cc6e6284edf4, string x08db3aeabb253cb1, string x1e218ceaee1bb583)
	{
		x943f6be3acf634db(x9e89cc6e6284edf4, $"{x08db3aeabb253cb1},{x1e218ceaee1bb583}".TrimEnd(','));
	}

	internal void xad600da2051d6341(string x9e89cc6e6284edf4, string x08db3aeabb253cb1, string x1e218ceaee1bb583, string x8cfbc105c29e356f)
	{
		x943f6be3acf634db(x9e89cc6e6284edf4, $"{x08db3aeabb253cb1},{x1e218ceaee1bb583},{x8cfbc105c29e356f}".TrimEnd(','));
	}

	internal void xcdbc678d36159c69(string x121383aa64985888, PreferredWidth x961016a387451f05)
	{
		if (x961016a387451f05 != null)
		{
			xcdbc678d36159c69(x121383aa64985888, xca004f56614e2431.x754c3a5f03a2ce84(x961016a387451f05.x7680505e84ce0354), x72a0c846678ecaf9.xf2767340c03bd9ec(x961016a387451f05.Type));
		}
	}

	[JavaThrows(true)]
	internal virtual void xd0c5f01ab55153ce(x5fb16e270c21db2e xde2016e90885f436, string x121383aa64985888, int xeaf1b27180c0557b)
	{
		throw new NotImplementedException("Concrete classes should implement.");
	}

	[JavaThrows(true)]
	internal virtual void xd0c5f01ab55153ce(xc1b2bac943a0f541 xde2016e90885f436, int xeaf1b27180c0557b)
	{
		throw new NotImplementedException("Concrete classes should implement.");
	}

	[JavaThrows(true)]
	internal virtual void x44d8d13f25d44840()
	{
		throw new NotImplementedException("Concrete classes should implement.");
	}

	[JavaThrows(true)]
	internal virtual void xb24134df8aeb5772(x978620a99b6d5014 xde2016e90885f436, int xeaf1b27180c0557b)
	{
		throw new NotImplementedException("Concrete classes should implement.");
	}

	[JavaThrows(true)]
	internal virtual void xb24134df8aeb5772(xc1b2bac943a0f541 xde2016e90885f436, int xeaf1b27180c0557b)
	{
		throw new NotImplementedException("Concrete classes should implement.");
	}

	internal void xb60ac95f9b746ba1()
	{
		x68936f0cacd103a9++;
	}

	internal void xfb4fa7dc975137f4()
	{
		x68936f0cacd103a9--;
	}
}
