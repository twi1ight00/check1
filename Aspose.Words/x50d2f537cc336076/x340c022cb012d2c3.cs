using Aspose.Words;
using Aspose.Words.Math;
using xe5b37aee2c2a4d4e;

namespace x50d2f537cc336076;

internal class x340c022cb012d2c3 : x57df270da83ea6de
{
	private const float x6acf9999f777460e = 0.75f;

	private x57df270da83ea6de xf442f8ad925baa34;

	private x3a383e6be139fbaa xf0e7190c3ad9bb90;

	private x57df270da83ea6de x8581d0178e3a2b89;

	private x57df270da83ea6de x9f60178899a7cf7e;

	internal x340c022cb012d2c3(OfficeMath officeMath)
		: this(officeMath, officeMath.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x398384f7454300c1)
	{
	}

	internal x340c022cb012d2c3(OfficeMath officeMath, bool scriptBefore)
		: base(officeMath)
	{
		xf442f8ad925baa34 = new x57df270da83ea6de(officeMath);
		xf0e7190c3ad9bb90 = new x3a383e6be139fbaa(officeMath);
		x8581d0178e3a2b89 = new x57df270da83ea6de(officeMath);
		x9f60178899a7cf7e = new x57df270da83ea6de(officeMath);
		xf0e7190c3ad9bb90.x1fa9148f6731ff24(x9f60178899a7cf7e);
		xf0e7190c3ad9bb90.x1fa9148f6731ff24(x8581d0178e3a2b89);
		if (scriptBefore)
		{
			base.x1fa9148f6731ff24(xf0e7190c3ad9bb90);
			base.x1fa9148f6731ff24(xf442f8ad925baa34);
		}
		else
		{
			base.x1fa9148f6731ff24(xf442f8ad925baa34);
			base.x1fa9148f6731ff24(xf0e7190c3ad9bb90);
		}
	}

	internal override void x1fa9148f6731ff24(x57df270da83ea6de x4bbc2c453c470189)
	{
		switch (x4bbc2c453c470189.xc48e358ce4f81353.x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.x16984029356c96b7:
			x9f60178899a7cf7e.x1fa9148f6731ff24(x4bbc2c453c470189);
			break;
		case x3e68720d12325f49.x06b102f48629e32f:
			x8581d0178e3a2b89.x1fa9148f6731ff24(x4bbc2c453c470189);
			break;
		default:
			xf442f8ad925baa34.x1fa9148f6731ff24(x4bbc2c453c470189);
			break;
		}
	}

	internal override void x62084450a0785b90()
	{
		xf0e7190c3ad9bb90.xb7ae55095fddecd9();
		xf0e7190c3ad9bb90.x43a729b39a97938d = x9f60178899a7cf7e.x6ae4612a8469678e.Height;
		if (xc69c22e02e64cead())
		{
			xf0e7190c3ad9bb90.x5152a5707921c783(0.75f, 0.75f);
		}
		xf442f8ad925baa34.xb7ae55095fddecd9();
		x5c013976a3dd29e6(xf0e7190c3ad9bb90);
		x5c013976a3dd29e6(xf442f8ad925baa34);
	}

	private bool xc69c22e02e64cead()
	{
		OfficeMath officeMath = base.xc48e358ce4f81353;
		while (officeMath.ParentNode != null && officeMath.ParentNode.NodeType == NodeType.OfficeMath)
		{
			OfficeMath officeMath2 = (OfficeMath)officeMath.ParentNode;
			if (officeMath2.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x06b102f48629e32f || officeMath2.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x16984029356c96b7)
			{
				return false;
			}
			officeMath = officeMath2;
		}
		return true;
	}
}
