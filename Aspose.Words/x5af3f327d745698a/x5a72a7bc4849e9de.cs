using System.IO;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;

namespace x5af3f327d745698a;

internal class x5a72a7bc4849e9de : x8761581bef471ee5
{
	private readonly x9db50866da3cf409 xfe708bfa16fbeba9;

	private readonly xb86dce4d7748d175 x1c6dc208ea5b28f2;

	private readonly x0c4de7b78d968e81 x7e64dd43ee8ffba7;

	string x8761581bef471ee5.x32513d67c4b572d4 => "\u0003ObjInfo";

	internal x9db50866da3cf409 xc76a2cd3a8f827bd => xfe708bfa16fbeba9;

	internal xb86dce4d7748d175 xddfc9dd13ff83330 => x1c6dc208ea5b28f2;

	internal x0c4de7b78d968e81 x87d385f79490c27a => x7e64dd43ee8ffba7;

	internal bool x713fda74e617b722 => (xc76a2cd3a8f827bd & x9db50866da3cf409.xb96cc45c13ecd384) != 0;

	internal x5a72a7bc4849e9de(x9db50866da3cf409 flags1, xb86dce4d7748d175 flags2, x0c4de7b78d968e81 cf)
	{
		xfe708bfa16fbeba9 = flags1;
		x1c6dc208ea5b28f2 = flags2;
		x7e64dd43ee8ffba7 = cf;
	}

	internal x5a72a7bc4849e9de(xe7be411416cfcd54 storage)
	{
		MemoryStream memoryStream = storage.x3e19bf48aeaa5779("\u0003ObjInfo");
		if (memoryStream != null)
		{
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			xfe708bfa16fbeba9 = (x9db50866da3cf409)binaryReader.ReadUInt16();
			x7e64dd43ee8ffba7 = (x0c4de7b78d968e81)binaryReader.ReadUInt16();
			if (x0d299f323d241756.xd7d2f6dd32a72a3b(binaryReader, 2))
			{
				x1c6dc208ea5b28f2 = (xb86dce4d7748d175)(binaryReader.ReadUInt16() & 0xF);
			}
		}
	}

	private void x66a781f9bc1549ba(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((ushort)xfe708bfa16fbeba9);
		xbdfb620b7167944b.Write((ushort)x7e64dd43ee8ffba7);
		xbdfb620b7167944b.Write((ushort)x1c6dc208ea5b28f2);
	}

	void x8761581bef471ee5.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x66a781f9bc1549ba
		this.x66a781f9bc1549ba(xbdfb620b7167944b);
	}
}
