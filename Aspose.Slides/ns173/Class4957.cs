using System.Collections;

namespace ns173;

internal class Class4957 : Class4942
{
	protected int int_15;

	protected int int_16;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	protected ArrayList arrayList_1;

	public bool IsTopAuto => bool_2;

	public bool IsBottomAuto => bool_3;

	public bool IsLeftAuto => bool_0;

	public bool IsRightAuto => bool_1;

	public override void vmethod_2(Class4942 childArea)
	{
		if (arrayList_1 == null)
		{
			arrayList_1 = new ArrayList();
		}
		childArea.vmethod_3(this);
		arrayList_1.Add(childArea);
	}

	public virtual void vmethod_5(Class4962 block)
	{
		vmethod_2(block);
	}

	public ArrayList method_37()
	{
		return arrayList_1;
	}

	public virtual bool vmethod_6()
	{
		if (arrayList_1 != null)
		{
			return arrayList_1.Count == 0;
		}
		return true;
	}

	public void method_38(int off, bool leftAuto, bool rightAuto)
	{
		int_15 = off;
		bool_0 = leftAuto;
		bool_1 = rightAuto;
	}

	public void method_39(int off, bool topAuto, bool bottomAuto)
	{
		int_16 = off;
		bool_2 = topAuto;
		bool_3 = bottomAuto;
	}

	public int method_40()
	{
		return int_15;
	}

	public int method_41()
	{
		return int_16;
	}
}
