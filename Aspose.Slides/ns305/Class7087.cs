namespace ns305;

internal class Class7087
{
	private long long_0;

	private long long_1;

	private long long_2;

	private long long_3;

	private Class6976 class6976_0;

	private string string_0;

	public long LineNumber => long_0;

	public long ColumnNumber => long_1;

	public long ByteOffset => long_2;

	public long Utf16Offset => long_3;

	public Class6976 RelatedNode => class6976_0;

	public string Uri => string_0;

	internal Class7087(long lineNumber, long columnNumber, long byteOffset, long utf16Offset, Class6976 relatedNode, string uri)
	{
		long_0 = lineNumber;
		long_1 = columnNumber;
		long_2 = byteOffset;
		long_3 = utf16Offset;
		class6976_0 = relatedNode;
		string_0 = uri;
	}
}
