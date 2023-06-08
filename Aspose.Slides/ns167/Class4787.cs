using System;
using System.Collections;
using System.Drawing;
using ns235;

namespace ns167;

internal class Class4787 : Class4779
{
	private RectangleF rectangleF_0;

	private Class6213 class6213_0;

	private Hashtable hashtable_0 = new Hashtable();

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

	internal Class6213 Canvas
	{
		get
		{
			return class6213_0;
		}
		set
		{
			class6213_0 = value;
		}
	}

	internal override bool CanHaveChildren => false;

	public override object Current
	{
		get
		{
			throw new InvalidOperationException("Enumeration is not supported.");
		}
	}

	internal override float GetRealWidth => 0f;

	internal override bool CanBeOptimized => false;

	internal Hashtable PathToZId => hashtable_0;

	internal Class4787()
	{
		class6213_0 = new Class6213();
		rectangleF_0 = RectangleF.Empty;
	}

	public override IEnumerator GetEnumerator()
	{
		return PathToZId.GetEnumerator();
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
	}

	internal void method_1(Class6217 path, int zID)
	{
		PathToZId.Add(path, zID);
	}
}
