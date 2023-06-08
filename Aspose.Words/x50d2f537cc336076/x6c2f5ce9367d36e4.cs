using System;
using Aspose.Words.Math;
using xe5b37aee2c2a4d4e;

namespace x50d2f537cc336076;

internal class x6c2f5ce9367d36e4 : x3a383e6be139fbaa
{
	private const float x9d2c78d5023b25af = 0.75f;

	private x57df270da83ea6de xb058538a38b71129;

	private x57df270da83ea6de x8954221d9fbe23e7;

	private bool xd76d8f4882000377;

	internal x6c2f5ce9367d36e4(OfficeMath officeMath, bool isLowerLimit)
		: base(officeMath)
	{
		xd76d8f4882000377 = isLowerLimit;
		xb058538a38b71129 = new x57df270da83ea6de(officeMath);
		x8954221d9fbe23e7 = new x57df270da83ea6de(officeMath);
		if (isLowerLimit)
		{
			base.x1fa9148f6731ff24(xb058538a38b71129);
			base.x1fa9148f6731ff24(x8954221d9fbe23e7);
		}
		else
		{
			base.x1fa9148f6731ff24(x8954221d9fbe23e7);
			base.x1fa9148f6731ff24(xb058538a38b71129);
		}
	}

	internal override void x1fa9148f6731ff24(x57df270da83ea6de x4bbc2c453c470189)
	{
		switch (x4bbc2c453c470189.xc48e358ce4f81353.x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.x1745ba6c6d5efbc4:
			x6463ea8e852547f9(x4bbc2c453c470189);
			break;
		case x3e68720d12325f49.x25d26846c330b189:
			x781e389ae8ccabea(x4bbc2c453c470189);
			break;
		default:
			throw new ArgumentException("Cannot add child of this type to the UpperLimit/LowerLimit element. Only Argument and Limit parts are allowed.");
		}
	}

	internal override void x62084450a0785b90()
	{
		foreach (x57df270da83ea6de item in x8954221d9fbe23e7.xf2453c298c5de6f5)
		{
			item.xb7ae55095fddecd9();
			item.x5152a5707921c783(0.75f, 0.75f);
		}
		base.x62084450a0785b90();
		base.x43a729b39a97938d = (xd76d8f4882000377 ? xb058538a38b71129.x43a729b39a97938d : (x8954221d9fbe23e7.x6ae4612a8469678e.Height + xb058538a38b71129.x43a729b39a97938d));
	}

	internal void x6463ea8e852547f9(x57df270da83ea6de x4bbc2c453c470189)
	{
		xb058538a38b71129.x1fa9148f6731ff24(x4bbc2c453c470189);
	}

	internal void x781e389ae8ccabea(x57df270da83ea6de x4bbc2c453c470189)
	{
		x8954221d9fbe23e7.x1fa9148f6731ff24(x4bbc2c453c470189);
	}
}
