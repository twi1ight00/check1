using ns53;

namespace ns19;

internal sealed class Class248
{
	private string string_0;

	private byte[] byte_0;

	private string string_1;

	private string string_2;

	private Class1348 class1348_0;

	public string PartPath => string_0;

	public byte[] PartData => byte_0;

	public string ContentType => string_1;

	public string TypeAttributeOfSourceRelationship
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public Class1348 PartRelationships => class1348_0;

	public Class248(string partPath, byte[] partData, string contentType, string typeAttributeOfSourceRelationship, Class1348 partRelationships)
	{
		string_0 = partPath;
		byte_0 = partData;
		string_1 = contentType;
		string_2 = typeAttributeOfSourceRelationship;
		class1348_0 = partRelationships;
	}
}
