using ns171;

namespace ns187;

internal class Class5046 : Class5045
{
	internal class Class5065 : Class5060
	{
		public Class5065(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_3()
		{
			return new Class5046();
		}

		public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			if (p is Class5046)
			{
				return p;
			}
			return base.vmethod_11(p, propertyList, fo);
		}
	}

	private Class5024 class5024_3;

	private Class5024 class5024_4;

	public override void imethod_1(int cmpId, Class5024 cmpnValue, bool bIsDefault)
	{
		switch (cmpId)
		{
		case 4096:
			method_11(cmpnValue, bIsDefault);
			break;
		case 1024:
			method_12(cmpnValue, bIsDefault);
			break;
		default:
			base.imethod_1(cmpId, cmpnValue, bIsDefault);
			break;
		}
	}

	public override Class5024 imethod_2(int cmpId)
	{
		return cmpId switch
		{
			4096 => method_13(), 
			1024 => method_14(), 
			_ => base.imethod_2(cmpId), 
		};
	}

	internal void method_11(Class5024 precedencE, bool bIsDefault)
	{
		class5024_3 = precedencE;
	}

	internal void method_12(Class5024 conditionalitY, bool bIsDefault)
	{
		class5024_4 = conditionalitY;
	}

	public Class5024 method_13()
	{
		return class5024_3;
	}

	public Class5024 method_14()
	{
		return class5024_4;
	}

	public bool method_15()
	{
		return class5024_4.imethod_0() == 32;
	}

	public override string ToString()
	{
		return string.Concat("Space[min:", method_8(null).vmethod_12(), ", max:", method_9(null).vmethod_12(), ", opt:", method_10(null).vmethod_12(), ", precedence:", class5024_3.vmethod_12(), ", conditionality:", class5024_4.vmethod_12(), "]");
	}

	public override Class5046 vmethod_5()
	{
		return this;
	}

	public override Class5045 vmethod_3()
	{
		return this;
	}

	public override object vmethod_12()
	{
		return this;
	}
}
