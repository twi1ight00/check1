using System;
using System.IO;
using x6c95d9cf46ff5f25;

namespace xfc5388ad7dff404f;

internal class xa2f1c3dcbd86f20a
{
	private readonly string xc61ff88f1f98652d;

	private string x98e285df741c9d32;

	private Stream xa49cef274042e702;

	private readonly x13a141f958daf286 x7f99709808bf10f5;

	public string x759aa16c2016a289 => xc61ff88f1f98652d;

	public string x189167ca3b0a8e0b => Path.GetExtension(xc61ff88f1f98652d).TrimStart('.');

	public string x0b93856f95be30d0
	{
		get
		{
			return x98e285df741c9d32;
		}
		set
		{
			x98e285df741c9d32 = value;
		}
	}

	public Stream xb8a774e0111d0fbe
	{
		get
		{
			return xa49cef274042e702;
		}
		set
		{
			xa49cef274042e702 = value;
		}
	}

	public x13a141f958daf286 xadb7000bed559a9a => x7f99709808bf10f5;

	public xa2f1c3dcbd86f20a(string partName, string contentType)
	{
		x0d299f323d241756.x48501aec8e48c869(partName, "partName");
		xc61ff88f1f98652d = partName;
		x98e285df741c9d32 = contentType;
		xa49cef274042e702 = new MemoryStream();
		x7f99709808bf10f5 = new x13a141f958daf286(partName);
	}

	public void x8191cf2327af73cf(string xafe2f3653ee64ebc)
	{
		Stream xedc894794186020d = File.Create(xafe2f3653ee64ebc);
		try
		{
			xa49cef274042e702.Position = 0L;
			x0d299f323d241756.x3ad8e53785c39acd(xa49cef274042e702, xedc894794186020d);
			xa49cef274042e702.Position = 0L;
		}
		finally
		{
			xa49cef274042e702.Close();
		}
	}

	public string x052a6c2e603b1662(string xc06e652f250a3786)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xc06e652f250a3786))
		{
			return "";
		}
		x5b6f1954712b741f x5b6f1954712b741f2 = x7f99709808bf10f5.x212c1a2c5130b96e(xc06e652f250a3786);
		if (x5b6f1954712b741f2 == null)
		{
			return "";
		}
		if (x5b6f1954712b741f2.x0552da4f5c09bde5)
		{
			string text = x5b6f1954712b741f2.x42f4c234c9358072;
			if (text.StartsWith("file:///"))
			{
				text = text.Replace("file:///", "");
				text = x0d4d45882065c63e.x2fbbd6c36ce879ff(text);
			}
			return text;
		}
		if (x0d4d45882065c63e.xbf8774d82d777b9e(x5b6f1954712b741f2.x42f4c234c9358072))
		{
			return x5b6f1954712b741f2.x42f4c234c9358072;
		}
		return xa687196d807ab9c0(x5b6f1954712b741f2);
	}

	public string xa687196d807ab9c0(x5b6f1954712b741f x3203320ef44c211d)
	{
		if (x3203320ef44c211d.x0552da4f5c09bde5)
		{
			throw new InvalidOperationException("An internal target is expected here.");
		}
		return xada461b17cdccac0.x653bf8787d72d626(xc61ff88f1f98652d, x3203320ef44c211d.x42f4c234c9358072);
	}

	public MemoryStream x108ab3c765e78082()
	{
		return x0d299f323d241756.xbb72e91bbb228dbd(xa49cef274042e702);
	}
}
