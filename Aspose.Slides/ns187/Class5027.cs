using System.Collections;
using ns171;
using ns195;

namespace ns187;

internal class Class5027 : Class5024
{
	internal class Class5054 : Class5052
	{
		public Class5054(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			if (p is Class5027)
			{
				return p;
			}
			return new Class5027(p);
		}
	}

	internal ArrayList arrayList_0 = new ArrayList();

	protected Class5027()
	{
	}

	public Class5027(Class5024 prop)
		: this()
	{
		vmethod_14(prop);
	}

	public virtual void vmethod_14(Class5024 prop)
	{
		arrayList_0.Add(prop);
	}

	public override ArrayList vmethod_8()
	{
		return arrayList_0;
	}

	public override object vmethod_12()
	{
		return arrayList_0;
	}

	public override int GetHashCode()
	{
		return arrayList_0.GetHashCode();
	}

	public bool method_3(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5027 @class))
		{
			return false;
		}
		return Class5721.smethod_0(arrayList_0, @class.arrayList_0);
	}
}
