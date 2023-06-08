using ns249;
using ns258;

namespace ns261;

internal class Class6420
{
	private Class6416 class6416_0;

	private Class6417 class6417_0;

	private Class6418 class6418_0;

	private Class6419 class6419_0;

	public Class6416 EffectReference
	{
		get
		{
			if (class6416_0 == null)
			{
				class6416_0 = new Class6416();
			}
			return class6416_0;
		}
		set
		{
			class6416_0 = value;
		}
	}

	public Class6417 FillReference
	{
		get
		{
			if (class6417_0 == null)
			{
				class6417_0 = new Class6417();
			}
			return class6417_0;
		}
		set
		{
			class6417_0 = value;
		}
	}

	public Class6418 FontReference
	{
		get
		{
			if (class6418_0 == null)
			{
				class6418_0 = new Class6418();
			}
			return class6418_0;
		}
		set
		{
			class6418_0 = value;
		}
	}

	public Class6419 LineReference
	{
		get
		{
			if (class6419_0 == null)
			{
				class6419_0 = new Class6419();
			}
			return class6419_0;
		}
		set
		{
			class6419_0 = value;
		}
	}

	internal Interface294 method_0(Class6360 brushRenderingContext)
	{
		return LineReference.method_0(brushRenderingContext);
	}

	internal Class6350 method_1(Class6360 brushRenderingContext)
	{
		return FillReference.method_0(brushRenderingContext);
	}
}
