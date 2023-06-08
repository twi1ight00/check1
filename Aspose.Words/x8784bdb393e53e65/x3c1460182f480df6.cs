using System.Collections;
using System.Drawing;
using x5794c252ba25e723;

namespace x8784bdb393e53e65;

internal class x3c1460182f480df6
{
	private Stack xf55420ac0ffb78da = new Stack();

	public xb4fb73d10814e223 xe046b26e27734297
	{
		get
		{
			if (xf55420ac0ffb78da.Count == 0)
			{
				return new xb4fb73d10814e223();
			}
			return (xb4fb73d10814e223)xf55420ac0ffb78da.Peek();
		}
	}

	public void x84e43ba1eb351dc4(x78e18bdf9a108059 x678241938de24d81)
	{
		xb4fb73d10814e223 obj = xe046b26e27734297.xe96b59ccb9e69142(x678241938de24d81);
		xf55420ac0ffb78da.Push(obj);
	}

	public void x23f6d2779534dd99()
	{
		if (xf55420ac0ffb78da.Count > 0)
		{
			xf55420ac0ffb78da.Pop();
		}
	}

	public x804c5bce88a9bb35 x7aa7510ea77cbf15(RectangleF x06b4849f65f5a9e4)
	{
		xb4fb73d10814e223 xb4fb73d10814e224 = xe046b26e27734297;
		x54366fa5f75a02f7 shapeTransformation = xb4fb73d10814e224.x5abbd23972d570a2();
		x54366fa5f75a02f7 shapeOffset = xb4fb73d10814e224.x779d03b9e20d92f5();
		return new x804c5bce88a9bb35(shapeTransformation, shapeOffset);
	}
}
