using System.IO;

namespace x639ad3f66698fe1b;

internal class x0462f8ecc269ec42 : x43845b10d17efb74
{
	private const int x1bb0ab981af7f94a = 4096;

	private StreamWriter x9b287b671d592594;

	internal x0462f8ecc269ec42(Stream stream)
		: this(stream, 4096)
	{
	}

	internal x0462f8ecc269ec42(Stream stream, int bufferSize)
	{
		x9b287b671d592594 = new StreamWriter(stream, x43845b10d17efb74.xaa122dba3e5cfe53, bufferSize);
	}

	internal override void x8d5c460c7f55c721(MemoryStream xcf18e5243f8d5fd3)
	{
		xcf18e5243f8d5fd3.WriteTo(x9b287b671d592594.BaseStream);
	}

	internal override void x6210059f049f0d48(char xbcea506a33cf9111)
	{
		x9b287b671d592594.Write(xbcea506a33cf9111);
	}

	internal override void x6210059f049f0d48(string xbcea506a33cf9111)
	{
		x9b287b671d592594.Write(xbcea506a33cf9111);
	}

	internal override void xbb7550bbb62a218c()
	{
		x9b287b671d592594.Flush();
	}
}
