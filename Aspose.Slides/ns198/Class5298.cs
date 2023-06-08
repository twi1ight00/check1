using System.Collections;
using ns173;
using ns176;
using ns189;
using ns196;

namespace ns198;

internal class Class5298 : Class5280, Interface172, Interface173, Interface175
{
	private Class5095 class5095_0;

	private Class5282 class5282_0;

	private bool bool_3;

	internal Class5337 class5337_0;

	private Class4942 class4942_0;

	private Class5319 class5319_0;

	private bool bool_4;

	private bool bool_5;

	internal bool IsInsideTableCell
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public Class5282 BodyLm
	{
		get
		{
			return class5282_0;
		}
		set
		{
			class5282_0 = value;
		}
	}

	public Class5319 Llm
	{
		get
		{
			return class5319_0;
		}
		set
		{
			class5319_0 = value;
		}
	}

	internal bool IsOrdinarContent
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	internal Class4942 method_24()
	{
		return class4942_0;
	}

	public override void imethod_8(Class4942 childArea)
	{
		if (bool_5)
		{
			imethod_2().imethod_8(childArea);
		}
		class4942_0 = childArea;
	}

	public Class5298(Class5095 node)
		: base(node)
	{
		class5095_0 = node;
	}

	public override void imethod_3()
	{
		if (class5282_0 == null)
		{
			class5282_0 = new Class5282(class5095_0);
		}
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		imethod_3();
		class5282_0.imethod_1(this);
		class5282_0.imethod_3();
		if (bool_5)
		{
			try
			{
				return class5282_0.imethod_14(context, alignment);
			}
			finally
			{
				imethod_6(fin: true);
			}
		}
		if (!bool_4)
		{
			Class5282.smethod_3(this)?.Add(this);
		}
		ArrayList arrayList = new ArrayList();
		Class5274 @class = new Class5277();
		class5337_0 = new Class5339(0, null, null, auxiliary: true);
		((Class5339)class5337_0).method_6(class5282_0);
		@class.Add(class5337_0);
		arrayList.Add(@class);
		imethod_6(fin: true);
		return arrayList;
	}

	public ArrayList imethod_27(ArrayList oldList)
	{
		return oldList;
	}

	public ArrayList imethod_28(ArrayList oldList, int depth)
	{
		return oldList;
	}

	public string imethod_29(Class5254 pos)
	{
		return null;
	}

	public void imethod_30(Class5254 pos, Class5685 hc)
	{
	}

	public bool imethod_31(ArrayList oldList)
	{
		return false;
	}

	public bool imethod_32(ArrayList oldList, int depth)
	{
		return false;
	}

	public ArrayList imethod_38(ArrayList oldList, int alignment, int depth)
	{
		return null;
	}
}
