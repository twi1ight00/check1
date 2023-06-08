using System.IO;
using Aspose;

namespace xeb665d1aeef09d64;

internal class xda6c010448467ed0 : x25998da3963930e9
{
	private readonly string xb60ae86f79aa8262;

	public string xa39af5a82860a9a3 => xb60ae86f79aa8262;

	public xda6c010448467ed0(string fileName)
	{
		xb60ae86f79aa8262 = fileName;
	}

	public override Stream OpenStream()
	{
		return File.OpenRead(xa39af5a82860a9a3);
	}

	[JavaThrows(false)]
	public override int GetSize()
	{
		if (!DoesDataExist())
		{
			return 0;
		}
		FileInfo fileInfo = new FileInfo(xa39af5a82860a9a3);
		return (int)fileInfo.Length;
	}

	[JavaThrows(false)]
	public override bool DoesDataExist()
	{
		if (xa39af5a82860a9a3 == null)
		{
			return false;
		}
		return File.Exists(xa39af5a82860a9a3);
	}
}
