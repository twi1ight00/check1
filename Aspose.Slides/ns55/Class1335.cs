namespace ns55;

internal class Class1335 : Class1298
{
	public const string string_0 = "application/vnd.ms-office.vbaProject";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.microsoft.com/office/2006/relationships/vbaProject");

	public override string ContentType => "application/vnd.ms-office.vbaProject";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;

	public override bool ForceCompression => false;
}
