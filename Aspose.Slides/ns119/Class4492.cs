using System.IO;

namespace ns119;

internal class Class4492
{
	private string string_0;

	private string string_1;

	private Class4487 class4487_0;

	private long long_0;

	public string FileName => string_0;

	public string FileExtension => string_1;

	public Class4487 StreamSource => class4487_0;

	public long Offset => long_0;

	public Class4492(Class4487 streamSource)
		: this(null, null, streamSource, 0L)
	{
	}

	public Class4492(string fileExtension, Class4487 streamSource)
		: this(null, fileExtension, streamSource, 0L)
	{
	}

	public Class4492(string fileExtension, Class4487 streamSource, long offset)
		: this(null, fileExtension, streamSource, offset)
	{
	}

	public Class4492(FileInfo fontFile)
		: this(fontFile.Name, fontFile.Extension.TrimStart('.'), new Class4489(fontFile.FullName), 0L)
	{
	}

	private Class4492(string fileName, string fileExtension, Class4487 streamSource)
		: this(fileName, fileExtension, streamSource, 0L)
	{
	}

	private Class4492(string fileName, string fileExtension, Class4487 streamSource, long offset)
	{
		long_0 = offset;
		string_0 = ((fileName != null) ? fileName.ToLower() : fileName);
		string_1 = fileExtension?.ToLower();
		class4487_0 = streamSource;
	}
}
