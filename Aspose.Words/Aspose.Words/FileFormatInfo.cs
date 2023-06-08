using System.Text;

namespace Aspose.Words;

public class FileFormatInfo
{
	private LoadFormat xac8f6c715bbaaafc = LoadFormat.Unknown;

	private bool x7344d6f6b6a9ada9;

	private bool x4140d760828b2762;

	private Encoding xcce637b6f486a407;

	public LoadFormat LoadFormat => xac8f6c715bbaaafc;

	public bool IsEncrypted => x7344d6f6b6a9ada9;

	public bool HasDigitalSignature => x4140d760828b2762;

	public Encoding Encoding => xcce637b6f486a407;

	internal FileFormatInfo()
	{
	}

	internal void x9d4c5edc77b82e9e(LoadFormat xdef7b99b7fc67519)
	{
		xac8f6c715bbaaafc = xdef7b99b7fc67519;
	}

	internal void xeaa80867023c8b84(bool x3686d3d908723793)
	{
		x7344d6f6b6a9ada9 = x3686d3d908723793;
	}

	internal void x8f26221a4a86f4ff(bool x6826d133226dba24)
	{
		x4140d760828b2762 = x6826d133226dba24;
	}

	internal void x07279a63090af02d(Encoding xff3edc9aa5f0523b)
	{
		xcce637b6f486a407 = xff3edc9aa5f0523b;
	}
}
