using ns171;

namespace ns187;

internal class Class5723
{
	protected Class5052 class5052_0;

	protected int int_0;

	protected int int_1;

	protected int int_2;

	protected int int_3;

	protected bool bool_0;

	private bool bool_1;

	public Class5723(Class5052 baseMaker)
	{
		class5052_0 = baseMaker;
		baseMaker.method_10(this);
	}

	public void method_0(int lrtB, int rltB, int tbrL, int tblR)
	{
		int_0 = lrtB;
		int_1 = rltB;
		int_2 = tbrL;
		int_3 = tblR;
	}

	public void method_1(bool useParenT)
	{
		bool_0 = useParenT;
	}

	public void method_2(bool relativE)
	{
		bool_1 = relativE;
	}

	public virtual bool vmethod_0(Class5634 propertyList)
	{
		if (!bool_1)
		{
			return false;
		}
		Class5634 @class = method_3(propertyList);
		if (@class != null)
		{
			int propId = @class.method_9(int_0, int_1, int_2, int_3);
			if (@class.vmethod_0(propId) != null)
			{
				return true;
			}
		}
		return false;
	}

	public virtual Class5024 vmethod_1(Class5634 propertyList)
	{
		Class5634 @class = method_3(propertyList);
		if (@class == null)
		{
			return null;
		}
		int propId = @class.method_9(int_0, int_1, int_2, int_3);
		Class5024 class2 = propertyList.method_3(propId);
		if (class2 != null)
		{
			Class5094 fo = propertyList.method_1();
			class2 = class5052_0.vmethod_11(class2, propertyList, fo);
		}
		return class2;
	}

	protected Class5634 method_3(Class5634 pList)
	{
		if (bool_0)
		{
			return pList.method_2();
		}
		return pList;
	}
}
