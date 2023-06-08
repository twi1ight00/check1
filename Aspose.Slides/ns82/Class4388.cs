using System.IO;
using System.Text;

namespace ns82;

internal class Class4388 : Class4387
{
	protected string string_1;

	public override string SourceName => string_1;

	protected Class4388()
	{
	}

	public Class4388(string fileName)
		: this(fileName, Encoding.Default)
	{
	}

	public Class4388(string fileName, Encoding encoding)
	{
		string_1 = fileName;
		vmethod_0(fileName, encoding);
	}

	public virtual void vmethod_0(string fileName, Encoding encoding)
	{
		if (fileName == null)
		{
			return;
		}
		StreamReader streamReader = null;
		try
		{
			FileInfo file = new FileInfo(fileName);
			int num = (int)smethod_0(file);
			char_0 = new char[num];
			streamReader = ((encoding == null) ? new StreamReader(fileName, Encoding.Default) : new StreamReader(fileName, encoding));
			int_0 = streamReader.Read(char_0, 0, char_0.Length);
		}
		finally
		{
			streamReader?.Close();
		}
	}

	private static long smethod_0(FileInfo file)
	{
		if (file.Exists)
		{
			return file.Length;
		}
		return 0L;
	}
}
