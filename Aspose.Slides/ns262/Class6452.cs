using System.Drawing;
using ns218;
using ns224;
using ns235;
using ns253;

namespace ns262;

internal abstract class Class6452 : Interface300, Interface301
{
	protected Class5999 class5999_0;

	protected string string_0;

	protected double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private Class6438 class6438_0;

	private Interface304 interface304_0;

	private Enum836 enum836_0;

	private double double_4;

	public Enum836 TokenType => enum836_0;

	public double Width => double_0;

	public Class6438 Run
	{
		get
		{
			return class6438_0;
		}
		set
		{
			class6438_0 = value;
		}
	}

	public double X
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public double LineSpacing => double_3;

	public double Ascent => double_1;

	public double Descent => double_2;

	public double Height => double_1 + double_2;

	protected Class6445 RunProperties => class6438_0.RunProperties;

	protected Class6452(Interface304 serviceLocator, Class6438 run, Interface314 tokenIterator)
	{
		interface304_0 = serviceLocator;
		class6438_0 = run;
		string_0 = tokenIterator.Token;
		enum836_0 = tokenIterator.TokenType;
		method_0();
	}

	public override string ToString()
	{
		return vmethod_0();
	}

	public Class6219 imethod_0()
	{
		SizeF size = new SizeF((float)Width, (float)Ascent);
		double num = Class5955.smethod_38(RunProperties.Spacing.ValueInPoints);
		PointF origin = new PointF((float)X, 0f);
		Interface311 @interface = interface304_0.imethod_5();
		Class5998 color = @interface.imethod_0(RunProperties);
		Class5998 outlineColor = @interface.imethod_1(RunProperties);
		return new Class6219(class5999_0, color, outlineColor, origin, vmethod_0(), size, (float)num);
	}

	protected abstract string vmethod_0();

	protected abstract void vmethod_1();

	private void method_0()
	{
		method_1();
		vmethod_1();
	}

	private void method_1()
	{
		class5999_0 = interface304_0.imethod_3().imethod_0(RunProperties);
		if (class5999_0 != null)
		{
			double_3 = Class5955.smethod_38(class5999_0.LineSpacingPoints);
			double_1 = Class5955.smethod_38(class5999_0.AscentPoints);
			double_2 = Class5955.smethod_38(class5999_0.DescentPoints);
		}
	}
}
