namespace ns55;

internal class Class1299 : Class1298
{
	public const string string_0 = "application/vnd.ms-office.activeX";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.microsoft.com/office/2006/relationships/activeXControlBinary");

	public override string ContentType => "application/vnd.ms-office.activeX";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;

	public override bool ForceCompression => false;
}
