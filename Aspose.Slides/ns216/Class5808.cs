using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5808 : Class5783
{
	internal static string Tag => "digestMethods";

	public Class5808()
	{
		Class5906.smethod_6(this, "type", XfaEnums.Enum692.const_0);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_54(this);
		base.vmethod_4(visitor);
		visitor.vmethod_55(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5808();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[1] { Class5867.Tag };
	}
}
