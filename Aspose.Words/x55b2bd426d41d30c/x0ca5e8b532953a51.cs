using System.IO;
using x6c95d9cf46ff5f25;

namespace x55b2bd426d41d30c;

internal class x0ca5e8b532953a51
{
	private readonly string xc61ff88f1f98652d;

	private readonly MemoryStream xa49cef274042e702;

	public string x759aa16c2016a289 => xc61ff88f1f98652d;

	public string x189167ca3b0a8e0b => Path.GetExtension(xc61ff88f1f98652d);

	public MemoryStream xb8a774e0111d0fbe => xa49cef274042e702;

	public x0ca5e8b532953a51(string name)
		: this(name, new MemoryStream())
	{
	}

	public x0ca5e8b532953a51(string name, MemoryStream ms)
	{
		x0d299f323d241756.x48501aec8e48c869(name, "PackagePart.Name");
		xc61ff88f1f98652d = name;
		xa49cef274042e702 = ms;
	}

	public void x8191cf2327af73cf(string xafe2f3653ee64ebc)
	{
		using Stream xedc894794186020d = File.Create(xafe2f3653ee64ebc);
		xa49cef274042e702.Position = 0L;
		x0d299f323d241756.x3ad8e53785c39acd(xa49cef274042e702, xedc894794186020d);
		xa49cef274042e702.Position = 0L;
	}
}
