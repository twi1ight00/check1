using Aspose.Words;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x9db5f2e5af3d596e;

namespace xf989f31a236ff98c;

internal class x20eec3666a2dc8d0
{
	private readonly xac4d96a62eaba39e x66c02128fdc6436a;

	private bool x1f0484f9483c2ba8;

	private bool xcbb460c1f6be6309;

	private bool x2585f423574e6984
	{
		get
		{
			if (!x1f0484f9483c2ba8)
			{
				xcbb460c1f6be6309 = (bool)x66c02128fdc6436a.xc3cc338a59c5293b(1560);
				x1f0484f9483c2ba8 = true;
			}
			return xcbb460c1f6be6309;
		}
	}

	private x20eec3666a2dc8d0(xac4d96a62eaba39e pr)
	{
		x66c02128fdc6436a = pr;
	}

	internal static void xb07a1ad51e61e4f3(StyleCollection x3fa6ecdd18b2ff6e, bool xdd0280d7d3660ad1)
	{
		foreach (Style item in x3fa6ecdd18b2ff6e)
		{
			if (item.Type == StyleType.Paragraph)
			{
				xb07a1ad51e61e4f3(item);
			}
		}
	}

	internal static void xb07a1ad51e61e4f3(xac4d96a62eaba39e x94aec03cf2ae750b)
	{
		x20eec3666a2dc8d0 x20eec3666a2dc8d = new x20eec3666a2dc8d0(x94aec03cf2ae750b);
		x20eec3666a2dc8d.x2a67e75fbdea29ff(1620, 1160, 1150);
		x20eec3666a2dc8d.x2a67e75fbdea29ff(1630, 1150, 1160);
		x20eec3666a2dc8d.x2a67e75fbdea29ff(1640, 1170, 1170);
		x20eec3666a2dc8d.x0a13294e86afd206();
	}

	private void x2a67e75fbdea29ff(int xce4ff28c53458566, int x1d5369b215707590, int x6d9f69da7120d190)
	{
		object obj = x66c02128fdc6436a.xb86fdbeadec3b75c(xce4ff28c53458566);
		if (obj != null)
		{
			int xba08ce632055a1d = (x2585f423574e6984 ? x6d9f69da7120d190 : x1d5369b215707590);
			x66c02128fdc6436a.xb6157b6da9895c0d(xba08ce632055a1d, obj);
			x66c02128fdc6436a.xb55a99e2e1381d7f(xce4ff28c53458566);
		}
	}

	private void x0a13294e86afd206()
	{
		object obj = x66c02128fdc6436a.xb86fdbeadec3b75c(1610);
		if (obj != null)
		{
			if (x2585f423574e6984)
			{
				obj = x1a78664fa10a3755.xbf8ba56877f02689((ParagraphAlignment)obj);
			}
			x66c02128fdc6436a.xb6157b6da9895c0d(1020, obj);
			x66c02128fdc6436a.xb55a99e2e1381d7f(1610);
		}
	}

	internal static void x945c00cb2f79f4ea(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		object obj = xe193ceb565ecaa0a.xf7866f89640a29a3(5101);
		if (obj == null)
		{
			return;
		}
		if (xe193ceb565ecaa0a.xf7866f89640a29a3(4010) == null)
		{
			if (xe193ceb565ecaa0a.xcedf9c82728ad579)
			{
				obj = xedb0eb766e25e0c9.xbf8ba56877f02689((TableAlignment)obj);
			}
			xe193ceb565ecaa0a.xae20093bed1e48a8(4010, obj);
		}
		xe193ceb565ecaa0a.x52b190e626f65140(5101);
	}
}
