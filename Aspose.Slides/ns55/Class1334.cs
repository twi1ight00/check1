namespace ns55;

internal class Class1334 : Class1298
{
	public const string string_0 = "application/x-fontdata";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.openxmlformats.org/officeDocument/2006/relationships/font");

	public override string ContentType => "application/x-fontdata";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;

	public override bool ForceCompression => false;
}
