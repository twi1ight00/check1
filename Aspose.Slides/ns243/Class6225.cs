using System.Drawing;
using ns235;
using ns242;

namespace ns243;

internal abstract class Class6225 : Interface260
{
	private PointF pointF_0 = PointF.Empty;

	private SizeF sizeF_0 = SizeF.Empty;

	private Struct220 struct220_0;

	public virtual PointF Location
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = value;
		}
	}

	public virtual SizeF Size => sizeF_0;

	public virtual Struct220 Margin
	{
		get
		{
			return struct220_0;
		}
		set
		{
			struct220_0 = value;
		}
	}

	public virtual RectangleF vmethod_0()
	{
		return new RectangleF(Location.X + Margin.float_1, Location.Y + Margin.float_0, Size.Width - Margin.float_1 - Margin.float_2, Size.Height - Margin.float_0 - Margin.float_3);
	}

	public virtual void vmethod_1(PointF toPoint)
	{
		pointF_0 = toPoint;
	}

	public void method_0(float x, float y)
	{
		vmethod_1(new PointF(x, y));
	}

	public void method_1(float dy)
	{
		method_0(Location.X, Location.Y + dy);
	}

	public void method_2(float dx)
	{
		method_0(Location.X + dx, Location.Y);
	}

	public abstract Class6204[] vmethod_2();

	public virtual void vmethod_3(Class6216 page, PointF position)
	{
		vmethod_1(position);
		page.method_0(vmethod_2());
	}

	public void method_3(Class6216 page, float x, float y)
	{
		vmethod_3(page, new PointF(x, y));
	}
}
