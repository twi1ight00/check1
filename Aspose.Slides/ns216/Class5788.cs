using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5788 : Class5783
{
	internal static string Tag => "barcode";

	public Class5788()
	{
		Class5906.smethod_4(this, "charEncoding", string.Empty);
		Class5906.smethod_2(this, "dataColumnCount", 0);
		Class5906.smethod_2(this, "dataLength", 0);
		Class5906.smethod_2(this, "dataRowCount", 0);
		Class5906.smethod_4(this, "endChar", string.Empty);
		Class5906.smethod_4(this, "errorCorrectionLevel", string.Empty);
		Class5906.smethod_1(this, "moduleHeight", 5f);
		Class5906.smethod_1(this, "moduleWidth", 0.25f);
		Class5906.smethod_3(this, "printCheckDigit", @default: false);
		Class5906.smethod_4(this, "rowColumnRatio", string.Empty);
		Class5906.smethod_4(this, "startChar", string.Empty);
		Class5906.smethod_3(this, "truncate", @default: false);
		Class5906.smethod_4(this, "type", string.Empty);
		Class5906.smethod_4(this, "wideNarrowRatio", string.Empty);
		Class5906.smethod_6(this, "checksum", XfaEnums.Enum681.const_0);
		Class5906.smethod_6(this, "dataPrep", XfaEnums.Enum682.const_0);
		Class5906.smethod_6(this, "textLocation", XfaEnums.Enum683.const_0);
		Class5906.smethod_6(this, "upsMode", XfaEnums.Enum684.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_7(this);
		base.vmethod_4(visitor);
		visitor.vmethod_8(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5788();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return null;
	}
}
