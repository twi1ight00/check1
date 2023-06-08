using System;
using System.Collections;
using System.Drawing;
using ns235;

namespace ns167;

internal class Class4789 : Class4779
{
	private static readonly PointF pointF_0 = default(PointF);

	private static readonly RectangleF rectangleF_0 = default(RectangleF);

	internal override PointF Origin
	{
		get
		{
			return pointF_0;
		}
		set
		{
		}
	}

	internal override RectangleF BoundingBox => rectangleF_0;

	internal override string Text => string.Empty;

	internal override float InsideTextDistance => 0f;

	internal override PointF MassCenter => pointF_0;

	internal override float FontSize => 1f;

	internal override Enum672 Style => Enum672.flag_0;

	internal override float Compactness => 0f;

	internal override bool CanHaveChildren => false;

	public override object Current
	{
		get
		{
			throw new InvalidOperationException("Please report exception. Can not enumerate" + ToString());
		}
	}

	internal override float GetRealWidth => 0f;

	internal override bool CanBeOptimized => false;

	internal override string FontFace => string.Empty;

	internal override void vmethod_1(Class6216 targetPage)
	{
	}

	public override IEnumerator GetEnumerator()
	{
		throw new InvalidOperationException("Please report exception. Can not enumerate" + ToString());
	}

	public override bool MoveNext()
	{
		throw new InvalidOperationException("Please report exception. Can not enumerate" + ToString());
	}

	public override void Reset()
	{
		throw new InvalidOperationException("Please report exception. Can not enumerate" + ToString());
	}
}
