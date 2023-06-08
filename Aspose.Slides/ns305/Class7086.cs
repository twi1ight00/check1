namespace ns305;

internal class Class7086
{
	private byte byte_0;

	private string string_0;

	private string string_1;

	private object object_0;

	private object object_1;

	private Class7087 class7087_0;

	public byte Severity => byte_0;

	public string Message => string_0;

	public string Type => string_1;

	public object RelatedException => object_0;

	public object RelatedData => object_1;

	public Class7087 Location => class7087_0;

	internal Class7086(byte severity, string message, string type, object relatedException, object relatedData, Class7087 location)
	{
		byte_0 = severity;
		string_0 = message;
		string_1 = type;
		object_0 = relatedException;
		object_1 = relatedData;
		class7087_0 = location;
	}
}
