using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns309;

internal class Class7110
{
	public class Class7111
	{
		internal RectangleF rectangleF_0;

		internal RectangleF rectangleF_1;

		internal GraphicsPath graphicsPath_0;

		public virtual GraphicsPath Outline => graphicsPath_0;

		public virtual RectangleF Bounds => rectangleF_0;

		public virtual RectangleF OutlineBounds => rectangleF_1;

		public Class7111(GraphicsPath outline, RectangleF geometrySpace)
		{
			graphicsPath_0 = outline;
			rectangleF_1 = outline.GetBounds();
			rectangleF_0 = geometrySpace;
		}
	}

	internal int int_0;

	internal Stack stack_0 = new Stack();

	internal Hashtable hashtable_0 = new Hashtable();

	public Class7110()
	{
		hashtable_0 = new Hashtable();
	}

	public Class7110(int count)
	{
		hashtable_0 = new Hashtable(count);
	}

	public virtual int vmethod_0()
	{
		return int_0;
	}

	public virtual Class7111 vmethod_1(char code)
	{
		if (hashtable_0.ContainsKey(code))
		{
			return (Class7111)hashtable_0[code];
		}
		return null;
	}

	public virtual Class7111 vmethod_2(char c, Class7111 value)
	{
		if (hashtable_0.ContainsKey(c))
		{
			hashtable_0[c] = value;
		}
		return null;
	}

	public virtual void Clear()
	{
		hashtable_0 = new Hashtable();
		int_0 = 0;
		stack_0 = new Stack();
	}
}
