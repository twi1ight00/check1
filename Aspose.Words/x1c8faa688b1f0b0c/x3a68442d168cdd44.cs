using System.Collections;
using System.Drawing;
using x5794c252ba25e723;
using xeb665d1aeef09d64;

namespace x1c8faa688b1f0b0c;

internal class x3a68442d168cdd44 : xfa6279ffd07aa4c9
{
	private readonly int x4574aea041dd835f;

	private readonly ArrayList x82b70567a5f68f41;

	private xe39d06eee35dd23d x4884fd3dc186019b = x6132db19c1686804;

	private static readonly xe39d06eee35dd23d x6132db19c1686804;

	public xe39d06eee35dd23d xddffcb24e864cfcc
	{
		get
		{
			return x4884fd3dc186019b;
		}
		set
		{
			x4884fd3dc186019b = value;
		}
	}

	public ArrayList xe0d5f9fb50308841 => x82b70567a5f68f41;

	public int xd2f68ee6f47e9dfb => x4574aea041dd835f;

	public override RectangleF BoundingBox
	{
		get
		{
			float num = x4884fd3dc186019b.x53531537bb3331e6;
			float num2 = x4884fd3dc186019b.x53531537bb3331e6;
			for (int i = 0; i < x82b70567a5f68f41.Count; i++)
			{
				string xb41faee6912a = (string)x82b70567a5f68f41[i];
				SizeF sizeF = x4884fd3dc186019b.x6e21842ebf5f70df(xb41faee6912a);
				if (sizeF.Width > num)
				{
					num = sizeF.Width;
				}
				if (sizeF.Height > num2)
				{
					num2 = sizeF.Height;
				}
			}
			return new RectangleF(base.xc22eade24b085d91, new SizeF(num + 3.5f, num2));
		}
	}

	public x3a68442d168cdd44(PointF origin, string name, ArrayList items, int defValue)
		: base(new PointF(origin.X - 1.75f, origin.Y), name)
	{
		x82b70567a5f68f41 = items;
		x4574aea041dd835f = defValue;
	}

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		visitor.VisitFormComboBox(this);
	}

	static x3a68442d168cdd44()
	{
		x6132db19c1686804 = x9d888f53892d94df.x9834ddb0e0bd5996.x491f5a7224612753("Times New Roman", 12f, FontStyle.Regular);
	}
}
