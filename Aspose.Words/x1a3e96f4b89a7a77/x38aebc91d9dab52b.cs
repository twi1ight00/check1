using Aspose.Words;
using x452f379ec5921195;
using x6c95d9cf46ff5f25;
using xa8550ea6ae4a81a5;
using xda075892eccab2ad;

namespace x1a3e96f4b89a7a77;

internal class x38aebc91d9dab52b
{
	private x38aebc91d9dab52b()
	{
	}

	internal static void x6210059f049f0d48(Document x6beba47238e0ade6, x873451caae5ad4ae xd07ce4b74c5774a7, bool x5fbb1a9c98604ef5)
	{
		if (x6beba47238e0ade6.x227665e444fb500a != null && x6beba47238e0ade6.x227665e444fb500a.xf2453c298c5de6f5.xd44988f225497f3a != 0)
		{
			x6210059f049f0d48(xd07ce4b74c5774a7, x6beba47238e0ade6.x227665e444fb500a, x5fbb1a9c98604ef5, x12f8e3199076f578: true);
		}
	}

	private static void x6210059f049f0d48(x873451caae5ad4ae xd07ce4b74c5774a7, x227665e444fb500a x5319ac6190db58c3, bool x5fbb1a9c98604ef5, bool x12f8e3199076f578)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f(x5319ac6190db58c3.x8864e5b3afde4d6e ? "w:frameset" : "w:frame");
		if (x12f8e3199076f578)
		{
			xe48f2142267c6ec9(xd07ce4b74c5774a7, x5319ac6190db58c3);
		}
		else
		{
			x9e5fb97666aedd30(xd07ce4b74c5774a7, x5319ac6190db58c3);
		}
		if (x5319ac6190db58c3.x8864e5b3afde4d6e)
		{
			xd07ce4b74c5774a7.x547195bcc386fe66("w:frameLayout", x72a0c846678ecaf9.x703423b6c1c23036(x5319ac6190db58c3.x5a5e07e9fa12451a));
		}
		else
		{
			xd07ce4b74c5774a7.x67aa7400b293b13a("w:MarH", x5319ac6190db58c3.x5982cde1fd0610eb);
			xd07ce4b74c5774a7.x67aa7400b293b13a("w:MarV", x5319ac6190db58c3.x5e520cbf43b1907e);
			xd07ce4b74c5774a7.x547195bcc386fe66("w:name", x5319ac6190db58c3.x759aa16c2016a289);
			if (x5319ac6190db58c3.xa39af5a82860a9a3 != null)
			{
				if (x5fbb1a9c98604ef5)
				{
					string xbcea506a33cf = ((x8f3af96aa56f1e32)xd07ce4b74c5774a7).x398b3bd0acd94b61.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/officeDocument/2006/relationships/frame", x5319ac6190db58c3.xa39af5a82860a9a3, x1bc1cc5e4fd586bf: true);
					xd07ce4b74c5774a7.x2307058321cdb62f("w:sourceFileName");
					xd07ce4b74c5774a7.xff520a0047c27122("r:id", xbcea506a33cf);
					xd07ce4b74c5774a7.x2dfde153f4ef96d0();
				}
				else
				{
					xd07ce4b74c5774a7.x547195bcc386fe66("w:sourceFileName", x5319ac6190db58c3.xa39af5a82860a9a3);
				}
			}
			if (x5319ac6190db58c3.x7c464f3c4155e7bb != 0)
			{
				xd07ce4b74c5774a7.x547195bcc386fe66("w:scrollbar", (x5319ac6190db58c3.x7c464f3c4155e7bb == x11d526cb3a620392.xbdc78d778d82071f) ? "on" : "off");
			}
		}
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:noResizeAllowed", x5319ac6190db58c3.x9e0b65219bafea05);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:linkedToFile", x5319ac6190db58c3.x1891c445b78b044b);
		xd07ce4b74c5774a7.x547195bcc386fe66("w:title", x5319ac6190db58c3.x238bf167ccfdd282);
		foreach (x227665e444fb500a item in x5319ac6190db58c3.xf2453c298c5de6f5)
		{
			x6210059f049f0d48(xd07ce4b74c5774a7, item, x5fbb1a9c98604ef5, x12f8e3199076f578: false);
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void xe48f2142267c6ec9(x873451caae5ad4ae xd07ce4b74c5774a7, x227665e444fb500a x5319ac6190db58c3)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("w:framesetSplitbar");
		xd07ce4b74c5774a7.x24f8794502b580ff("w:w", x5319ac6190db58c3.x1da3d4a0edfe0291, 0);
		xd07ce4b74c5774a7.x547195bcc386fe66("w:color", x5319ac6190db58c3.xab068b018026a18d);
		string text = x72a0c846678ecaf9.x8b9ec7eefd64375b(x5319ac6190db58c3.x3650f9b73dc5111b);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			xd07ce4b74c5774a7.x547195bcc386fe66($"w:{text}", xbcea506a33cf9111: true);
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x9e5fb97666aedd30(x873451caae5ad4ae xd07ce4b74c5774a7, x227665e444fb500a x5319ac6190db58c3)
	{
		string arg = "";
		if (x5319ac6190db58c3.x92c54fd3d3742544 == xd656a4828bafb8a2.x2f7951fa0946af7e)
		{
			arg = "%";
		}
		else if (x5319ac6190db58c3.x92c54fd3d3742544 == xd656a4828bafb8a2.x7d5889b1d338a9a9)
		{
			arg = "*";
		}
		arg = $"{x5319ac6190db58c3.xb305c2eaafa86574}{arg}";
		if (arg != "1*")
		{
			xd07ce4b74c5774a7.x547195bcc386fe66("w:sz", arg);
		}
	}
}
