using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Words.Math;
using x5794c252ba25e723;

namespace x50d2f537cc336076;

internal class x1dfdb69b4a79e67d : x57df270da83ea6de
{
	private float x3261abcac8888c4a;

	private int x9c8e465a79bff887;

	private readonly xe22a4a9a14e524d7 x1f5fa703ca321162;

	internal xe22a4a9a14e524d7 xa796a0bb75c9edf6 => x1f5fa703ca321162;

	internal x1dfdb69b4a79e67d(xe22a4a9a14e524d7 parentMatrix, OfficeMath officeMath)
		: base(officeMath)
	{
		x1f5fa703ca321162 = parentMatrix;
	}

	internal override void x62084450a0785b90()
	{
		for (int i = 0; i < base.xf2453c298c5de6f5.Count; i++)
		{
			x57df270da83ea6de x57df270da83ea6de2 = (x57df270da83ea6de)base.xf2453c298c5de6f5[i];
			x57df270da83ea6de2.xb7ae55095fddecd9();
			x1f5fa703ca321162.xa79d36cfb8b92ea1(x57df270da83ea6de2, i);
			x5c013976a3dd29e6(x57df270da83ea6de2);
		}
	}

	internal override void xb7ae55095fddecd9()
	{
		for (int i = 0; i < base.xf2453c298c5de6f5.Count; i++)
		{
			x57df270da83ea6de x57df270da83ea6de2 = (x57df270da83ea6de)base.xf2453c298c5de6f5[i];
			base.xefb7a8f84373ac04.xd6b6ed77479ef68c(x57df270da83ea6de2.xefb7a8f84373ac04);
			float num = x1f5fa703ca321162.x3a2949e4f384d864(i);
			float x3758cf4ee715d = x3261abcac8888c4a + (num - x57df270da83ea6de2.x6ae4612a8469678e.Width) / 2f;
			float x6842879318972d9e = base.x43a729b39a97938d - x57df270da83ea6de2.x43a729b39a97938d;
			if (x57df270da83ea6de2.xefb7a8f84373ac04.x52dde376accdec7d == null)
			{
				x57df270da83ea6de2.xefb7a8f84373ac04.x52dde376accdec7d = new x54366fa5f75a02f7();
			}
			x57df270da83ea6de2.xefb7a8f84373ac04.x52dde376accdec7d.xce92de628aa023cf(x3758cf4ee715d, x6842879318972d9e, MatrixOrder.Append);
			x3261abcac8888c4a += num;
			if (i < base.xf2453c298c5de6f5.Count - 1)
			{
				x3261abcac8888c4a += x1f5fa703ca321162.x79e0368f9606a712;
			}
		}
		x6ae4612a8469678e = new RectangleF(x6ae4612a8469678e.X, x6ae4612a8469678e.Y, x3261abcac8888c4a, x6ae4612a8469678e.Height);
	}

	internal override void x1fa9148f6731ff24(x57df270da83ea6de x4bbc2c453c470189)
	{
		if (x9c8e465a79bff887 >= x1f5fa703ca321162.x6e1eb96b81362ebc)
		{
			throw new IndexOutOfRangeException("Cannot add column at this index");
		}
		base.x1fa9148f6731ff24(x4bbc2c453c470189);
		x9c8e465a79bff887++;
	}
}
