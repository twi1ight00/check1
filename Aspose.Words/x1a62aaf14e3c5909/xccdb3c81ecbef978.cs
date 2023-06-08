using System.IO;
using x011d489fb9df7027;

namespace x1a62aaf14e3c5909;

internal class xccdb3c81ecbef978 : xddf6304144fd3863
{
	internal int x90b1cee5d7d50332;

	internal int xf5be0187c03e1d05;

	internal int xdf09a79a6cd8b125;

	internal int x3290a7e57100eb12;

	internal int x721a1e02c8238b0d;

	internal int x61babdf53fe51a3e;

	internal xccdb3c81ecbef978()
		: base(x773fe540042dad03.x6299a07c6a18ef52, 1)
	{
	}

	internal xccdb3c81ecbef978(int ruleId, int connectorSpid, x6299a07c6a18ef52 connRule)
		: this()
	{
		x90b1cee5d7d50332 = ruleId;
		x3290a7e57100eb12 = connectorSpid;
		if (connRule != null)
		{
			xf5be0187c03e1d05 = connRule.x7088df3c97402096;
			xdf09a79a6cd8b125 = connRule.xd17a6a5c2bf454d1;
			x721a1e02c8238b0d = connRule.x721a1e02c8238b0d;
			x61babdf53fe51a3e = connRule.x61babdf53fe51a3e;
		}
		else
		{
			xf5be0187c03e1d05 = 0;
			xdf09a79a6cd8b125 = 0;
			x721a1e02c8238b0d = -1;
			x61babdf53fe51a3e = -1;
		}
	}

	protected override void DoRead(BinaryReader reader)
	{
		x90b1cee5d7d50332 = reader.ReadInt32();
		xf5be0187c03e1d05 = reader.ReadInt32();
		xdf09a79a6cd8b125 = reader.ReadInt32();
		x3290a7e57100eb12 = reader.ReadInt32();
		x721a1e02c8238b0d = reader.ReadInt32();
		x61babdf53fe51a3e = reader.ReadInt32();
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		writer.Write(x90b1cee5d7d50332);
		writer.Write(xf5be0187c03e1d05);
		writer.Write(xdf09a79a6cd8b125);
		writer.Write(x3290a7e57100eb12);
		writer.Write(x721a1e02c8238b0d);
		writer.Write(x61babdf53fe51a3e);
	}

	internal x6299a07c6a18ef52 x865b320f557323c1()
	{
		return new x6299a07c6a18ef52(xf5be0187c03e1d05, xdf09a79a6cd8b125, x721a1e02c8238b0d, x61babdf53fe51a3e);
	}
}
