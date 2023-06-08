using System.Collections;
using System.IO;
using ns276;

namespace ns234;

internal class Class6170
{
	private readonly Class6752 class6752_0;

	private readonly IEnumerator ienumerator_0;

	public string EntryFileName => CurrentEntry.FileName;

	private Class6751 CurrentEntry => (Class6751)ienumerator_0.Current;

	public Class6170(Stream stream)
	{
		class6752_0 = Class6752.Read(stream);
		ienumerator_0 = ((IEnumerable)class6752_0).GetEnumerator();
	}

	public bool method_0()
	{
		return ienumerator_0.MoveNext();
	}

	public MemoryStream method_1()
	{
		MemoryStream memoryStream = new MemoryStream();
		method_2(memoryStream);
		memoryStream.Position = 0L;
		return memoryStream;
	}

	public void method_2(Stream stream)
	{
		CurrentEntry.method_8(stream);
	}
}
