using System;

namespace x4f4df92b75ba3b67;

internal class x3a8cfc6f629fbbd3 : x264ba3b7aca691be
{
	private static readonly x71d83b132c76c288 xf208939c35716203 = x71d83b132c76c288.x35bdac1bf9dfae7c;

	private x71d83b132c76c288 xbda386857a145ba9 = xf208939c35716203;

	private x71d83b132c76c288 xb5262e43897a32f1 = xf208939c35716203;

	private x71d83b132c76c288 x029943228f3f94d0 = xf208939c35716203;

	private x71d83b132c76c288 x857835c88ba4a346 = xf208939c35716203;

	private x8424217194953834 x5611b3ba1d52b4e3 = x04941736fe45f438;

	private static readonly x8424217194953834 x04941736fe45f438 = x8424217194953834.x3b69e896556f1925;

	private bool xa4b4bec426f1f34c;

	private static readonly bool xa7f0b4a45b8589d5 = false;

	private bool x87e0a27e5f148320 = xa7f0b4a45b8589d5;

	private bool x26ce5e959d0833f8 = xa7f0b4a45b8589d5;

	private bool x7c46799532a8a94d = xa7f0b4a45b8589d5;

	private bool x43fd597c9509f662 = xa7f0b4a45b8589d5;

	private bool xe8ab99892ccb6332 = xa7f0b4a45b8589d5;

	private bool x2d9aac06110737f7 = xa7f0b4a45b8589d5;

	public bool x386272bfac8a85ce
	{
		get
		{
			return x2d9aac06110737f7;
		}
		set
		{
			x2d9aac06110737f7 = value;
		}
	}

	public bool x2b59d72739c06121
	{
		get
		{
			return xe8ab99892ccb6332;
		}
		set
		{
			xe8ab99892ccb6332 = value;
		}
	}

	public bool xe61f01b2459117b7
	{
		get
		{
			return x43fd597c9509f662;
		}
		set
		{
			x43fd597c9509f662 = value;
		}
	}

	public bool x802ea1fff4062090
	{
		get
		{
			return x7c46799532a8a94d;
		}
		set
		{
			x7c46799532a8a94d = value;
		}
	}

	public bool x33643aa82f2d76fc
	{
		get
		{
			return x26ce5e959d0833f8;
		}
		set
		{
			x26ce5e959d0833f8 = value;
		}
	}

	public bool x566babeed8c6845f
	{
		get
		{
			return x87e0a27e5f148320;
		}
		set
		{
			x87e0a27e5f148320 = value;
		}
	}

	public x8424217194953834 xffa5635a5bafbff0
	{
		get
		{
			return x5611b3ba1d52b4e3;
		}
		set
		{
			switch (value)
			{
			case x8424217194953834.x3b69e896556f1925:
			case x8424217194953834.xfd8cbfbeef1b8f83:
			case x8424217194953834.x61f811cb359b47c8:
			case x8424217194953834.xa651687af7e276c1:
				x5611b3ba1d52b4e3 = value;
				break;
			default:
				throw new ArgumentOutOfRangeException("Please report exception. Invalid PdfPageModeType value.");
			}
		}
	}

	internal bool xcbd6c6bf927b346a
	{
		get
		{
			return xa4b4bec426f1f34c;
		}
		set
		{
			xa4b4bec426f1f34c = value;
		}
	}

	public x71d83b132c76c288 x6e02b9c75c9d4748
	{
		get
		{
			return x857835c88ba4a346;
		}
		set
		{
			x857835c88ba4a346 = value;
		}
	}

	public x71d83b132c76c288 x1ee746dd2a1971c4
	{
		get
		{
			return x029943228f3f94d0;
		}
		set
		{
			x029943228f3f94d0 = value;
		}
	}

	public x71d83b132c76c288 x7616c15a6c715635
	{
		get
		{
			return xb5262e43897a32f1;
		}
		set
		{
			xb5262e43897a32f1 = value;
		}
	}

	public x71d83b132c76c288 x3d2310214f6233ba
	{
		get
		{
			return xbda386857a145ba9;
		}
		set
		{
			xbda386857a145ba9 = value;
		}
	}

	internal x3a8cfc6f629fbbd3(x4882ae789be6e2ef context)
		: base(context)
	{
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		if (xbda386857a145ba9 != xf208939c35716203)
		{
			writer.xa4dc0ad8886e23a2("/PrintClip", xb4f4824af7c55e3a.xe379e5b48a37d6a8(xbda386857a145ba9));
		}
		if (xb5262e43897a32f1 != xf208939c35716203)
		{
			writer.xa4dc0ad8886e23a2("/PrintArea", xb4f4824af7c55e3a.xe379e5b48a37d6a8(xb5262e43897a32f1));
		}
		if (x029943228f3f94d0 != xf208939c35716203)
		{
			writer.xa4dc0ad8886e23a2("/ViewClip", xb4f4824af7c55e3a.xe379e5b48a37d6a8(x029943228f3f94d0));
		}
		if (x857835c88ba4a346 != xf208939c35716203)
		{
			writer.xa4dc0ad8886e23a2("/ViewArea", xb4f4824af7c55e3a.xe379e5b48a37d6a8(x857835c88ba4a346));
		}
		if (xa4b4bec426f1f34c && x5611b3ba1d52b4e3 != x04941736fe45f438)
		{
			writer.xa4dc0ad8886e23a2("/NonFullScreenPageMode", xb4f4824af7c55e3a.xe7c427215108f919(x5611b3ba1d52b4e3));
		}
		if (x87e0a27e5f148320 != xa7f0b4a45b8589d5)
		{
			writer.xa4dc0ad8886e23a2("/DisplayDocTitle", x87e0a27e5f148320);
		}
		if (x26ce5e959d0833f8 != xa7f0b4a45b8589d5)
		{
			writer.xa4dc0ad8886e23a2("/CenterWindow", x26ce5e959d0833f8);
		}
		if (x7c46799532a8a94d != xa7f0b4a45b8589d5)
		{
			writer.xa4dc0ad8886e23a2("/FitWindow", x7c46799532a8a94d);
		}
		if (x43fd597c9509f662 != xa7f0b4a45b8589d5)
		{
			writer.xa4dc0ad8886e23a2("/HideWindowUI", x43fd597c9509f662);
		}
		if (xe8ab99892ccb6332 != xa7f0b4a45b8589d5)
		{
			writer.xa4dc0ad8886e23a2("/HideMenubar", xe8ab99892ccb6332);
		}
		if (x2d9aac06110737f7 != xa7f0b4a45b8589d5)
		{
			writer.xa4dc0ad8886e23a2("/HideToolbar", x2d9aac06110737f7);
		}
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
	}
}
