using System.IO;
using x011d489fb9df7027;

namespace x5af3f327d745698a;

internal class xf0002907cfe93bb4
{
	private readonly x1ba6afab4f42a0ee x25c558e3fb729edc;

	private readonly string x93168ed101bbb044;

	private readonly string x35c30f877ecc4e7a;

	private readonly string x1356b481f33e39f3;

	internal x1ba6afab4f42a0ee x1ba6afab4f42a0ee => x25c558e3fb729edc;

	internal string x570858a97a5a2c4a => x93168ed101bbb044;

	internal string xbd11df86767e08a3 => x35c30f877ecc4e7a;

	internal string x73cf5fe9b727ba52 => x1356b481f33e39f3;

	internal xf0002907cfe93bb4(x1ba6afab4f42a0ee oleObjectType, string className, string topicName, string itemName)
	{
		x25c558e3fb729edc = oleObjectType;
		x93168ed101bbb044 = className;
		x35c30f877ecc4e7a = topicName;
		x1356b481f33e39f3 = itemName;
	}

	internal xf0002907cfe93bb4(BinaryReader reader, int codePage)
	{
		reader.ReadInt32();
		int num = reader.ReadInt32();
		x25c558e3fb729edc = ((num != 1) ? x1ba6afab4f42a0ee.xc24de6454f8b0f37 : x1ba6afab4f42a0ee.x1891c445b78b044b);
		x93168ed101bbb044 = x9ac0da7388ceac43.x58db9aaa4a730e59(reader);
		x35c30f877ecc4e7a = x9ac0da7388ceac43.x58db9aaa4a730e59(reader);
		x1356b481f33e39f3 = x9ac0da7388ceac43.x58db9aaa4a730e59(reader);
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(1281);
		xbdfb620b7167944b.Write((x25c558e3fb729edc == x1ba6afab4f42a0ee.x1891c445b78b044b) ? 1 : 2);
		x9ac0da7388ceac43.xf6c2f11ceec579ae(xbdfb620b7167944b, x93168ed101bbb044);
		x9ac0da7388ceac43.x41d7feb042ee43f7(xbdfb620b7167944b, x35c30f877ecc4e7a);
		x9ac0da7388ceac43.x41d7feb042ee43f7(xbdfb620b7167944b, x1356b481f33e39f3);
	}
}
