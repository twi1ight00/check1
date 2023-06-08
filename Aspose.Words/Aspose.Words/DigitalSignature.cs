using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Aspose.Words;

public class DigitalSignature
{
	private readonly DigitalSignatureType x5b367242ed92a496;

	private X509Certificate2 xaf0495c401b3e1bb;

	private DateTime x498b49e5a7342f1c;

	private string xb987d0d97b770ddc;

	private bool x0dfad4a2ac4c4b47;

	private bool xb864d714ac2f7c4e;

	private readonly ArrayList x0a18a6cfb4c1b981 = new ArrayList();

	private byte[] x262034d5fec7782b;

	private byte[] x5a0225b53720c22f;

	private byte[] x9d1cfd6826d69de5;

	private string xed4a7b1500064e12;

	private Guid xa4e17c033d7ba0d1;

	private Guid xa84639e0253d4d04;

	private bool x1770d8ea6a4264e4;

	public DigitalSignatureType SignatureType => x5b367242ed92a496;

	public DateTime SignTime => x498b49e5a7342f1c;

	public string Comments => xb987d0d97b770ddc;

	public bool IsValid => x0dfad4a2ac4c4b47;

	public X509Certificate2 Certificate => xaf0495c401b3e1bb;

	internal bool xb515b28da60b35db
	{
		get
		{
			return xb864d714ac2f7c4e;
		}
		set
		{
			xb864d714ac2f7c4e = value;
		}
	}

	internal ArrayList xdf0c8cea9b2d73a3 => x0a18a6cfb4c1b981;

	internal byte[] xcc18177a965e0313
	{
		get
		{
			return x262034d5fec7782b;
		}
		set
		{
			x262034d5fec7782b = value;
		}
	}

	internal byte[] xfb5048ebfc118445
	{
		get
		{
			return x5a0225b53720c22f;
		}
		set
		{
			x5a0225b53720c22f = value;
		}
	}

	internal byte[] x96b293f7587d2033
	{
		get
		{
			return x9d1cfd6826d69de5;
		}
		set
		{
			x9d1cfd6826d69de5 = value;
		}
	}

	internal bool x5c9e4e2dc9b12067
	{
		get
		{
			return x1770d8ea6a4264e4;
		}
		set
		{
			x1770d8ea6a4264e4 = value;
		}
	}

	internal string xf9ad6fb78355fe13
	{
		get
		{
			return xed4a7b1500064e12;
		}
		set
		{
			xed4a7b1500064e12 = value;
		}
	}

	internal Guid x7c739bac7cd13266
	{
		get
		{
			return xa4e17c033d7ba0d1;
		}
		set
		{
			xa4e17c033d7ba0d1 = value;
		}
	}

	internal Guid x0d25a466d9b78572
	{
		get
		{
			return xa84639e0253d4d04;
		}
		set
		{
			xa84639e0253d4d04 = value;
		}
	}

	internal DigitalSignature(DigitalSignatureType sigType)
	{
		x5b367242ed92a496 = sigType;
		x498b49e5a7342f1c = DateTime.MinValue;
		xb987d0d97b770ddc = "";
	}

	internal void x2da4bc39c98a8695(DateTime x0fefd6e3b0eb0ba9)
	{
		x498b49e5a7342f1c = x0fefd6e3b0eb0ba9;
	}

	internal void xafe9b6061e340c76(string x540a9eb552a13d7b)
	{
		xb987d0d97b770ddc = x540a9eb552a13d7b;
	}

	internal void xb84489d1134cdb3c(bool x7d95d971d8923f4c)
	{
		x0dfad4a2ac4c4b47 = x7d95d971d8923f4c;
	}

	internal void xb126629734b482a4(X509Certificate2 x93bf26bc80edc72e)
	{
		xaf0495c401b3e1bb = x93bf26bc80edc72e;
	}
}
