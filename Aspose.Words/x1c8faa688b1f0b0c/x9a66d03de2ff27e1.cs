using System.Drawing;
using System.Text.RegularExpressions;

namespace x1c8faa688b1f0b0c;

internal class x9a66d03de2ff27e1 : x4fdf549af9de6b97
{
	private PointF x831916008bfc3ed7 = PointF.Empty;

	private readonly string xc61ff88f1f98652d;

	public PointF xc22eade24b085d91
	{
		get
		{
			return x831916008bfc3ed7;
		}
		set
		{
			x831916008bfc3ed7 = value;
		}
	}

	public string x759aa16c2016a289 => xc61ff88f1f98652d;

	public bool x4b8f3649c1a3071c => xc61ff88f1f98652d.StartsWith("_");

	public x9a66d03de2ff27e1(PointF origin, string name)
	{
		x831916008bfc3ed7 = origin;
		xc61ff88f1f98652d = x493eb1990ce18545(name);
	}

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		visitor.VisitBookmark(this);
	}

	internal static string x493eb1990ce18545(string xc15bd84e01929885)
	{
		Regex regex = new Regex("\\s");
		return regex.Replace(xc15bd84e01929885, "_");
	}
}
