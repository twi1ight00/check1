using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5797 : Class5783
{
	internal static string Tag => "certificates";

	public Class5797()
	{
		Class5906.smethod_6(this, "credentialServerPolicy", XfaEnums.Enum692.const_0);
		Class5906.smethod_4(this, "url", string.Empty);
		Class5906.smethod_4(this, "urlPolicy", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_29(this);
		base.vmethod_4(visitor);
		visitor.vmethod_30(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5797();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[5]
		{
			Class5823.Tag,
			Class5876.Tag,
			Class5833.Tag,
			Class5845.Tag,
			Class5850.Tag
		};
	}
}
