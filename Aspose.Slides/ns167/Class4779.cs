using System.Collections;
using System.Drawing;
using ns161;
using ns235;

namespace ns167;

internal abstract class Class4779 : IEnumerable, IEnumerator
{
	private Class4779 class4779_0;

	internal abstract PointF Origin { get; set; }

	internal abstract RectangleF BoundingBox { get; }

	internal abstract string Text { get; }

	internal abstract float InsideTextDistance { get; }

	internal abstract PointF MassCenter { get; }

	internal PointF GeometricCenter => new PointF(BoundingBox.Width / 2f + BoundingBox.X, BoundingBox.Height / 2f + BoundingBox.Y);

	internal abstract float FontSize { get; }

	internal abstract Enum672 Style { get; }

	internal abstract string FontFace { get; }

	internal abstract float Compactness { get; }

	internal Class4779 Parent
	{
		get
		{
			return class4779_0;
		}
		set
		{
			class4779_0 = value;
		}
	}

	internal abstract bool CanBeOptimized { get; }

	private SizeF RelativeOffset => new SizeF(BoundingBox.X, BoundingBox.Y);

	internal abstract bool CanHaveChildren { get; }

	public abstract object Current { get; }

	internal abstract float GetRealWidth { get; }

	internal Class4779 MParent
	{
		get
		{
			return class4779_0;
		}
		set
		{
			class4779_0 = value;
		}
	}

	internal virtual void vmethod_0()
	{
		if (class4779_0 != null)
		{
			class4779_0.vmethod_0();
		}
	}

	public abstract IEnumerator GetEnumerator();

	public abstract bool MoveNext();

	public abstract void Reset();

	internal PointF method_0(PointF absolute, float leftMargin)
	{
		if (Class4860.Instance.Options.Mode == Enum676.const_1)
		{
			return new PointF(absolute.X - ((this is Class4781) ? RelativeOffset.Width : leftMargin), absolute.Y - RelativeOffset.Height);
		}
		return new PointF(absolute.X - RelativeOffset.Width, absolute.Y - RelativeOffset.Height);
	}

	internal abstract void vmethod_1(Class6216 targetPage);
}
