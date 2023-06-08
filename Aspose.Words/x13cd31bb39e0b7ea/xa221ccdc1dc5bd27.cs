using Aspose.Words;
using x28925c9b27b37a46;
using x38d3ef1c1d247e82;
using x6c95d9cf46ff5f25;
using x9e34b6f7e9185197;
using xc76255e87e5986c6;

namespace x13cd31bb39e0b7ea;

internal class xa221ccdc1dc5bd27 : x2d1eb36fbee7f55a
{
	private bool x14b97b7d9dea1217;

	private x3dabda6865ed239d xd2714535f669c453;

	private x1e9b3e0e8864e135 x0da9da90bfa5838b;

	private static readonly int[] x44bf96149d676f96 = new int[4] { 230, 270, 235, 240 };

	private static readonly xd0fe745f27933c97[] x5dfda13c4767ecf6 = new xd0fe745f27933c97[8]
	{
		xd0fe745f27933c97.xda51a4646f9f1d2d,
		xd0fe745f27933c97.xaeb730a64aee20c9,
		xd0fe745f27933c97.x30b70c795933534f,
		xd0fe745f27933c97.x66341c066a75e7f9,
		xd0fe745f27933c97.x66d2ceccc2db37c1,
		xd0fe745f27933c97.x6a2e55c2ebf144a4,
		xd0fe745f27933c97.xd0e706f7fa6c84d1,
		xd0fe745f27933c97.xb5416fb0ca9c28ab
	};

	internal void x18dfca7c5fd2402f(DocumentBase x6beba47238e0ade6, x1e9b3e0e8864e135 x33e549b893445a37, bool x01d490739120dd35)
	{
		x14b97b7d9dea1217 = x01d490739120dd35;
		xd2714535f669c453 = x6beba47238e0ade6.x9bb3f6e28fa55f34();
		x0da9da90bfa5838b = x33e549b893445a37;
		x6beba47238e0ade6.Accept(this);
		if (x0da9da90bfa5838b != null)
		{
			xf8a0e0ab1cdfa331();
		}
	}

	protected override void DoHandleRunPr(xeedad81aaed42a76 runPr)
	{
		if (runPr != null)
		{
			if (x14b97b7d9dea1217)
			{
				x30f96f66f1661e11(runPr);
			}
			if (x0da9da90bfa5838b != null)
			{
				x90155d31864eeb96(runPr);
			}
		}
	}

	private void xf8a0e0ab1cdfa331()
	{
		if (xd2714535f669c453 != null)
		{
			xd0fe745f27933c97[] array = x5dfda13c4767ecf6;
			foreach (xd0fe745f27933c97 xa1724a07fef092c in array)
			{
				string text = xd2714535f669c453.xaf95fb496eb25433(xa1724a07fef092c);
				if (x0d299f323d241756.x5959bccb67bbf051(text))
				{
					x0da9da90bfa5838b.xd6b6ed77479ef68c(text);
				}
			}
		}
		x0da9da90bfa5838b.xd6b6ed77479ef68c(xeedad81aaed42a76.x0095b789d636f3ae(230));
	}

	private void x30f96f66f1661e11(xeedad81aaed42a76 x789564759d365819)
	{
		x2eb602182f228b13(x789564759d365819, 530, 230);
		x2eb602182f228b13(x789564759d365819, 560, 270);
		x2eb602182f228b13(x789564759d365819, 550, 235);
		x2eb602182f228b13(x789564759d365819, 540, 240);
	}

	private void x2eb602182f228b13(xeedad81aaed42a76 x789564759d365819, int x737c76338f805efb, int x405d47e0d1fb89e8)
	{
		if (((x09ce2c02826e31a6)x789564759d365819).get_xe6d4b1b411ed94b5(x405d47e0d1fb89e8) != null)
		{
			return;
		}
		object obj = x789564759d365819.xf7866f89640a29a3(x737c76338f805efb);
		if (obj != null)
		{
			xd0fe745f27933c97 xa1724a07fef092c = (xd0fe745f27933c97)obj;
			string xbcea506a33cf = xd2714535f669c453.xaf95fb496eb25433(xa1724a07fef092c);
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
			{
				x789564759d365819.xae20093bed1e48a8(x405d47e0d1fb89e8, xbcea506a33cf);
			}
			x789564759d365819.x52b190e626f65140(x737c76338f805efb);
		}
	}

	private void x90155d31864eeb96(xeedad81aaed42a76 x789564759d365819)
	{
		int[] array = x44bf96149d676f96;
		foreach (int xba08ce632055a1d in array)
		{
			object obj = x789564759d365819.xf7866f89640a29a3(xba08ce632055a1d);
			if (obj != null)
			{
				x0da9da90bfa5838b.xd6b6ed77479ef68c(obj);
			}
		}
	}
}
