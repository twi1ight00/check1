using System;
using System.IO;
using xb92b7270f78a4e8d;

namespace x5af3f327d745698a;

internal class x64d2e942085ade70 : x8761581bef471ee5
{
	private readonly string x35c30f877ecc4e7a;

	private readonly string x1356b481f33e39f3;

	string x8761581bef471ee5.x32513d67c4b572d4 => "\u0003LinkInfo";

	internal string xbd11df86767e08a3 => x35c30f877ecc4e7a;

	internal string x73cf5fe9b727ba52 => x1356b481f33e39f3;

	internal x64d2e942085ade70(xe7be411416cfcd54 storage)
	{
		string x759aa16c2016a = ((x8761581bef471ee5)this).x759aa16c2016a289;
		MemoryStream memoryStream = storage.x3e19bf48aeaa5779(x759aa16c2016a);
		if (memoryStream != null)
		{
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			x35c30f877ecc4e7a = new string(binaryReader.ReadChars(binaryReader.ReadInt16()));
			x1356b481f33e39f3 = new string(binaryReader.ReadChars(binaryReader.ReadInt16()));
			return;
		}
		throw new InvalidOperationException($"{x759aa16c2016a} is not found.");
	}

	private void x66a781f9bc1549ba(BinaryWriter xbdfb620b7167944b)
	{
		throw new NotImplementedException();
	}

	void x8761581bef471ee5.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x66a781f9bc1549ba
		this.x66a781f9bc1549ba(xbdfb620b7167944b);
	}
}
