using System.Collections;
using x5794c252ba25e723;

namespace xc7ce8a6a920f8012;

internal class xfaa0b71704009335 : x0096796e2eb81db6
{
	private short xd3c04920a4e99e88 = 1;

	private ArrayList xe748e4e777f2627a = new ArrayList();

	private short x4f42947183db5ba4;

	public short xde89252455da1b3c => x4f42947183db5ba4;

	public xfaa0b71704009335(x34b34bf589d8ec1e context, short characterId)
		: base(context)
	{
		x4f42947183db5ba4 = characterId;
	}

	public void x1fa9148f6731ff24(short x9780d7c271345d55, x54366fa5f75a02f7 x5b0b266e72247144, string xc15bd84e01929885)
	{
		x1fa9148f6731ff24(x9780d7c271345d55, x5b0b266e72247144, xc15bd84e01929885, x4fc602f6d6f4c1ca: false);
	}

	public void x1fa9148f6731ff24(short x9780d7c271345d55, x54366fa5f75a02f7 x5b0b266e72247144, string xc15bd84e01929885, bool x4fc602f6d6f4c1ca)
	{
		x36ed93bceea22bd2 value = new x36ed93bceea22bd2(x9780d7c271345d55, x5b0b266e72247144, xd3c04920a4e99e88++, xc15bd84e01929885, x4fc602f6d6f4c1ca);
		xe748e4e777f2627a.Add(value);
	}

	public void x6210059f049f0d48()
	{
		xb4e6bcae51300e9c xb4e6bcae51300e9c2 = new xb4e6bcae51300e9c(base.x28fcdc775a1d069c);
		xb4e6bcae51300e9c2.xacf4b9ddf32bef06();
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(x4f42947183db5ba4);
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(1);
		xa8cbe6d157a3b60f xa8cbe6d157a3b60f2 = new xa8cbe6d157a3b60f(base.x28fcdc775a1d069c);
		foreach (x36ed93bceea22bd2 item in xe748e4e777f2627a)
		{
			xa8cbe6d157a3b60f2.x23deaf2a36abf030(item);
		}
		base.x5aa326f374b3d0ef.x4eadf767e5f91a38(xf066f1f57515a14c.xcb09e66e779b210e, 0);
		base.x5aa326f374b3d0ef.x4eadf767e5f91a38(xf066f1f57515a14c.x9fd888e65466818c, 0);
		xb4e6bcae51300e9c2.xc463dec5a3ab6e2d(xf066f1f57515a14c.x96542c3f203318aa);
	}
}
