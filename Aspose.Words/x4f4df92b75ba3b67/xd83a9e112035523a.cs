using System;

namespace x4f4df92b75ba3b67;

internal class xd83a9e112035523a : x264ba3b7aca691be
{
	private string x797649178933822e;

	private string xc9c94625dd81f95e;

	private string x2ea205893aecb323;

	private string xe93eef819d0ce5ad;

	private string xc539d78cbe7328ff;

	private string xd6909232d2af772c;

	private string xc61ff88f1f98652d;

	private DateTime xca33054605efbc20 = DateTime.MinValue;

	private string x1a1d81c196cdd0dc;

	public string xcd5d15a1f9661947
	{
		get
		{
			return x797649178933822e;
		}
		set
		{
			x797649178933822e = value;
		}
	}

	public string xfb99a81ca7845421
	{
		get
		{
			return xc9c94625dd81f95e;
		}
		set
		{
			xc9c94625dd81f95e = value;
		}
	}

	public string xfe2547b8d747df6a
	{
		get
		{
			return x2ea205893aecb323;
		}
		set
		{
			x2ea205893aecb323 = value;
		}
	}

	public string xbb6d310c2b0ab6cc
	{
		get
		{
			return xe93eef819d0ce5ad;
		}
		set
		{
			xe93eef819d0ce5ad = value;
		}
	}

	public string xab07b26048f600ba
	{
		get
		{
			return xc539d78cbe7328ff;
		}
		set
		{
			xc539d78cbe7328ff = value;
		}
	}

	public string x0124e2b3982c7c2b
	{
		get
		{
			return xd6909232d2af772c;
		}
		set
		{
			xd6909232d2af772c = value;
		}
	}

	public string x32e1da0b7ddf4b75
	{
		get
		{
			return xc61ff88f1f98652d;
		}
		set
		{
			xc61ff88f1f98652d = value;
		}
	}

	public DateTime x3a4da692532b620c
	{
		get
		{
			return xca33054605efbc20;
		}
		set
		{
			xca33054605efbc20 = value;
		}
	}

	public string x84b5eecbdcca03b0
	{
		get
		{
			return x1a1d81c196cdd0dc;
		}
		set
		{
			x1a1d81c196cdd0dc = value;
		}
	}

	public xd83a9e112035523a(x4882ae789be6e2ef context)
		: base(context)
	{
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x1c638d277561c422(xbfbb1719d4106af2());
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		writer.xa4dc0ad8886e23a2("/ByteRange", x2ea205893aecb323.PadRight(30));
		writer.xa4dc0ad8886e23a2("/Contents", $"<{x1a1d81c196cdd0dc}>");
		writer.xa4dc0ad8886e23a2("/Type", "/Sig");
		writer.xa4dc0ad8886e23a2("/Filter", $"/{x797649178933822e}");
		writer.xa4dc0ad8886e23a2("/SubFilter", $"/{xc9c94625dd81f95e}");
		writer.x94aba205302527e1("/ContactInfo", xe93eef819d0ce5ad);
		writer.x94aba205302527e1("/Location", xc539d78cbe7328ff);
		writer.x94aba205302527e1("/Reason", xd6909232d2af772c);
		writer.x94aba205302527e1("/Name", xc61ff88f1f98652d);
		writer.xa4dc0ad8886e23a2("/M", xca33054605efbc20);
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
	}
}
