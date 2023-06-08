namespace ns55;

internal class Class1297 : Class1223
{
	public readonly string string_0;

	public readonly Class1338 class1338_0;

	public override string ContentType => string_0;

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;

	public Class1297(string _contentType, string _typeAttributeOfSourceRelationship)
	{
		string_0 = _contentType;
		class1338_0 = new Class1338(_typeAttributeOfSourceRelationship);
	}
}
