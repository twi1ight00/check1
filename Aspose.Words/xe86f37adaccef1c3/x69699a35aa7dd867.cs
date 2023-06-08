using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;
using xfbd1009a0cbb9842;

namespace xe86f37adaccef1c3;

internal class x69699a35aa7dd867
{
	private readonly bool xab18fce9189810dc;

	private readonly Stack xa31da6cb620556b9 = new Stack();

	private Field x1bd07ea82f6cde1a;

	private readonly xcbf34d70634239ae x687fa6dce5a64332 = new xcbf34d70634239ae();

	internal bool x1f14e048f5f7a72a => xa31da6cb620556b9.Count > 0;

	internal xcbf34d70634239ae xf7e212954bf72f68 => x687fa6dce5a64332;

	internal x69699a35aa7dd867(bool createRegions)
	{
		xab18fce9189810dc = createRegions;
	}

	internal bool x3dba3735b42cd449(Field xe01ae93d9fe5a880)
	{
		if (xe01ae93d9fe5a880.Type != FieldType.FieldMergeField)
		{
			return false;
		}
		x561fa53c007d3597 x561fa53c007d = (x561fa53c007d3597)xe01ae93d9fe5a880;
		if (x561fa53c007d.x6f452516cc92f528)
		{
			x59836fde710e5845(x561fa53c007d.xae9d2e3eea32978f, xe01ae93d9fe5a880);
			return true;
		}
		if (x561fa53c007d.x5aafe4417767ef58)
		{
			xeb360709cfbc091d(x561fa53c007d.xae9d2e3eea32978f, xe01ae93d9fe5a880);
			return true;
		}
		return false;
	}

	private void x59836fde710e5845(string xede86a619b9b1c93, Field x19ed958d3e279231)
	{
		if (!x1f14e048f5f7a72a)
		{
			x1bd07ea82f6cde1a = x19ed958d3e279231;
		}
		xa31da6cb620556b9.Push(xede86a619b9b1c93);
	}

	private void xeb360709cfbc091d(string xede86a619b9b1c93, Field xcefb1e5afebcd738)
	{
		if (!x1f14e048f5f7a72a)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pbmifedjiekjodbkbdikkookmcglcdnlfcemonkmkccnobjnfnpnpbhoaboofbfpfbmpgmcaabkafabbpaibbapbmpfcelmcdaeddpkdcpbebpieeppeapgfpjnfdkegeplggkchapjhhjainihibooianfjinmjjmdknmkkanblmmilfhplplgmalnmamenmklnokcomkjookapekhpkfopkkfaikmacjdbakkbpjbcgfic", 1134267353)), xede86a619b9b1c93));
		}
		string text = (string)xa31da6cb620556b9.Pop();
		if (!x0d299f323d241756.x90637a473b1ceaaa(xede86a619b9b1c93, text))
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lphnbcpnecgokbnonaepgmkpiacaoajabaabklgbgaobkpecbllclpcdmojdbpaebpheckoemoffbomflodgnnkginbhajihpnphpmgiomninmejanljmmcklhjkphalanhlciolmmfmdhmmjgdnklknlkbobkioblpokfgpljnpdkeagjlabkcblejbgjacejhcgjocpdfdjimdkhdekikeghbfihifncpfnhgglhngfgehdhlhchcilbjihgajlfhjcbojmffknemkcfdlcfkldabmneimcepmmegnodnnjdeobpkoaecpadjppcaaochabdoancfbmnlbaoccbdkceoadncidenodinfe", 1051776949)), xede86a619b9b1c93, text));
		}
		if (!x1f14e048f5f7a72a && xab18fce9189810dc)
		{
			xc5c3f438428cb03b xccb63ca5f63dc = new xc5c3f438428cb03b(xede86a619b9b1c93, x1bd07ea82f6cde1a, xcefb1e5afebcd738);
			x687fa6dce5a64332.xd6b6ed77479ef68c(xccb63ca5f63dc);
		}
	}

	internal void xe641355482f2e5c9()
	{
		x6decf84496a0b1f2();
	}

	private void x6decf84496a0b1f2()
	{
		for (int i = 0; i < x687fa6dce5a64332.xd44988f225497f3a; i++)
		{
			xc5c3f438428cb03b xc5c3f438428cb03b2 = x687fa6dce5a64332.get_xe6d4b1b411ed94b5(i);
			for (int j = i + 1; j < x687fa6dce5a64332.xd44988f225497f3a; j++)
			{
				xc5c3f438428cb03b xc5c3f438428cb03b3 = x687fa6dce5a64332.get_xe6d4b1b411ed94b5(j);
				if (xc5c3f438428cb03b2.x12cb12b5d2cad53d == xc5c3f438428cb03b3.x12cb12b5d2cad53d || xc5c3f438428cb03b2.x12cb12b5d2cad53d == xc5c3f438428cb03b3.x9fd888e65466818c || xc5c3f438428cb03b2.x9fd888e65466818c == xc5c3f438428cb03b3.x12cb12b5d2cad53d || xc5c3f438428cb03b2.x9fd888e65466818c == xc5c3f438428cb03b3.x9fd888e65466818c)
				{
					throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("iefhjfmhofdiofkipabjjfijoepjifgkkenkfeelnpklmecmmdjmldankdhnndonjdfoldmofocpjojpkdbamohagdpannfbdnmbbbeclblcoacdhmidlmpdmbhepmneibffpllfflcgbakgfabhbphhlpohcpfieomiapdjlkkjkjbklmiklopkaogloinlnnemnmlmmmcnlmjnomaokmhommooghfpglmpbldallkailbbglibilpbbggcblncpkedjjldhkcegkjeofafbjhfhjofkifgdemgjidhlikhkdbiliiimhpighgjocnjohekjglkchclhgjlpbammghmkfomigfnefmnhfdopfkolebphfipmeppbaganenaneebipkbeeccfdjccdadbehdjdodpdfedoleeddffckfpbbghnhghcpgcbghlbnhabeiimkijbcjdajjbaakiahkopnkglelfamlppcmeakmilan", 922580219)), xc5c3f438428cb03b2.x759aa16c2016a289, xc5c3f438428cb03b3.x759aa16c2016a289));
				}
			}
		}
	}

	internal static xcbf34d70634239ae xf3baad719840beed(Node xda5bf54deb817e37)
	{
		x69699a35aa7dd867 x69699a35aa7dd868 = new x69699a35aa7dd867(createRegions: true);
		x6435b7bbb0879a04 x6435b7bbb0879a = xe25d778fe9f1252a.x105bab38d511372f(xda5bf54deb817e37);
		foreach (Field item in x6435b7bbb0879a)
		{
			x69699a35aa7dd868.x3dba3735b42cd449(item);
		}
		x69699a35aa7dd868.xe641355482f2e5c9();
		return x69699a35aa7dd868.xf7e212954bf72f68;
	}
}
