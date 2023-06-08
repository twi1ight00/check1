namespace ns55;

internal class Class1336 : Class1223
{
	public const string string_0 = "application/vnd.openxmlformats-package.digital-signature-origin";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.openxmlformats.org/package/2006/relationships/digital-signature/origin");

	public override string ContentType => "application/vnd.openxmlformats-package.digital-signature-origin";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;
}
