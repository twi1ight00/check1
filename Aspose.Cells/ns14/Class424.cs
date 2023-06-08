using System.Runtime.CompilerServices;

namespace ns14;

internal abstract class Class424 : Class423
{
	private readonly bool bool_0;

	protected Class484 class484_0;

	protected Class484 class484_1;

	protected double double_0;

	protected double double_1;

	public abstract double Width { get; }

	internal Class424(bool bool_1)
	{
		bool_0 = bool_1;
	}

	protected abstract void vmethod_2();

	protected abstract void vmethod_3();

	[SpecialName]
	protected abstract bool vmethod_4();

	protected void method_0()
	{
		double_0 = vmethod_1(class484_0);
	}

	protected void method_1()
	{
		double_1 = vmethod_1(class484_1);
	}

	public virtual int vmethod_5(string string_0, char char_0)
	{
		if (vmethod_4())
		{
			if (class484_0 == null)
			{
				vmethod_3();
			}
			if (bool_0)
			{
				return (int)((Width - (double)((string_0 != null && !string_0.Equals("")) ? class484_0.method_2(string_0) : 0)) / (double)class484_0.method_3(char_0));
			}
			return (int)((Width * double_0 - (double)((string_0 != null && !string_0.Equals("")) ? class484_0.method_2(string_0) : 0)) / (double)class484_0.method_3(char_0));
		}
		if (class484_1 == null)
		{
			vmethod_2();
		}
		if (bool_0)
		{
			return (int)((Width - ((string_0 == null) ? 0.0 : ((double)class484_1.method_2(string_0)))) / (double)class484_1.method_3(char_0));
		}
		if (class484_0 == null)
		{
			vmethod_3();
		}
		return (int)((Width * double_0 - ((string_0 == null) ? 0.0 : ((double)class484_1.method_2(string_0)))) / (double)class484_1.method_3(char_0));
	}

	protected override int vmethod_0(string string_0)
	{
		if (vmethod_4())
		{
			if (string_0 != null && !string_0.Equals(""))
			{
				if (class484_0 == null)
				{
					vmethod_3();
				}
				if (bool_0)
				{
					return (int)((Width - (double)class484_0.method_2(string_0)) / double_0);
				}
				return (int)(Width - (double)class484_0.method_2(string_0) / double_0);
			}
			return (int)Width;
		}
		if (class484_1 == null)
		{
			vmethod_2();
		}
		if (bool_0)
		{
			return (int)((Width - ((string_0 == null) ? 0.0 : ((double)class484_1.method_2(string_0)))) / double_1);
		}
		if (class484_0 == null)
		{
			vmethod_3();
		}
		return (int)((Width * double_0 - ((string_0 == null) ? 0.0 : ((double)class484_1.method_2(string_0)))) / double_1);
	}
}
