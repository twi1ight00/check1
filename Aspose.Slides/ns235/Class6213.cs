using ns224;

namespace ns235;

internal class Class6213 : Class6212, Interface261
{
	private Class6002 class6002_0;

	private Class6217 class6217_0;

	private Class6270 class6270_0;

	public Class6002 RenderTransform
	{
		get
		{
			return class6002_0;
		}
		set
		{
			class6002_0 = value;
		}
	}

	public Class6217 Clip
	{
		get
		{
			return class6217_0;
		}
		set
		{
			class6217_0 = value;
		}
	}

	public Class6270 Hyperlink
	{
		get
		{
			return class6270_0;
		}
		set
		{
			class6270_0 = value;
		}
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_2(this);
		base.vmethod_0(visitor);
		visitor.vmethod_3(this);
	}

	public Class6213 method_3()
	{
		return MemberwiseClone() as Class6213;
	}
}
