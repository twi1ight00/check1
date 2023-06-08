using System.Drawing;
using ns171;
using ns176;
using ns178;
using ns183;

namespace ns189;

internal class Class5111 : Class5109
{
	private PointF pointF_0 = PointF.Empty;

	private bool bool_1;

	private string string_5;

	private Interface182 interface182_6;

	public Class5111(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		string_5 = pList.method_6(Enum679.const_385).vmethod_13();
		base.vmethod_2(pList);
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_52(this);
	}

	internal override void vmethod_11()
	{
		if (class5088_2 == null)
		{
			method_13("one (1) non-XSL namespace child");
		}
		vmethod_3().vmethod_53(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			method_11(loc, nsURI, localName);
		}
		else if (class5088_2 != null)
		{
			method_7(loc, new Class5619(nsURI, null, localName));
		}
	}

	public override string vmethod_21()
	{
		return "instream-foreign-object";
	}

	public override int vmethod_24()
	{
		return 37;
	}

	private void method_57()
	{
		if (!bool_1)
		{
			Class5089 @class = (Class5089)class5088_2;
			Point empty = Point.Empty;
			pointF_0 = @class.vmethod_30(empty, string_5);
			interface182_6 = @class.method_26();
			bool_1 = true;
		}
	}

	public override int vmethod_32()
	{
		method_57();
		if (!pointF_0.IsEmpty)
		{
			return (int)(pointF_0.X * 1000f);
		}
		return 0;
	}

	public override int vmethod_33()
	{
		method_57();
		if (!pointF_0.IsEmpty)
		{
			return (int)(pointF_0.Y * 1000f);
		}
		return 0;
	}

	public override Interface182 vmethod_34()
	{
		method_57();
		return interface182_6;
	}

	internal override void vmethod_12(Class5088 child)
	{
		base.vmethod_12(child);
	}

	public Class5089 method_58()
	{
		return (Class5089)class5088_2;
	}
}
