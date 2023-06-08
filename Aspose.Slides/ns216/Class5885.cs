using System.Xml;
using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5885 : Class5782
{
	private string string_4;

	public string Value => string_4;

	internal static string Tag => "script";

	public override object Clone()
	{
		Class5885 @class = (Class5885)base.Clone();
		@class.string_4 = Value;
		return @class;
	}

	public Class5885()
	{
		Class5906.smethod_4(this, "binding", string.Empty);
		Class5906.smethod_4(this, "contentType", string.Empty);
		Class5906.smethod_6(this, "runAt", XfaEnums.Enum733.const_0);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_141(this);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		string_4 = reader.method_7(node);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5885();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
