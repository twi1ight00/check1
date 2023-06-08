using System;
using Aspose.Words.Math;
using x28925c9b27b37a46;
using xe5b37aee2c2a4d4e;

namespace x50d2f537cc336076;

internal class x5f3b476864de6d7d : x3a383e6be139fbaa
{
	private const float x9d2c78d5023b25af = 0.75f;

	private x57df270da83ea6de x17df215388015b66;

	private x57df270da83ea6de xf588c0e36fc7325d;

	private x57df270da83ea6de xe5aa9f13f1710148;

	internal x5f3b476864de6d7d(OfficeMath officeMath)
		: base(officeMath)
	{
		x17df215388015b66 = new x57df270da83ea6de(officeMath);
		xf588c0e36fc7325d = new x57df270da83ea6de(officeMath);
		xe5aa9f13f1710148 = new x57df270da83ea6de(officeMath);
		base.x1fa9148f6731ff24(x17df215388015b66);
		base.x1fa9148f6731ff24(xe5aa9f13f1710148);
		base.x1fa9148f6731ff24(xf588c0e36fc7325d);
		xeedad81aaed42a76 xeedad81aaed42a = (xeedad81aaed42a76)officeMath.xeedad81aaed42a76.x8b61531c8ea35b85();
		xeedad81aaed42a.x437e3b626c0fdd43 *= 2;
		x6dd1552d6eb89e4e x6dd1552d6eb89e4e = (x6dd1552d6eb89e4e)officeMath.x52642f91ccdeeb35;
		xe5aa9f13f1710148.x1fa9148f6731ff24(new xc1e7448c64b3a897(x6dd1552d6eb89e4e.x067d56aec20cdd99.ToString(), xeedad81aaed42a, isArgument: false));
	}

	internal override void x1fa9148f6731ff24(x57df270da83ea6de x4bbc2c453c470189)
	{
		switch (x4bbc2c453c470189.xc48e358ce4f81353.x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.x06b102f48629e32f:
			xf588c0e36fc7325d.x1fa9148f6731ff24(x4bbc2c453c470189);
			break;
		case x3e68720d12325f49.x16984029356c96b7:
			x17df215388015b66.x1fa9148f6731ff24(x4bbc2c453c470189);
			break;
		default:
			throw new ArgumentException("Cannot add child of this type to the NAry function. Only subscript and superscript parts are allowed.");
		}
	}

	internal override void x62084450a0785b90()
	{
		foreach (x57df270da83ea6de item in x17df215388015b66.xf2453c298c5de6f5)
		{
			item.xb7ae55095fddecd9();
			item.x5152a5707921c783(0.75f, 0.75f);
		}
		foreach (x57df270da83ea6de item2 in xf588c0e36fc7325d.xf2453c298c5de6f5)
		{
			item2.xb7ae55095fddecd9();
			item2.x5152a5707921c783(0.75f, 0.75f);
		}
		base.x62084450a0785b90();
		base.x43a729b39a97938d = x17df215388015b66.x6ae4612a8469678e.Height + xe5aa9f13f1710148.x43a729b39a97938d;
	}
}
