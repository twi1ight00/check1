namespace ns55;

internal class Class1263 : Class1262
{
	public const string string_2 = "application/vnd.openxmlformats-package.core-properties+xml";

	public const string string_3 = "http://schemas.openxmlformats.org/package/2006/metadata/core-properties";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties");

	public override string ContentType => "application/vnd.openxmlformats-package.core-properties+xml";

	public sealed override string RootNamespace => "http://schemas.openxmlformats.org/package/2006/metadata/core-properties";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;
}
