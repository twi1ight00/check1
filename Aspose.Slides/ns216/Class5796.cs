using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5796 : Class5783
{
	internal static string Tag => "caption";

	public XfaEnums.Enum691 Placement => (XfaEnums.Enum691)method_5("placement").Value;

	public float Reserve
	{
		get
		{
			return (float)method_5("reserve").Value;
		}
		set
		{
			method_5("reserve").Value = value;
		}
	}

	public Class5796()
	{
		Class5906.smethod_6(this, "placement", XfaEnums.Enum691.const_0);
		Class5906.smethod_6(this, "presence", XfaEnums.Enum687.const_0);
		Class5906.smethod_1(this, "reserve", -1f);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_26(this);
		base.vmethod_4(visitor);
		visitor.vmethod_27(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5796();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[5]
		{
			Class5816.Tag,
			Class5820.Tag,
			Class5829.Tag,
			Class5836.Tag,
			Class5893.Tag
		};
	}
}
