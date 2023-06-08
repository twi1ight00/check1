using System;
using System.Collections;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Saving;
using x13f1efc79617a47b;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x38a89dee67fc7a16;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;
using x7c7a1dceb600404e;
using xb92b7270f78a4e8d;
using xf9a9481c3f63a419;

namespace xbe829a00a7a86dc3;

internal class x738c5c0b76a0e787 : x2cd1f1f5e07462a8
{
	internal Hashtable x2538deb7db4a006c = new Hashtable();

	private readonly x8556eed81191af11 xb36c250515e408ad;

	private readonly xf7173b82df2a4de7 x800085dd555f7711;

	private readonly xbb6564a24d4c901a xbc33695753285351;

	private MemoryStream xacf0bee3b31dd27d;

	private ArrayList x59fc0436dd9fe5df;

	private int x816fd393960f4186 = 1;

	private Hashtable xbd1cf65dfdae0e0b;

	internal Document x2c8c6741422a1298 => xb36c250515e408ad.x2c8c6741422a1298;

	internal WordML2003SaveOptions xf57de0fd37d5e97d => (WordML2003SaveOptions)xb36c250515e408ad.xf57de0fd37d5e97d;

	internal xf7173b82df2a4de7 xe1410f585439c7d4 => x800085dd555f7711;

	internal MemoryStream xf673ee20dd3b9183
	{
		get
		{
			if (xacf0bee3b31dd27d == null)
			{
				xa5809ec092f26e19();
			}
			return xacf0bee3b31dd27d;
		}
	}

	public x8556eed81191af11 x8556eed81191af11 => xb36c250515e408ad;

	public string x399786efbd2099c3 => "src";

	public string xd1abb1ff4a5f37ef => "o:href";

	ArrayList x2cd1f1f5e07462a8.xe3a0505c2452b0b0
	{
		get
		{
			if (x59fc0436dd9fe5df == null)
			{
				x59fc0436dd9fe5df = new ArrayList();
			}
			return x59fc0436dd9fe5df;
		}
	}

	bool x2cd1f1f5e07462a8.xd36e0c6c8431aa55 => false;

	internal x738c5c0b76a0e787(x8556eed81191af11 saveInfo, xf7173b82df2a4de7 builder)
	{
		xb36c250515e408ad = saveInfo;
		x800085dd555f7711 = builder;
		xbc33695753285351 = new xbb6564a24d4c901a(xb36c250515e408ad.x2c8c6741422a1298.Styles);
	}

	internal string x7af082eaf8e0caa4(int xddd12ddd8b1e4a90)
	{
		return xbc33695753285351.x7af082eaf8e0caa4(xddd12ddd8b1e4a90);
	}

	private void xa5809ec092f26e19()
	{
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(Guid.Empty);
		foreach (DictionaryEntry item in xb36c250515e408ad.xf341204f1f55ff47)
		{
			string xc15bd84e = (string)item.Key;
			xe7be411416cfcd54 xa9288ded743127e = (xe7be411416cfcd54)item.Value;
			xd8c3135513b9115b.x29e7ace4c90f74cd.xd6b6ed77479ef68c(xc15bd84e, xa30d6f9953e1ac23(xa9288ded743127e));
		}
		if (xd8c3135513b9115b.x29e7ace4c90f74cd.Count > 0)
		{
			xacf0bee3b31dd27d = new MemoryStream();
			xd8c3135513b9115b.x0acd3c2012ea2ee8(xacf0bee3b31dd27d);
		}
	}

	private static MemoryStream xa30d6f9953e1ac23(xe7be411416cfcd54 xa9288ded743127e2)
	{
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(xa9288ded743127e2);
		MemoryStream memoryStream = new MemoryStream();
		xd8c3135513b9115b.x0acd3c2012ea2ee8(memoryStream);
		memoryStream.Position = 0L;
		MemoryStream memoryStream2 = new MemoryStream();
		x0d299f323d241756.x244f57c2c3806fa8((uint)memoryStream.Length, memoryStream2);
		xf1da3993f05a75b7.x575db3fedeadea6b(memoryStream, memoryStream2, x2e6ebe7013ab34b9.x1455a9a8b1cd9f39);
		return memoryStream2;
	}

	private string x9636fc9f1575f1b5(int xba08ce632055a1d9)
	{
		if (xbd1cf65dfdae0e0b == null)
		{
			xbd1cf65dfdae0e0b = new Hashtable();
			foreach (ShapeBase childNode in x2c8c6741422a1298.GetChildNodes(NodeType.Shape, isDeep: true))
			{
				string name = childNode.Name;
				if (name.StartsWith("_s"))
				{
					xbd1cf65dfdae0e0b[x64893267b789fd52.x650d90d2e073ca99(name)] = name;
				}
			}
		}
		return xbd1cf65dfdae0e0b[xba08ce632055a1d9] as string;
	}

	string x2cd1f1f5e07462a8.xb60a89e8f071915f(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x9636fc9f1575f1b5
		return this.x9636fc9f1575f1b5(xba08ce632055a1d9);
	}

	private string x409b79e8af90123b(string xe9c763083b68a7ee)
	{
		return xe9c763083b68a7ee;
	}

	string x2cd1f1f5e07462a8.xf1b629587cb7c15e(string xe9c763083b68a7ee)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x409b79e8af90123b
		return this.x409b79e8af90123b(xe9c763083b68a7ee);
	}

	private string xbbec0cfabbdf646a(byte[] x43e181e083db6cdf)
	{
		Guid guid = x66cdafe77e7aa42b.x8341ba999ffebb91(x43e181e083db6cdf);
		if (x2538deb7db4a006c.ContainsKey(guid))
		{
			return (string)x2538deb7db4a006c[guid];
		}
		xfe2ff3c162b47c70 xfe2ff3c162b47c = xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(x43e181e083db6cdf);
		byte[] xf9a0d04800d = x43e181e083db6cdf;
		string x9635f68941f6bd;
		string xe5d6992d68f50ebb;
		switch (xfe2ff3c162b47c)
		{
		case xfe2ff3c162b47c70.xc2746d872ce402e9:
			x9635f68941f6bd = "01";
			xe5d6992d68f50ebb = "bmp";
			break;
		case xfe2ff3c162b47c70.x8e716ec1cb703e9f:
			x9635f68941f6bd = "01";
			xe5d6992d68f50ebb = "gif";
			break;
		case xfe2ff3c162b47c70.x796ab23ce57ee1e0:
			x9635f68941f6bd = "02";
			xe5d6992d68f50ebb = "jpg";
			break;
		case xfe2ff3c162b47c70.x6339cdb9e2b512c7:
			x9635f68941f6bd = "03";
			xe5d6992d68f50ebb = "png";
			break;
		case xfe2ff3c162b47c70.xd69df86e2a88ddb2:
			x9635f68941f6bd = "06";
			xe5d6992d68f50ebb = "emz";
			xf9a0d04800d = x64893267b789fd52.xda9a45260aafce5e(x43e181e083db6cdf);
			break;
		case xfe2ff3c162b47c70.xb5fe04c34562f438:
			x9635f68941f6bd = "08";
			xe5d6992d68f50ebb = "wmz";
			xf9a0d04800d = x64893267b789fd52.xda9a45260aafce5e(x43e181e083db6cdf);
			break;
		case xfe2ff3c162b47c70.x26c36dd85013b919:
			x9635f68941f6bd = "0A";
			xe5d6992d68f50ebb = "pcz";
			xf9a0d04800d = x64893267b789fd52.x7b2ace3ecba130d8(x43e181e083db6cdf);
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bhaghihgiiogihfhdhmhmhdibhkifhbjngijlhpjdggkpfnkibelofllpfcmafjmdfanoehngaonhffojfmonedppdkphpaajdiapdpabdgbkdnbndecddlcgdcdecjdocaeobhekboednefebmfccdgmbkgabbhcbihiapholficpmihaejhaljgpbkmnikinpkjkgllonllpemaplmmocnmojnloaockho", 866934812)));
		}
		string text = xf70a2b11a9bb19be(x9635f68941f6bd, xe5d6992d68f50ebb, xf9a0d04800d);
		x2538deb7db4a006c.Add(guid, text);
		return text;
	}

	string x2cd1f1f5e07462a8.x2f696e6403c110df(byte[] x43e181e083db6cdf)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xbbec0cfabbdf646a
		return this.xbbec0cfabbdf646a(x43e181e083db6cdf);
	}

	internal string xf70a2b11a9bb19be(string x9635f68941f6bd49, string xe5d6992d68f50ebb, MemoryStream xcf18e5243f8d5fd3)
	{
		return xf70a2b11a9bb19be(x9635f68941f6bd49, xe5d6992d68f50ebb, xcf18e5243f8d5fd3.ToArray());
	}

	private string xf70a2b11a9bb19be(string x9635f68941f6bd49, string xe5d6992d68f50ebb, byte[] xf9a0d04800d70471)
	{
		string arg = xca004f56614e2431.x6c89d5642f47f66d(x816fd393960f4186);
		x816fd393960f4186++;
		string text = $"wordml://{x9635f68941f6bd49}{arg}.{xe5d6992d68f50ebb}";
		x800085dd555f7711.x2307058321cdb62f("w:binData");
		x800085dd555f7711.x943f6be3acf634db("w:name", text);
		x800085dd555f7711.xe24c4103102bcb90(xf9a0d04800d70471, 0, xf9a0d04800d70471.Length);
		x800085dd555f7711.x2dfde153f4ef96d0();
		return text;
	}
}
