using ns171;
using ns176;
using ns195;

namespace ns187;

internal class Class5044 : Class5024, Interface237
{
	internal class Class5063 : Class5060
	{
		public Class5063(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_3()
		{
			return new Class5044();
		}

		public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			if (p is Class5044)
			{
				return p;
			}
			return base.vmethod_11(p, propertyList, fo);
		}
	}

	private Class5024 class5024_0;

	private Class5024 class5024_1;

	public Class5044()
	{
	}

	public Class5044(Class5024 ipd, Class5024 bpd)
		: this()
	{
		class5024_0 = ipd;
		class5024_1 = bpd;
	}

	public Class5044(Class5024 len)
		: this(len, len)
	{
	}

	public void imethod_1(int cmpId, Class5024 cmpnValue, bool bIsDefault)
	{
		switch (cmpId)
		{
		case 512:
			class5024_1 = cmpnValue;
			break;
		case 1536:
			class5024_0 = cmpnValue;
			break;
		}
	}

	public Class5024 imethod_2(int cmpId)
	{
		return cmpId switch
		{
			512 => method_4(), 
			1536 => method_3(), 
			_ => null, 
		};
	}

	public Class5024 method_3()
	{
		return class5024_0;
	}

	public Class5024 method_4()
	{
		return class5024_1;
	}

	public override string ToString()
	{
		return string.Concat("LengthPair[ipd:", method_3().vmethod_12(), ", bpd:", method_4().vmethod_12(), "]");
	}

	public override Class5044 vmethod_4()
	{
		return this;
	}

	public override object vmethod_12()
	{
		return this;
	}

	public override int GetHashCode()
	{
		int num = 1;
		num = 31 + Class5721.smethod_1(class5024_1);
		return 31 * num + Class5721.smethod_1(class5024_0);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5044 @class))
		{
			return false;
		}
		if (Class5721.smethod_0(class5024_1, @class.class5024_1))
		{
			return Class5721.smethod_0(class5024_0, @class.class5024_0);
		}
		return false;
	}
}
