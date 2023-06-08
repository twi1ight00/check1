using System;
using System.IO;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;
using xb92b7270f78a4e8d;

namespace x5af3f327d745698a;

internal class xc869805892681306 : x8761581bef471ee5
{
	private const int x32c273d6eb45bf94 = 1907505652;

	private int x3bbe2a8b425452f7;

	private int x9003a6523dc4c74f;

	private byte[] x39fe37ea3e7afe4a;

	private string x317b909a6ce5c7a5;

	private string x64489a9a9991be6c;

	private x87d385f79490c27a x38421648c6b78ead;

	private string x24daa5af600defde;

	private Guid x31394132931742a3;

	private readonly string x11d83bfbd131ae32;

	private readonly x87d385f79490c27a xa098e952d55ade55;

	string x8761581bef471ee5.x32513d67c4b572d4 => "\u0001CompObj";

	internal string x988cbbe5c7948492 => x11d83bfbd131ae32;

	internal x87d385f79490c27a x87d385f79490c27a => xa098e952d55ade55;

	internal Guid x933ed8cf24f04c67 => x31394132931742a3;

	internal xc869805892681306(string progId)
	{
		x31394132931742a3 = x9ac0da7388ceac43.x38fd54ed55196575(progId);
		x11d83bfbd131ae32 = "";
		xa098e952d55ade55 = new x87d385f79490c27a("");
	}

	internal xc869805892681306(xe7be411416cfcd54 storage)
	{
		MemoryStream memoryStream = storage.x3e19bf48aeaa5779("\u0001CompObj");
		if (memoryStream != null)
		{
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			x3bbe2a8b425452f7 = binaryReader.ReadInt32();
			x9003a6523dc4c74f = binaryReader.ReadInt32();
			x39fe37ea3e7afe4a = binaryReader.ReadBytes(4);
			x31394132931742a3 = new Guid(binaryReader.ReadBytes(16));
			x11d83bfbd131ae32 = x9ac0da7388ceac43.x58db9aaa4a730e59(binaryReader);
			xa098e952d55ade55 = new x87d385f79490c27a(binaryReader, isUnicode: false);
			x317b909a6ce5c7a5 = x9ac0da7388ceac43.x58db9aaa4a730e59(binaryReader);
			if (x0d299f323d241756.xd7d2f6dd32a72a3b(binaryReader, 4) && binaryReader.ReadInt32() == 1907505652)
			{
				x64489a9a9991be6c = x93b05c1ad709a695.xf30570713d4bb9fe(binaryReader);
				x38421648c6b78ead = new x87d385f79490c27a(binaryReader, isUnicode: true);
				x24daa5af600defde = x93b05c1ad709a695.xf30570713d4bb9fe(binaryReader);
			}
		}
	}

	private void x66a781f9bc1549ba(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(4294836225u);
		xbdfb620b7167944b.Write(2563);
		xbdfb620b7167944b.Write(uint.MaxValue);
		xbdfb620b7167944b.Write(x31394132931742a3.ToByteArray());
		x9ac0da7388ceac43.x41d7feb042ee43f7(xbdfb620b7167944b, x11d83bfbd131ae32);
		((xa098e952d55ade55 == null) ? new x87d385f79490c27a("") : xa098e952d55ade55).x6210059f049f0d48(xbdfb620b7167944b, x5be1cad1d00af914: false);
		x9ac0da7388ceac43.x41d7feb042ee43f7(xbdfb620b7167944b, "");
		xbdfb620b7167944b.Write(1907505652);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
	}

	void x8761581bef471ee5.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x66a781f9bc1549ba
		this.x66a781f9bc1549ba(xbdfb620b7167944b);
	}
}
