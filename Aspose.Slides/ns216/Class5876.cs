using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5876 : Class5782
{
	internal static string Tag => "keyUsage";

	public Class5876()
	{
		Class5906.smethod_4(this, "crlSign", string.Empty);
		Class5906.smethod_4(this, "dataEncipherment", string.Empty);
		Class5906.smethod_4(this, "decipherOnly", string.Empty);
		Class5906.smethod_4(this, "digitalSignature", string.Empty);
		Class5906.smethod_4(this, "encipherOnly", string.Empty);
		Class5906.smethod_4(this, "keyAgreement", string.Empty);
		Class5906.smethod_4(this, "keyCertSign", string.Empty);
		Class5906.smethod_4(this, "keyEncipherment", string.Empty);
		Class5906.smethod_4(this, "nonRepudiation", string.Empty);
		Class5906.smethod_6(this, "type", XfaEnums.Enum692.const_0);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_98(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5876();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
