using System;
using System.IO;
using Aspose;
using x13f1efc79617a47b;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal class xed28787af62b195b
{
	private uint[] _xbd492d4fc8202882 = new uint[3] { 305419896u, 591751049u, 878082192u };

	private x41fcadcc0506e331 x68803aa6b676738b = new x41fcadcc0506e331();

	private byte xafc9a417672836b1
	{
		get
		{
			ushort num = (ushort)((ushort)(_xbd492d4fc8202882[2] & 0xFFFFu) | 2u);
			return (byte)(num * (num ^ 1) >> 8);
		}
	}

	private xed28787af62b195b()
	{
	}

	public static xed28787af62b195b x24d00e2eda0373b8(string xe8e4b5871d71a79a)
	{
		xed28787af62b195b xed28787af62b195b2 = new xed28787af62b195b();
		if (xe8e4b5871d71a79a == null)
		{
			throw new x37721f08ca773e2b("This entry requires a password.");
		}
		xed28787af62b195b2.xda8ac495c42eb425(xe8e4b5871d71a79a);
		return xed28787af62b195b2;
	}

	public static xed28787af62b195b x7b5a0a9e4db4ba74(string xe8e4b5871d71a79a, x990d54f34b2b5118 xfbf34718e704c6bc)
	{
		Stream x3c23849cf83dda = xfbf34718e704c6bc._x3c23849cf83dda47;
		xfbf34718e704c6bc._x8109109d50a7c0cd = new byte[12];
		byte[] x8109109d50a7c0cd = xfbf34718e704c6bc._x8109109d50a7c0cd;
		xed28787af62b195b xed28787af62b195b2 = new xed28787af62b195b();
		if (xe8e4b5871d71a79a == null)
		{
			throw new x37721f08ca773e2b("This entry requires a password.");
		}
		xed28787af62b195b2.xda8ac495c42eb425(xe8e4b5871d71a79a);
		x990d54f34b2b5118.x139a09abfe673a44(x3c23849cf83dda, x8109109d50a7c0cd);
		byte[] array = xed28787af62b195b2.xa9083cd230b926ce(x8109109d50a7c0cd, x8109109d50a7c0cd.Length);
		if (array[11] != (byte)((xfbf34718e704c6bc._x5e4059a15fb5fca5 >> 24) & 0xFF))
		{
			if ((xfbf34718e704c6bc._x2d3be316c1c6e811 & 8) != 8)
			{
				throw new x37721f08ca773e2b("The password did not match.");
			}
			if (array[11] != (byte)((xfbf34718e704c6bc._xc3309b8559936a71 >> 8) & 0xFF))
			{
				throw new x37721f08ca773e2b("The password did not match.");
			}
		}
		return xed28787af62b195b2;
	}

	public byte[] xa9083cd230b926ce(byte[] x22587fcaa38ca5e7, int x961016a387451f05)
	{
		if (x22587fcaa38ca5e7 == null)
		{
			throw new xc5e345d2a919c94b(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("oklojmcpdnjpanaaomhaanoajhfbklmbildcdlkcplbddmidhlpdilgepgne", 1589308267)), new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("piielkpelkgfegnfnkegdklgjkchpjjhjkaikjhipeoiajfjojmjijdkmikkoibleiilkdpllfgmjhnmehenailneicoihjojhaplghpogopkgfaddmagbdbgfkbjfbcnficcfpcmegdgfndfdeedeledfcfmejffppfpdhgeeogpdfhndmhgocifckifcbjnnhjicpjgcgkccnkondlmbllaccmebjmbbanangn", 306595917)), "cipherText"));
		}
		if (x961016a387451f05 > x22587fcaa38ca5e7.Length)
		{
			throw new xc5e345d2a919c94b(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mfinhhpnbigoohnomhepohlphccaigjaggabbghbngobbhfcfgmcggddnbkd", 1993005081)), new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lafmhcmmhcdnaojnjcbopbiofcpolbgpfcnpgbealmkamacbkbjbebaciahckaocaafdglldhncefpjeapafmphfaapfepfgfpmghodhkokhgobipkiicjpidogjennjomekgilkpmclfmjllmambmhmlmommlfnbhmnoldomkkoklbpgkippkppekgaalnaojebiklbdfccnjjcckadnjhdljodeefedimedidfldkflibgciigdhpglhghihnhogeiihlidccjehjjfgaklfhkfgokebflagmlagdmlakmnebngfinhfpnaegoienojpdpkelpcecaapiabeabcdhbmcobeoecedmchcddfdkdnbbefnhebcpefbgfmmmfnbegoalgiachamihbaaippgikaoiiafjkpljmpckmojkmpaloohlbpolnofmmjmmkndnioknfobobniogopoijgp", 496288969)), "length"));
		}
		byte[] array = new byte[x961016a387451f05];
		for (int i = 0; i < x961016a387451f05; i++)
		{
			byte b = (byte)(x22587fcaa38ca5e7[i] ^ xafc9a417672836b1);
			x31cdf3ecdce6cc8b(b);
			array[i] = b;
		}
		return array;
	}

	public byte[] x510fa7633d236c28(byte[] xa34812994d16a83e, int x961016a387451f05)
	{
		if (xa34812994d16a83e == null)
		{
			throw new xc5e345d2a919c94b(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("halicccjmcjjjcakhchkjcokcnelebmlkbdmmakmibbnmbinabpnbbgoimmo", 338922180)), new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bcdandkandbbgphbpdpbfdgcldncbdedldldmcceboieccafadhfkcofobfgacmggbdhmmjhooaiebiigapicbgjgbnjkaeklalknpblaajlmpplfmgmiknmjpenkolneocomjjojoapcohpenopjnfalnmaoldbmmkbmnbcfnicohpcimgdnmndimeegmlepgcfokjfokaggghgblogpkfhlkmhhgdifkkijkbjnjijkjpjjfgk", 1224540895)), "plaintext"));
		}
		if (x961016a387451f05 > xa34812994d16a83e.Length)
		{
			throw new xc5e345d2a919c94b(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kgibfipbpigcminckiedmildfdcehhjenhafpghflhofphfgdhmgehdhlckh", 201463847)), new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("midaikkaikbbbgibkkpbakgcgkncmjedgkldhjcemejeniafljhffjofjifglimgbidhhdkhjfbiphiibhpinhgjbinjfhekghlkigcllgjlhgamadhmdbomeefnffmnpedohakoafbpgeipmeppcegamenandebcpkbpdccncjcldadhchdadodfcfebdmepbdfjckfenagobigdcpgobghmbnhfmdiealieacjmlijmaakdahkepnkmpeljpllpocmjpjmekanfphngoonmnfogomofjdpbokpbobamiiaompahngbinnbbmecjmlckhcdlmjddmaebhhecmoedlffnkmffgdgflkgikbhglihojphgfgicknigjejneljojckpijkjialbehlciolaifmlimmjidnlhknnhbongionhpopggpchnpogeanblalfcbjgjbggaccfhchgocjbfd", 1458897738)), "length"));
		}
		byte[] array = new byte[x961016a387451f05];
		for (int i = 0; i < x961016a387451f05; i++)
		{
			byte x514c497312dec79e = xa34812994d16a83e[i];
			array[i] = (byte)(xa34812994d16a83e[i] ^ xafc9a417672836b1);
			x31cdf3ecdce6cc8b(x514c497312dec79e);
		}
		return array;
	}

	public void xda8ac495c42eb425(string x99fa5901270da959)
	{
		byte[] array = x977b5605864b2047.xfa83398499680a50(x99fa5901270da959);
		for (int i = 0; i < x99fa5901270da959.Length; i++)
		{
			x31cdf3ecdce6cc8b(array[i]);
		}
	}

	private void x31cdf3ecdce6cc8b(byte x514c497312dec79e)
	{
		_xbd492d4fc8202882[0] = (uint)x68803aa6b676738b.x9ac874b331c22f88((int)_xbd492d4fc8202882[0], x514c497312dec79e);
		_xbd492d4fc8202882[1] = _xbd492d4fc8202882[1] + (byte)_xbd492d4fc8202882[0];
		_xbd492d4fc8202882[1] = _xbd492d4fc8202882[1] * 134775813 + 1;
		_xbd492d4fc8202882[2] = (uint)x68803aa6b676738b.x9ac874b331c22f88((int)_xbd492d4fc8202882[2], (byte)(_xbd492d4fc8202882[1] >> 24));
	}
}
