using System.IO;
using x011d489fb9df7027;
using xb92b7270f78a4e8d;

namespace x5af3f327d745698a;

internal class xfa9b77033f6e5e27 : x320b28ae68e47317
{
	private readonly byte[] x419a03d0b8d6386c;

	private readonly x59772113b8075329 xd828dede45258e23;

	internal override x1ba6afab4f42a0ee xcfc06e7ce72a0f0b => x1ba6afab4f42a0ee.xc24de6454f8b0f37;

	internal byte[] x6a3df4ad78faf19b => x419a03d0b8d6386c;

	internal x59772113b8075329 x59772113b8075329 => xd828dede45258e23;

	internal xfa9b77033f6e5e27(xf0002907cfe93bb4 objectHeader, BinaryReader reader)
	{
		x93168ed101bbb044 = objectHeader.x570858a97a5a2c4a;
		int count = reader.ReadInt32();
		x419a03d0b8d6386c = reader.ReadBytes(count);
		xd828dede45258e23 = x59772113b8075329.x06b0e25aa6ad68a9(reader);
	}

	internal xfa9b77033f6e5e27(string progId, xe7be411416cfcd54 embeddedData, byte[] metafileData)
	{
		x93168ed101bbb044 = progId;
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(embeddedData);
		MemoryStream memoryStream = new MemoryStream();
		xd8c3135513b9115b.x0acd3c2012ea2ee8(memoryStream);
		x419a03d0b8d6386c = memoryStream.ToArray();
		xd828dede45258e23 = ((metafileData != null) ? ((x59772113b8075329)new x103f5cc254d14402(metafileData)) : ((x59772113b8075329)new xd19c736ea89ed0bc()));
	}

	internal override void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xf0002907cfe93bb4 xf0002907cfe93bb5 = new xf0002907cfe93bb4(x1ba6afab4f42a0ee.xc24de6454f8b0f37, x93168ed101bbb044, "", "");
		xf0002907cfe93bb5.x6210059f049f0d48(xbdfb620b7167944b);
		xbdfb620b7167944b.Write(x419a03d0b8d6386c.Length);
		xbdfb620b7167944b.Write(x419a03d0b8d6386c);
		xd828dede45258e23.x6210059f049f0d48(xbdfb620b7167944b);
	}
}
