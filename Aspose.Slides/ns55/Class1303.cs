namespace ns55;

internal class Class1303 : Class1301
{
	public const string string_0 = "audio/wav";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.openxmlformats.org/officeDocument/2006/relationships/audio");

	public override string ContentType => "audio/wav";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;
}
