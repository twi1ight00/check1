using System.IO;

namespace x4f4df92b75ba3b67;

internal class xa73d31814e085e6d : x4c746eafc29e5079
{
	private const int x036099b0a33958c5 = 1;

	private const int x30965a8eaf43c6c1 = 1;

	private const int xac5e3b5bf8a1c6b9 = 8;

	private const string xbc555ab54ddf9825 = "/DecodeParms";

	private const string x0823c4eb2b792cf0 = "/Predictor";

	private const string xa558bf3f3fddd9a5 = "/Colors";

	private const string xb71d5fc68aed05cb = "/BitsPerComponent";

	private const string x8fde6986f3facc4c = "/Columns";

	private x78a77d442e16bfcb xc95e25b32501a226 = x78a77d442e16bfcb.x23b58036890a1f7a;

	private int x416daa5f27da7c5c = 1;

	private bool xe02b46c4fdb602d3;

	private int x660741034f534cfd = 1;

	private bool x7e66295c2fb6fa9a;

	private int xe97e96740bd5f717 = 8;

	private bool xb7d6b8f1214d125b;

	private bool x522e60f200de0ba2;

	private bool xab0acb384148d1b7;

	internal int x2c0320b7c80c1e61
	{
		get
		{
			return x416daa5f27da7c5c;
		}
		set
		{
			if (value != 1)
			{
				x416daa5f27da7c5c = value;
				xe02b46c4fdb602d3 = true;
			}
		}
	}

	internal int xbd7bb54d8760ed0a
	{
		get
		{
			return x660741034f534cfd;
		}
		set
		{
			if (value != 1)
			{
				x660741034f534cfd = value;
				x7e66295c2fb6fa9a = true;
			}
		}
	}

	internal int x1fda32d41ebcf020
	{
		get
		{
			return xe97e96740bd5f717;
		}
		set
		{
			if (value != 8)
			{
				xe97e96740bd5f717 = value;
				xb7d6b8f1214d125b = true;
			}
		}
	}

	public bool x988e9397bc83aaf3
	{
		set
		{
			x522e60f200de0ba2 = value;
			xab0acb384148d1b7 = true;
		}
	}

	internal override Stream xdd66d940acb3d138(Stream xf823f0edaa261f3b)
	{
		x5798408e240c6434();
		if (xc95e25b32501a226 != x78a77d442e16bfcb.xc19713a99141b6ee)
		{
			return new xae0e17c5b80c840f(xf823f0edaa261f3b, xc95e25b32501a226, x416daa5f27da7c5c, x660741034f534cfd, xe97e96740bd5f717);
		}
		return new xae0e17c5b80c840f(xf823f0edaa261f3b);
	}

	internal override void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		x5798408e240c6434();
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Filter", "/LZWDecode");
		if (xc95e25b32501a226 != x78a77d442e16bfcb.xc19713a99141b6ee)
		{
			xbdfb620b7167944b.x6210059f049f0d48("/DecodeParms");
			xbdfb620b7167944b.xafb7e6f79ed43681();
			xbdfb620b7167944b.xa4dc0ad8886e23a2("/Predictor", (int)xc95e25b32501a226);
			if (xe02b46c4fdb602d3)
			{
				xbdfb620b7167944b.xa4dc0ad8886e23a2("/Colors", x416daa5f27da7c5c);
			}
			if (x7e66295c2fb6fa9a)
			{
				xbdfb620b7167944b.xa4dc0ad8886e23a2("/Columns", x660741034f534cfd);
			}
			if (xb7d6b8f1214d125b)
			{
				xbdfb620b7167944b.xa4dc0ad8886e23a2("/BitsPerComponent", xe97e96740bd5f717);
			}
			xbdfb620b7167944b.x693a8d6d020474f2();
		}
	}

	private void x5798408e240c6434()
	{
		if (!xab0acb384148d1b7 && !xe02b46c4fdb602d3 && !xb7d6b8f1214d125b && !x7e66295c2fb6fa9a)
		{
			return;
		}
		if (x522e60f200de0ba2)
		{
			if (x416daa5f27da7c5c >= 3)
			{
				xc95e25b32501a226 = x78a77d442e16bfcb.x298ca06b895fb903;
			}
			else
			{
				xc95e25b32501a226 = x78a77d442e16bfcb.xc19713a99141b6ee;
			}
		}
		else if (x416daa5f27da7c5c >= 3)
		{
			xc95e25b32501a226 = x78a77d442e16bfcb.xb1a9c37804ac83d7;
		}
		else
		{
			xc95e25b32501a226 = x78a77d442e16bfcb.xc19713a99141b6ee;
		}
	}
}
