using System;
using System.Collections;
using System.IO;
using x13f1efc79617a47b;
using xa604c4d210ae0581;

namespace x9e260ffa1ac41ffa;

internal abstract class x9331ac0876d3bbff
{
	internal x25732282434cea28 xa0f875cb0577ebbd;

	internal ArrayList xc42ae64d502433bd = new ArrayList();

	internal x9331ac0876d3bbff()
	{
		xa0f875cb0577ebbd = DoCreateFKPBuilder();
	}

	internal void xd6b6ed77479ef68c(int xb55016094f0bf0bc, int x4919a826cd6fa1bd, x71d23a26ce0a5b23 x6eb3757a94e174fc)
	{
		if (!xa0f875cb0577ebbd.xd6b6ed77479ef68c(xb55016094f0bf0bc, x4919a826cd6fa1bd, x6eb3757a94e174fc))
		{
			xbb7550bbb62a218c();
			xa0f875cb0577ebbd = DoCreateFKPBuilder();
			if (!xa0f875cb0577ebbd.xd6b6ed77479ef68c(xb55016094f0bf0bc, x4919a826cd6fa1bd, x6eb3757a94e174fc))
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("emlbpnccjojcgoadeohdgoodpifenmmenmdfkmkfdibgaligflpgkhghlmnhdmeibhlicmcjdljjnkakfghkiiokkiflmimlhgdm", 1603869569)));
			}
		}
	}

	internal xc9072e4c3fa520ad xdc1f68583974b7db(Stream xcf18e5243f8d5fd3)
	{
		xbb7550bbb62a218c();
		xc9072e4c3fa520ad xc9072e4c3fa520ad = new xc9072e4c3fa520ad(4);
		for (int i = 0; i < xc42ae64d502433bd.Count; i++)
		{
			x65018335ce75ca44 x65018335ce75ca45 = xc42ae64d502433bd[i] as x65018335ce75ca44;
			int pn = (int)xcf18e5243f8d5fd3.Position / 512;
			xcf18e5243f8d5fd3.Write(x65018335ce75ca45.x6b73aa01aa019d3a, 0, x65018335ce75ca45.x6b73aa01aa019d3a.Length);
			xc9072e4c3fa520ad.xd6b6ed77479ef68c(x65018335ce75ca45.x58fd11ed15e55c75.x12cb12b5d2cad53d, x65018335ce75ca45.x58fd11ed15e55c75.x9fd888e65466818c, new xedae736cb5467eb4(pn));
		}
		return xc9072e4c3fa520ad;
	}

	private void xbb7550bbb62a218c()
	{
		x65018335ce75ca44 value = xa0f875cb0577ebbd.x3351d447ab90c1ad();
		xc42ae64d502433bd.Add(value);
		xa0f875cb0577ebbd = null;
	}

	protected abstract x25732282434cea28 DoCreateFKPBuilder();
}
