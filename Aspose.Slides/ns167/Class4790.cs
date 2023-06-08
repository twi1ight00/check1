using System;
using System.Collections;
using System.Drawing;
using ns235;

namespace ns167;

internal class Class4790 : Class4779
{
	internal const int int_0 = 1;

	internal const int int_1 = 1;

	internal const int int_2 = 1;

	private bool bool_0;

	private readonly Class6220 class6220_0;

	private RectangleF rectangleF_0;

	private int int_3 = -1;

	internal override PointF Origin
	{
		get
		{
			return rectangleF_0.Location;
		}
		set
		{
			rectangleF_0.Location = value;
		}
	}

	internal override RectangleF BoundingBox => rectangleF_0;

	internal override string Text => string.Empty;

	internal override float InsideTextDistance => 0f;

	internal override PointF MassCenter => new PointF(BoundingBox.Width / 2f + BoundingBox.X, BoundingBox.Height / 2f + BoundingBox.Y);

	internal override float FontSize => 0f;

	internal override Enum672 Style => Enum672.flag_0;

	internal override string FontFace => string.Empty;

	internal override float Compactness => 1f;

	internal override bool CanHaveChildren => false;

	public override object Current
	{
		get
		{
			throw new InvalidOperationException("Enumeration is not supported.");
		}
	}

	public byte[] ImageData => class6220_0.ImageBytes;

	internal override float GetRealWidth => 0f;

	internal override bool CanBeOptimized => false;

	internal bool IsBehindText
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public int ZId => int_3;

	internal Class4790(Class6220 source)
	{
		class6220_0 = source;
		SizeF size = source.Size;
		size.Width /= 1f;
		size.Height /= 1f;
		rectangleF_0 = new RectangleF(source.Origin, size);
	}

	internal Class4790(Class6220 source, int zId)
	{
		class6220_0 = source;
		SizeF size = source.Size;
		size.Width /= 1f;
		size.Height /= 1f;
		int_3 = zId;
		rectangleF_0 = new RectangleF(source.Origin, size);
	}

	public override IEnumerator GetEnumerator()
	{
		throw new InvalidOperationException("Enumeration is not supported.");
	}

	public override bool MoveNext()
	{
		throw new InvalidOperationException("Enumeration is not supported.");
	}

	public override void Reset()
	{
		throw new InvalidOperationException("Enumeration is not supported.");
	}

	internal override void vmethod_1(Class6216 targetPage)
	{
		SizeF size = class6220_0.Size;
		size.Width /= 1f;
		size.Height /= 1f;
		targetPage.Add(new Class6220(class6220_0.Origin, size, class6220_0.ImageBytes));
	}
}
