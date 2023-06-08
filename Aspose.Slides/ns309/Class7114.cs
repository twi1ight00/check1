using System.Drawing;

namespace ns309;

internal class Class7114
{
	private Class7112 class7112_0;

	private float float_0;

	public virtual float HorizontalLevel => class7112_0.GetLevel();

	public virtual float VerticalAdvance => float_0;

	public virtual RectangleF Bounds => class7112_0.method_9();

	public virtual float LSB => class7112_0.method_10();

	public virtual float RSB => class7112_0.method_0();

	public virtual int Type => class7112_0.method_1();

	public Class7114()
	{
	}

	public Class7114(Class7112 metrics, float vertical)
	{
		class7112_0 = metrics;
		float_0 = vertical;
	}

	public Class7114(float horizontalAdvance, float verticalAdvance, RectangleF bounds, byte glyphType)
	{
		class7112_0 = new Class7112(horizontalAdvance, bounds, glyphType);
		float_0 = verticalAdvance;
	}

	public virtual bool vmethod_0()
	{
		return class7112_0.method_3();
	}

	public virtual bool vmethod_1()
	{
		return class7112_0.method_2();
	}

	public virtual bool vmethod_2()
	{
		return class7112_0.method_6();
	}

	public virtual bool vmethod_3()
	{
		return class7112_0.method_4();
	}

	public virtual bool vmethod_4()
	{
		return class7112_0.method_5();
	}
}
