namespace ns55;

internal class Class1264 : Class1262
{
	public const string string_2 = "application/vnd.openxmlformats-officedocument.custom-properties+xml";

	public const string string_3 = "http://schemas.openxmlformats.org/officeDocument/2006/custom-properties";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.openxmlformats.org/officeDocument/2006/relationships/custom-properties");

	public override string ContentType => "application/vnd.openxmlformats-officedocument.custom-properties+xml";

	public sealed override string RootNamespace => "http://schemas.openxmlformats.org/officeDocument/2006/custom-properties";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;
}
