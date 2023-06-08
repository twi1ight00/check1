using System.Collections;
using System.IO;
using x6c95d9cf46ff5f25;

namespace x45a758cd6bdecee3;

internal class x483dcea572fd1c73
{
	private readonly int xadfd68aea6af7e9d;

	private readonly xd345c73dd1b16b74 x14a2f87d74dbdad1;

	public x483dcea572fd1c73(int sfntVersion)
	{
		xadfd68aea6af7e9d = sfntVersion;
		x14a2f87d74dbdad1 = new xd345c73dd1b16b74(isCaseSensitive: true);
	}

	public void x53eb838d813e202e(string xffe521cc76054baf, byte[] x89fb45eae1c0ead6)
	{
		x14a2f87d74dbdad1.Add(xffe521cc76054baf, x89fb45eae1c0ead6);
	}

	public byte[] x094a5f6342d60df4()
	{
		using MemoryStream memoryStream = new MemoryStream();
		x631c3b95a074f9f3(memoryStream);
		return memoryStream.ToArray();
	}

	public void x631c3b95a074f9f3(Stream xcf18e5243f8d5fd3)
	{
		x73087173962e3778 x73087173962e = new x73087173962e3778(xcf18e5243f8d5fd3);
		xf2e052cd3abef6d7 xf2e052cd3abef6d8 = new xf2e052cd3abef6d7();
		xf2e052cd3abef6d8.x77fa6322561797a0 = xadfd68aea6af7e9d;
		xf2e052cd3abef6d8.x444aa5ad583fb445 = (ushort)x14a2f87d74dbdad1.Count;
		xf2e052cd3abef6d8.x6210059f049f0d48(x73087173962e);
		uint num = (uint)(xcf18e5243f8d5fd3.Position + 16 * x14a2f87d74dbdad1.Count);
		long position = xcf18e5243f8d5fd3.Position;
		foreach (DictionaryEntry item in x14a2f87d74dbdad1)
		{
			xcf18e5243f8d5fd3.Position = position;
			byte[] array = (byte[])item.Value;
			x1d5a785c8d5b14ee x1d5a785c8d5b14ee2 = new x1d5a785c8d5b14ee();
			x1d5a785c8d5b14ee2.xd229d86af0f16fb0 = (string)item.Key;
			x1d5a785c8d5b14ee2.x1be93eed8950d961 = (uint)array.Length;
			x1d5a785c8d5b14ee2.xf1d9b91c9700c401 = num;
			x1d5a785c8d5b14ee2.x05dda501c2a6f104 = x1d5a785c8d5b14ee.x7feeb3b91bfbb9ea(array);
			x1d5a785c8d5b14ee2.x6210059f049f0d48(x73087173962e);
			position = xcf18e5243f8d5fd3.Position;
			xcf18e5243f8d5fd3.Position = num;
			x73087173962e.x4c116b70372a3c6d(array, 0, array.Length);
			x8d3dd219b3c42944(x73087173962e);
			num = (uint)xcf18e5243f8d5fd3.Position;
		}
	}

	private void x8d3dd219b3c42944(x73087173962e3778 xbdfb620b7167944b)
	{
		x0d299f323d241756.xb66a70c14b63a912(xbdfb620b7167944b.x9e418ad9a56d1cf5, 4);
	}
}
